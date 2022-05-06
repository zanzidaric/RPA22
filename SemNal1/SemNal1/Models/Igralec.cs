using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemNal1.Models
{
    public class Igralec
    {
        public int Id { get; set; }
        public string IgralecIme { get; set; }
        public string IgralecPriimek { get; set; }
        public virtual Ekipa Ekipa { get; set; }
        public int EkipaId { get; set; }
    }
}