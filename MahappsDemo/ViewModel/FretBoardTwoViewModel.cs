using Caliburn.Micro;
using MahappsDemo.Model;
using System.Windows;
using Enum = MahappsDemo.Model.Enum;

namespace MahappsDemo.ViewModel
{
    public class FretBoardTwoViewModel : BaseTabViewModel
    {
        public readonly string[] _scale;

        public BindableCollection<Fret> EString { get; set; }
        public BindableCollection<Fret> AString { get; set; }
        public BindableCollection<Fret> DString { get; set; }
        public BindableCollection<Fret> GString { get; set; }
        public BindableCollection<Fret> BString { get; set; }
        public BindableCollection<Fret> E2String { get; set; }

        public FretBoardTwoViewModel()
        {
            DisplayName = "Fretboard two";

            EString = CreateString(Enum.Standard.E); 
            AString = CreateString(Enum.Standard.A);
            DString = CreateString(Enum.Standard.D);
            GString = CreateString(Enum.Standard.G);
            BString = CreateString(Enum.Standard.B);
            E2String = CreateString(Enum.Standard.e);

            _scale = new string[] { "A", "A#Bb", "B", "C", "C#Db", "D", "D#Eb", "E", "F", "F#Gb", "G", "G#Ab" };

            IsAnswerVisible = false;
            CreateNewQuestion();
        }

        public void FretString(Fret fret)
        {
            MessageBox.Show(string.Format("Just fretted position {0} on string {1}", 
                fret.Position, fret.StringName));
        }

        private BindableCollection<Fret> CreateString(Enum.Standard stringName)
        {
            var stringModel = new BindableCollection<Fret>();

            for (int i = 0; i < 12; i++)
            {
                stringModel.Add(new Fret() { StringName = stringName, Position = i });
            }

            return stringModel;
        }

        private void CreateNewQuestion()
        {
            Question = "This is the question";
        }

        private string _question;
        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                NotifyOfPropertyChange(() => Question);
            }
        }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                NotifyOfPropertyChange(() => Answer);
            }
        }

        private bool _isAnswerVisible;
        public bool IsAnswerVisible
        {
            get { return _isAnswerVisible; }
            set
            {
                _isAnswerVisible = value;
                NotifyOfPropertyChange(() => IsAnswerVisible);
            }
        }


    }
}
