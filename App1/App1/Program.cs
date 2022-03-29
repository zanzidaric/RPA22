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
            foreach (var y in x1)
            {
                Console.WriteLine(y.D_IME + " " + y.D_KONTAKT);
            }
            Console.ReadLine();
        }
    }
}
