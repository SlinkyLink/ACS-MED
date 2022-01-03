using System;
using System.Globalization;
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
            _DrawContext();
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
        private void DBControl_FloatTextPreview(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            e.Handled = !regex.IsMatch(e.Text);
            
            if ((sender as TextBox).Text.Split('.').Length - 1 == 1 && e.Text == ".")
            {
                e.Handled = !e.Handled;
            }
        }
        private void ExecuteBtn(object sender, MouseButtonEventArgs e)
        {
            for (int i = TextBoxValues.Children.Count - 1; i >= 0; i--)
            {
                if(TextBoxValues.Children[i] is Border)
                {
                    if (((TextBoxValues.Children[i] as Border).Child as TextBox).Text == "")
                    {
                        return;
                    }
                }
                if(EMode == EMode.Add)
                {
                    if(TextBoxValues.Children[i] is StackPanel)
                    {
                        var addStack = TextBoxValues.Children[i] as StackPanel;
                        for(int j = addStack.Children.Count - 1; j >= 0; j--)
                        {
                            if (TextBoxValues.Children[j] is Border)
                            {
                                if (((TextBoxValues.Children[j] as Border).Child as TextBox).Text == "")
                                {
                                    return;
                                }
                            }
                        }
                    }
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
            string flName = TextBoxFLName.Text;
            string weight = TextBoxWeightValue.Text;
            int growth = Convert.ToInt32(TextBoxGrowthValue.Text);
            string numberPhone = TextBoxNumberValue.Text;
            string sex = TextBoxSexValue.Text;
            string dateBirth = TextBoxDateBirthValue.Text;
            string rhFactor = TextBoxRhFactorValue.Text;

            int idClient = ControllerDB.GenerateID("Clients");
            int idFactor = ControllerDB.GetIdRhFactor(rhFactor);
            int idDoc = ControllerDB.LogDoctor.ID;
            string createdAt = ASUDBController.TIME;

            ControllerDB.AddData(new Clients
            {
                ID = idClient,
                Username = flName,
                Sex = sex,
                DateOfBirth = dateBirth,
                IDRhFactor = idFactor,
                Weight = weight,
                Growth = growth,
                NumberPhone = numberPhone,
                CreatedAt = createdAt,
                DocID = idDoc,
                MedStory = ""
            }); 


            for (int i = TextBoxValues.Children.Count - 1; i >= 0; i--)
            {
                if (TextBoxValues.Children[i] is Border)
                {
                    ((TextBoxValues.Children[i] as Border).Child as TextBox).Text = "";
                }
                if (EMode == EMode.Add)
                {
                    if (TextBoxValues.Children[i] is StackPanel)
                    {
                        var addStack = TextBoxValues.Children[i] as StackPanel;
                        for (int j = addStack.Children.Count - 1; j >= 0; j--)
                        {
                            if (addStack.Children[j] is Border)
                            {
                                ((addStack.Children[j] as Border).Child as TextBox).Text = "";
                            }
                        }
                    }
                }
            }
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as PatientsPage).UpdateData();
                    return;
                }
            }

        }
        private void SexMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContexRhFactor.Visibility == Visibility.Visible) ContexRhFactor.Visibility = Visibility.Hidden;

            if (ContexSex.Visibility == Visibility.Visible) ContexSex.Visibility = Visibility.Hidden;
            else ContexSex.Visibility = Visibility.Visible;

        }
        private void RhFactorMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContexSex.Visibility == Visibility.Visible) ContexSex.Visibility = Visibility.Hidden;

            if (ContexRhFactor.Visibility == Visibility.Visible) ContexRhFactor.Visibility = Visibility.Hidden;
            else ContexRhFactor.Visibility = Visibility.Visible;
        }
        private void SelectSex(object sender, MouseButtonEventArgs e)
        {
            TextBoxSexValue.Text = (sender as Border).Tag.ToString();
            ContexSex.Visibility = Visibility.Hidden;
        }
        private void SelectRhFactor(object sender, MouseButtonEventArgs e)
        {
            TextBoxRhFactorValue.Text = ((sender as Border).Tag as RhFactor).Name;
            ContexRhFactor.Visibility = Visibility.Hidden;
        }
        private void _Update()
        {
            bool isChange = false;
            var client = ControllerDB.activeTable as Clients;

            string username = TextBoxFLName.Text;
            string numberPhone = TextBoxNumberValue.Text;
            string weight = TextBoxWeightValue.Text;
            int growth =  Convert.ToInt32(TextBoxGrowthValue.Text);

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
            if (weight != client.Weight)
            {
                ControllerDB.UpdateData(client, "Weight", weight, "ID", client.ID.ToString());
                isChange = true;
            }
            if (growth != client.Growth)
            {
                ControllerDB.UpdateData(client, "Growth", growth, "ID", client.ID.ToString());
                isChange = true;
            }
            if (isChange) MessageBox.Show("Дані було змінено");
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as PatientsPage).UpdateData();
                    return;
                }
            }
        }
        private void _FillTextBox()
        {
            var client = ControllerDB.activeTable as Clients;
            for(int i = AddLabelVaribles.Children.Count - 1; i >= 0; i--)
            {
                AddLabelVaribles.Children.RemoveAt(i);
            }
            for (int i = AddTexBoxValues.Children.Count - 1; i >= 0; i--)
            {
                AddTexBoxValues.Children.RemoveAt(i);
            }

            TextBoxFLName.Text = client.Username;
            TextBoxWeightValue.Text = client.Weight;
            TextBoxGrowthValue.Text = client.Growth.ToString();
            TextBoxNumberValue.Text = client.NumberPhone;
        }
        private void _DrawContext()
        {
            //RhFactor
            foreach(var table in ControllerDB.Tables)
            {
                if(table is RhFactor)
                {
                    Border border = new Border
                    {
                        Style = (Style)FindResource("ValueBorder"),
                        Margin = new Thickness(0, 1, 0, 1),
                        Tag = table as RhFactor
                    };
                    TextBox textbox = new TextBox
                    {
                        Style = (Style)FindResource("ValueTextBox"),
                        IsReadOnly = true,
                        Focusable = false,
                        Cursor = Cursors.Arrow,
                        FontSize = 12,
                        Text = (table as RhFactor).Name
                    };
                    border.Child = textbox;
                    border.MouseDown += SelectRhFactor;
                    StackPanelRhFactorValues.Children.Add(border);
                }
            }
            //Sex Man Famale
            Border manBorder = new Border
            {
                Style = (Style)FindResource("ValueBorder"),
                Margin = new Thickness(0, 1, 0, 1),
                Tag = "Чоловік"
            };
            TextBox manTexBox = new TextBox
            {
                Style = (Style)FindResource("ValueTextBox"),
                IsReadOnly = true,
                Focusable = false,
                Cursor = Cursors.Arrow,
                FontSize = 12,
                Text = "Чоловік"
            };
            manBorder.Child = manTexBox;
            Border famaleBorder = new Border
            {
                Style = (Style)FindResource("ValueBorder"),
                Margin = new Thickness(0, 1, 0, 1),
                Tag = "Жінка"
            };
            TextBox famaleTexBox = new TextBox
            {
                Style = (Style)FindResource("ValueTextBox"),
                IsReadOnly = true,
                Focusable = false,
                Cursor = Cursors.Arrow,
                FontSize = 12,
                Text = "Жінка"
            };
            famaleBorder.Child = famaleTexBox;
            manBorder.MouseDown += SelectSex;
            famaleBorder.MouseDown += SelectSex;
            StackPanelSexValues.Children.Add(manBorder);
            StackPanelSexValues.Children.Add(famaleBorder);
        }
    }
}
