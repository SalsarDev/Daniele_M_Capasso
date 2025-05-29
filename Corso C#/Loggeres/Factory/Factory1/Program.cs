using System;
using System.Collections.Generic;
interface IVeicolo
{
    void Avvia();
    void Tipo();
}
class Auto : IVeicolo
{
    public void Avvia() { Console.WriteLine("Avvio auto"); }
    public void Tipo() { Console.WriteLine("Tipo: Auto"); }
}

class Moto : IVeicolo
{
    public void Avvia() { Console.WriteLine("Avvio moto"); }
    public void Tipo() { Console.WriteLine("Tipo: Moto"); }
}

class Camion : IVeicolo
{
    public void Avvia() { Console.WriteLine("Avvio camion"); }
    public void Tipo() { Console.WriteLine("Tipo: Camion"); }
}

class VeicoloFactory
{
    public static IVeicolo CreaVeicolo(string tipo)
    {
        tipo = tipo.ToLower();
        if (tipo == "auto")
            return new Auto();
        else if (tipo == "moto")
            return new Moto();
        else if (tipo == "camion")
            return new Camion();
        else
        {
            Console.WriteLine("Tipo di veicolo non valido.");
            return null;
        }
    }
}

// Menu
class MenuVeicoli
{
    Dictionary<int, string> opzioni;

    public void Inizializza()
    {
        opzioni = new Dictionary<int, string>();
        opzioni.Add(1, "auto");
        opzioni.Add(2, "moto");
        opzioni.Add(3, "camion");
        opzioni.Add(0, "esci");
    }

    public void Mostra()
    {
        Inizializza();

        int scelta = -1;

        while (scelta != 0)
        {
            foreach (KeyValuePair<int, string> op in opzioni)
            {
                Console.WriteLine(op.Key + ": " + op.Value);
            }

            Console.Write("Scegli un'opzione: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out scelta) || !opzioni.ContainsKey(scelta))
            {
                Console.WriteLine("Scelta non valida.");
                scelta = -1;
                continue;
            }

            if (scelta == 0)
            {
                Console.WriteLine("Uscita dal programma.");
                break;
            }

            string tipo = opzioni[scelta];
            IVeicolo i = VeicoloFactory.CreaVeicolo(tipo);

            if (i != null)
            {
                i.Avvia();
                i.Tipo();
            }
        }
    }
}

// Main
class Program
{
    static void Main()
    {
        MenuVeicoli menu = new MenuVeicoli();
        menu.Mostra();
    }
}
