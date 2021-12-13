using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ASUMED.Control
{
    public partial class ClientExePage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        public EMode EMode { get; set; }
        public ClientExePage()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            switch (EMode)
            {
                case EMode.Add:
                    (BorderExe.Child as Label).Content = "Добавити";
                    break;
                case EMode.Update:
                    (BorderExe.Child as Label).Content = "Оновити";
                    _FillTextBox();
                    break;
                default:
                    break;
            }
        }
        private void CloseWin(object sender, MouseButtonEventArgs e)
        {
            foreach (Window win in Application.Current.Windows)
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
            for (int i = TextBoxValues.Children.Count - 1; i >= 0; i--)
            {
                if (((TextBoxValues.Children[i] as Border).Child as TextBox).Text == "")
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
        private void _Add()
        {
            int userID = ControllerDB.GenerateID("Clients");
            string numberPhone = ((TextBoxValues.Children[1] as Border).Child as TextBox).Text;
            int docId = ControllerDB.LogDoctor.ID;
            string username = ((TextBoxValues.Children[0] as Border).Child as TextBox).Text; 
            string createdAt = ASUDBController.TIME;
            ControllerDB.AddData(new Clients
            {
                ID = userID,
                Username = username,
                NumberPhone = numberPhone,
                CreatedAt = createdAt
            });
            ControllerDB.AddData(new UseDocsCl
            {
                DocID = docId,
                ClientID = userID
            });
            foreach (Border bor in TextBoxValues.Children)
            {
                (bor.Child as TextBox).Text = "";
            }
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as PatientsPage).UpdateData(null, null);
                    return;
                }
            }

        }
        private void _Update()
        {
            bool isChange = false;
            var client = ControllerDB.activeTable as Clients;
            string username = ((TextBoxValues.Children[0] as Border).Child as TextBox).Text;
            string numberPhone = ((TextBoxValues.Children[1] as Border).Child as TextBox).Text;

            if (username != client.Username)
            {
                ControllerDB.UpdateData(client, "Username", $"'{username}'", "ID", client.ID.ToString());
                isChange = true;
            }
            if (numberPhone != client.NumberPhone)
            {
                ControllerDB.UpdateData(client, "NumberPhone", $"'{numberPhone}'", "ID", client.ID.ToString());
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
        private void _FillTextBox()
        {
            Clients client = (ControllerDB.activeTable as Clients);
            ((TextBoxValues.Children[0] as Border).Child as TextBox).Text = client.Username;
            ((TextBoxValues.Children[1] as Border).Child as TextBox).Text = client.NumberPhone.ToString();
        }
    }
}
