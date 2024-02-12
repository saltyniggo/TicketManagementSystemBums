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
        public static event Action TicketCompleted;
        
        private Ticket ticket;

        public Ticket Ticket
        {
            get { return ticket; }
            set { ticket = value; }
        }

        public DetailTicketPage()
        {
           InitializeComponent();
        }

        public DetailTicketPage(Ticket ticket)
        {
            this.ticket = ticket;
            InitializeComponent();
            txtDate.Text = ticket.TicketDate.ToString("dd/MM/yyyy");
            txtName.Text = ticket.TicketName;
            txtPriority.Text = ticket.Priority.ToString();
            txtAssignedUser.Text = ticket.TicketAssignedUser == 0 ? "" : OverviewPage.UserName;
            txtDescription.Text = ticket.TicketDescription;
        }

        private void EditTicket(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditTicketPage(this.ticket));
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void CompleteTicket(object sender, RoutedEventArgs e)
        {
            this.Ticket.Status = Ticket.TicketStatus.Completed;
            TicketCompleted?.Invoke();
            MessageBox.Show("Ticket has been completed");
            Window.GetWindow(this).Close();
        }
    }
}
