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
        [Required(ErrorMessage ="Ime je obvezen podatek!")]
        public string StudentName { get; set; }
        [Display(Name ="Starost")]
        [Range(5,50,ErrorMessage ="Starost more biti od 5 do 50")]
        public int Age { get; set; }
        
    }
}