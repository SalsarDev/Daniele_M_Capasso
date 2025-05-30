using System;

public class Program
{
    public static void Main()
    {
        GestoreLibreria gestore = GestoreLibreria.GetInstance();
        bool continua = true;

        Console.WriteLine("=== SISTEMA GESTIONE LIBRERIA ===");

        while (continua)
        {
            Console.WriteLine("\n--- MENU PRINCIPALE ---");
            Console.WriteLine("1. Aggiungi libro");
            Console.WriteLine("2. Cerca libro");
            Console.WriteLine("3. Aggiungi Utente");
            Console.WriteLine("4. Rimuovi Utente");
            Console.WriteLine("4. Visualizza tutta la libreria");
            Console.WriteLine("0. Esci");
            Console.Write("Scegli un'opzione (1-5): ");

            string scelta = Console.ReadLine();

            switch (scelta)
            {
                case "1":
                    AggiungiLibro(gestore);
                    break;
                case "2":
                    CercaLibro(gestore);
                    break;
                case "3":
                    AggiungiUtente(gestore);
                    break;
                case "4":

                    break;
                case "5":
                    gestore.StampaLibreria();
                    break;
                case "0":
                    continua = false;
                    Console.WriteLine("Arrivederci!");
                    break;
                default:
                    Console.WriteLine("Opzione non valida. Riprova.");
                    break;
            }
        }
    }
    private static void AggiungiLibro(GestoreLibreria gestore)
    {
        Console.WriteLine("\n--- AGGIUNGI LIBRO ---");
        Console.Write("Inserisci il titolo: ");
        string titolo = Console.ReadLine();

        Console.Write("Inserisci l'autore: ");
        string autore = Console.ReadLine();

        Console.Write("Inserisci l'anno di uscita: ");
        if (int.TryParse(Console.ReadLine(), out int anno))
        {
            Console.WriteLine("Scegli il tipo di libro:");
            Console.WriteLine("1. Fantasy");
            Console.WriteLine("2. Avventura");
            Console.WriteLine("3. Horror");
            Console.Write("Tipo (1-3): ");

            string tipoScelta = Console.ReadLine();
            string tipo = "";

            switch (tipoScelta)
            {
                case "1":
                    tipo = "fantasy";
                    break;
                case "2":
                    tipo = "avventura";
                    break;
                case "3":
                    tipo = "horror";
                    break;
                default:
                    Console.WriteLine("Tipo non valido.");
                    return;
            }

            try
            {
                Libro libro = CreazioneLibri.Libri(tipo, titolo, anno, autore);
                gestore.AggiungiLibro(libro);
                gestore.Notify(libro);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore nell'aggiunta del libro: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Anno non valido.");
        }
    }

    private static void CercaLibro(GestoreLibreria gestore)
    {
        Console.WriteLine("\n--- CERCA LIBRO ---");
        Console.WriteLine("Cerca per:");
        Console.WriteLine("1. Titolo");
        Console.WriteLine("2. Autore");
        Console.WriteLine("3. Anno");
        Console.Write("Scegli criterio di ricerca (1-3): ");

        string criterio = Console.ReadLine();

        switch (criterio)
        {
            case "1":
                Console.Write("Inserisci il titolo: ");
                string titolo = Console.ReadLine();
                StampaLibri(CercaLibriPerTitolo(titolo, gestore));
                break;
            case "2":
                Console.Write("Inserisci l'autore: ");
                string autore = Console.ReadLine();
                StampaLibri(CercaLibriPerAutore(autore, gestore));
                break;
            case "3":
                Console.Write("Inserisci l'anno: ");
                int anno = int.Parse(Console.ReadLine());
                StampaLibri(CercaLibriPerAnno(anno, gestore));
                break;
            default:
                Console.WriteLine("Criterio non valido.");
                break;
        }
    }
    public static void AggiungiUtente(GestoreLibreria gestore)
    {
        Console.WriteLine("Inserisci il nome dell'utente da aggiungere: ");
        string nome = Console.ReadLine();

        var utente = new Utente(nome);
        gestore.Attach(utente);
    }

    public static void RimuoviUtente(GestoreLibreria gestore)
    {
    }

    public static List<Libro> CercaLibriPerTitolo(string titolo, GestoreLibreria gestore)
    {
        List<Libro> risultati = new List<Libro>();
        string titoloMinuscolo = titolo.ToLower();

        foreach (Libro libro in gestore._listaLibro)
        {
            if (libro.titolo.ToLower().Contains(titoloMinuscolo))
            {
                risultati.Add(libro);
            }
        }
        return risultati;
    }

    public static List<Libro> CercaLibriPerAutore(string autore, GestoreLibreria gestore)
    {
        List<Libro> risultati = new List<Libro>();
        string autoreMinuscolo = autore.ToLower();

        foreach (Libro libro in gestore._listaLibro)
        {
            if (libro.autore.ToLower().Contains(autoreMinuscolo))
            {
                risultati.Add(libro);
            }
        }
        return risultati;
    }

    public static List<Libro> CercaLibriPerAnno(int anno, GestoreLibreria gestore)
    {
        List<Libro> risultati = new List<Libro>();

        foreach (Libro libro in gestore._listaLibro)
        {
            if (libro.annoUscita == anno)
            {
                risultati.Add(libro);
            }
        }
        return risultati;
    }

    public static void StampaLibri(List<Libro> lista)
    {
        foreach (Libro l in lista)
        {
            Console.WriteLine(l.descrizioneLibro());
        }
    }
}