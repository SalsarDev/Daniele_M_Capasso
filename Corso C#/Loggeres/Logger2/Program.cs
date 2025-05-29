using System;
using System.Collections.Generic;

public sealed class Logger
{
    private static Logger instance;

    private List<string> logs = new List<string>();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
                instance = new Logger();
            return instance;
        }
    }

    public void Log(string message)
    {
        logs.Add(message);
    }

    public List<string> GetLogs()
    {
        return logs;
    }
}

class Program
{
    static void Main()
    {
        bool avvio = true;

        while (avvio)
        {
            Console.WriteLine("1. Aggiungi messaggio");
            Console.WriteLine("2. Visualizza tutti i messaggi");
            Console.WriteLine("3. Esci");
            Console.Write("Scegli un'opzione: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Inserisci messaggio: ");3
                    string message = Console.ReadLine();
                    Logger.Instance.Log(message);
                    Console.WriteLine("Messaggio aggiunto!");
                    break;

                case "2":
                    Console.WriteLine("Messaggio Presente:");
                    List<string> logs = Logger.Instance.GetLogs();
                    if (logs.Count == 0)
                    {
                        Console.WriteLine("Nessun messaggio");
                    }
                    else
                    {
                        foreach (var log in logs)
                        {
                            Console.WriteLine(log);
                        }
                    }
                    break;

                case "3":
                    avvio = false;
                    Console.WriteLine("Uscita ");
                    break;

                default:
                    Console.WriteLine("Opzione non valida, riprova.");
                    break;
            }
        }
    }
}
