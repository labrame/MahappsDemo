using Caliburn.Micro;
using MahappsDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Enum = MahappsDemo.Model.Enum;

namespace MahappsDemo.ViewModel
{
    public class FretBoardTwoViewModel : BaseTabViewModel
    {
        private readonly List<string> _scale;
        private readonly List<string> _string;
        private readonly Random _random;

        private string _requestedString;
        private string _requestedNote;

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

            _scale = new List<string> { "A", "A#Bb", "B", "C", "C#Db", "D", "D#Eb", "E", "F", "F#Gb", "G", "G#Ab" };
            _string = new List<string> { "E", "A", "D", "G", "B", "e" };
            _random = new Random();

            IsAnswerVisible = false;
            IsNextQuestionButtonVisible = false;
            CreateNewQuestion();
        }

        public void FretString(Fret fret)
        {
            var isCorrectAnswer = ValidateAnswer(fret);
            CreateAnswer(isCorrectAnswer);
        }

        public void DisplayNextQuestion()
        {
            IsAnswerVisible = false;
            CreateNewQuestion();
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
            _requestedNote = RandomNote();
            _requestedString = RandomString();
            IsAnswerVisible = false;
            Question = string.Format("Find {0} on the {1} string", _requestedNote, _requestedString);
        }

        private void CreateAnswer(bool isCorrectAnswer)
        {
            IsAnswerVisible = true;
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
            //To be sure to always have the result is the list create a double scale
            List<string> doubleScale = new List<string>();
            doubleScale.AddRange(_scale);
            doubleScale.AddRange(_scale);

            int stringZeroPosition = doubleScale.IndexOf(fret.StringName.ToString());
            var frettedNote = doubleScale[stringZeroPosition + fret.Position];
            return frettedNote == _requestedNote.ToString();
        }
    }
}
