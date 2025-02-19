using System;
using System.Collections.Generic;

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
                Console.Clear();
                Console.WriteLine($"\n-------------------\n{i}. KÖR:");

                foreach (var versenyzo in Versenyzok)
                {
                    if (versenyzo.Kiszall)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{versenyzo.Nev} már kiesett a versenyből.");
                        Console.ResetColor();
                        continue;
                    }

                    int sebesseg = random.Next(90, 130);
                    if (random.Next(1, 10001) <= 1)
                    {
                        versenyzo.SzenvedBalesetet();
                        continue;
                    }

                    versenyzo.Auto.KopikGumi();
                    Console.WriteLine($"{versenyzo.Nev} - Sebesség: {sebesseg} km/h, Gumi állapot: {versenyzo.Auto.GumiÁllapot}%");

                    if (versenyzo.Auto.GumiÁllapot < 20)
                    {
                        if (random.Next(1, 10001) <= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"{versenyzo.Nev} DNF-t kapott, mert a gumi állapota kritikus alá csökkent!");
                            Console.ResetColor();
                            versenyzo.SzenvedBalesetet();
                            continue;
                        }
                    }

                    if (versenyzo.Auto.GumiÁllapot == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"{versenyzo.Nev} boxba megy a gumi cseréjére.");
                        Console.ResetColor();
                        versenyzo.Auto.GumiÁllapot = 100;

                        int dnfEsely = random.Next(1, 101);
                        if (dnfEsely <= 20)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{versenyzo.Nev} DNF-t kapott! A versenyző kiesett.");
                            Console.ResetColor();
                            versenyzo.SzenvedBalesetet();
                        }
                    }
                }

                if (i < korok)
                {
                    Console.WriteLine("\nNyomj egy gombot a következő kör indításához...");
                    Console.ReadKey();
                }
            }

            ResetAll();

            var nyertes = Versenyzok.Find(v => !v.Kiszall);
            if (nyertes == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Minden versenyző kiesett.");
                Console.ResetColor();
            }
            return nyertes!;
        }

        public void ResetAll()
        {
            foreach (var versenyzo in Versenyzok)
            {
                versenyzo.Kiszall = false;
                versenyzo.Baleset = false;
                versenyzo.Auto.GumiÁllapot = 100;
            }
        }
    }
}