using System;
using System.Collections.Generic;

class Soldato
{
    public string Nome { get; set; }
    public string Grado { get; set; }

    private int anniServizio;
    public int AnniServizio
    {
        get => anniServizio;
        set
        {
            if (value >= 0)
                anniServizio = value;
        }
    }

    public virtual void Descrizione()
    {
        Console.WriteLine($"Nome: {Nome}, Grado: {Grado}, Anni di Servizio: {AnniServizio}");
    }
}

class Fante : Soldato
{
    public string Arma { get; set; }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine($"Arma: {Arma}");
    }
}

class Artigliere : Soldato
{
    private int calibro;
    public int Calibro
    {
        get => calibro;
        set
        {
            if (value > 0)
                calibro = value;
        }
    }

    public override void Descrizione()
    {
        base.Descrizione();
        Console.WriteLine($"Calibro: {Calibro}");
    }
}

class Program
{
    static void Main()
    {
        List<Soldato> esercito = new List<Soldato>();
        bool continua = true;

        while (continua)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("a. Aggiungere un nuovo Fante");
            Console.WriteLine("b. Aggiungere un nuovo Artigliere");
            Console.WriteLine("c. Visualizzare tutti i soldati");
            Console.WriteLine("d. Uscire");
            Console.Write("Scelta: ");
            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "a":
                    Fante fante = new Fante();
                    Console.Write("Nome: ");
                    fante.Nome = Console.ReadLine();
                    Console.Write("Grado: ");
                    fante.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: ");
                    fante.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Arma: ");
                    fante.Arma = Console.ReadLine();
                    esercito.Add(fante);
                    break;

                case "b":
                    Artigliere artigliere = new Artigliere();
                    Console.Write("Nome: ");
                    artigliere.Nome = Console.ReadLine();
                    Console.Write("Grado: ");
                    artigliere.Grado = Console.ReadLine();
                    Console.Write("Anni di servizio: ");
                    artigliere.AnniServizio = int.Parse(Console.ReadLine());
                    Console.Write("Calibro: ");
                    artigliere.Calibro = int.Parse(Console.ReadLine());
                    esercito.Add(artigliere);
                    break;

                case "c":
                    foreach (var soldato in esercito)
                    {
                        soldato.Descrizione();
                        Console.WriteLine("-----");
                    }
                    break;

                case "d":
                    continua = false;
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
    }
}
