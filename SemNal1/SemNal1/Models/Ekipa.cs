using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemNal1.Models
{
    public class Ekipa
    {
        public int Id { get; set; }
        public string EkipaIme { get; set; }
        public string EkipaSponsor { get; set; }
        public virtual Turnir Turnir { get; set; }
        public int TurnirId { get; set; }
    }
}