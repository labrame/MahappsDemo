using Caliburn.Micro;
using MahappsDemo.ViewModel;
using System;

namespace MahappsDemo
{
    public class ShellViewModel : Conductor<Object>.Collection.OneActive
    {   
        public ShellViewModel(PageOneViewModel pageOne, PageTwoViewModel pageTwo, FretBoardViewModel fretBoard)
        {
            Items.Add(pageOne);
            Items.Add(pageTwo);
            Items.Add(fretBoard);
            DisplayName = "Mahapps Demo";
        }
    }
}
