using Caliburn.Micro;
using System.Windows;

namespace MahappsDemo.ViewModel
{
    public class BubblingViewModel : BaseTabViewModel
    {
        public BindableCollection<Model> Items { get; private set; }

        public BubblingViewModel()
        {
            Items = new BindableCollection<Model> { new Model("E"), new Model("A"), new Model("D")};
            DisplayName = "Bubbling";
        }

        public void Fretted(Model fret)
        {
            MessageBox.Show(string.Format("Just fretted {0}", fret.Id));
        }
    }

    public class Model
    {
        public string Id { get; set; }

        public Model(string id)
        {
            Id = id;
        }
    }
}
