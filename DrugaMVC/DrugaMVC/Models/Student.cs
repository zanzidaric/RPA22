using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DrugaMVC.Models
{
    public class Student
    {
        //prop tab tab (kratica)
        public int StudentId { get; set; }
        [Display(Name ="Ime")]
        public string StudentName { get; set; }
        [Display(Name ="Starost")]
        public int Age { get; set; }
        
    }
}