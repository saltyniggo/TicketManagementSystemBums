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
using TicketManagementSystemBums.MainWindow.Forms.DetailWindow;

namespace TicketManagementSystemBums.MainWindow
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    /// 
    public partial class SettingsPage : Page
    {
        private string userName;
        private int userId;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }
        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
            }
        }


        public SettingsPage(string userName, int userId)
        {
            this.userName = userName;
            this.userId = userId;
            InitializeComponent();
            sidebarTitle.Text = $"Welcome {UserName} {UserId}";

        }
        private void openOverview(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OverviewPage(UserName, UserId));
        }

        private void logout(object sender, RoutedEventArgs e)
        {
            new StartWindow().Show();
            Window.GetWindow(this).Close();
        }
    }
}
