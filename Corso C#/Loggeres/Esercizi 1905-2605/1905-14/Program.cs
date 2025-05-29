using System;
using System.Collections.Generic;

abstract class Corso
{
    public string Titolo { get; set; }
    public int DurataOre { get; set; }
    public Docente Insegnante { get; set; } 

    public abstract void ErogaCorso();
    public abstract void StampaDettagli();
}

class CorsoInPresenza : Corso
{
    public string Aula { get; set; }
    public int NumeroPosti { get; set; }

    public override void ErogaCorso()
    {
        Console.WriteLine($"Corso in presenza: {Titolo} in aula {Aula}");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Dettagli Corso in Presenza: {Titolo}, Durata: {DurataOre} ore, Aula: {Aula}, Posti disponibili: {NumeroPosti}, Insegnante: {Insegnante.Nome}");
    }
}

class CorsoOnline : Corso
{
    public string Piattaforma { get; set; }
    public string LinkAccesso { get; set; }

    public override void ErogaCorso()
    {
        Console.WriteLine($"Corso online: {Titolo} su {Piattaforma}");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Dettagli Corso Online: {Titolo}, Durata: {DurataOre} ore, Piattaforma: {Piattaforma}, Link: {LinkAccesso}, Insegnante: {Insegnante.Nome}");
    }
}

class Docente
{
    public string Nome { get; private set; }
    public string Materia { get; private set; }

    public Docente(string nome, string materia)
    {
        Nome = nome;
        Materia = materia;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Corso> corsi = new List<Corso>();
        
        while (true)
        {
            Console.WriteLine("1. Aggiungi Corso in Presenza");
            Console.WriteLine("2. Aggiungi Corso Online");
            Console.WriteLine("3. Esci");
            Console.Write("Scegli un'opzione: ");
            string scelta = Console.ReadLine();

            if (scelta == "3") break;

            Console.Write("Inserisci il titolo del corso: ");
            string titolo = Console.ReadLine();
            Console.Write("Inserisci la durata (ore): ");
            int durataOre = int.Parse(Console.ReadLine());

            Console.Write("Inserisci il nome del docente: ");
            string nomeDocente = Console.ReadLine();
            Console.Write("Inserisci la materia del docente: ");
            string materiaDocente = Console.ReadLine();
            Docente docente = new Docente(nomeDocente, materiaDocente);

            Corso corso = null;

            if (scelta == "1")
            {
                Console.Write("Inserisci l'aula: ");
                string aula = Console.ReadLine();
                Console.Write("Inserisci il numero di posti: ");
                int numeroPosti = int.Parse(Console.ReadLine());

                corso = new CorsoInPresenza
                {
                    Titolo = titolo,
                    DurataOre = durataOre,
                    Aula = aula,
                    NumeroPosti = numeroPosti,
                    Insegnante = docente
                };
            }
            else if (scelta == "2")
            {
                Console.Write("Inserisci la piattaforma: ");
                string piattaforma = Console.ReadLine();
                Console.Write("Inserisci il link di accesso: ");
                string linkAccesso = Console.ReadLine();

                corso = new CorsoOnline
                {
                    Titolo = titolo,
                    DurataOre = durataOre,
                    Piattaforma = piattaforma,
                    LinkAccesso = linkAccesso,
                    Insegnante = docente
                };
            }

            if (corso != null)
            {
                corsi.Add(corso);
                Console.WriteLine("Corso aggiunto con successo!");
            }
        }

        Console.WriteLine("Dettagli corsi:");
        foreach (var corso in corsi)
        {
            corso.ErogaCorso();
            corso.StampaDettagli();
        }
    }
}