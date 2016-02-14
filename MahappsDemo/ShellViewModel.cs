using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MahappsDemo
{
    public class ShellViewModel : Conductor<Object>
    {
        public ShellViewModel()
        {
            ShowPageOne();
        }

        public void ShowPageOne()
        {
            ActivateItem(new PageOneViewModel());
        }

        public void ShowPageTwo()
        {
            ActivateItem(new PageTwoViewModel());
        }
    }
}
