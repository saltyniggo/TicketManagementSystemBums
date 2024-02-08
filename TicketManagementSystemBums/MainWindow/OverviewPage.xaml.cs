using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketManagementSystemBums.LoginWindow;
using TicketManagementSystemBums.MainWindow.Forms;
using TicketManagementSystemBums.MainWindow.Forms.DetailWindow;
using static TicketManagementSystemBums.Ticket;

namespace TicketManagementSystemBums.MainWindow
{
    /// <summary>
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage : Page
    {
        private DetailWindow currentDetailWindow;
        private static ListBox unassigned;
        private static ListBox assigned;
        private static ListBox completed;

        public static List<Ticket> Tickets = new List<Ticket>();

        public static ListBox Unassigned
        {
            get
            {
                return unassigned;
            }
            set
            {
                unassigned = value;
            }
        }
        public static ListBox Assigned
        { 
            get
            {
                return assigned;
            }
            set
            {
                assigned = value;
            }
        }
        public static ListBox Completed
        {
            get
            {
                return completed;
            }
            set
            {
                completed = value;
            }
        }

        public OverviewPage()
        {
            InitializeComponent();
            Tickets.Clear();
            sidebarTitle.Text = $"Welcome {MainWindow.UserName}";
            Unassigned = listUnassigned;
            Assigned = listAssigned; 
            Completed = listCompleted; 
            RefreshLists();
            EditTicketPage.TicketUpdated += RefreshLists;
            AddTicketWindow.TicketAdded += RefreshLists;
            DetailTicketPage.TicketCompleted += RefreshLists;
        }


        private void OpenAddTicketForm(object sender, RoutedEventArgs e)
        {
            new AddTicketWindow().Show();
        }

        public void RefreshLists()
        {
            Tickets.Clear();
            LoadTickets(MainWindow.UserId);
            listUnassigned.Items.Clear();
            listAssigned.Items.Clear();
            listCompleted.Items.Clear();

            foreach (var ticket in Tickets)
            {
                switch (ticket.Status)
                {
                    case TicketStatus.Unassigned:
                        listUnassigned.Items.Add(ticket);
                        break;
                    case TicketStatus.Assigned:
                        listAssigned.Items.Add(ticket);
                        break;
                    case TicketStatus.Completed:
                        listCompleted.Items.Add(ticket);
                        break;
                }
            }
        }
        private void LoadTickets(int userId)
        {
            string connString = Database.CreateConnString().Result;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand query = new NpgsqlCommand("SELECT * FROM tickets WHERE ticket_assigneduser = @userId or ticket_assigneduser is null", conn))
                    {
                        query.Parameters.AddWithValue("userId", userId);
                        using (var reader = query.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Ticket ticket = new Ticket()
                                {
                                    TicketID = reader.GetInt32(0),
                                    TicketName = reader.GetString(1),
                                    TicketDescription = reader.GetString(2),
                                    Priority = (TicketPriority)reader.GetInt32(3),
                                    Status = (TicketStatus)reader.GetInt32(4),
                                    TicketAssignedUser = reader.IsDBNull(5) ? Convert.ToInt32(null) : reader.GetInt32(4),
                                    TicketDate = reader.GetDateTime(6)
                                };
                                Tickets.Add(ticket);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beep Boop, an error occurred: {ex.Message}");
            }
        }
        private void Ticket_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ticket? item = ((FrameworkElement)sender).DataContext as Ticket;
            this.currentDetailWindow?.Close();
            this.currentDetailWindow = new DetailWindow(item);
            this.currentDetailWindow.Show();
        }

        private void openSettings(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new SettingsPage());
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Window.GetWindow(this).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshLists();
        }
    }
}
