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


        public OverviewPage()
        {
            InitializeComponent();
            FillLists();
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

                Ticket ticket = new Ticket
                {
                    TicketName = randomString,
                    TicketDate = DateTime.Today.AddDays(random.Next(-10, 10)).Date,
                    Priority = (TicketPriority)random.Next(0, 4),
                    TicketAssignedUser = "User" + random.Next(1, 5),
                    TicketDescription = "Description" + random.Next(1, 100),
                    Status = (TicketStatus)random.Next(0, 3)
                };


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
            Ticket item = (sender as FrameworkElement).DataContext as Ticket;
            if (currentDetailWindow != null)
            {
                currentDetailWindow.Close();
            }
            currentDetailWindow = new DetailWindow(item);
            currentDetailWindow.Show();
        }


    }
}
