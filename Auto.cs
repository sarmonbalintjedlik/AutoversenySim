using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace AutoVerseny
{
    public class Auto
    {
        public string Mark { get; set; }
        public int GumiÁllapot { get; set; }

        public Auto(string mark)
        {
            Mark = mark;
            GumiÁllapot = 100;
        }

        public void KopikGumi()
        {
            GumiÁllapot -= 5;
            if (GumiÁllapot < 0) GumiÁllapot = 0;
        }
    }


}
