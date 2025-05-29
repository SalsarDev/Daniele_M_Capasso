using System;
using System.Collections.Generic;

namespace VeicoliApp
{
    public interface IVeicolo
    {
        void Avvia();
        void MostraTipo();
    }

    public class Auto : IVeicolo
    {
        public void Avvia() => Console.WriteLine("L'auto parte");
        public void MostraTipo() => Console.WriteLine("Veicolo: Auto");
    }

    public class Moto : IVeicolo
    {
        public void Avvia() => Console.WriteLine("La moto parte.");
        public void MostraTipo() => Console.WriteLine("Veicolo: Moto");
    }

    public class Camion : IVeicolo
    {
        public void Avvia() => Console.WriteLine("Il camion parte");
        public void MostraTipo() => Console.WriteLine("Veicolo: Camion");
    }

    public static class VeicoloFactory
    {
        public static IVeicolo CreaVeicolo(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "auto": return new Auto();
                case "moto": return new Moto();
                case "camion": return new Camion();
                default: throw new ArgumentException("Tipo di veicolo non riconosciuto.");
            }
        }
    }

    public sealed class RegistroVeicoli
    {
        private static RegistroVeicoli istanza = null;

        private List<Auto> autoList;
        private List<Moto> motoList;
        private List<Camion> camionList;

        private RegistroVeicoli()
        {
            autoList = new List<Auto>();
            motoList = new List<Moto>();
            camionList = new List<Camion>();
        }

        public static RegistroVeicoli Istanza
        {
            get
            {
                if (istanza == null)
                    istanza = new RegistroVeicoli();
                return istanza;
            }
        }

        public void Registra(IVeicolo veicolo)
        {
            switch (veicolo)
            {
                case Auto a: autoList.Add(a); break;
                case Moto m: motoList.Add(m); break;
                case Camion c: camionList.Add(c); break;
            }
        }

        public void StampaTutti()
        {
            Console.WriteLine("Veicoli Registrati");

            Console.WriteLine("Auto:");
            foreach (var a in autoList) a.MostraTipo();

            Console.WriteLine("Moto:");
            foreach (var m in motoList) m.MostraTipo();

            Console.WriteLine("Camion:");
            foreach (var c in camionList) c.MostraTipo();
        }

        public void StampaPerTipo(string tipo)
        {
            Console.WriteLine($"\n--- Veicoli di tipo: {tipo} ---");

            switch (tipo.ToLower())
            {
                case "auto":
                    foreach (var a in autoList) a.MostraTipo();
                    break;
                case "moto":
                    foreach (var m in motoList) m.MostraTipo();
                    break;
                case "camion":
                    foreach (var c in camionList) c.MostraTipo();
                    break;
                default:
                    Console.WriteLine("Tipo di veicolo non riconosciuto.");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Crea un veicolo (Auto, Moto, Camion)");
                Console.WriteLine("2. Mostra tutti i veicoli");
                Console.WriteLine("3. Mostra veicoli di un tipo specifico");
                Console.WriteLine("4. Esci");

                Console.Write("Scelta: ");
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        Console.Write("Inserisci il tipo di veicolo da creare: ");
                        string tipo = Console.ReadLine();
                        try
                        {
                            IVeicolo veicolo = VeicoloFactory.CreaVeicolo(tipo);
                            veicolo.Avvia();
                            RegistroVeicoli.Istanza.Registra(veicolo);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        RegistroVeicoli.Istanza.StampaTutti();
                        break;

                    case "3":
                        Console.Write("Inserisci il tipo di veicolo da mostrare (Auto, Moto, Camion): ");
                        string tipoDaMostrare = Console.ReadLine();
                        RegistroVeicoli.Istanza.StampaPerTipo(tipoDaMostrare);
                        break;

                    case "4":
                        Console.WriteLine("Uscita dal programma.");
                        return;

                    default:
                        Console.WriteLine("Scelta non valida.");
                        break;
                }
            }
        }
    }
}


