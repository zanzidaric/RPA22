using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seminarska.Models
{
    public class Turnir
    {
        public int Id { get; set; }
        public string TurnirIme { get; set; }
        public DateTime Datum { get; set; }
    }
}