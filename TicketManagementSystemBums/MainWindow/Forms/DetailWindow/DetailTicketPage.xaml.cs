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

namespace TicketManagementSystemBums.MainWindow.Forms.DetailWindow
{
    /// <summary>
    /// Interaction logic for DetailTicketPage.xaml
    /// </summary>
    public partial class DetailTicketPage : Page
    {
        private Ticket ticket;

        public DetailTicketPage()
        {
            InitializeComponent();
            txtName.Text = "DATA_MISSING";
            txtDate.Text = "DATA_MISSING";
            txtPriority.Text = "DATA_MISSING";
            txtAssignedUser.Text = "DATA_MISSING";
            txtDescription.Text = "DATA_MISSING";
        }

        public DetailTicketPage(Ticket ticket)
        {
            this.ticket = ticket;
            InitializeComponent();
            txtName.Text = ticket.Name;
            txtDate.Text = ticket.Date.ToString();
            txtPriority.Text = ticket.Priority.ToString();
            txtAssignedUser.Text = ticket.AssignedUser;
            txtDescription.Text = ticket.Description;
        }

        private void EditTicket(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditTicketPage(this.ticket));
        }
    }
}
