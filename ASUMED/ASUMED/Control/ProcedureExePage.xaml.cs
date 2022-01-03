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

namespace ASUMED.Control
{
    /// <summary>
    /// Логика взаимодействия для ProcedureExePage.xaml
    /// </summary>
    public partial class ProcedureExePage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        public EMode EMode { get; set; }

        private Grid _contextDoctor, _contextPatient, _contextProcedure;
        public ProcedureExePage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (EMode == EMode.Add)
                (ExeBorder.Child as Label).Content = "Додати";
            else if (EMode == EMode.Update)
            {
                (ExeBorder.Child as Label).Content = "Оновити";
            }
            TextBoxProcedureValue.Text = (ControllerDB.activeTable as Procedures).Name;
            _DrawContexts();
        }
        private void CallContext(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border == null) return;
            if((string)border.Tag == "Procedure")
            {
                if(ContextDoctor != null)
                    ContextDoctor.Visibility = Visibility.Hidden;
                if(ContextPatient != null)
                    ContextPatient.Visibility = Visibility.Hidden;

                if (ContextProcedure != null)
                {
                    if (ContextProcedure.Visibility == Visibility.Visible)
                        ContextProcedure.Visibility = Visibility.Hidden;
                    else
                        ContextProcedure.Visibility = Visibility.Visible;
                }  
            }
            else if ((string)border.Tag == "Patient")
            {
                if (ContextDoctor != null)
                    ContextDoctor.Visibility = Visibility.Hidden;
                if (ContextProcedure != null)
                    ContextProcedure.Visibility = Visibility.Hidden;

                if (ContextPatient != null)
                {
                    if (ContextPatient.Visibility == Visibility.Visible)
                        ContextPatient.Visibility = Visibility.Hidden;
                    else
                        ContextPatient.Visibility = Visibility.Visible;
                }
            }
            else if ((string)border.Tag == "Doctor")
            {
                if (ContextPatient != null)
                    ContextPatient.Visibility = Visibility.Hidden;
                if (ContextProcedure != null)
                    ContextProcedure.Visibility = Visibility.Hidden;
                if (ContextDoctor != null)
                {
                    if (ContextDoctor.Visibility == Visibility.Visible)
                        ContextDoctor.Visibility = Visibility.Hidden;
                    else
                        ContextDoctor.Visibility = Visibility.Visible;
                }
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
        private void ExecuteBtn(object sender, MouseButtonEventArgs e)
        {
            for(int i  = ValuesStackPanel.Children.Count - 1; i >= 0; i--)
            {
                if(ValuesStackPanel.Children[i] is Border bor)
                {
                    if(bor.Child is TextBox txtBox)
                    {
                        if (txtBox.Text == "") return;
                    }
                }

            }
            Doctors doctor = ControllerDB.GetTable("Doctors", "Username", TextBoxDoctorValue.Text) as Doctors;
            Clients clients = ControllerDB.GetTable("Clients", "Username", TextBoxPatientValue.Text) as Clients;
            Procedures procedure = ControllerDB.GetTable("Procedures", "Name", TextBoxProcedureValue.Text) as Procedures;
            string time = TextBoxTimeValue.Text;
            if (EMode == EMode.Add)
            {
                ControllerDB.AddData(new ProcedClients
                {
                    ClientID = clients.ID,
                    DocID = doctor.ID,
                    ProcedureID = procedure.ID,
                    Time = time
                });
                for (int i = ValuesStackPanel.Children.Count - 1; i >= 0; i--)
                {
                    if (ValuesStackPanel.Children[i] is Border bor)
                    {
                        if (i > 0)
                        {
                            if (bor.Child is TextBox txtBox)
                            {
                                txtBox.Text = "";
                            }
                        }
                    }
                }
            }
            else if(EMode == EMode.Update)
            {
                ControllerDB.UpdateProcedure(procedure.ID, clients.ID, doctor.ID, time);
                CloseWin(null, null);
            }
        }
        private void SelectContexItem(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if(border.Tag is Doctors doc)
            {
                TextBoxDoctorValue.Text = doc.Username;
            }
            else if (border.Tag is Clients client)
            {
                TextBoxPatientValue.Text = client.Username;
            }
            else if (border.Tag is Procedures procedure)
            {
                TextBoxProcedureValue.Text = procedure.Name;
            }

            if(ContextDoctor != null)
                ContextDoctor.Visibility = Visibility.Hidden;
            if(ContextPatient != null)
                ContextPatient.Visibility = Visibility.Hidden;
            if(ContextProcedure != null)
                ContextProcedure.Visibility = Visibility.Hidden;

            if(EMode == EMode.Update)
            {
                if((sender as Border).Tag is Clients)
                {
                    ContextDoctor = _contextDoctor;
                    foreach (var list in ControllerDB.GetAboutProcedure(ControllerDB.activeTable as Procedures))
                    {
                        List<DBTable> tab = null;
                        foreach (var table in list)
                        {
                            if (table is Clients client)
                            {
                                if (TextBoxPatientValue.Text == client.Username)
                                {
                                    tab = list;
                                    break;
                                }
                            }
                        }
                        if(tab != null)
                        {
                            foreach(var table in tab)
                            {
                                if(table is Doctors doctor)
                                {
                                    TextBoxDoctorValue.Text = doctor.Username;
                                }
                                if(table is ProcedClients proc)
                                {
                                    TextBoxTimeValue.Text = proc.Time;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void _DrawContexts()
        {
            if (EMode == EMode.Add)
            {
                foreach (var table in ControllerDB.Tables)
                {
                    //Add doctors
                    if (table is Doctors doc)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("ValueBorder"),
                            Margin = new Thickness(0, 1, 0, 1),
                            Tag = doc
                        };
                        TextBox textbox = new TextBox
                        {
                            Style = (Style)FindResource("ValueTextBox"),
                            IsReadOnly = true,
                            Focusable = false,
                            Cursor = Cursors.Arrow,
                            FontSize = 12,
                            Text = doc.Username
                        };
                        border.Child = textbox;
                        border.MouseDown += SelectContexItem;
                        StackPanelDoctorValues.Children.Add(border);
                        continue;
                    }
                    //Add patients
                    if (table is Clients client)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("ValueBorder"),
                            Margin = new Thickness(0, 1, 0, 1),
                            Tag = client
                        };
                        TextBox textbox = new TextBox
                        {
                            Style = (Style)FindResource("ValueTextBox"),
                            IsReadOnly = true,
                            Focusable = false,
                            Cursor = Cursors.Arrow,
                            FontSize = 12,
                            Text = client.Username
                        };
                        border.Child = textbox;
                        border.MouseDown += SelectContexItem;
                        StackPanelPatientValue.Children.Add(border);
                        continue;
                    }
                    //Add procedure
                    if (table is Procedures procedure)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("ValueBorder"),
                            Margin = new Thickness(0, 1, 0, 1),
                            Tag = procedure
                        };
                        TextBox textbox = new TextBox
                        {
                            Style = (Style)FindResource("ValueTextBox"),
                            IsReadOnly = true,
                            Focusable = false,
                            Cursor = Cursors.Arrow,
                            FontSize = 12,
                            Text = procedure.Name
                        };
                        border.Child = textbox;
                        border.MouseDown += SelectContexItem;
                        StackPanelProcedureValue.Children.Add(border);
                        continue;
                    }
                }
            }
            else if (EMode == EMode.Update)
            {
                foreach (var list in ControllerDB.GetAboutProcedure(ControllerDB.activeTable as Procedures))
                {
                    foreach (var table in list)
                    {
                        if (table is Clients client)
                        {
                            Border border = new Border
                            {
                                Style = (Style)FindResource("ValueBorder"),
                                Margin = new Thickness(0, 1, 0, 1),
                                Tag = client
                            };
                            TextBox textbox = new TextBox
                            {
                                Style = (Style)FindResource("ValueTextBox"),
                                IsReadOnly = true,
                                Focusable = false,
                                Cursor = Cursors.Arrow,
                                FontSize = 12,
                                Text = client.Username
                            };
                            border.Child = textbox;
                            border.MouseDown += SelectContexItem;
                            StackPanelPatientValue.Children.Add(border);
                            continue;
                        }
                    }
                }
                foreach (var table in ControllerDB.Tables)
                {
                    if (table is Doctors doc)
                    {
                        Border border = new Border
                        {
                            Style = (Style)FindResource("ValueBorder"),
                            Margin = new Thickness(0, 1, 0, 1),
                            Tag = doc
                        };
                        TextBox textbox = new TextBox
                        {
                            Style = (Style)FindResource("ValueTextBox"),
                            IsReadOnly = true,
                            Focusable = false,
                            Cursor = Cursors.Arrow,
                            FontSize = 12,
                            Text = doc.Username
                        };
                        border.Child = textbox;
                        border.MouseDown += SelectContexItem;
                        StackPanelDoctorValues.Children.Add(border);
                        continue;
                    }
                }
                _contextProcedure = ContextProcedure;
                _contextDoctor = ContextDoctor;
                ContextProcedure = null;
                ContextDoctor = null;
                TextBoxTimeValue.IsReadOnly = true;
            }
        }
    }
}
