using Caliburn.Micro;
using System;

namespace MahappsDemo
{
    public class ShellViewModel : Conductor<Object>.Collection.OneActive
    {
        public ShellViewModel()
        {
            DisplayName = "MAHAPPS DEMO";

            var pageOne = new PageOneViewModel();
            var pageTwo = new PageTwoViewModel();

            Items.Add(pageOne);
            Items.Add(pageTwo);
        }
    }
}
