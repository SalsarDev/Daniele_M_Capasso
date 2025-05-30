public interface IObserver
{
    void Update(string message);
}

// CLASSE UTENTE CHE IMPLEMENTA IObserver
public class Utente : IObserver
{
    public string Nome { get; private set; }

    public Utente(string nome)
    {
        Nome = nome;
    }

    public void Update(string message)
    {
        Console.WriteLine($"NOTIFICA per {Nome}: {message}");
    }
}
