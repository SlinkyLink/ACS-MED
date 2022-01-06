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
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using ASUMED.Controller;


namespace ASUMED.Control
{
    public partial class DBControl : Window
    {
        public ASUDBController ControllerDB { get; set; }
        public TPage tpage;
        public EMode EMode;
        public DBControl()
        {
            InitializeComponent();
        }
        private void WindowMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void CloseWin(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = ElementsGrid.Children.Count - 1; i >= 0; i--)
            {
                var elem = ElementsGrid.Children[i];
                if (elem is not Frame)
                {
                    ElementsGrid.Children.RemoveAt(i);
                }
            }
            _AddBorderValVar();
        }
        private void _AddBorderValVar()
        {
            switch (tpage)
            {
                case TPage.Doctors:
                    WindowContent.Content = new DoctorExePage
                    {
                        ControllerDB = this.ControllerDB,
                        EMode = this.EMode
                    };
                    break;
                case TPage.Patients:
                    WindowContent.Content = new ClientExePage
                    {
                        ControllerDB = this.ControllerDB,
                        EMode = this.EMode
                    };
                    break;
                case TPage.Procedures:
                    WindowContent.Content = new ProcedureExePage
                    {
                        ControllerDB = this.ControllerDB,
                        EMode= this.EMode
                    };
                    break;
                case TPage.Pills:
                    WindowContent.Content = new PillsExePage
                    {
                        ControllerDB = this.ControllerDB,
                        EMode = this.EMode
                    };
                    break;
                default:
                    break;
            }
        }

        private void WindowClick(object sender, MouseButtonEventArgs e)
        {
            if(WindowContent.Content is DoctorExePage)
            {
                (WindowContent.Content as DoctorExePage).ContextPosition.Visibility = Visibility.Hidden;
                (WindowContent.Content as DoctorExePage).ContextSpecialization.Visibility = Visibility.Hidden;
                (WindowContent.Content as DoctorExePage).ContextShedule.Visibility = Visibility.Hidden;
                (WindowContent.Content as DoctorExePage).ContexSex.Visibility = Visibility.Hidden;
            }
        }
    }
}
