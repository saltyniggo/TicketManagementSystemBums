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
        public void FillLists()
        {
            Random random = new Random();

            for (int i = 0; i < 69; i++)
            {
                string randomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 12)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                listUnassigned.Items.Add(randomString);
                listAssigned.Items.Add(randomString);
                listCompleted.Items.Add(randomString);
            }

            List<string> unassignedItems = new List<string>();
            List<string> assignedItems = new List<string>();   
            List<string> completedItems = new List<string>();

            foreach (var item in unassignedItems)
            {
                listUnassigned.Items.Add(item);
            }

            foreach (var item in assignedItems)
            {
                listAssigned.Items.Add(item);
            }

            foreach (var item in completedItems)
            {
                listCompleted.Items.Add(item);
            }
        }

        public OverviewPage()
        {
            InitializeComponent();
            FillLists();
        }

        private void OpenAddTicketForm(object sender, RoutedEventArgs e)
        {
            new AddTicketWindow().Show();
        }
    }
}
