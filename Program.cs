using System;
using System.Collections.Generic;

namespace AutoVerseny
{
    class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static List<Palya> palyak = new List<Palya>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------- VERSENY SZIMULATOR ----------\n");
                Console.WriteLine("1. Versenyző létrehozás");
                Console.WriteLine("2. Pálya létrehozás");
                Console.WriteLine("3. Versenyző, pálya elvétele");
                Console.WriteLine("4. Versenyzők és pályák listázása");
                Console.WriteLine("5. Futam elkezdése");
                Console.WriteLine("6. Kilépés");
                Console.Write("Válassz egy menüpontot: ");
                string valasztas = Console.ReadLine()!;

                switch (valasztas)
                {
                    case "1":
                        LetrehozVersenyzo();
                        break;
                    case "2":
                        LetrehozPalya();
                        break;
                    case "3":
                        TorolElem();
                        break;
                    case "4":
                        Listazas();
                        break;
                    case "5":
                        KezdVerseny();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Érvénytelen választás. Nyomj egy gombot a folytatáshoz...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void LetrehozVersenyzo()
        {
            Console.Clear();
            Console.Write("Add meg a versenyző nevét: ");
            string nev = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(nev))
            {
                Console.WriteLine("A versenyző neve nem lehet üres!");
                Console.ReadKey();
                return;
            }

            Console.Write("Add meg az autó márkáját: ");
            string autoMarka = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(autoMarka))
            {
                Console.WriteLine("Az autó márkája nem lehet üres!");
                Console.ReadKey();
                return;
            }

            versenyzok.Add(new Versenyzo(nev, new Auto(autoMarka)));
            Console.WriteLine("Versenyző hozzáadva!");
            Console.ReadKey();
        }


        static void LetrehozPalya()
        {
            Console.Clear();
            Console.Write("Add meg a pálya nevét: ");
            string nev = Console.ReadLine()!;
            if (string.IsNullOrWhiteSpace(nev))
            {
                Console.WriteLine("A pálya neve nem lehet üres!");
                Console.ReadKey();
                return;
            }

            Console.Write("Hány körös legyen a pálya? ");
            int korok;
            while (!int.TryParse(Console.ReadLine(), out korok) || korok <= 0)
            {
                Console.Write("Érvénytelen szám. Adj meg egy pozitív egész számot: ");
            }

            palyak.Add(new Palya(nev, korok));
            Console.WriteLine("Pálya hozzáadva!");
            Console.ReadKey();
        }


        static void TorolElem()
        {
            Console.Clear();
            Console.Write("Versenyző vagy pálya törlése? (v/p): ");
            string tipus = Console.ReadLine()!;

            if (tipus.ToLower() == "v")
            {
                Console.Write("Add meg a versenyző nevét: ");
                string nev = Console.ReadLine()!;
                var versenyzo = null as Versenyzo;
                foreach (var v in versenyzok)
                {
                    if (v.Nev == nev)
                    {
                        versenyzo = v;
                        break;
                    }
                }

                if (versenyzo != null)
                {
                    versenyzok.Remove(versenyzo);
                    Console.WriteLine("Versenyző eltávolítva!");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen nevű versenyző.");
                }
            }
            else if (tipus.ToLower() == "p")
            {
                Console.Write("Add meg a pálya nevét: ");
                string nev = Console.ReadLine()!;
                var palya = null as Palya;
                foreach (var p in palyak)
                {
                    if (p.Nev == nev)
                    {
                        palya = p;
                        break;
                    }
                }

                if (palya != null)
                {
                    palyak.Remove(palya);
                    Console.WriteLine("Pálya eltávolítva!");
                }
                else
                {
                    Console.WriteLine("Nincs ilyen nevű pálya.");
                }
            }
            else
            {
                Console.WriteLine("Érvénytelen választás.");
            }
            Console.ReadKey();
        }


        static void Listazas()
        {
            Console.Clear();
            Console.WriteLine("Versenyzők:");
            foreach (var versenyzo in versenyzok)
            {
                Console.WriteLine($"- {versenyzo.Nev} ({versenyzo.Auto.Mark})");
            }

            Console.WriteLine("\nPályák:");
            foreach (var palya in palyak)
            {
                Console.WriteLine($"- {palya.Nev} ({palya.KorokSzama} kör)");
            }
            Console.WriteLine("\nNyomj meg egy gombot a folytatáshoz...");
            Console.ReadKey();
        }

        static void KezdVerseny()
        {
            Console.Clear();
            if (versenyzok.Count == 0 || palyak.Count == 0)
            {
                Console.WriteLine("Nincs elég versenyző vagy pálya a verseny indításához.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Elérhető pályák:");
            for (int i = 0; i < palyak.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {palyak[i].Nev} - {palyak[i].KorokSzama} kör");
            }
            Console.Write("Válassz egy pályát (1 - {0}): ", palyak.Count);
            int valasztottPalya;
            while (!int.TryParse(Console.ReadLine(), out valasztottPalya) || valasztottPalya < 1 || valasztottPalya > palyak.Count)
            {
                Console.Write("Érvénytelen választás. Adj meg egy érvényes számot: ");
            }

            var verseny = new Verseny(versenyzok, palyak[valasztottPalya - 1], new Idojaras("Napos"));
            var nyertes = verseny.InditVerseny();

            Console.WriteLine("\nA verseny győztese: " + (nyertes != null ? nyertes.Nev : "Nincs nyertes, mindenki kiesett!"));
            Console.ReadKey();
        }
    }
}
