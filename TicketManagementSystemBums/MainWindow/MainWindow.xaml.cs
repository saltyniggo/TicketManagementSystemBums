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

namespace TicketManagementSystemBums.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string userName = "Nico Schulz";

        public static string UserName
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

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new OverviewPage());
        }
        public MainWindow(string test)
        {
            InitializeComponent();
            MainFrame.Navigate(new OverviewPage(test));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}
