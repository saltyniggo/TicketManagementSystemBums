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
            txtAssignedUser.Text = ticket.TicketAssignedUser.ToString();
            txtDescription.Text = ticket.TicketDescription;
        }

        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            while (txtName.Text == "" || txtDate.Text == "" || txtPriority.Text == "")
            {
                MessageBox.Show("Please fill in all fields");
                return;
            }
            Ticket.TicketName = txtName.Text;
            Ticket.TicketDate = txtDate.SelectedDate.Value;
            Ticket.Priority = (TicketPriority)txtPriority.SelectedIndex;
            Ticket.TicketAssignedUser = Convert.ToInt32(txtAssignedUser.Text);
            Ticket.TicketDescription = txtDescription.Text;

            if (Ticket.Status != TicketStatus.Completed)
            {
                Ticket.Status = string.IsNullOrEmpty(txtAssignedUser.Text) ? TicketStatus.Unassigned : TicketStatus.Assigned;
            }

            TicketUpdated?.Invoke();
            Window.GetWindow(this).Close();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
