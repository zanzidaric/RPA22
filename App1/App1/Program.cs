using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities contex = new BazaZaVajeEntities();
            //vsi dobavitelji
            //var x1 = from a in contex.DOBAVITELJ
            //         select a;
            var x1 = contex.DOBAVITELJ;
            //foreach (var y in x1)
            //{
            //    Console.WriteLine(y.D_IME + " " + y.D_KONTAKT);
            //}
            //Console.ReadLine();
            //vaja1
            DateTime datum = DateTime.Parse("20.1.2004");
            var x2 = from a in contex.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };
            //foreach(var y in x2)
            //{
            //    Console.WriteLine(y.Opis + " " + y.Cena);
            //}
            //vaja2
            DateTime danes = DateTime.Now;
            //Alternative way ---- TimeSpan ts = new TimeSpan(365, 0, 0, 0);
            danes=danes.AddDays(365);
            var x3 = from a in contex.PRODUKT                   
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA,Zapadlost = danes};
            //foreach (var y in x3)
            //{
            //    Console.WriteLine(y.Opis+" "+y.Zapadlost);
            //}
            //vaja3
            //izberi P_OPIS, P_ZALOGA, P_MIN,P_CENA iz tabele PRODUKT, kjer je P_CENA manjša od 50 in
            //je P_DATUM večji kot 15.jan. 2004
            DateTime datum2 = DateTime.Parse("15.1.2004");
            var x9 = from a in contex.PRODUKT
                     where a.P_CENA<50
                     where a.P_DATUM<datum2
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };
                      
            //foreach(var y in x9)
            //{
            //    Console.WriteLine(y.Opis+" "+y.Cena);
            //}
            //vaja4
            var x4 = from a in contex.DOBAVITELJ
                     where a.D_KONTAKT.StartsWith("Smith")
                     select a;
            //foreach(var y in x4)
            //{
            //    Console.WriteLine(y.D_KONTAKT);
            //}
            //vaja5
            //izberi vse dobavitelje, kjer je zaloga v produktu manjša od dvakratnika minimalne zaloge
            
            //vaja6
            var x5 = (from a in contex.PRODUKT
                      select a.D_KODA).Distinct();
            //foreach (var y in x5)
            //{
            //    Console.WriteLine(y);
            //}
            //vaja7
            var x6 = contex.DOBAVITELJ.Where(e => !x5.Any(p => p == e.D_KODA));
            //foreach(var y in x6)
            //{
            //    Console.WriteLine(y.D_KODA);
            //}
            //vaja 8
            var x7 = contex.KUPEC.Sum(e => e.KUP_STANJE);
            var x8 = (from a in contex.KUPEC
                      select a.KUP_STANJE).Sum();
            //Console.WriteLine("prvi rez "+x7);
            //Console.WriteLine("drugi rez "+x8);
        }
    }
}
