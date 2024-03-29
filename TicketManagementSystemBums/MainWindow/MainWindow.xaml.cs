﻿using System;
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
        private static string userName;
        private static int userId;

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
        public static int UserId
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

        public MainWindow(string userName, int userId)
        {
            InitializeComponent();
            UserName = userName;
            UserId = userId;
            MainFrame.Navigate(new OverviewPage(userName, userId));
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
