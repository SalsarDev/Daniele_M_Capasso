using System;
using System.Collections.Generic;

public class ConfigurazioneSistema
{
    private static ConfigurazioneSistema _istanza;
    private static object _lock = new object();

    private Dictionary<string, string> _configurazioni;

    private ConfigurazioneSistema()
    {
        _configurazioni = new Dictionary<string, string>();
    }

    public static ConfigurazioneSistema Instance
    {
        get
        {
            lock (_lock)
            {
                if (_istanza == null)
                {
                    _istanza = new ConfigurazioneSistema();
                }
                return _istanza;
            }
        }
    }

    public void Imposta(string chiave, string valore)
    {
        _configurazioni[chiave] = valore;
    }

    public string Leggi(string chiave)
    {
        if (_configurazioni.ContainsKey(chiave))
        {
            return _configurazioni[chiave];
        }
        else
        {
            return "Chiave non trovata";
        }
    }

    public void StampaTutte()
    {
        Console.WriteLine("Configurazioni Salvate");
        if (_configurazioni.Count == 0)
        {
            Console.WriteLine("Nessuna configurazione presente.");
        }
        else
        {
            foreach (var item in _configurazioni)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

public static class ModuloA
{
    public static void Configura()
    {
        var config = ConfigurazioneSistema.Instance;
        config.Imposta("Tema", "Chiaro");
        config.Imposta("Lingua", "Italiano");
    }
}

public static class ModuloB
{
    public static void Configura()
    {
        var config = ConfigurazioneSistema.Instance;
        config.Imposta("Volume", "75%");
        config.Imposta("Risoluzione", "1920x1080");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Configurazione Sistema");
        ModuloA.Configura();
        ModuloB.Configura();

        bool esci = false;

        while (!esci)
        {
            Console.WriteLine("1. Imposta configurazione");
            Console.WriteLine("2. Leggi configurazione");
            Console.WriteLine("3. Stampa tutte le configurazioni");
            Console.WriteLine("4. Esci");
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();

            var config = ConfigurazioneSistema.Instance;

            switch (scelta)
            {
                case "1":
                    Console.Write("Inserisci chiave: ");
                    string chiave = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(chiave))
                    {
                        Console.WriteLine("Errore: la chiave non può essere vuota. Riprova.");
                        break;
                    }

                    if (chiave != "Tema" && chiave != "Lingua" && chiave != "Volume" && chiave != "Risoluzione")
                    {
                        Console.WriteLine("Errore: chiave non valida. Usa una delle seguenti chiavi:");
                        Console.WriteLine("Tema, Lingua, Volume, Risoluzione");
                        break;
                    }

                    Console.Write("Inserisci valore: ");
                    string valore = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(valore))
                    {
                        Console.WriteLine("Errore: il valore non può essere vuoto. Riprova.");
                        break;
                    }

                    bool valoreValido = false;

                    if (chiave == "Tema" && (valore == "Chiaro" || valore == "Scuro"))
                    {
                        valoreValido = true;
                    }
                    else if (chiave == "Lingua" && (valore == "Italiano" || valore == "Inglese"))
                    {
                        valoreValido = true;
                    }
                    else if (chiave == "Volume" && (valore == "75%" || valore == "50%"))
                    {
                        valoreValido = true;
                    }
                    else if (chiave == "Risoluzione" && (valore == "1920x1080" || valore == "1280x720"))
                    {
                        valoreValido = true;
                    }

                    if (!valoreValido)
                    {
                        Console.WriteLine($"Errore: valore non valido per la chiave '{chiave}'.");
                        Console.WriteLine("Valori validi per " + chiave + ":");
                        if (chiave == "Tema") Console.WriteLine("Chiaro, Scuro");
                        else if (chiave == "Lingua") Console.WriteLine("Italiano, Inglese");
                        else if (chiave == "Volume") Console.WriteLine("75%, 50%");
                        else if (chiave == "Risoluzione") Console.WriteLine("1920x1080, 1280x720");
                        break;
                    }

                    config.Imposta(chiave, valore);
                    Console.WriteLine("Configurazione aggiornata.");
                    break;

                case "2":
                    Console.Write("Inserisci chiave da leggere: ");
                    string daLeggere = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(daLeggere))
                    {
                        Console.WriteLine("Errore: la chiave non può essere vuota. Riprova.");
                        break;
                    }

                    string risultato = config.Leggi(daLeggere);
                    if (risultato == "Chiave non trovata")
                    {
                        Console.WriteLine("Chiave non trovata. Seleziona un'altra chiave.");
                    }
                    else
                    {
                        Console.WriteLine("Valore: " + risultato);
                    }
                    break;

                case "3":
                    config.StampaTutte();
                    break;

                case "4":
                    esci = true;
                    Console.WriteLine("Uscita dal programma.");
                    break;

                default:
                    Console.WriteLine("Scelta non valida. Riprova.");
                    break;
            }
        }
    }
}



