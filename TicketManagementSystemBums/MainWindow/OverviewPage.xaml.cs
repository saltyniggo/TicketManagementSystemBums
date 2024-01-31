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

namespace TicketManagementSystemBums.MainWindow
{
    /// <summary>
    /// Interaction logic for OverviewPage.xaml
    /// </summary>
    public partial class OverviewPage : Page
    {
        private EditTicketWindow currentEditTicketWindow;

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

            for (int i = 0; i < 7; i++)
            {
                string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                Ticket ticket = new Ticket
                {
                    Name = randomString,
                    Date = DateTime.Now.AddDays(random.Next(-10, 10)),
                    Priority = random.Next(1, 5),
                    AssignedUser = "User" + random.Next(1, 5),
                    Description = "Description" + random.Next(1, 100)
                };

                listUnassigned.Items.Add(ticket);
                listAssigned.Items.Add(ticket);
                listCompleted.Items.Add(ticket);
            }
        }
        private void Ticket_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ticket item = (sender as FrameworkElement).DataContext as Ticket;
            if (currentEditTicketWindow != null)
            {
                currentEditTicketWindow.Close();
            }
            currentEditTicketWindow = new EditTicketWindow(item);
            currentEditTicketWindow.Show();
        }


    }
}
