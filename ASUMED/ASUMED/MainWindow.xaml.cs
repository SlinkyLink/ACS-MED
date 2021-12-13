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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(controllerDB.CheckLogPass(textLogin.Text, textPass.Password))
            {
                ERank eRank = new ERank();
                controllerDB.GetAcc(textLogin.Text, textPass.Password);
                if (controllerDB.GetLogDoctorRank() == "Головний лікар") eRank = ERank.ChiefDoctor;
                else eRank = ERank.Doctor;
                new ControlWindow
                {
                    ControllerDB = this.controllerDB,
                    ERank = eRank
                }.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong login or password");
            }
        }
    }
}
