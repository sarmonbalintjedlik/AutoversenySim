using System;
using System.Collections.Generic;

namespace AutoVerseny
{
    class Program
    {
        static List<Versenyzo> versenyzok = new List<Versenyzo>();
        static List<Palya> palyak = new List<Palya>();
        static int menuIndex = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------- VERSENY SZIMULATOR ----------\n");
                MenuKiiras();

                string input = Console.ReadLine()!;

                if (int.TryParse(input, out menuIndex) && menuIndex >= 1 && menuIndex <= 6)
                {
                    switch (menuIndex)
                    {
                        case 1:
                            LetrehozVersenyzo();
                            break;
                        case 2:
                            LetrehozPalya();
                            break;
                        case 3:
                            TorolElem();
                            break;
                        case 4:
                            Listazas();
                            break;
                        case 5:
                            KezdVerseny();
                            break;
                        case 6:
                            return;
                    }
                }
                else
                {
                    Console.WriteLine("Érvénytelen választás! Kérlek válassz egy számot a menüből (1-6).");
                    Console.ReadKey();
                }
            }
        }

        static void MenuKiiras()
        {
            string[] menuItems = {
        "1. Versenyző létrehozás",
        "2. Pálya létrehozás",
        "3. Versenyző, pálya elvétele",
        "4. Versenyzők és pályák listázása",
        "5. Futam elkezdése",
        "6. Kilépés"
    };
            foreach (var item in menuItems)
            {
                Console.WriteLine(item);
            }
            Console.Write("Választás: ");
        }


        static void LetrehozVersenyzo()
        {
            Console.Clear();
            string nev;

            while (true)
            {
                Console.Write("Add meg a versenyző nevét: ");
                nev = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(nev))
                {
                    Console.WriteLine("A név nem lehet üres. Kérlek, adj meg egy nevet.");
                }
                else
                {
                    bool nevMarLetezik = false;
                    foreach (var versenyzo in versenyzok)
                    {
                        if (versenyzo.Nev.ToLower() == nev.ToLower())
                        {
                            nevMarLetezik = true;
                            break;
                        }
                    }

                    if (nevMarLetezik)
                    {
                        Console.WriteLine("Ez a név már foglalt, kérlek adj meg egy másikat.");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.Write("Add meg az autó márkáját: ");
            string autoMarka = Console.ReadLine()!;

            while (string.IsNullOrWhiteSpace(autoMarka))
            {
                Console.Write("Az autó márkáját nem hagyhatod üresen. Kérlek add meg: ");
                autoMarka = Console.ReadLine()!;
            }

            versenyzok.Add(new Versenyzo(nev, new Auto(autoMarka)));
            Console.WriteLine("Versenyző hozzáadva!");
            Console.ReadKey();
        }

        static void LetrehozPalya()
        {
            Console.Clear();
            string nev;

            while (true)
            {
                Console.Write("Add meg a pálya nevét: ");
                nev = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(nev))
                {
                    Console.WriteLine("A pálya név nem lehet üres. Kérlek, adj meg egy nevet.");
                }
                else
                {
                    bool nevMarLetezik = false;
                    foreach (var palya in palyak)
                    {
                        if (palya.Nev.ToLower() == nev.ToLower())
                        {
                            nevMarLetezik = true;
                            break;
                        }
                    }

                    if (nevMarLetezik)
                    {
                        Console.WriteLine("Ez a pálya név már foglalt, kérlek adj meg egy másikat.");
                    }
                    else
                    {
                        break;
                    }
                }
            }

            int korok;
            Console.Write("Hány körös legyen a pálya? ");

            while (true)
            {
                string korokInput = Console.ReadLine()!;

                if (int.TryParse(korokInput, out korok) && korok > 0)
                {
                    break;
                }
                else
                {
                    Console.Write("Érvénytelen szám. Adj meg egy pozitív egész számot: ");
                }
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
                Versenyzo versenyzo = null!;

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
                Palya palya = null!;

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
            Console.Write($"Válassz egy pályát (1 - {palyak.Count}): ");
            string bemenet = Console.ReadLine()!;

            bool isValid = true;
            int valasztottPalya = 0;

            for (int i = 0; i < bemenet.Length; i++)
            {
                if (bemenet[i] < '0' || bemenet[i] > '9')
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
            {
                for (int i = 0; i < bemenet.Length; i++)
                {
                    valasztottPalya = valasztottPalya * 10 + (bemenet[i] - '0');
                }
            }

            if (isValid && valasztottPalya >= 1 && valasztottPalya <= palyak.Count)
            {
                var verseny = new Verseny(versenyzok, palyak[valasztottPalya - 1], new Idojaras("Napos"));
                var nyertes = verseny.InditVerseny();

                Console.WriteLine("\nA verseny győztese: " + (nyertes != null ? nyertes.Nev : "Nincs nyertes, mindenki kiesett!"));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Érvénytelen pálya választás! Kérlek válassz egy számot a menüből.");
                Console.ReadKey();
            }
        }

    }
}