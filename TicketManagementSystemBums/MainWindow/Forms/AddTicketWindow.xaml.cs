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
            while (txtName.Text == "" || txtDate.Text == "" || txtPriority.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            Ticket ticket = new Ticket
            {
                TicketName = txtName.Text,
                TicketDate = DateTime.Parse(txtDate.Text),
                Priority = (TicketPriority)Enum.Parse(typeof(TicketPriority), txtPriority.Text),
                TicketAssignedUser = txtAssignedUser.Text,
                TicketDescription = txtDescription.Text,
                Status = txtAssignedUser.Text == "" ? TicketStatus.Unassigned : TicketStatus.Assigned
            };
            OverviewPage.Tickets.Add(ticket);
            TicketAdded?.Invoke();
            Window.GetWindow(this).Close();
        }
    }
}
