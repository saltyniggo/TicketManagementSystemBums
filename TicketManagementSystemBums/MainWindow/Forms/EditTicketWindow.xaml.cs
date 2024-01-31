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
using System.Windows.Shapes;

namespace TicketManagementSystemBums.MainWindow.Forms
{
    /// <summary>
    /// Interaction logic for EditTicketWindow.xaml
    /// </summary>
    public partial class EditTicketWindow : Window
    {
        public EditTicketWindow()
        {
            InitializeComponent();
        }

        public EditTicketWindow(Ticket ticket)
        {
            InitializeComponent();
            txtName.Text = ticket.Name;
            txtDate.Text = ticket.Date.ToString();
            txtPriority.Text = ticket.Priority.ToString();
            txtAssignedUser.Text = ticket.AssignedUser;
            txtDescription.Text = ticket.Description;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void SubmitTicket(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

    }
}
