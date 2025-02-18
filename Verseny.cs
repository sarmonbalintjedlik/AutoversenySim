using AutoVerseny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoVerseny
{
    public class Verseny
    {
        public List<Versenyzo> Versenyzok { get; set; }
        public Palya Palya { get; set; }
        public Idojaras Időjárás { get; set; }

        public Verseny(List<Versenyzo> versenyzok, Palya palya, Idojaras idojaras)
        {
            Versenyzok = versenyzok;
            Palya = palya;
            Időjárás = idojaras;
        }

        public Versenyzo InditVerseny()
        {
            int korok = Palya.KorokSzama;
            Random random = new Random();

            for (int i = 1; i <= korok; i++)
            {
                Console.WriteLine($"\n-------------------\n{i}. KÖR:");
                foreach (var versenyzo in Versenyzok)
                {
                    if (versenyzo.Kiszall)
                    {
                        Console.WriteLine($"{versenyzo.Nev} már kiesett a versenyből.");
                        continue;
                    }

                    int sebesseg = random.Next(90, 130);
                    if (random.Next(1, 10) > 9)
                    {
                        versenyzo.SzenvedBalesetet();
                        continue;
                    }

                    versenyzo.Auto.KopikGumi();
                    Console.WriteLine($"{versenyzo.Nev} - Sebesség: {sebesseg} km/h, Gumi állapot: {versenyzo.Auto.GumiÁllapot}%");
                }

                if (i < korok)
                {
                    Console.WriteLine("\nNyomj egy gombot a következő kör indításához...");
                    Console.ReadKey();
                }
            }

            var nyertes = Versenyzok.Find(v => !v.Kiszall);
            if (nyertes == null)
            {
                Console.WriteLine("Minden versenyző kiesett.");
            }
            return nyertes!;
        }
    }



}
