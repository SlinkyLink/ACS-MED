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
using ASUMED.Controller;

namespace ASUMED
{
    /// <summary>
    /// Логика взаимодействия для ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        private ASUDBController controllerDB;
        public ControlWindow()
        {
            InitializeComponent();
        }

        public void OpenLogin(string login, ASUDBController controllerDB)
        {
            this.Show();
            this.controllerDB = controllerDB;
            AddDoctorsPanels();
            MessageBox.Show($"Hello {login}");
        }

        private void LineImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CrossImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
            
        }

        private void SquareImg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }



        private void AddDoctorsPanels()
        {
           foreach(var doctor in controllerDB.Tables)
            {
                if(doctor is Doctors doc)
                {
                    Border border = new Border()
                    {
                        Style = (Style)FindResource("LeftBorder"),
                        Tag = doc
                    };

                    border.Child = new Label()
                    {
                        Style = (Style)FindResource("LeftLabel"),
                        Content = doc.Username
                    };
                    border.Cursor = Cursors.Hand;
                    ListDoctorsPanel.Children.Add(border);

                    border.MouseDown += Border_MouseDown;
                }
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var doctor = (Doctors)((Border)sender).Tag;
            if (doctor == null) return;

            FSTexBox.Text = doctor.Username;
            DRTexBox.Text = doctor.CreatedAt;

        }
    }
}
