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

namespace ASUMED
{
    public partial class PillsPage : Page
    {
        private TPage _page;
        public ASUDBController ControllerDB { get; set; }
        public ERank ERank;
        public double scrollW, scrollH;

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            _page = TPage.Pills;
        }

        public PillsPage()
        {
            InitializeComponent();
        }
    }
}
