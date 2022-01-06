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
using System.Windows.Navigation;
using ASUMED.Controller;
using System.IO;

namespace ASUMED
{
    public partial class ControlWindow : Window, IWindowASU
    {
        public ASUDBController ControllerDB;
        public ERank ERank;
        private TPage _page;
        private double offsizeW, offsizeH;
        bool ResizeInProcess = false;
        public ControlWindow()
#pragma warning restore CS8618 // поле "ControllerDB", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающий значения NULL.
        {
            InitializeComponent();
            offsizeW = 20f;
            offsizeH = 50f;
        }
        public void WindowMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        public void CloseWindow(object sender, MouseButtonEventArgs e)
        {
            FileInfo fileInfo = new FileInfo("asu.db");
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo("Backup/asu.db", true);
            }
            ControllerDB.DBClose();
           foreach(var window in Application.Current.Windows)
            {
                (window as Window).Close();
            }
        }
        public void NormMaxWindow(object sender, MouseButtonEventArgs e)
        {
            if(this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
            else if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
            _ResizePages();
        }
        private void WindowNormMaxDoubleCLick(object sender, MouseButtonEventArgs e)
                {
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        if (e.ClickCount == 2)
                        {
                            if (this.WindowState == WindowState.Normal) this.WindowState = WindowState.Maximized;
                            else if (this.WindowState == WindowState.Maximized) this.WindowState = WindowState.Normal;
                            _ResizePages();
                        }
                    }
                }
        public void MinimizedWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        public void ChangePage(object sender, MouseButtonEventArgs e)
        {
            _page = (TPage)((Border)sender).Tag;
            double scrollW = 120f, scrollH = 120f;
            if (Height > 120f)
                scrollH = Height - 120f;
            if (Width > 120f)
                scrollW = Height - 120f;
            switch (_page)
            {
                case TPage.Doctors:
                    WindowContent.Content = new DoctorsPage()
                    {
                        scrollW = scrollW,
                        scrollH = scrollH,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW,
                        ControllerDB = this.ControllerDB,
                        ERank = this.ERank
                    };
                    break;
                case TPage.Patients:
                    WindowContent.Content = new PatientsPage()
                    {
                        scrollH = scrollH,
                        scrollW = scrollW,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW,
                        ControllerDB = this.ControllerDB,
                        ERank = this.ERank
                    };
                    break;
                case TPage.Procedures:
                    WindowContent.Content = new ProceduresPage()
                    {
                        scrollH = scrollH,
                        scrollW = scrollW,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW,
                        ControllerDB = this.ControllerDB,
                        ERank = this.ERank
                    };
                    break;
                case TPage.Pills:
                    WindowContent.Content = new PillsPage()
                    {
                        scrollH = scrollH,
                        scrollW = scrollW,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW,
                        ControllerDB = this.ControllerDB,
                        ERank = this.ERank
                    };
                    break;
                case TPage.Help:
                    WindowContent.Content = new HelpsPage()
                    {
                        scrollH = scrollH,
                        scrollW = scrollW,
                        ControllerDB = this.ControllerDB,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW,
                    };
                    break;
                case TPage.Configuration:
                    break;
                case TPage.About:
                    WindowContent.Content = new AboutPage
                    {
                        scrollH = scrollH,
                        scrollW = scrollW,
                        ControllerDB = this.ControllerDB,
                        MaxHeight = Height - offsizeH,
                        MaxWidth = Width - offsizeW
                    };
                    break;
                default:
                    break;
            }
            foreach(var page in PagesB.Children)
            {
                if(page is Border && sender is Border)
                {
                    Border border = (Border)page;
                    Border clickBorder = (Border)sender; 
                   if(border.Tag == clickBorder.Tag)
                   {
                        var brush = new BrushConverter();
                        border.Background = (Brush)brush.ConvertFrom("#FF29C8FF");
                    }
                   else
                {
                    var brush = new BrushConverter();
                    border.Background = (Brush)brush.ConvertFrom("#FFC8F0FF");
                }
                }
            }
        }
        private void MouseNormalOutMax(object sender, MouseEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                if (WindowState == WindowState.Maximized)
                {
                    this.Width = this.ActualWidth;
                    this.Height = this.ActualHeight;
                    this.Left = 0;
                    this.Top = 0;
                    this.WindowStartupLocation = WindowStartupLocation.Manual;
                    this.WindowState = WindowState.Normal;
                    this.DragMove();
                    _ResizePages();
                }
            }
        }
        private void Resize_Init(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized) return;
            Rectangle senderRect = sender as Rectangle;
            if (senderRect != null)
            {
                ResizeInProcess = true;
                senderRect.CaptureMouse();
            }
        }
        private void Resize_End(object sender, MouseButtonEventArgs e)
        {
            Rectangle senderRect = sender as Rectangle;
            if (senderRect != null)
            {
                ResizeInProcess = false; ;
                senderRect.ReleaseMouseCapture();
            }
        }
        private void Resizeing_Form(object sender, MouseEventArgs e)
        {
            if (ResizeInProcess)
            {
                Rectangle senderRect = sender as Rectangle;
                Window mainWindow = senderRect.Tag as Window;
                if (senderRect != null)
                {
                    double width = e.GetPosition(mainWindow).X;
                    double height = e.GetPosition(mainWindow).Y;
                    senderRect.CaptureMouse();
                    if (senderRect.Name.ToLower().Contains("right"))
                    {
                        width += 5;
                        if (width > 0)
                            mainWindow.Width = width;
                    }
                    if (senderRect.Name.ToLower().Contains("left"))
                    {
                        width -= 5;
                        mainWindow.Left += width;
                        width = mainWindow.Width - width;
                        if (width > 0)
                        {
                            mainWindow.Width = width;
                        }
                    }
                    if (senderRect.Name.ToLower().Contains("bottom"))
                    {
                        height += 5;
                        if (height > 0)
                            mainWindow.Height = height;
                    }
                    if (senderRect.Name.ToLower().Contains("top"))
                    {
                        height -= 5;
                        mainWindow.Top += height;
                        height = mainWindow.Height - height;
                        if (height > 0)
                        {
                            mainWindow.Height = height;
                        }
                    }
                    _ResizePages();
                }
            }
        }
        private void _ResizePages()
        {
            if (this.Height <= this.MinHeight) Height = MinHeight;
            if(this.Width <= this.MinWidth) Width = MinWidth;
            if (WindowContent.Content != null)
            {
                (WindowContent.Content as Page).MinWidth = Width - offsizeW;
                (WindowContent.Content as Page).MinHeight = Height - offsizeH;
                (WindowContent.Content as Page).MaxHeight = Height - offsizeH;
                (WindowContent.Content as Page).MaxWidth = Width - offsizeW;
                if (WindowContent.Content is DoctorsPage)
                {
                    var doctorPage = (DoctorsPage)WindowContent.Content;
                    if (Height > 110f)
                        doctorPage.ScrollViewerList.MaxHeight = Height - 110f;
                }
                if (WindowContent.Content is PatientsPage)
                {
                    var patientsPage = (PatientsPage)WindowContent.Content;
                    if (Height > 110f)
                        patientsPage.ScrollViewerList.MaxHeight = Height - 110f;
                }
                if (WindowContent.Content is ProceduresPage)
                {
                    var patientsPage = (ProceduresPage)WindowContent.Content;
                    if (Height > 110f)
                        patientsPage.ScrollViewerList.MaxHeight = Height - 110f;
                }
                if (WindowContent.Content is PillsPage)
                {
                    var patientsPage = (PillsPage)WindowContent.Content;
                    if (Height > 110f)
                        patientsPage.ScrollViewerList.MaxHeight = Height - 110f;
                }
            }
        }
    }
    public enum TPage
    {
        Doctors,
        Patients,
        Procedures,
        Pills,
        Help,
        Configuration,
        About
    }
    public enum EMode
    {
        Add,
        Update,
        AddPill
    }
    public enum EReference
    {
        LICENCE,
        DEVELOPERS,
        HELP
    }
    public enum ERank
    {
       Doctor,
       ChiefDoctor
    }
}
