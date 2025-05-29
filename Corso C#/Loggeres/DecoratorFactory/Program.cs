using System;

class TortaDecoratorFactory
{
    // Interfaccia
    public interface ITorta
    {
        string Descrizione();
    }

    // Torte base
    public class TortaCioccolato : ITorta
    {
        public string Descrizione() => "Torta al cioccolato";
    }

    public class TortaVaniglia : ITorta
    {
        public string Descrizione() => "Torta alla vaniglia";
    }

    public class TortaFrutta : ITorta
    {
        public string Descrizione() => "Torta alla frutta";
    }

    // Decoratore 1
    public abstract class DecoratoreTorta : ITorta
    {
        private readonly ITorta baseTorta;

        public DecoratoreTorta(ITorta torta)
        {
            baseTorta = torta;
        }

        protected string GetDescrizioneBase()
        {
            return baseTorta.Descrizione();
        }

        public abstract string Descrizione();
    }

    // Decoratori
    public class ConPanna : DecoratoreTorta
    {
        public ConPanna(ITorta torta) : base(torta) { }

        public override string Descrizione()
        {
            return GetDescrizioneBase() + " con panna";
        }
    }

    public class ConFragole : DecoratoreTorta
    {
        public ConFragole(ITorta torta) : base(torta) { }

        public override string Descrizione()
        {
            return GetDescrizioneBase() + " con fragole";
        }
    }

    public class ConGlassa : DecoratoreTorta
    {
        public ConGlassa(ITorta torta) : base(torta) { }

        public override string Descrizione()
        {
            return GetDescrizioneBase() + " con glassa";
        }
    }

    // Factory
    public static class TortaFactory
    {
        public static ITorta CreaTortaBase(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "cioccolato": return new TortaCioccolato();
                case "vaniglia": return new TortaVaniglia();
                case "frutta": return new TortaFrutta();
                default: throw new ArgumentException("Tipo di torta non valido.");
            }
        }
    }

    // Programma principale
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Scegli il tipo di torta (cioccolato, vaniglia, frutta):");
            string tipo = Console.ReadLine();

            ITorta miaTorta;

            try
            {
                miaTorta = TortaFactory.CreaTortaBase(tipo);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Vuoi aggiungere panna? (si/no)");
            if (Console.ReadLine().ToLower() == "si")
            {
                miaTorta = new ConPanna(miaTorta);
            }

            Console.WriteLine("Vuoi aggiungere fragole? (si/no)");
            if (Console.ReadLine().ToLower() == "si")
            {
                miaTorta = new ConFragole(miaTorta);
            }

            Console.WriteLine("Vuoi aggiungere glassa? (si/n)");
            if (Console.ReadLine().ToLower() == "si")
            {
                miaTorta = new ConGlassa(miaTorta);
            }

            Console.WriteLine("\nDescrizione finale della torta:");
            Console.WriteLine(miaTorta.Descrizione());
        }
    }
}

