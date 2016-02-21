using Caliburn.Micro;
using MahappsDemo.ViewModel;
using System;

namespace MahappsDemo
{
    public class ShellViewModel : Conductor<Object>.Collection.OneActive
    {   
        public ShellViewModel(  PageOneViewModel pageOne,
                                PageTwoViewModel pageTwo, 
                                FretBoardViewModel fretBoard, 
                                BubblingViewModel bubbling,
                                FretBoardTwoViewModel fretBoardTwo)
        {
            Items.Add(pageOne);
            Items.Add(pageTwo);
            Items.Add(fretBoard);
            Items.Add(bubbling);
            Items.Add(fretBoardTwo);
            DisplayName = "Mahapps Demo";
        }
    }
}
