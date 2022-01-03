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
    public partial class ProceduresPage : Page
    {
        private TPage _page;
        public ASUDBController ControllerDB { get; set; }
        public ERank ERank;
        public double scrollW, scrollH;
        public ProceduresPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
            _page = TPage.Procedures;
            for (int i = StackPanelProceduresList.Children.Count - 1; i >= 0; i--)
            {
                StackPanelProceduresList.Children.RemoveAt(i);
            }
            ScrollViewerList.MaxHeight = scrollH;
            ScrollViewerList.MaxWidth = scrollW;
            foreach (var window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    Width = ((ControlWindow)window).Width;
                    Height = ((ControlWindow)window).Height;
                }
            }
            _AddBordersProcedure();
        }
        private void ContextUpdateMouseDown(object sender, MouseButtonEventArgs e)
        {
            new DBControl
            {
                ControllerDB = ControllerDB,
                tpage = _page,
                EMode = EMode.Update
            }.Show();
        }
        private void ContextAddMouseDown(object sender, MouseButtonEventArgs e)
        {
            new DBControl
            {
                ControllerDB = ControllerDB,
                tpage = _page,
                EMode = EMode.Add
            }.Show();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        { 
            ControllerDB.activeTable = ((sender as Border).Tag as Procedures);
            if (e.ChangedButton == MouseButton.Left)
            {
                Procedures proc = ((Border)sender).Tag as Procedures;
                Doctors doctor = null;
                Clients client = null;
                ProcedClients procedClient = null;

                string tmp = "";
                foreach (var list in ControllerDB.GetAboutProcedure(proc))
                {
                    foreach (var table in list)
                    {
                        if (table is Doctors) doctor = (Doctors)table;
                        else if (table is Clients) client = (Clients)table;
                        else if (table is ProcedClients) procedClient = (ProcedClients)table;
                    }
                    if (doctor == null || client == null || procedClient == null) return;
                    tmp += $"\tПроцедура:{proc.Name}\n\tХто проводить:{doctor.Username}\n\tПацієнт:{client.Username}\n\tКоли проводиться:{procedClient.Time}";
                    tmp += "\n\n\n";
                }
                TextBoxProcedures.Text = tmp;
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorderUpdate");
            }
        }
        private void _AddBordersProcedure()
        {
            foreach(var table in ControllerDB.Tables)
            {
                if (table is Procedures proc)
                {
                    if (proc.ID != 100)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("LeftBorder"),
                            Tag = proc,
                        };


                        border.Child = new Label
                        {
                            Style = (Style)FindResource("LeftLabel"),
                            Content = proc.Name
                        };

                        border.Cursor = Cursors.Hand;
                        StackPanelProceduresList.Children.Add(border);

                        border.MouseDown += Border_MouseDown;
                    }
                }
            }
        }
        private void _UpdateData()
        {
            for (int i = StackPanelProceduresList.Children.Count - 1; i >= 0; i--)
            {
                StackPanelProceduresList.Children.RemoveAt(i);
            }
            ControllerDB.Update();
            _AddBordersProcedure();
        }

    }
}
