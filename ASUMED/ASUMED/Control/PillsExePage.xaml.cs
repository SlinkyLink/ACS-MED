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
    /// <summary>
    /// Логика взаимодействия для PillsExePage.xaml
    /// </summary>
    public partial class PillsExePage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        public EMode EMode { get; set; }

        private Grid _contextNamePill;
        public PillsExePage()
        {
            InitializeComponent();
        }
        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            if (EMode == EMode.Update)
            {
                (BorderExe.Child as Label).Content = "Прописати";
                BorderExe.MouseDown += BtnExeDown;
                if (TextBoxNamePillValue != null)
                    TextBoxNamePillValue.Text = (ControllerDB.activeTable as Pills).Name;
                TextBoxTypePillValue.Text = (ControllerDB.GetTypeOfPill(ControllerDB.activeTable as Pills)).Name;
                _DrawNameContext(ControllerDB.GetTypeOfPill(ControllerDB.activeTable as Pills));
                _contextNamePill = ContextNamePill;
                ContextNamePill = null;
                ContextTypePill = null;
            }

            else if (EMode == EMode.Add || EMode == EMode.AddPill)
            {
                (BorderExe.Child as Label).Content = "Добавити на склад";
                BorderExe.MouseDown += BtnExeDown;
                if (LabelVaribles.Children.Count == TextBoxValues.Children.Count)
                {
                    for (int i = TextBoxValues.Children.Count - 1; i >= 0; i--)
                    {
                        if(TextBoxValues.Children[i] is Border bor)
                        {
                            if(bor.Name == "BorderPatient")
                            {
                                TextBoxValues.Children.RemoveAt(i);
                            }
                        }
                        if(LabelVaribles.Children[i] is Label label)
                        {
                            if (label.Name == "LabelPatient")
                            {
                                LabelVaribles.Children.RemoveAt(i);
                            }
                        }
                    }
                }
                if(EMode == EMode.Add)
                {
                    ContextNamePill = null;
                    ContextTypePill = null;
                    if (TextBoxNamePillValue != null)
                        TextBoxNamePillValue.Text = (ControllerDB.activeTable as Pills).Name;
                    TextBoxTypePillValue.Text = (ControllerDB.GetTypeOfPill(ControllerDB.activeTable as Pills)).Name;
                    _DrawNameContext(ControllerDB.GetTypeOfPill(ControllerDB.activeTable as Pills));
                    _contextNamePill = ContextNamePill;
                }
                else if(EMode == EMode.AddPill)
                {
                    TextBoxNamePillValue.Focusable = true;
                    TextBoxNamePillValue.IsReadOnly = false;
                    TextBoxNamePillValue.Cursor = Cursors.IBeam;
                }
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
        private void CallContext(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border == null) return;
            if ((string)border.Tag == "Type")
            {
                if (ContextNamePatient != null)
                    ContextNamePatient.Visibility = Visibility.Hidden;
                if (ContextNamePill != null)
                    ContextNamePill.Visibility = Visibility.Hidden;

                if (ContextTypePill != null)
                {
                    if (ContextTypePill.Visibility == Visibility.Visible)
                        ContextTypePill.Visibility = Visibility.Hidden;
                    else
                        ContextTypePill.Visibility = Visibility.Visible;
                }
            }
            else if ((string)border.Tag == "Name")
            {
                if (ContextNamePatient != null)
                    ContextNamePatient.Visibility = Visibility.Hidden;
                if (ContextTypePill != null)
                    ContextTypePill.Visibility = Visibility.Hidden;

                if (ContextNamePill != null)
                {
                    if (ContextNamePill.Visibility == Visibility.Visible)
                        ContextNamePill.Visibility = Visibility.Hidden;
                    else
                        ContextNamePill.Visibility = Visibility.Visible;
                }
            }
            else if ((string)border.Tag == "Patient")
            {
                if (ContextNamePill != null)
                    ContextNamePill.Visibility = Visibility.Hidden;
                if (ContextTypePill != null)
                    ContextTypePill.Visibility = Visibility.Hidden;
                if (ContextNamePatient != null)
                {
                    if (ContextNamePatient.Visibility == Visibility.Visible)
                        ContextNamePatient.Visibility = Visibility.Hidden;
                    else
                        ContextNamePatient.Visibility = Visibility.Visible;
                }
            }
        }
        private void SelectContexItem(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border == null) return;

            if(border.Tag is PillType pt)
            {
                TextBoxTypePillValue.Text = pt.Name;
                ContextTypePill.Visibility = Visibility.Hidden;
                if(StackPanelNameValues.Children.Count > 0)
                {
                    for(int i = StackPanelNameValues.Children.Count - 1; i >= 0; i--)
                    {
                        StackPanelNameValues.Children.RemoveAt(i);
                    }
                }
                if (TextBoxNamePillValue.Text.Length > 0) TextBoxNamePillValue.Text = "";

                _DrawNameContext(pt);
            }
            else if(border.Tag is Clients client)
            {
                TextBoxNamePatientValue.Text = client.Username;
                ContextNamePatient.Visibility = Visibility.Hidden;
            }
            else if(border.Tag is Pills pill)
            {
                TextBoxNamePillValue.Text = pill.Name;
                ContextNamePill.Visibility = Visibility.Hidden;
            }
        }
        private void BtnExeDown(object sender, MouseButtonEventArgs e)
        {
            for (int i = TextBoxValues.Children.Count - 1; i >= 0; i--)
            {
                if (TextBoxValues.Children[i] is Border border)
                {
                    if (border.Child is TextBox txtBox)
                    {
                        if (txtBox.Text.Length == 0) return;
                    }
                }
            }
            if (EMode == EMode.Add)
            {
                _UpdatePill();
            }
            else if(EMode == EMode.AddPill)
            {
                _AddNewPill();
            }
            else if(EMode == EMode.Update)
            {
                _AddClient();
            }
            ControllerDB.Update();
            foreach (Window window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    var controlWindow = (ControlWindow)window;
                    (controlWindow.WindowContent.Content as PillsPage).Update();
                    return;
                }
            }
        }
        private void DBControl_IntTextPreview(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void _AddClient()
        {
            Clients client = ControllerDB.GetTable(typeof(Clients).Name, "Username", TextBoxNamePatientValue.Text) as Clients;
            Pills pill = ControllerDB.GetTable(typeof(Pills).Name, "Name", TextBoxNamePillValue.Text) as Pills;
            if (pill.Amount < Convert.ToInt32(TextBoxAmountValue.Text))
            {
                MessageBox.Show("Недостатньо ліків");
                return;
            }

            ControllerDB.AddData(new ClientPills
            {
                ClientID = client.ID,
                PillID = pill.ID,
                Amount = Convert.ToInt32(TextBoxAmountValue.Text)
            });
            
            ControllerDB.UpdateData(pill, "Amount", pill.Amount - Convert.ToInt32(TextBoxAmountValue.Text) , "ID", pill.ID);
            TextBoxNamePatientValue.Text = "";
            TextBoxAmountValue.Text = "";
        }
        private void _AddNewPill()
        {

            ControllerDB.AddData(new Pills
            {
                ID = ControllerDB.GenerateID(typeof(Pills).Name),
                Name = TextBoxNamePillValue.Text,
                Amount = Convert.ToInt32(TextBoxAmountValue.Text),
                TypeID = (ControllerDB.GetTable(typeof(PillType).Name, "Name", TextBoxTypePillValue.Text) as PillType).ID
            });
            TextBoxNamePillValue.Text = "";
            TextBoxAmountValue.Text = "";
        }
        private void _UpdatePill()
        {
            Pills pill = ControllerDB.GetTable(typeof(Pills).Name, "Name", TextBoxNamePillValue.Text) as Pills;
            ControllerDB.UpdateData(pill , "Amount", Convert.ToInt32(TextBoxAmountValue.Text) + pill.Amount, "ID", pill.ID);
            TextBoxAmountValue.Text = "";
        }
        private void _DrawContext()
        {
            foreach(var table in ControllerDB.Tables)
            {
                if(table is PillType pt)
                {
                    Border border = new Border
                    {
                        Style = (Style)FindResource("ValueBorder"),
                        Margin = new Thickness(0, 1, 0, 1),
                        Tag = pt
                    };
                    TextBox textbox = new TextBox
                    {
                        Style = (Style)FindResource("ValueTextBox"),
                        IsReadOnly = true,
                        Focusable = false,
                        Cursor = Cursors.Arrow,
                        FontSize = 12,
                        Text = pt.Name
                    };
                    border.Child = textbox;
                    border.MouseDown += SelectContexItem;
                    StackPanelTypeValues.Children.Add(border);
                    continue;
                }
                if (BorderPatient != null)
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
                        StackPanelNamePatientValues.Children.Add(border);
                        continue;
                    }
                }
            }
        }
        private void _DrawNameContext(PillType pillType)
        {
            foreach (var pill in ControllerDB.GetPills(pillType))
            {
                Border border = new Border
                {
                    Style = (Style)FindResource("ValueBorder"),
                    Margin = new Thickness(0, 1, 0, 1),
                    Tag = pill
                };
                TextBox textbox = new TextBox
                {
                    Style = (Style)FindResource("ValueTextBox"),
                    IsReadOnly = true,
                    Focusable = false,
                    Cursor = Cursors.Arrow,
                    FontSize = 12,
                    Text = pill.Name
                };
                border.Child = textbox;
                border.MouseDown += SelectContexItem;
                StackPanelNameValues.Children.Add(border);
                continue;
            }
            if (StackPanelNameValues.Children.Count == 0) ContextNamePill = null;
            else ContextNamePill = _contextNamePill;
        } 
    }
}
