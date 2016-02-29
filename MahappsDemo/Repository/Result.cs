using System;
using System.ComponentModel.DataAnnotations;

namespace MahappsDemo.Repository
{
    public class Result
    {
        [Key]
        public int ID{ get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }

        public DateTime RequestedOn { get; set; }

        public DateTime AnsweredOn { get; set; }

        public bool IsCorrect { get; set; }
    }
}
