using System;
using System.Collections.Generic;

// Interfaccia Principale
public interface IPizza
{
    string Descrizione();
}

// Factory

public static class PizzaFactory
{
    public static IPizza CreaPizza(string tipo)
    {
        return tipo.ToLower() switch
        {
            "margherita" => new Margherita(),
            "diavola" => new Diavola(),
            "vegetariana" => new Vegetariana(),
            _=>throw new ArgumentException("Tipo pizza non riconosciuto")
        };
    }
}

public class Margherita : IPizza
{
    public string Descrizione() => "Pizza Margherita";
}

public class Diavola : IPizza
{
    public string Descrizione() => "Pizza Diavola";
}

public class Vegetariana : IPizza
{
    public string Descrizione() => "Pizza Vegetariana";
}

// Decorator

public abstract class IngredienteDecorator : IPizza
{
    protected IPizza pizza;

    public IngredienteDecorator(IPizza pizza)
    {
        this.pizza = pizza;
    }

    public abstract string Descrizione();
}

public class ConOlive : IngredienteDecorator
{
    public ConOlive(IPizza pizza) : base(pizza) { }

    public override string Descrizione() => pizza.Descrizione() + ", Olive";
}

public class ConMozzarellaExtra : IngredienteDecorator
{
    public ConMozzarellaExtra(IPizza pizza) : base(pizza) { }

    public override string Descrizione() => pizza.Descrizione() + ", Mozzarella Extra";
}

public class ConFunghi : IngredienteDecorator
{
    public ConFunghi(IPizza pizza) : base(pizza) { }

    public override string Descrizione() => pizza.Descrizione() + ", Funghi";
}

// Strategy

public interface IMetodoCottura
{
    string Cuoci(string pizza);
}

public class FornoElettrico : IMetodoCottura
{
    public string Cuoci(string pizza) => $"Cuocio la {pizza} nel forno elettrico.";
}

public class FornoLegna : IMetodoCottura
{
    public string Cuoci(string pizza) => $"Cuocio la {pizza} nel forno a legna.";
}

public class FornoVentilato : IMetodoCottura
{
    public string Cuoci(string pizza) => $"Cuocio la {pizza} nel forno ventilato.";
}

// Observer

public interface IObserver
{
    void Aggiorna(string ordine);
}

public class SistemaLog : IObserver
{
    public void Aggiorna(string ordine)
    {
        Console.WriteLine($"Nuovo ordine creato: {ordine}");
    }
}

public class SistemaMarketing : IObserver
{
    public void Aggiorna(string ordine)
    {
        Console.WriteLine($"Promozione inviata per ordine: {ordine}");
    }
}

public interface ISubject
{
    void AggiungiObserver(IObserver observer);
    void RimuoviObserver(IObserver observer);
    void NotificaObservers();
}

// Singleton

public sealed class GestoreOrdine : ISubject
{
    private static GestoreOrdine instance = null;
    private static readonly object lock1 = new object();

    private List<IObserver> observers = new List<IObserver>();
    private string ordineCorrente;

    private GestoreOrdine() { }

    public static GestoreOrdine Instance
    {
        get
        {
            lock (lock1)
            {
                if (instance == null)
                {
                    instance = new GestoreOrdine();
                }
                return instance;
            }
        }
    }

    public void AggiungiObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RimuoviObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void CreaOrdine(string pizza)
    {
        ordineCorrente = pizza;
        Console.WriteLine($"Ordine creato: {ordineCorrente}");
        NotificaObservers();
    }

    public void StampaOrdine()
    {
        Console.WriteLine($"Ordine attuale: {ordineCorrente}");
    }

    public void NotificaObservers()
    {
        foreach (var observer in observers)
        {
            observer.Aggiorna(ordineCorrente);
        }
    }
}

// Main

class Program
{
    static void Main(string[] args)
    {
        // Scelta pizza 
        Console.WriteLine("Scegli la pizza : Margherita, Diavola, Vegetariana");
        string tipoPizza = Console.ReadLine();

        IPizza pizza = PizzaFactory.CreaPizza(tipoPizza);

        // Aggiunta ingredienti extra
        Console.WriteLine("Aggiungi ingredienti extra? (olive, mozzarella, funghi)");
        string extra = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(extra) && extra.ToLower() != "no")
        {
            string[] ingredienti = extra.Split(',');

            foreach (var ing in ingredienti)
            {
                switch (ing.Trim().ToLower())
                {
                    case "olive":
                        pizza = new ConOlive(pizza);
                        break;
                    case "mozzarella":
                        pizza = new ConMozzarellaExtra(pizza);
                        break;
                    case "funghi":
                        pizza = new ConFunghi(pizza);
                        break;
                    default:
                        Console.WriteLine($"Ingrediente {ing.Trim()} non riconosciuto.");
                        break;
                }
            }
        }

        // Scelta metodo cottura
        Console.WriteLine("Scegli metodo di cottura: FornoElettrico, FornoLegna, FornoVentilato");
        string metodoCotturaScelto = Console.ReadLine();

        IMetodoCottura metodoCottura = metodoCotturaScelto.ToLower() switch
        {
            "fornoelettrico" => new FornoElettrico(),
            "fornolegna" => new FornoLegna(),
            "fornoventilato" => new FornoVentilato(),
            _=>throw new ArgumentException("Metodo di cottura non riconosciuto")
        };

        // Ordine
        GestoreOrdine gestore = GestoreOrdine.Instance;

        // Observer
        gestore.AggiungiObserver(new SistemaLog());
        gestore.AggiungiObserver(new SistemaMarketing());

        string descrizionePizza = pizza.Descrizione();

        // Cucina la pizza
        string risultatoCottura = metodoCottura.Cuoci(descrizionePizza);
        Console.WriteLine(risultatoCottura);

        // Crea ordine
        gestore.CreaOrdine(descrizionePizza);

        // Stampa ordine
        gestore.StampaOrdine();
    }
}

