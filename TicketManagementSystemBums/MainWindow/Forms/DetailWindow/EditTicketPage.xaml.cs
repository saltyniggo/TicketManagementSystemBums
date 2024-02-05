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
using TicketManagementSystemBums.MainWindow;
using static TicketManagementSystemBums.Ticket;

namespace TicketManagementSystemBums.MainWindow.Forms.DetailWindow
{
    /// <summary>
    /// Interaction logic for EditTicketPage.xaml
    /// </summary>
    public partial class EditTicketPage : Page
    {
        private Ticket Ticket { get; set; }
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
            txtAssignedUser.Text = ticket.TicketAssignedUser;
            txtDescription.Text = ticket.TicketDescription;
        }

        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                Ticket.TicketName = txtName.Text;
            }
            else
            {
                MessageBox.Show("Invalid Ticket Name");
                return;
            }
            if (DateTime.TryParse(txtDate.Text, out DateTime ticketDate))
            {
                Ticket.TicketDate = ticketDate;
            }
            else
            {
                MessageBox.Show("Invalid Date");
                return;
            }
            if (Enum.TryParse(txtPriority.Text, out TicketPriority priority))
            {
                Ticket.Priority = priority;
            }
            else
            {
                MessageBox.Show("Invalid Priority");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtAssignedUser.Text))
            {
                Ticket.TicketAssignedUser = txtAssignedUser.Text;
            }
            else
            {
                MessageBox.Show("Invalid Assigned User");
                return;
            }
            if (!string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                Ticket.TicketDescription = txtDescription.Text;
            }
            else
            {
                MessageBox.Show("Invalid Description");
                return;
            }

            Window.GetWindow(this).Close();
        }


    }
}
