using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Security;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        public RegisterPage(string email)
        {
            InitializeComponent();
            txtBoxEmail.Text = email;
        }

        private async void ClickedRegister(object sender, RoutedEventArgs e)
        {
            string name = txtBoxName.Text;
            string email = txtBoxEmail.Text;
            string password = pswBoxPassword.Password;
            string passwordRepeat = pswBoxPasswordRepeat.Password;

            string connString = Database.CreateConnString();

            try
            {
                using (var conn = new NpgsqlConnection(connString))
                {
                    await conn.OpenAsync();

                    bool emailExists = await CheckIfEmailExistsAsync(email, conn);

                    if (!emailExists)
                    {
                        if (ValidateName(name) && ValidateEmail(email) && ValidatePasswordLength(password) && ValidatePasswordMatch(password, passwordRepeat))
                        {
                            int user_id = await Database.CountRowsAsync("users", connString) + 1;
                            using (var cmd2 = new NpgsqlCommand("INSERT INTO users (user_id, user_name, user_email, user_password) VALUES (@user_id, @name, @email, @password)", conn))
                            {
                                cmd2.Parameters.AddWithValue("user_id", user_id);
                                cmd2.Parameters.AddWithValue("name", name);
                                cmd2.Parameters.AddWithValue("email", email);
                                cmd2.Parameters.AddWithValue("password", password);
                                await cmd2.ExecuteNonQueryAsync();
                                MessageBox.Show("Account created successfully!");
                                this.NavigationService.Navigate(new LoginPage());
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid input! Please try again.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("There is already an account using the entered email!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private async Task<bool> CheckIfEmailExistsAsync(string email, NpgsqlConnection conn)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM users WHERE user_email = @email", conn))
            {
                cmd.Parameters.AddWithValue("email", email);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    return reader.HasRows;
                }
            }
        }

        private bool ValidateName(string name)
        {
            return (name.Length > 3) ? true : false;
        }

        private bool ValidateEmail(string email)
        {
            try
            {
                MailAddress testMail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidatePasswordLength(string password)
        {
            return (password.Length > 8) ? true : false;
        }

        private bool ValidatePasswordMatch(string password, string passwordRepeat)
        {
            return (password == passwordRepeat) ? true : false;
        }

        private void BackToLogin(object sender, RoutedEventArgs e)
        {
            if (txtBoxEmail.Text != "")
                this.NavigationService.Navigate(new LoginPage(txtBoxEmail.Text));
            else
                this.NavigationService.Navigate(new LoginPage());
        }
    }
}
