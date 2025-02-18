using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerseny
{
    public class Auto
    {
        public string Mark { get; set; }
        public int GumiÁllapot { get; set; }
        private static Random random = new Random();

        public Auto(string mark)
        {
            Mark = mark;
            GumiÁllapot = 100;
        }

        public void KopikGumi()
        {
            int kopas = random.Next(3, 8);
            GumiÁllapot -= kopas;
            if (GumiÁllapot < 0) GumiÁllapot = 0;
        }
    }
}
