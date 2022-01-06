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
    public partial class PillsPage : Page
    {
        private TPage _page;
        public ASUDBController ControllerDB { get; set; }
        public ERank ERank;
        public double scrollW, scrollH;
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
            _page = TPage.Pills;
            for(int i = ListPills.Children.Count - 1; i >= 0; i--)
            {
                ListPills.Children.RemoveAt(i);
            }
            ScrollViewerList.MaxHeight = scrollH;
            ScrollViewerList.MaxWidth = scrollW;
            foreach(var window in Application.Current.Windows)
            {
                if(window is ControlWindow)
                {
                    Width = ((ControlWindow)window).Width;
                    Height = ((ControlWindow)window).Height;
                }
            }
            _AddPills();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (sender is Border bor) ControllerDB.activeTable = (bor.Tag as Pills);
            else return;
            if(e.ChangedButton == MouseButton.Left)
            {
                Pills pill = bor.Tag as Pills;
                TextBoxNameValue.Text = pill.Name;
                TextBoxTypeValue.Text = ControllerDB.GetTypeOfPill(pill).Name;
                TextBoxAmountValue.Text = pill.Amount.ToString();

                string txt = "";
                foreach(var client in ControllerDB.GetPatientsPill(pill))
                {
                    txt += $"\tПацієнт:{client.Username}\n";
                }
                TextBoxListClient.Text = txt;
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                if(ERank == ERank.ChiefDoctor)
                {
                    (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorder");
                }
                else if (ERank == ERank.Doctor)
                {
                    (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorderWrite");
                }
            }
        }
        private void AddStorage(object sender, MouseButtonEventArgs e)
        {
            EMode emode = new();
            if (sender is Ellipse) emode = EMode.AddPill;
            else emode = EMode.Add;

            foreach (Window window in Application.Current.Windows)
            {
                if (window is DBControl) return;
            }
            new DBControl()
            {
                ControllerDB = this.ControllerDB,
                tpage = _page,
                EMode = emode
            }.Show();
        }
        private void AddClient(object sender, MouseButtonEventArgs e)
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
        private void _AddPills()
        {
            foreach(var table in ControllerDB.Tables)
            {
                if(table is PillType pt)
                {
                    var pills = ControllerDB.GetPills(pt);
                    if(pills.Count > 0)
                    {
                        ListPills.Children.Add(new Label
                        {
                            Style = (Style)FindResource("LeftLabel"),
                            FontSize = 15,
                            Content = pt.Name

                        });
                        foreach (var pill in pills)
                        {
                            Border border = new Border
                            {
                                Style = (Style)FindResource("LeftBorder"),
                                Tag = pill,
                            };


                            border.Child = new Label
                            {
                                Style = (Style)FindResource("LeftLabel"),
                                Content = pill.Name
                            };

                            border.Cursor = Cursors.Hand;
                            ListPills.Children.Add(border);

                            border.MouseDown += Border_MouseDown;
                        }
                    }
                }
            }
        }
        public void Update()
        {
            for(int i = ListPills.Children.Count - 1; i >= 0; i--)
            {
                ListPills.Children.RemoveAt(i);
            }
            _AddPills();
        }
        public PillsPage()
        {
            InitializeComponent();
        }
    }
}
