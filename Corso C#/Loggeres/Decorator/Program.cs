using System;

public interface IBevanda
{
    string Descrizione();
    double Costo();
}

public class Caffe : IBevanda
{
    public string Descrizione() => "Caffè";
    public double Costo() => 1.0;
}

public class Te : IBevanda
{
    public string Descrizione() => "Tè";
    public double Costo() => 0.8;
}

public abstract class DecoratoreBevanda : IBevanda
{
    protected IBevanda bevanda;
    public DecoratoreBevanda(IBevanda bevanda) => this.bevanda = bevanda;
    public abstract string Descrizione();
    public abstract double Costo();
}

public class ConLatte : DecoratoreBevanda
{
    public ConLatte(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() => bevanda.Descrizione() + " + Latte";
    public override double Costo() => bevanda.Costo() + 0.3;
}

public class ConCioccolato : DecoratoreBevanda
{
    public ConCioccolato(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() => bevanda.Descrizione() + " + Cioccolato";
    public override double Costo() => bevanda.Costo() + 0.5;
}

public class ConPanna : DecoratoreBevanda
{
    public ConPanna(IBevanda bevanda) : base(bevanda) { }
    public override string Descrizione() => bevanda.Descrizione() + " + Panna";
    public override double Costo() => bevanda.Costo() + 0.4;
}

class Program
{
    static void Main(string[] args)
    {
        IBevanda bevanda = new Caffe();
        bevanda = new ConLatte(bevanda);
        bevanda = new ConCioccolato(bevanda);
        bevanda = new ConPanna(bevanda);
        Console.WriteLine("Ordine: " + bevanda.Descrizione());
        Console.WriteLine("Costo totale: " + bevanda.Costo().ToString("0.00") + " €");
    }
}

