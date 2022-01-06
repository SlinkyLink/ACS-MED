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
using Cryptography;

namespace ASUMED.Control
{
    public partial class DoctorExePage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        public EMode EMode;
        public List<Border> botders;
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
                    AddValuesStackPanel.Visibility = Visibility.Hidden;
                    AddValuesLabeles.Visibility = Visibility.Hidden;
                    _FillTextBox();
                    break;
                default:
                    break;
            }
            _DrawContexts();
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
            for (int i = ValuesStackPanel.Children.Count - 1; i >= 0; i--)
            {
                if(ValuesStackPanel.Children[i] is Border)
                {
                    if (((ValuesStackPanel.Children[i] as Border).Child as TextBox).Text == "")
                    {
                        return;
                    }
                }
                if (EMode == EMode.Add)
                {
                    if (ValuesStackPanel.Children[i] is StackPanel)
                    {
                        for (int j = AddValuesStackPanel.Children.Count - 1; j >= 0; j--)
                        {
                            if (AddValuesStackPanel.Children[j] is Border)
                            {
                                if (((AddValuesStackPanel.Children[j] as Border).Child as TextBox).Text == "")
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
        private void PositionMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContextSpecialization.Visibility == Visibility.Visible)
                ContextSpecialization.Visibility = Visibility.Hidden;
            if (ContexSex.Visibility == Visibility.Visible)
                ContexSex.Visibility = Visibility.Hidden;
            if (ContextShedule.Visibility == Visibility.Visible)
                ContextShedule.Visibility = Visibility.Hidden;

            if (ContextPosition.Visibility == Visibility.Visible)
                ContextPosition.Visibility = Visibility.Hidden;
            else ContextPosition.Visibility = Visibility.Visible;
        }
        private void SpecializationMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContextPosition.Visibility == Visibility.Visible)
                ContextPosition.Visibility = Visibility.Hidden;
            if (ContexSex.Visibility == Visibility.Visible)
                ContexSex.Visibility = Visibility.Hidden;
            if (ContextShedule.Visibility == Visibility.Visible)
                ContextShedule.Visibility = Visibility.Hidden;

            if(ContextSpecialization.Visibility == Visibility.Visible)
                ContextSpecialization.Visibility = Visibility.Hidden;
            else ContextSpecialization.Visibility = Visibility.Visible;
        }
        private void SexMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContextPosition.Visibility == Visibility.Visible)
                ContextPosition.Visibility = Visibility.Hidden;
            if (ContextSpecialization.Visibility == Visibility.Visible)
                ContextSpecialization.Visibility = Visibility.Hidden;
            if (ContextShedule.Visibility == Visibility.Visible)
                ContextShedule.Visibility = Visibility.Hidden;

            if (ContexSex.Visibility == Visibility.Visible)
                ContexSex.Visibility = Visibility.Hidden;
            else ContexSex.Visibility = Visibility.Visible;
        }
        private void SheduleMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (ContextPosition.Visibility == Visibility.Visible)
                ContextPosition.Visibility = Visibility.Hidden;
            if (ContextSpecialization.Visibility == Visibility.Visible)
                ContextSpecialization.Visibility = Visibility.Hidden;
            if (ContexSex.Visibility == Visibility.Visible)
                ContexSex.Visibility = Visibility.Hidden;

            if (ContextShedule.Visibility == Visibility.Visible)
                ContextShedule.Visibility = Visibility.Hidden;
            else ContextShedule.Visibility = Visibility.Visible;
        }
        private void SelectPosition(object sender, MouseButtonEventArgs e)
        {
            RankGroups posit = (sender as Border).Tag as RankGroups;
            TextBoxPositionValue.Text = posit.Name;
            ContextPosition.Visibility = Visibility.Hidden;
        }
        private void SelectSpecialization(object sender, MouseButtonEventArgs e)
        {
            Specialization posit = (sender as Border).Tag as Specialization;
            TextBoxSpecializationValue.Text = posit.Name;
            ContextSpecialization.Visibility = Visibility.Hidden;
        }
        private void SelectSex(object sender, MouseButtonEventArgs e)
        {
            TextBoxSexValue.Text = (string)(sender as Border).Tag;
            ContexSex.Visibility = Visibility.Hidden;
        }
        private void SelectShedule(object sender, MouseButtonEventArgs e)
        {
            TextBoxSheduleValue.Text = (string)(sender as Border).Tag;
            ContextShedule.Visibility = Visibility.Hidden;
        }
        private void _FillTextBox()
        {
            Doctors doc = (ControllerDB.activeTable as Doctors);
            TextBoxFLValue.Text = doc.Username;
            TextBoxPositionValue.Text = ControllerDB.GetDoctorRank(doc);
            TextBoxSpecializationValue.Text = ControllerDB.GetSpecializationOfDoctor(doc);
            TextBoxIDPassValue.Text = doc.IDPassport.ToString();
            TextBoxLogValue.Text = (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Username;
            TextBoxPassValue.Text = (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Password;
        }
        private void _Add()
        {
            string fsname = TextBoxFLValue.Text;
            string position = TextBoxPositionValue.Text;
            string specialization = TextBoxSpecializationValue.Text;
            int idPass = Convert.ToInt32(TextBoxIDPassValue.Text);
            string login = TextBoxLogValue.Text;
            string pass = TextBoxPassValue.Text;
            string sex = TextBoxSexValue.Text;
            string datebirth = TextBoxDateOfBirthValue.Text;
            string shedule = TextBoxSheduleValue.Text;

            int createdBy = ControllerDB.LogDoctor.ID;
            int idDoc = ControllerDB.GenerateID("Doctors");
            int idRank = ControllerDB.GetRankID(position);
            int idAcc = idDoc;
            int idSpec = 0;
            foreach (var table in ControllerDB.Tables)
            {
                if (table is Accounts acc)
                {
                    if (acc.Username == login)
                    {
                        MessageBox.Show("Такий логін існує");
                        return;
                    }
                }
            }

            foreach (var table in ControllerDB.Tables)
            {
                if(table is Specialization)
                {
                    if((table as Specialization).Name == specialization)
                    {
                        idSpec = (table as Specialization).ID;
                        break;
                    }
                }
            }
            
            

            int sh = 0;
            int c = 0;
            if(shedule == "Пн 7:30-12:30, Вт 12:30-17:30...")
            {
                sh = 1;
            }
            else if (shedule == "Пн 12:30-17:30, Вт 7:30-12:30...")
            {
                sh = 2;
            }

            for(int i = 0; i < 7; i++)
            {
                if(i == 0)
                {
                    ControllerDB.AddData(new SheduleDoctors
                    { 
                        DocID = idDoc,
                        TimeID = 21,
                        DayID = i,
                    });
                    continue;
                }
                else if (i == 6)
                {
                    ControllerDB.AddData(new SheduleDoctors
                    {
                        DocID = idDoc,
                        TimeID = 20,
                        DayID = i,
                    });
                    continue;
                }
                else
                {
                    if (sh == 1)
                    {
                        if(i % 2 == 0)
                        {
                            ControllerDB.AddData(new SheduleDoctors
                            {
                                DocID = idDoc,
                                TimeID = 10,
                                DayID = i
                            });
                            continue;
                        }
                        else if (i % 2 == 1)
                        {
                            ControllerDB.AddData(new SheduleDoctors
                            {
                                DocID = idDoc,
                                TimeID = 11,
                                DayID= i
                            });
                        }
                    }
                    else if (sh == 2)
                    {
                        if (i % 2 == 0)
                        {
                            ControllerDB.AddData(new SheduleDoctors
                            {
                                DocID = idDoc,
                                TimeID = 11,
                                DayID = i
                            });
                            continue;
                        }
                        else if (i % 2 == 1)
                        {
                            ControllerDB.AddData(new SheduleDoctors
                            {
                                DocID = idDoc,
                                TimeID = 10,
                                DayID = i
                            });
                        }
                    }
                }
            }
            ControllerDB.AddData(new Doctors
            {
                ID = idDoc,
                Username = fsname,
                Sex = sex,
                DateOfBirth = datebirth,
                IDPassport = idPass,
                CreatedAt = ASUDBController.TIME,
                CreatedBy = createdBy,
                IDSpec = idSpec
                
            });
            ControllerDB.AddData(new Accounts
            {
                ID = idAcc,
                Username = login,
                Password = Sha256.ToSHA256(pass),
                CreatedBy = createdBy,
                RankID = idRank
            });

            for (int i = ValuesStackPanel.Children.Count - 1; i >= 0; i--)
            {
                if (ValuesStackPanel.Children[i] is Border)
                {
                    ((ValuesStackPanel.Children[i] as Border).Child as TextBox).Text = "";
                }
                if (ValuesStackPanel.Children[i] is StackPanel)
                {
                    for (int j = AddValuesStackPanel.Children.Count - 1; j >= 0; j--)
                    {
                        if (AddValuesStackPanel.Children[j] is Border)
                        {
                            ((AddValuesStackPanel.Children[j] as Border).Child as TextBox).Text = "";
                        }
                    }
                }
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
            
            string flname = TextBoxFLValue.Text;
            string position = TextBoxPositionValue.Text;
            string specialization = TextBoxSpecializationValue.Text;
            int idPass = Convert.ToInt32(TextBoxIDPassValue.Text);
            string login = TextBoxLogValue.Text;
            string pass = TextBoxPassValue.Text;


            var doc = ControllerDB.activeTable as Doctors;
            var loginDoc = ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts;


            if (flname != doc.Username)
            {
                isChange = true;
                ControllerDB.UpdateData(doc, "Username", flname, "ID", doc.ID);
            }
            if(position != ControllerDB.GetDoctorRank(doc))
            {
                isChange = true;
                ControllerDB.UpdateData(loginDoc, "RankID", ControllerDB.GetRankID(position), "ID", doc.ID);
            }
            if(specialization != ControllerDB.GetSpecializationOfDoctor(doc))
            {
                isChange = true;
                ControllerDB.UpdateData(doc, "IDSpec", ControllerDB.GetSpecializationID(specialization), "ID", doc.ID);
            }
            if(idPass != doc.IDPassport)
            {
                isChange = true;
                ControllerDB.UpdateData(doc, "IDPassport", idPass, "ID", doc.ID);
            }
            if(login != (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Username)
            {
                isChange = true;
                ControllerDB.UpdateData(loginDoc, "Username", login, "ID", loginDoc.ID);

            }
            if (Sha256.ToSHA256(pass) != (ControllerDB.GetTable("Accounts", "ID", doc.ID) as Accounts).Password)
            {
                isChange = true;
                ControllerDB.UpdateData(loginDoc, "Password", Sha256.ToSHA256(pass), "ID", loginDoc.ID);
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
        private void _DrawContexts()
        {
            ContextPosition.Width += 5f;
            ContextSpecialization.Width += 5f;
            ContexSex.Width += 5f;
            //Positions
            foreach(var table in ControllerDB.Tables)
            {
                if(table is RankGroups)
                {
                    Border border = new Border
                    {
                        Style = (Style)FindResource("ValueBorder"),
                        Tag = table as RankGroups,
                        Margin = new Thickness(0, 1, 0, 1)
                    };
                    border.MouseDown += SelectPosition;
                    TextBox textBox = new TextBox
                    {
                        Style = (Style)FindResource("ValueTextBox"),
                        IsReadOnly = true,
                        Focusable = false,
                        Cursor = Cursors.Arrow,
                        Text = (table as RankGroups).Name
                    };
                    border.Child = textBox;
                    StackPanelPositionValues.Children.Add(border);
                }
            }
            //Specializations
            foreach (var table in ControllerDB.Tables)
            {
                if (table is Specialization)
                {
                    Border border = new Border
                    {
                        Style = (Style)FindResource("ValueBorder"),
                        Tag = table as Specialization,
                        Margin = new Thickness(0, 1, 0, 1)
                    };
                    border.MouseDown += SelectSpecialization;

                    TextBox textBox = new TextBox
                    {
                        Style = (Style)FindResource("ValueTextBox"),
                        IsReadOnly = true,
                        Focusable = false,
                        Cursor = Cursors.Arrow,
                        FontSize = 12,
                        Text = (table as Specialization).Name
                    };
                    border.Child = textBox;
                    StackPanelSpecializationValues.Children.Add(border);
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
            //Shedule
            Border sheduleBorder1 = new Border
            {
                Style = (Style)FindResource("ValueBorder"),
                Margin = new Thickness(0, 1, 0, 1),
                Tag = "Пн 7:30-12:30, Вт 12:30-17:30..."
            };
            TextBox sheduleTextBox1 = new TextBox
            {
                Style = (Style)FindResource("ValueTextBox"),
                IsReadOnly = true,
                Focusable = false,
                Cursor = Cursors.Arrow,
                FontSize = 12,
                Text = "Пн 7:30-12:30, Вт 12:30-17:30..."
            };
            sheduleBorder1.Child = sheduleTextBox1;
            Border sheduleBorder2 = new Border
            {
                Style = (Style)FindResource("ValueBorder"),
                Margin = new Thickness(0, 1, 0, 1),
                Tag = "Пн 12:30-17:30, Вт 7:30-12:30..."
            };
            TextBox sheduleTextBox2 = new TextBox
            {
                Style = (Style)FindResource("ValueTextBox"),
                IsReadOnly = true,
                Focusable = false,
                Cursor = Cursors.Arrow,
                FontSize = 12,
                Text = "Пн 12:30-17:30, Вт 7:30-12:30..."
            };
            sheduleBorder2.Child = sheduleTextBox2;
            sheduleBorder1.MouseDown += SelectShedule;
            sheduleBorder2.MouseDown += SelectShedule;
            StackPanelSheduleValues.Children.Add(sheduleBorder1);
            StackPanelSheduleValues.Children.Add(sheduleBorder2);
        }
    }
}

