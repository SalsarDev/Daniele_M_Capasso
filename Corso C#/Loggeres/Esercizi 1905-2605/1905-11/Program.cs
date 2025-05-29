using System;
using System.Collections.Generic;

class Veicolo
{
    public string Marca { get; set; }
    public string Modello { get; set; }

    public Veicolo(string marca, string modello)
    {
        Marca = marca;
        Modello = modello;
    }

    public virtual void StampaInfo()
    {
        Console.WriteLine($"Marca: {Marca}, Modello: {Modello}");
    }
}

class Auto : Veicolo
{
    public int NumeroPorte { get; set; }

    public Auto(string marca, string modello, int numeroPorte)
        : base(marca, modello)
    {
        NumeroPorte = numeroPorte;
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Auto - Marca: {Marca}, Modello: {Modello}, Numero Porte: {NumeroPorte}");
    }
}

class Moto : Veicolo
{
    public string TipoManubrio { get; set; }

    public Moto(string marca, string modello, string tipoManubrio)
        : base(marca, modello)
    {
        TipoManubrio = tipoManubrio;
    }

    public override void StampaInfo()
    {
        Console.WriteLine($"Moto - Marca: {Marca}, Modello: {Modello}, Tipo Manubrio: {TipoManubrio}");
    }
}

class Program
{
    static void Main()
    {
        List<Veicolo> garage = new List<Veicolo>();
        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("MENU ");
            Console.WriteLine("1. Inserisci un nuovo veicolo");
            Console.WriteLine("2. Visualizza tutti i veicoli");
            Console.WriteLine("3. Esci");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    Console.Write("Tipo di veicolo (auto/moto): ");
                    string tipo = Console.ReadLine().ToLower();

                    Console.Write("Marca: ");
                    string marca = Console.ReadLine();
                    Console.Write("Modello: ");
                    string modello = Console.ReadLine();

                    if (tipo == "auto")
                    {
                        Console.Write("Numero di porte: ");
                        int porte = int.Parse(Console.ReadLine());
                        garage.Add(new Auto(marca, modello, porte));
                    }
                    else if (tipo == "moto")
                    {
                        Console.Write("Tipo manubrio: ");
                        string manubrio = Console.ReadLine();
                        garage.Add(new Moto(marca, modello, manubrio));
                    }
                    else
                    {
                        Console.WriteLine("Tipo non valido");
                    }
                    break;

                case "2":
                    Console.WriteLine("Veicoli nel garage");
                    foreach (var v in garage)
                    {
                        v.StampaInfo();
                    }
                    break;

                case "3":
                    esci = true;
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }

            Console.WriteLine(); 
        }
    }
}
