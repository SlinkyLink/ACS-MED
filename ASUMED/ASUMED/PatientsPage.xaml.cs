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
using ASUMED.Controller;
using ASUMED.Control;

namespace ASUMED
{
    public partial class PatientsPage : Page
    {
        private TPage _page;
        public ASUDBController ControllerDB { get; set; }
        public ERank ERank;
        public double scrollW, scrollH;
        public PatientsPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
            for (int i = ListPatientsPanel.Children.Count - 1; i >= 0; i--)
            {
                ListPatientsPanel.Children.RemoveAt(i);
            }
            foreach (var window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    Width = ((ControlWindow)window).Width;
                    Height = ((ControlWindow)window).Height;
                }
            }
            ScrollViewerList.MaxHeight = scrollH;
            ScrollViewerList.MaxWidth = scrollW;
            AddPatientsPanels();
            _page = TPage.Patients;
        }
        private void AddData(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is DBControl) return;
            }
            new DBControl()
            {
                ControllerDB = this.ControllerDB,
                tpage = _page,
                EMode = EMode.Add
            }.Show();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ControllerDB.activeTable = ((sender as Border).Tag as Clients);
            if (e.ChangedButton == MouseButton.Left)
            {
                var patient = ((Border)sender).Tag as Clients;
                if (patient == null) return;
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                if (ERank == ERank.ChiefDoctor)
                {
                    (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorder");
                }
                else if (ERank == ERank.Doctor)
                {
                    (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorderUpdate");
                }
            }
        }
        private void DeleteItem(object sender, MouseButtonEventArgs e)
        {
            return;
        }
        public void UpdateData(object sender, MouseButtonEventArgs e)
        {
            _UpdateData();
        }
        private void UpdateItem(object sender, MouseButtonEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is DBControl) return;
            }
            new DBControl()
            {
                ControllerDB = this.ControllerDB,
                tpage = _page,
                EMode = EMode.Update
            }.Show();
        }
        public void AddPatientsPanels()
                {
                    if (ERank == ERank.ChiefDoctor)
                    {
                        foreach (var patient in ControllerDB.Tables)
                        {
                            if (patient is Clients pat)
                            {
                                Border border = new Border
                                {
                                    Style = (Style)FindResource("LeftBorder"),
                                    Tag = pat,
                                };
                                border.Child = new Label
                                {
                                    Style = (Style)FindResource("LeftLabel"),
                                    Content = pat.Username
                                };
                                border.Cursor = Cursors.Hand;
                                ListPatientsPanel.Children.Add(border);

                                border.MouseDown += Border_MouseDown;
                            }
                        }
                    }
                    else if (ERank == ERank.Doctor)
                    {
                        foreach (Clients client in ControllerDB.GetPatientsOfDoctor(ControllerDB.LogDoctor))
                        {
                            Border border = new Border
                            {
                                Style = (Style)FindResource("LeftBorder"),
                                Tag = client
                            };
                            border.Child = new Label
                            {
                                Style = (Style)FindResource("LeftLabel"),
                                Content = client.Username
                            };
                            border.Cursor = Cursors.Hand;
                            ListPatientsPanel.Children.Add(border);

                            border.MouseDown += Border_MouseDown;
                        }
                    }


                }
        private void _UpdateData()
        {
            for (int i = ListPatientsPanel.Children.Count - 1; i >= 0; i--)
            {
                ListPatientsPanel.Children.RemoveAt(i);
            }
            ControllerDB.Update();
            AddPatientsPanels();
        }
    }
}
