
public interface ILibreria
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify(Libro libro);
}

public sealed class GestoreLibreria : ILibreria
{
    private static GestoreLibreria _instance;

    public List<Libro> _listaLibro;
    private List<IObserver> _observers;

    private GestoreLibreria()
    {
        _listaLibro = new List<Libro>();
        _observers = new List<IObserver>();
    }

    public static GestoreLibreria GetInstance()
    {
        if (_instance == null)
        {
            _instance = new GestoreLibreria();
        }
        return _instance;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    // Rimuove un osservatore dalla lista
    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    // Invia una notizia a tutti gli osservatori registrati
    public void Notify(Libro libro)
    {
        // Notifica tutti gli osservatori nella lista
        foreach (var observer in _observers)
        {
            observer.Update(libro.descrizioneLibro());
        }
    }

    public void StampaLibreria()
    {
        foreach (Libro o in _listaLibro)
        {
            Console.WriteLine(o);
        }
    }

    public void StampaUtenti()
    {
        int count = 0;
        foreach (Utente u in _observers)
        {
            Console.WriteLine($"[{count}] {u.Nome}");
            count++;
        }
    }

    public void AggiungiLibro(Libro libro)
    {
        _listaLibro.Add(libro);
    }

    public void RimuoviLibro(Libro libro)
    {
        _listaLibro.Remove(libro);
    }

}

