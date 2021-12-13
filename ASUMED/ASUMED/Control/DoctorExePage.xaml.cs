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
using System.Text.RegularExpressions;
using ASUMED.Controller;


namespace ASUMED.Control
{
    public partial class DoctorExePage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        public EMode EMode;
        public DoctorExePage()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            switch (EMode)
            {
                case EMode.Add:
                    (ExeBorder.Child as Label).Content = "Добавити";
                    break;
                case EMode.Update:
                    (ExeBorder.Child as Label).Content = "Оновити";
                    _FillTextBox();
                    break;
                default:
                    break;
            }
        }
        private void CloseWin(object sender, MouseButtonEventArgs e)
        {
            foreach(Window win in Application.Current.Windows)
            {
                if (win is DBControl)
                {
                    var dbControl = (win as DBControl);
                    dbControl.Close();
                    GC.Collect(); 
                    GC.WaitForPendingFinalizers(); 
                    GC.Collect();
                }
            }
        }
        private void DBControl_StrTextPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regexen = new Regex("^[a-zA-Z]+$");
            Regex regexru = new Regex("^[а-яА-я]+$");
            Regex regexua = new Regex("^[іїґєІЇҐЄ]+$");
            if (!regexen.IsMatch(e.Text) && !regexru.IsMatch(e.Text) && !regexua.IsMatch(e.Text))
                e.Handled = true;
            base.OnPreviewTextInput(e);
        }
        private void DBControl_IntTextPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void ExecuteBtn(object sender, MouseButtonEventArgs e)
        {
            for (int i = ValuesTextBox.Children.Count - 1; i >= 0; i--)
            {
                if (((ValuesTextBox.Children[i] as Border).Child as TextBox).Text == "")
                {
                    return;
                }
            }
            switch (EMode)
            {
                case EMode.Add:
                    _Add();
                    break;
                case EMode.Update:
                    _Update();
                    break;
                default:
                    break;
            }
        }
        private void _FillTextBox()
        {
            Doctors doc = (ControllerDB.activeTable as Doctors);
            ((ValuesTextBox.Children[0] as Border).Child as TextBox).Text = doc.Username;
            ((ValuesTextBox.Children[1] as Border).Child as TextBox).Text = doc.IDPassport.ToString();
            ((ValuesTextBox.Children[2] as Border).Child as TextBox).Text = (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Username.ToString();
            ((ValuesTextBox.Children[3] as Border).Child as TextBox).Text = (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Password.ToString();
        }
        private void _Add()
        {
            int idDoc = ControllerDB.GenerateID("Doctors");
            string username = ((ValuesTextBox.Children[0] as Border).Child as TextBox).Text;
            int idPassport = Convert.ToInt32(((ValuesTextBox.Children[1] as Border).Child as TextBox).Text);
            string login = ((ValuesTextBox.Children[2] as Border).Child as TextBox).Text;
            string password = ((ValuesTextBox.Children[3] as Border).Child as TextBox).Text;
            string createdAt = ASUDBController.TIME;
            string createdBy = ControllerDB.LogDoctor.Username;

            ControllerDB.AddData(new Doctors
            {
                ID = idDoc,
                Username = username,
                IDPassport = idPassport,
                CreatedAt = createdAt,
                CreatedBy = createdBy,
            });
            ControllerDB.AddData(new Accounts
            {
                ID = idDoc,
                Username = login,
                Password = password,
                CreatedBy=createdBy
            });
            ControllerDB.AddData(new DocsCl
            {
                DocID = idDoc,
                AccID = idDoc
            });
            ControllerDB.AddData(new RankSys
            {
                AccID = idDoc,
                RankID = ControllerDB.GetRankID("Лікар")
            });
            foreach (Border bor in ValuesTextBox.Children)
            {
                (bor.Child as TextBox).Text = "";
            }
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as DoctorsPage).UpdateData();
                    return;
                }
            }
        }
        private void _Update()
        {
            bool isChange = false;
            var doc = ControllerDB.activeTable as Doctors;
            var loginDoc = ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts;
            string username = ((ValuesTextBox.Children[0] as Border).Child as TextBox).Text;
            int idPassport = Convert.ToInt32(((ValuesTextBox.Children[1] as Border).Child as TextBox).Text);
            string login = ((ValuesTextBox.Children[2] as Border).Child as TextBox).Text; 
            string password = ((ValuesTextBox.Children[3] as Border).Child as TextBox).Text; 
            if (username != doc.Username)
            {
                ControllerDB.UpdateData(doc, "Username", $"'{username}'", "ID", doc.ID.ToString());
                isChange = true;
            }
            if (idPassport != doc.IDPassport)
            {
                ControllerDB.UpdateData(doc, "IDPassport", $"'{idPassport}'", "ID", doc.ID.ToString());
                isChange=true;
            }
            if (login != loginDoc.Username)
            {
                ControllerDB.UpdateData(loginDoc, "Username", $"'{login}'", "ID", loginDoc.ID.ToString());
                isChange = true;
            }
            if (password != loginDoc.Password)
            {
                ControllerDB.UpdateData(loginDoc, "Password", $"'{password}'", "ID", loginDoc.ID.ToString());
                isChange = true;
            }
            if (isChange) MessageBox.Show("Дані було змінено");
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as DoctorsPage).UpdateData();
                    return;
                }
            }
        }
    }
}

