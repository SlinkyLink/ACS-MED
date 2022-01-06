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
    public partial class HelpsPage : Page
    {
        public double scrollW, scrollH;
        public ASUDBController ControllerDB { get; set; }
        public HelpsPage()
        {
            InitializeComponent();
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            string line;
            string text = "";
            try
            {
                StreamReader sr = new StreamReader("INFO/HELP");
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
            TextBoxContent.Text = text;
            LabelFSName.Content = ControllerDB.LogDoctor.Username;
        }
    }
}
