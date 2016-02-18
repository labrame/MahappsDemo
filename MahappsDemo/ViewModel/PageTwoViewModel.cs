using System.Windows;

namespace MahappsDemo.ViewModel
{
    public class PageTwoViewModel : BaseTabViewModel
    {
        string _name;

        public PageTwoViewModel()
        {
            DisplayName = "Page two";
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
            MessageBox.Show(string.Format("Bonjour {0}", Name));
        }
    }
}
