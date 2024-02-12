using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static TicketManagementSystemBums.Ticket;
using TicketManagementSystemBums.MainWindow;
using Npgsql;

namespace TicketManagementSystemBums.MainWindow.Forms
{
    /// <summary>
    /// Interaction logic for AddTicketWindow.xaml
    /// </summary>
    public partial class AddTicketWindow : Window
    {
        public static event Action TicketAdded;

        public AddTicketWindow()
        {
            InitializeComponent();
        }
        
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        
        private void AddTicket(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtDate.Text == "" || txtPriority.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            string connString = Database.CreateConnString().Result;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand query = new NpgsqlCommand("INSERT INTO tickets (ticket_name, ticket_date, ticket_priority, " +
                        "ticket_description, ticket_assigneduser, ticket_status) VALUES (@name, @date, @priority, @description, @assigneduser, @status)", conn))
                    {
                        query.Parameters.AddWithValue("name", txtName.Text);
                        query.Parameters.AddWithValue("date", DateTime.Parse(txtDate.Text));
                        query.Parameters.AddWithValue("priority", (int)Enum.Parse(typeof(TicketPriority), txtPriority.Text));
                        query.Parameters.AddWithValue("description", txtDescription.Text);
                        query.Parameters.AddWithValue("assigneduser", 0);
                        query.Parameters.AddWithValue("status", (int)TicketStatus.Unassigned);
                        query.ExecuteNonQuery();
                    }
                }
                TicketAdded?.Invoke();
                Window.GetWindow(this).Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
