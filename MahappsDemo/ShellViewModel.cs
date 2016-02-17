using Caliburn.Micro;
using System;

namespace MahappsDemo
{
    public class ShellViewModel : Conductor<Object>.Collection.OneActive
    {   
        public ShellViewModel(PageOneViewModel pageOne, PageTwoViewModel pageTwo)
        {
            Items.Add(pageOne);
            Items.Add(pageTwo);
            DisplayName = "Mahapps Demo";
        }
    }
}
