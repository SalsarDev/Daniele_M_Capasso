using System;
using System.Collections.Generic;

// Interfaccia Observer
public interface IObserver
{
    void Aggiorna(string messaggio);
}

// Interfaccia Soggetto
public interface ISoggetto
{
    void Registra(IObserver osservatore);
    void Rimuovi(IObserver osservatore);
    void Notifica(string messaggio);
}

// Classe CentroMeteo
public class CentroMeteo : ISoggetto
{
    private List<IObserver> osservatori = new List<IObserver>();

    public void Registra(IObserver osservatore)
    {
        osservatori.Add(osservatore);
    }

    public void Rimuovi(IObserver osservatore)
    {
        osservatori.Remove(osservatore);
    }

    public void Notifica(string messaggio)
    {
        foreach (var osservatore in osservatori)
        {
            osservatore.Aggiorna(messaggio);
        }
    }

    public void AggiornaMeteo(string dati)
    {
        Console.WriteLine($"Nuovo dato meteo: {dati}");
        Notifica(dati);
    }
}

public class DisplayConsole : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Meteo aggiornato: {messaggio}");
    }
}

public class DisplayMobile : IObserver
{
    public void Aggiorna(string messaggio)
    {
        Console.WriteLine($"Meteo sul telefono: {messaggio}");
    }
}

// Main
class Program
{
    static void Main(string[] args)
    {
        CentroMeteo centro = new CentroMeteo();

        DisplayConsole console = new DisplayConsole();
        DisplayMobile mobile = new DisplayMobile();

        centro.Registra(console);
        centro.Registra(mobile);

        while (true)
        {
            Console.Write("Inserisci nuovo dato meteo oppure premi Invio per uscire: ");
            string dato = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dato)) break;

            centro.AggiornaMeteo(dato);
        }
    }
}
