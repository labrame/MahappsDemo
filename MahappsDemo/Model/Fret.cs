using System.Windows;

namespace MahappsDemo.Model
{
    public class Fret
    {
        public Enum.Standard StringName { get; set; }

        public int Position { get; set; }

        public string NoteName { get; set; }

        public Visibility IsPositionVisible { get; set; }

        public Visibility IsNoteNameVisible { get; set; }
    }
}
