using System;
using System.Collections.Generic;
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
        private List<Ticket> tickets = new List<Ticket>();
        private string userName = "Nico Schulz";

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
        public List<Ticket> Tickets
        {
            get
            {
                return tickets;
            }
            set
            {
                tickets = value;
            }
        }   
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        public OverviewPage()
        {
            InitializeComponent();
            sidebarTitle.Text = $"Welcome {UserName}";
            Unassigned = listUnassigned;
            Assigned = listAssigned; 
            Completed = listCompleted; 
            FillLists();
            RefreshLists();
            EditTicketPage.TicketUpdated += RefreshLists;
        }


        private void OpenAddTicketForm(object sender, RoutedEventArgs e)
        {
            new AddTicketWindow().Show();
        }

        public void FillLists()
        {
            Random random = new Random();

            for (int i = 0; i < 14; i++)
            {
                string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                Ticket ticket = new Ticket()
                {
                    TicketName = randomString,
                    TicketDate = DateTime.Today.AddDays(random.Next(-10, 10)).Date,
                    Priority = (TicketPriority)random.Next(0, 4),
                    TicketAssignedUser = "User" + random.Next(1, 5),
                    TicketDescription = "Description" + random.Next(1, 100),
                    Status = (TicketStatus)random.Next(0, 3)
                };
                tickets.Add(ticket);

                //switch (ticket.Status)
                //{
                //    case TicketStatus.Unassigned:
                //        listUnassigned.Items.Add(ticket);
                //        break;
                //    case TicketStatus.Assigned:
                //        listAssigned.Items.Add(ticket);
                //        break;
                //    case TicketStatus.Completed:
                //        listCompleted.Items.Add(ticket);
                //        break;
                //}
            }
        }

        public void RefreshLists()
        {
            listUnassigned.Items.Clear();
            listAssigned.Items.Clear();
            listCompleted.Items.Clear();

            foreach (var ticket in tickets)
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

        private void Ticket_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ticket? item = ((FrameworkElement)sender).DataContext as Ticket;
            this.currentDetailWindow?.Close();
            this.currentDetailWindow = new DetailWindow(item);
            this.currentDetailWindow.Show();
        }

        private void openAccount(object sender, RoutedEventArgs e)
        {

        }

        private void openSettings(object sender, RoutedEventArgs e)
        {

        }

        private void logout(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Window.GetWindow(this).Close();
        }
    }
}
