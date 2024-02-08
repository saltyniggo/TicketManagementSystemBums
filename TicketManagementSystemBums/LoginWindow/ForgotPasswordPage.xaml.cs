using Npgsql;
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

namespace TicketManagementSystemBums.LoginWindow
{
    /// <summary>
    /// Interaction logic for ForgotPasswordPage.xaml
    /// </summary>
    public partial class ForgotPasswordPage : Page
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
        private void BackToLogin(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }

        private void ClickedReset(object sender, RoutedEventArgs e)
        {
            string email = txtBoxEmail.Text;
            string connString = Database.CreateConnString().Result;
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(connString))
                {
                    conn.Open();
                    using (NpgsqlCommand query = new NpgsqlCommand("SELECT * FROM users WHERE user_email = @email", conn))
                    {
                        query.Parameters.AddWithValue("email", email);
                        using (var reader = query.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                MessageBox.Show("There exists an account with the entered mail, but I did not feel like implementing this function so yeaa..");
                            }
                            else
                            {
                                MessageBox.Show("There exists no account with the entered email. Please try again!.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
