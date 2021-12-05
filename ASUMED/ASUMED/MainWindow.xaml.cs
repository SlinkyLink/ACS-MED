using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using ASUMED.Controller;

namespace ASUMED
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ASUDBController controllerDB;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CrossImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void LineImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            controllerDB = new();
        }

        private void textLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
           controllerDB.LoginText = textLogin.Text;
        }

        private void textPass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            controllerDB.PasswordText = textPass.Password;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(controllerDB.CheckLogPass(textLogin.Text, textPass.Password))
            {
                ControlWindow controlWindow = new ControlWindow();
                this.Close();
                controlWindow.OpenLogin(textLogin.Text, controllerDB);
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }


    }
}
