using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VajaMVC.Models
{
    public class Izpit
    {
        //prop tab tab (kratica)
        public DateTime Datum { get; set; }
        
        public int Id { get; set; }
        
        public int Ocena { get; set; }
        public virtual Predmet predmet { get; set; }
        public int PredmetId { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }


    }
}