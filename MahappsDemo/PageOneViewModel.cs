using Caliburn.Micro;
using System.Windows;

namespace MahappsDemo
{
    public class PageOneViewModel : BaseTabViewModel
    {
        string _name;

        public PageOneViewModel()
        {
            DisplayName = "Page one";
        }

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
            MessageBox.Show(string.Format("Hello {0}", Name));
        }
    }
}
