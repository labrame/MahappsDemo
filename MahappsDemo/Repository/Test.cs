using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahappsDemo.Repository
{
    public class Test
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual List<Result> Results { get; set; }
    }
}
