using System;
using System.Collections.Generic;

public interface IVeicolo
{
    void Avvio();
    void DescrizioneTipo();
}

public class Auto : IVeicolo
{
    public void Avvio()
    {
        Console.WriteLine("Avviamento dell'automobile");
    }

    public void DescrizioneTipo()
    {
        Console.WriteLine("Categoria: Automobile");
    }
}

public class Moto : IVeicolo
{
    public void Avvio()
    {
        Console.WriteLine("Avviamento della motocicletta");
    }

    public void DescrizioneTipo()
    {
        Console.WriteLine("Categoria: Motocicletta");
    }
}

public class Camion : IVeicolo
{
    public void Avvio()
    {
        Console.WriteLine("Avviamento del camion");
    }

    public void DescrizioneTipo()
    {
        Console.WriteLine("Categoria: Camion");
    }
}

public abstract class FabbricaMezzo
{
    public abstract IVeicolo CreaMezzo(string categoria);

    public void AvviaCreazione()
    {
        string categoria = Console.ReadLine();
        IVeicolo veicolo = CreaMezzo(categoria);

        if (veicolo != null)
        {
            veicolo.Avvio();
            veicolo.DescrizioneTipo();
        }
    }
}

public class CostruttoreConcrete : FabbricaMezzo
{
    public override IVeicolo CreaMezzo(string categoria)
    {
        switch (categoria.ToLower())
        {
            case "automobile":
                return new Auto();
            case "motocicletta":
                return new Moto();
            case "camion":
                return new Camion();
            default:
                Console.WriteLine("Tipo di mezzo non riconosciuto");
                return null;
        }
    }
}

public class AvvioProgramma
{
    public static void Main()
    {
        List<object> listaVeicoli = new List<object>();
        bool continua = true;

        do
        {
            Console.WriteLine("1. Crea un nuovo veicolo\n0. Chiudi il programma");
            int scelta = int.Parse(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.WriteLine("Specifica il tipo di veicolo da creare (automobile, camion, motocicletta)");
                    FabbricaMezzo fabbrica = new CostruttoreConcrete();
                    fabbrica.AvviaCreazione();
                    listaVeicoli.Add(fabbrica);
                    break;
                case 0:
                    continua = false;
                    break;
                default:
                    Console.WriteLine("Opzione non valida, riprova.");
                    break;
            }
        } while (continua);
    }
}

