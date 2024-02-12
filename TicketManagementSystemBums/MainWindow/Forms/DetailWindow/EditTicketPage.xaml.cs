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
using TicketManagementSystemBums;
using TicketManagementSystemBums.MainWindow;
using static TicketManagementSystemBums.Ticket;
using TicketManagementSystemBums.MainWindow.Forms;
using Npgsql;

namespace TicketManagementSystemBums.MainWindow.Forms.DetailWindow
{
    /// <summary>
    /// Interaction logic for EditTicketPage.xaml
    /// </summary>
    public partial class EditTicketPage : Page
    {
        public static event Action TicketUpdated;

        public Ticket Ticket { get; set; }
        public EditTicketPage()
        {
            InitializeComponent();
        }

        public EditTicketPage(Ticket ticket)
        {
            this.Ticket = ticket;
            InitializeComponent();
            txtName.Text = ticket.TicketName;
            txtDate.Text = ticket.TicketDate.ToString();
            txtPriority.Text = ticket.Priority.ToString();
            chkbxAssign.IsChecked = ticket.TicketAssignedUser != 0 ? true : false;
            txtDescription.Text = ticket.TicketDescription;
        }

        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtDate.Text == "" || txtPriority.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            int ticketStatus;
            if (this.Ticket.Status == TicketStatus.Completed)
            {
                ticketStatus = 2;
            } else if (chkbxAssign.IsChecked == true)
            {
                ticketStatus = 1;
            } else
            {
                ticketStatus = 0;
            }
            int assignedUser = chkbxAssign.IsChecked == true ? OverviewPage.UserId : 0;
            string connString = Database.CreateConnString().Result;
            
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand query = new NpgsqlCommand("UPDATE tickets SET ticket_name = @name, ticket_date = @date, " +
                        "ticket_priority = @priority, ticket_description = @description, ticket_assigneduser = @assigneduser, ticket_status = @status " +
                        "WHERE ticket_id = @id", conn))
                    {
                        query.Parameters.AddWithValue("name", txtName.Text);
                        query.Parameters.AddWithValue("date", DateTime.Parse(txtDate.Text));
                        query.Parameters.AddWithValue("priority", (int)Enum.Parse(typeof(TicketPriority), txtPriority.Text));
                        query.Parameters.AddWithValue("description", txtDescription.Text);
                        query.Parameters.AddWithValue("assignedUser", assignedUser);
                        query.Parameters.AddWithValue("status", ticketStatus);
                        query.Parameters.AddWithValue("id", this.Ticket.TicketID);
                        query.ExecuteNonQuery();
                    }
                }
                TicketUpdated?.Invoke(); 
                Window.GetWindow(this).Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
