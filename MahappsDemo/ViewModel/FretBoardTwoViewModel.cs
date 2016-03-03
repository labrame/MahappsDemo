using Caliburn.Micro;
using MahappsDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Enum = MahappsDemo.Model.Enum;
using System.Windows;
using MahappsDemo.Repository;

namespace MahappsDemo.ViewModel
{
    public class FretBoardTwoViewModel : BaseTabViewModel
    {
        private const string _statusMessage = "Question {0} or of {1}";

        private readonly List<string> _scale;
        private readonly List<string> _doubleScale;
        private readonly List<string> _string;
        private readonly Random _random;

        private string _requestedString;
        private string _requestedNote;
        private bool _isPositionDisplayed;
        private int _currentQuestion;

        private BindableCollection<Fret> _Estring;
        public BindableCollection<Fret> EString
        {
            get { return _Estring; }
            set
            {
                _Estring = value;
                NotifyOfPropertyChange(() => EString);
            }
        }

        private BindableCollection<Fret> _AString;
        public BindableCollection<Fret> AString
        {
            get { return _AString; }
            set
            {
                _AString = value;
                NotifyOfPropertyChange(() => AString);
            }
        }

        private BindableCollection<Fret> _DString;
        public BindableCollection<Fret> DString
        {
            get { return _DString; }
            set
            {
                _DString = value;
                NotifyOfPropertyChange(() => DString);
            }
        }

        private BindableCollection<Fret> _GString;
        public BindableCollection<Fret> GString
        {
            get { return _GString; }
            set
            {
                _GString = value;
                NotifyOfPropertyChange(() => GString);
            }
        }

        private BindableCollection<Fret> _BString;
        public BindableCollection<Fret> BString
        {
            get { return _BString; }
            set
            {
                _BString = value;
                NotifyOfPropertyChange(() => BString);
            }
        }

        private BindableCollection<Fret> _E2String;
        public BindableCollection<Fret> E2String
        {
            get { return _E2String; }
            set
            {
                _E2String = value;
                NotifyOfPropertyChange(() => E2String);
            }
        }

        private Test Test { get; set; }

        public string TestName { get; set; }

        public int NumberOfQuestion { get; set; }

        private bool _isCreateNewTestEnabled;
        public bool IsCreateNewTestEnabled
        {
            get { return _isCreateNewTestEnabled; }
            set
            {
                _isCreateNewTestEnabled = value;
                NotifyOfPropertyChange(() => IsCreateNewTestEnabled);
            }
        }

        public FretBoardTwoViewModel()
        {
            DisplayName = "Fretboard two";

            _scale = new List<string> { "A", "A#Bb", "B", "C", "C#Db", "D", "D#Eb", "E", "F", "F#Gb", "G", "G#Ab" };
            _string = new List<string> { "E", "A", "D", "G", "B", "e" };
            _random = new Random();

            //To be sure to always have the result is the list create a double scale
            _doubleScale = new List<string>();
            _doubleScale.AddRange(_scale);
            _doubleScale.AddRange(_scale);
            
            IsAnswerVisible = Visibility.Hidden;
            IsNextQuestionButtonVisible = false;
            CreateNewQuestion();

            _isPositionDisplayed = true;
            CreateAllString();

            EnableCreateTest(true);
        }

        public void CreateNewTest()
        {
            using (var db = new TestContext())
            {
                var test = new Test() { DateAdded = DateTime.Now, Name = TestName};
                db.Tests.Add(test);
                db.SaveChanges();

                //retrieve test
                Test = test;

                EnableCreateTest(false);
            }
        }

        private string _testStageDescription;
        public string TestStageDescription
        {
            get { return _testStageDescription; }
            set
            {
                _testStageDescription = value;
                NotifyOfPropertyChange(() => TestStageDescription);
            }
        }

        public void FretString(Fret fret)
        {
            var isCorrectAnswer = ValidateAnswer(fret);
            CreateAnswer(isCorrectAnswer);
        }

        public void DisplayNextQuestion()
        {
            IsAnswerVisible = Visibility.Hidden;
            CreateNewQuestion();
        }

        public void DisplayPositionOrNote()
        {
            _isPositionDisplayed = !_isPositionDisplayed;

            CreateAllString();
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

        private Visibility _isAnswerVisible;
        public Visibility IsAnswerVisible
        {
            get { return _isAnswerVisible; }
            set
            {
                _isAnswerVisible = value;
                NotifyOfPropertyChange(() => IsAnswerVisible);
            }
        }

        private bool _isNextQuestionButtonVisible;
        public bool IsNextQuestionButtonVisible
        {
            get { return _isNextQuestionButtonVisible; }
            set
            {
                _isNextQuestionButtonVisible = value;
                NotifyOfPropertyChange(() => IsNextQuestionButtonVisible);
            }
        }

        private void CreateAllString()
        {
            EString = CreateString(Enum.Standard.E);
            AString = CreateString(Enum.Standard.A);
            DString = CreateString(Enum.Standard.D);
            GString = CreateString(Enum.Standard.G);
            BString = CreateString(Enum.Standard.B);
            E2String = CreateString(Enum.Standard.e);
        }

        private BindableCollection<Fret> CreateString(Enum.Standard stringName)
        {
            var stringModel = new BindableCollection<Fret>();
            var twelveNoteOfString = GetConsecutiveNote(stringName.ToString());

            for (int i = 0; i < 12; i++)
            {
                stringModel.Add(new Fret()
                {
                    StringName = stringName,
                    Position = i,
                    NoteName = twelveNoteOfString[i],
                    IsNoteNameVisible = _isPositionDisplayed ? Visibility.Collapsed : Visibility.Visible,
                    IsPositionVisible = _isPositionDisplayed ? Visibility.Visible : Visibility.Collapsed
                });
            }

            return stringModel;
        }

        private void CreateNewQuestion()
        {
            _requestedNote = RandomNote();
            _requestedString = RandomString();
            IsAnswerVisible = Visibility.Hidden;
            Question = string.Format("Find {0} on the {1} string", _requestedNote, _requestedString);
        }

        private void CreateAnswer(bool isCorrectAnswer)
        {
            IsAnswerVisible = Visibility.Visible;
            if (isCorrectAnswer)
            {
                Answer = "This is the correct answer!";
                IsNextQuestionButtonVisible = true;
            }
            else
            {
                Answer = "This is incorrect try Again";
                IsNextQuestionButtonVisible = false;
            }
        }

        private string RandomString()
        {
            return _string[_random.Next(0, 5)];
        }

        private string RandomNote()
        {
            return _scale[_random.Next(0, 11)];
        }

        private bool ValidateAnswer(Fret fret)
        {
            int stringZeroPosition = _doubleScale.IndexOf(fret.StringName.ToString());
            var frettedNote = _doubleScale[stringZeroPosition + fret.Position];
            return frettedNote == _requestedNote.ToString() && fret.StringName.ToString() == _requestedString;
        }

        private List<string> GetConsecutiveNote(string startNote)
        {
            var twelveNotes = new List<string>();

            int stringZeroPosition = _doubleScale.IndexOf(startNote.ToUpper());

            for (var i = stringZeroPosition; i <= 11; i++)
            {
                twelveNotes.Add(_doubleScale[i]);
            }

            for (int i = 0; i < stringZeroPosition; i++)
            {
                twelveNotes.Add(_doubleScale[i]);
            }

            return twelveNotes;
        }

        private void EnableCreateTest(bool isEnabled)
        {
            IsCreateNewTestEnabled = isEnabled;
        }

        private void CreateDescription()
        {
            TestStageDescription = string.Format(_testStageDescription, NumberOfQuestion, _currentQuestion);
        }
    }
}
