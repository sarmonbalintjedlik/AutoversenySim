using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerseny
{
    public class Palya
    {
        public string Nev { get; set; }
        public int KorokSzama { get; set; }

        public Palya(string nev, int korokSzama)
        {
            Nev = nev;
            KorokSzama = korokSzama;
        }
    }
}
