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
    public partial class DoctorsPage : Page
    {
        public ASUDBController ControllerDB;
        public ControlWindow controlWindow;
        public ERank ERank;
        private TPage _page;
        public double scrollW, scrollH;
        public DoctorsPage()
        {
            InitializeComponent();
        } 
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
            _page = TPage.Doctors;
            for (int i = ListDoctorsPanel.Children.Count - 1; i >= 0; i--)
            {
                ListDoctorsPanel.Children.RemoveAt(i);
            }
            if(ERank != ERank.ChiefDoctor)
            {
                for(int i = AddBtn.Children.Count - 1; i >= 0; i--)
                {
                    AddBtn.Children.RemoveAt(i);
                }
                for(int i = TextBoxMainValues.Children.Count - 1;i >= 0;i--)
                {
                    TextBoxMainValues.Children.RemoveAt(i);
                }
                for(int i = LablesMainVaribles.Children.Count - 1;i >= 0; i--)
                {
                    LablesMainVaribles.Children.RemoveAt(i);
                }
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
            AddDoctorsPanels();
        }
        public void AddDoctorsPanels()
        {
            foreach (var doctor in ControllerDB.Tables)
            {
                if (doctor is Doctors doc)
                {
                    if (doc.ID != 100)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("LeftBorder"),
                            Tag = doc,
                        };


                        border.Child = new Label
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
        }
        public void UpdateData()
        {
            _UpdateData();
        }
        private void AddData(object sender, MouseButtonEventArgs e)
        {
            foreach(Window window in Application.Current.Windows)
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
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ControllerDB.activeTable = ((sender as Border).Tag as Doctors);
            if (e.ChangedButton == MouseButton.Left)
            {
                var doctor = ((Border)sender).Tag as Doctors;
                if (doctor == null) return;
                

                TextBoxFLValue.Text = doctor.Username;
                TextBoxSexValue.Text = doctor.Sex;
                TextBoxPositionValue.Text = ControllerDB.GetDoctorRank(doctor);
                TextBoxSpecializationValue.Text = ControllerDB.GetSpecializationOfDoctor(doctor);
                TextBoxExperienceTimeValue.Text = "";
                TextBoxSheduleValue.Text = ControllerDB.GetSheduleTodayOfDoctor(doctor);
                if (ERank == ERank.ChiefDoctor)
                {
                    TextBoxIDPassportValue.Text = doctor.IDPassport.ToString();
                    TextBoxDateOfBirthValue.Text = doctor.DateOfBirth;
                    TextBoxCreatedAtValue.Text = doctor.CreatedAt;
                    TextBoxCreatedByValue.Text = ControllerDB.GetNameDoctor(doctor.CreatedBy);
                    TextBoxNumberReceptionValue.Text = "";
                    TextBoxWorkTimeValue.Text = "";
                }
                TextBoxListClients.Text = "";
                foreach (Clients client in ControllerDB.GetPatientsOfDoctor(doctor))
                {
                    if(ERank == ERank.ChiefDoctor)
                        TextBoxListClients.Text += $"{client.Username}\n";
                    else if(doctor == ControllerDB.LogDoctor) 
                        TextBoxListClients.Text += $"{client.Username}\n";
                }
            }
            else if (e.ChangedButton == MouseButton.Right)
            {
                if (ERank == ERank.ChiefDoctor)
                {
                    bool isDoc = false;
                    if (sender is not Border) return;
                    if ((((Border)sender).Tag as Doctors).Username == ControllerDB.LogDoctor.Username) isDoc = true;

                    if (isDoc)
                    {
                        (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorderUpdate");
                    }
                    else
                    {
                        (sender as Border).ContextMenu = (ContextMenu)FindResource("cmBorder");
                    }
                }
            }
        }
        private void DeleteItem(object sender, RoutedEventArgs e)
        {
            Doctors doc = (ControllerDB.activeTable as Doctors);
            ControllerDB.DellData(ControllerDB.GetTable("DocsCl", "AccID", $"{doc.ID}"), doc.ID);
            ControllerDB.DellData(ControllerDB.GetTable("RankSys", "AccID", $"{doc.ID}"), doc.ID);
            ControllerDB.DellData(ControllerDB.GetTable("Accounts", "ID", $"{doc.ID}"), doc.ID);
            ControllerDB.DellData(doc, doc.ID);
            _UpdateData();
        }
        private void _UpdateData()
        {
            for (int i = ListDoctorsPanel.Children.Count - 1; i >= 0; i--)
            {
                ListDoctorsPanel.Children.RemoveAt(i);
            }
            ControllerDB.Update();
            AddDoctorsPanels();
        }
       
    }
}
