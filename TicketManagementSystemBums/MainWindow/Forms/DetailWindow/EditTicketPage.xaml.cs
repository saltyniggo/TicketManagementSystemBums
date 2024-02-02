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
            txtName.Text = ticket.Name;
            txtDate.Text = ticket.Date.ToString();
            txtPriority.Text = ticket.Priority.ToString();
            txtAssignedUser.Text = ticket.AssignedUser;
            txtDescription.Text = ticket.Description;
        }
        
        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            Ticket.Name = txtName.Text;
            Ticket.Date = DateTime.Parse(txtDate.Text);
            Ticket.Priority = int.Parse(txtPriority.Text);
            Ticket.AssignedUser = txtAssignedUser.Text;
            Ticket.Description = txtDescription.Text;
            Window.GetWindow(this).Close();
        }
    }
}
