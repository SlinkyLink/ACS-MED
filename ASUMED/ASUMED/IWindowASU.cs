using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace ASUMED
{
    internal interface IWindowASU
    {
        void WindowMove(object sender, MouseButtonEventArgs e);
        void CloseWindow(object sender, MouseButtonEventArgs e);
        void NormMaxWindow(object sender, MouseButtonEventArgs e);
        void MinimizedWindow(object sender, MouseButtonEventArgs e);
        //void ChangePage(object sender, MouseButtonEventArgs e);
    }
}
