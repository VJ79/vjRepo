using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCEverything.Areas.StudentManagement.Models
{
    public class Student1
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}