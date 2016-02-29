using System.ComponentModel.DataAnnotations;

namespace MahappsDemo.Repository
{
    public class Question
    {
        [Key]
        public int ID { get; set; }

        public string StringRequested { get; set; }

        public string NoteRequested { get; set; }
    }
}
