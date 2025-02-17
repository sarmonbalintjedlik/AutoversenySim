using System;
using System.Collections.Generic;

namespace AutoVerseny
{
    class Program
    {
        static void Main(string[] args)
        {
            var monaco = new Palya("Monaco", 5);
            var silverstone = new Palya("Silverstone", 6);
            var monza = new Palya("Monza", 4);
            var spa = new Palya("Spa-Francorchamps", 5);
            var leMans = new Palya("Circuit de la Sarthe (Le Mans)", 6);

            var esosIdo = new Idojaras("Esős");
            var naposIdo = new Idojaras("Napos");

            var lewisHamilton = new Versenyzo("Lewis Hamilton", new Auto("Mercedes"));
            var maxVerstappen = new Versenyzo("Max Verstappen", new Auto("Red Bull"));
            var charlesLeclerc = new Versenyzo("Charles Leclerc", new Auto("Ferrari"));
            var sebastianVettel = new Versenyzo("Sebastian Vettel", new Auto("Aston Martin"));
            var fernandoAlonso = new Versenyzo("Fernando Alonso", new Auto("Aston Martin"));

            var versenyzok = new List<Versenyzo> { lewisHamilton, maxVerstappen, charlesLeclerc, sebastianVettel, fernandoAlonso };

            var random = new Random();
            var selectedPalya = new List<Palya> { monaco, silverstone, monza, spa, leMans }[random.Next(0, 5)];
            var selectedIdojaras = random.Next(0, 2) == 0 ? esosIdo : naposIdo;

            var verseny = new Verseny(versenyzok, selectedPalya, selectedIdojaras);
            var nyertes = verseny.InditVerseny();

            Console.WriteLine($"\nA verseny győztese: {nyertes.Nev}!");
        }
    }
}

