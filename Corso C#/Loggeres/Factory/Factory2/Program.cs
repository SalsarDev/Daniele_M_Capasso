using System;

public interface IShape
{
    void Draw();
}

public class CircleShape : IShape
{
    public void Draw()
    {
        Console.WriteLine("Sto disegnando un cerchio.");
    }
}

public class SquareShape : IShape
{
    public void Draw()
    {
        Console.WriteLine("Sto disegnando un quadrato.");
    }
}

public abstract class ShapeFactory
{
    public abstract IShape Create();
}

public class CircleFactory : ShapeFactory
{
    public override IShape Create()
    {
        return new CircleShape();
    }
}

public class SquareFactory : ShapeFactory
{
    public override IShape Create()
    {
        return new SquareShape();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Inserisci la forma da disegnare (circle/square):");
        string input = Console.ReadLine().ToLower();

        ShapeFactory factory;

        if (input == "circle")
        {
            factory = new CircleFactory();
        }
        else if (input == "square")
        {
            factory = new SquareFactory();
        }
        else
        {
            Console.WriteLine("Forma non riconosciuta.");
            return;
        }

        IShape shape = factory.Create();
        shape.Draw();
    }
}
