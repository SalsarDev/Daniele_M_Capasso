using System;

class PiattoInfo
{
    //IPiatto
    public interface IPiatto
    {
        string Info();
        string Preparazione();
    }

    // Classi Piatto base
    public class Pizza : IPiatto
    {
        public string Info() => "Pizza";
        public string Preparazione() => "Preparazione non definita";
    }

    public class Hamburger : IPiatto
    {
        public string Info() => "Hamburger";
        public string Preparazione() => "Preparazione non definita";
    }

    public class Insalata : IPiatto
    {
        public string Info() => "Insalata";
        public string Preparazione() => "Preparazione non definita";
    }

    // Decorator abstract
    public abstract class IngredienteExtra : IPiatto
    {
        protected IPiatto _piatto;

        protected IngredienteExtra(IPiatto piatto)
        {
            _piatto = piatto;
        }

        public virtual string Info() => _piatto.Info();
        public virtual string Preparazione() => _piatto.Preparazione();
    }

    // Decorators
    public class ConFormaggio : IngredienteExtra
    {
        public ConFormaggio(IPiatto piatto) : base(piatto) { }

        public override string Info() => _piatto.Info() + " con formaggio";
    }

    public class ConBacon : IngredienteExtra
    {
        public ConBacon(IPiatto piatto) : base(piatto) { }

        public override string Info() => _piatto.Info() + " con bacon";
    }

    public class ConSalsa : IngredienteExtra
    {
        public ConSalsa(IPiatto piatto) : base(piatto) { }

        public override string Info() => _piatto.Info() + " con salsa";
    }

    // Factory per creare i piatti
    public static class PiattoFactory
    {
        public static IPiatto Crea(string tipo)
        {
            return tipo.ToLower() switch
            {
                "pizza" => new Pizza(),
                "hamburger" => new Hamburger(),
                "insalata" => new Insalata(),
                _ => throw new ArgumentException("Tipo di piatto non valido")
            };
        }
    }

    // Interfaccia strategia preparazione
    public interface IPreparazioneStrategia
    {
        string Preparazione(string info);
    }

    // Strategie
    public class Fritto : IPreparazioneStrategia
    {
        public string Preparazione(string info) => $"{info} è stato fritto.";
    }

    public class AlForno : IPreparazioneStrategia
    {
        public string Preparazione(string info) => $"{info} è stato cotto al forno.";
    }

    public class AllaGriglia : IPreparazioneStrategia
    {
        public string Preparazione(string info) => $"{info} è stato grigliato.";
    }

    // Classe Chef
    public class Chef
    {
        private IPreparazioneStrategia _strategia;

        public Chef(IPreparazioneStrategia strategia)
        {
            _strategia = strategia;
        }

        public void ImpostaStrategia(IPreparazioneStrategia strategia)
        {
            _strategia = strategia;
        }

        public string PreparaPiatto(IPiatto piatto)
        {
            return _strategia.Preparazione(piatto.Info());
        }
    }

    // Programma principale
    public class Program
    {
        public static void Main()
        {
            // Creazione piatto base
            IPiatto piatto = PiattoFactory.Crea("pizza");

            // Aggiunta ingredienti
            piatto = new ConFormaggio(piatto);
            piatto = new ConBacon(piatto);
            piatto = new ConSalsa(piatto);

            // Strategia
            IPreparazioneStrategia strategia = new AlForno();
            Chef chef = new Chef(strategia);

            Console.WriteLine("Descrizione: " + piatto.Info());
            Console.WriteLine("Preparazione: " + chef.PreparaPiatto(piatto));
        }
    }
}
