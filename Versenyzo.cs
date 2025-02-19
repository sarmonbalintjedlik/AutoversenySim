using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerseny
{
    public class Versenyzo
    {
        public string Nev { get; set; }
        public Auto Auto { get; set; }
        public bool Baleset { get; set; }
        public bool Kiszall { get; set; }
        public int OsszesitettTavolsag { get; set; }

        public Versenyzo(string nev, Auto auto)
        {
            Nev = nev;
            Auto = auto;
            Baleset = false;
            Kiszall = false;
            OsszesitettTavolsag = 0;
        }

        public void SzenvedBalesetet()
        {
            Baleset = true;
            Kiszall = true;
            Console.WriteLine($"{Nev} balesetet szenvedett és kiesett a versenyből!");
        }
        public void Folytathatja()
        {
            if (!Baleset)
            {
                Console.WriteLine($"{Nev} továbbra is versenyez!");
            }
            else
            {
                Console.WriteLine($"{Nev} nem folytathatja a versenyt, mivel balesetet szenvedett.");
            }
        }
    }
}
