﻿using Caliburn.Micro;
using System.Windows;

namespace MahappsDemo
{
    public class PageTwoViewModel : PropertyChangedBase
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
                NotifyOfPropertyChange(() => CanSayHello);
            }
        }

        public bool CanSayHello
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }

        public void SayHello()
        {
            MessageBox.Show(string.Format("Bonjour {0}", Name));
        }
    }
}
