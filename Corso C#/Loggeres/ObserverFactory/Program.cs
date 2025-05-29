using System;
using System.Collections.Generic;

class SistemaUtentiObserver
{
    public interface IObserver
    {
        void NotificaCreazione(string nomeUtente);
    }

    public interface ISoggetto
    {
        void Registra(IObserver o);
        void Rimuovi(IObserver o);
        void Notifica(string nomeUtente);
    }

    public class GestoreCreazioneUtente : ISoggetto
    {
        private List<IObserver> observers = new List<IObserver>();
        private List<Utente> utenti = new List<Utente>();

        public void Registra(IObserver o)
        {
            observers.Add(o);
        }

        public void Rimuovi(IObserver o)
        {
            observers.Remove(o);
        }

        public void Notifica(string nomeUtente)
        {
            foreach (var o in observers)
            {
                o.NotificaCreazione(nomeUtente);
            }
        }

        public void CreaUtente(string nome)
        {
            Utente nuovoUtente = UserFactory.Crea(nome);
            utenti.Add(nuovoUtente);
            Console.WriteLine($"Utente creato: {nuovoUtente}");
            Notifica(nome);
        }

        public void VisualizzaUtenti()
        {
            Console.WriteLine("Utenti registrati");
            if (utenti.Count == 0)
                Console.WriteLine("Nessun utente registrato.");
            else
                foreach (var u in utenti)
                    Console.WriteLine(u);
        }
    }

    public static class UserFactory
    {
        public static Utente Crea(string nome)
        {
            return new Utente(nome);
        }
    }

    public class Utente
    {
        public string Nome { get; private set; }

        public Utente(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Nome utente: {Nome}";
        }
    }

    public class ModuloLog : IObserver
    {
        public void NotificaCreazione(string nomeUtente)
        {
            Console.WriteLine($"Utente creato: {nomeUtente}");
        }
    }

    public class ModuloMarketing : IObserver
    {
        public void NotificaCreazione(string nomeUtente)
        {
            Console.WriteLine($"Nuovo utente registrato: {nomeUtente}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GestoreCreazioneUtente gestore = new GestoreCreazioneUtente();
            gestore.Registra(new ModuloLog());
            gestore.Registra(new ModuloMarketing());

            Console.WriteLine("Scrivi il nome di un nuovo utente da creare");
            Console.WriteLine("Scrivi 'mostra' per visualizzare tutti gli utenti registrati.");
            Console.WriteLine("Lascia vuoto per uscire.");

            while (true)
            {
                Console.Write("Comando o nome utente: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                else if (input.ToLower() == "mostra")
                    gestore.VisualizzaUtenti();
                else
                    gestore.CreaUtente(input);
            }

            Console.WriteLine("Programma terminato.");
        }
    }
}



