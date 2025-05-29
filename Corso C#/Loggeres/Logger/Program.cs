using System;
using System.Collections.Generic;
public sealed class Singleton
{
    private static Singleton istanza;
    private Singleton() { }

    public static Singleton GetIstanza()
    {
        if (istanza == null)
            istanza = new Singleton();
        return istanza;
    }

    public void ScriviMessaggio(string messaggio)
    {
        Console.WriteLine($"[{DateTime.Now}] {messaggio}");
    }
}

public class Program
{
    public static void Main()
    {
        var singleton1 = Singleton.GetIstanza();
        var singleton2 = Singleton.GetIstanza();

        singleton1.ScriviMessaggio("Sistema Inizializzato.");
        singleton2.ScriviMessaggio("Connessione al database stabilita.");

        Console.WriteLine("HashCode singleton1: " + singleton1.GetHashCode());
        Console.WriteLine("HashCode singleton2: " + singleton2.GetHashCode());

        Console.WriteLine("Programma terminato.");
    }
}

