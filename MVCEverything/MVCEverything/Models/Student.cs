using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEverything.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public string Tel13 { get; set; }
    }
}