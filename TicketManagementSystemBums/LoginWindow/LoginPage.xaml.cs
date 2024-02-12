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
using Npgsql;

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
            string email = txtBoxEmail.Text;
            string password = pswBoxPassword.Password;

            string connString = Database.CreateConnString().Result;

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand query = new NpgsqlCommand("SELECT * FROM users WHERE user_email = @email AND user_password = @password", conn))
                    {
                        query.Parameters.AddWithValue("email", email);
                        query.Parameters.AddWithValue("password", password);
                        using (var reader = query.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                int userId = 0;
                                string userName = string.Empty;

                                while (reader.Read())
                                {
                                    userId = reader.GetInt32(0);
                                    userName = reader.GetString(2);
                                }
                                new MainWindow.MainWindow(userName: userName, userId: userId).Show();
                                Window.GetWindow(this).Close();
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Beep Boop, an error occurred: {ex.Message}");
            }
        }
    }
}