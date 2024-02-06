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

namespace TicketManagementSystemBums.LoginWindow
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(string email)
        {
            InitializeComponent();
            txtBoxEmail.Text = email;
        }


        private void ClickedRegister(object sender, RoutedEventArgs e)
        {
            if (txtBoxEmail.Text != "")
                this.NavigationService.Navigate(new RegisterPage(txtBoxEmail.Text));
            else
                this.NavigationService.Navigate(new RegisterPage());
        }

        private void ForgotPassword(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ForgotPasswordPage());
        }

        private void ClickedLogin(object sender, RoutedEventArgs e)
        {
            if (txtBoxEmail.Text == "test")
            {
                new MainWindow.MainWindow("test").Show();
            } else
            {
                new MainWindow.MainWindow().Show();
            }
            Window.GetWindow(this).Close();
        }
    }
}
