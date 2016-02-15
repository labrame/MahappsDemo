using Caliburn.Micro;

namespace MahappsDemo
{
    public class BaseTabViewModel : Screen
    {
        private bool _isEnabled;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value.Equals(_isEnabled)) return;
                _isEnabled = value;
                NotifyOfPropertyChange(() => IsEnabled);
            }
        }
    }
}
