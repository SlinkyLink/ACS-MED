using System;
using System.Collections.Generic;
using System.IO;
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


namespace ASUMED
{
    public partial class AboutPage : Page
    {
        public ASUDBController ControllerDB { get; set; }
        private EReference refer;
        public double scrollW, scrollH;
        public AboutPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
            foreach (var window in Application.Current.Windows)
            {
                if (window is ControlWindow)
                {
                    Width = ((ControlWindow)window).Width;
                    Height = ((ControlWindow)window).Height;
                }
            }
        }
        private void BorderReferenceClick(object sender, MouseButtonEventArgs e)
        {
            refer = (EReference)((Border)sender).Tag;
            string path;
            string label;
            switch (refer)
            {
                case EReference.LICENCE:
                    path = "INFO/LICENSE";
                    label = "Ліцензія";
                    break;
                case EReference.DEVELOPERS:
                    path = "INFO/DEVELOPERS";
                    label = "Розробники";
                    break;
                default:
                    return;
            }

            string line;
            string text = "";
            try
            {
                StreamReader sr = new StreamReader(path);
                line = sr.ReadLine();
                while (line != null)
                {
                    text += line + "\n";
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LabelPageInfo.Content = label;
            _DrawInfo(text);
        }
        private void _DrawInfo(string text)
        {
            TextBoxContent.Text = text;
        }

       
    }
}
