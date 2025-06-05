using System;

enum GiornoSettimana
{
    Lunedi,
    Martedi,
    Mercoledi,
    Giovedi,
    Venerdi,
    Sabato,
    Domenica
}

class Program
{
    static void Main()
    {
        GiornoSettimana oggi = GiornoSettimana.Martedi;

        switch (oggi)
        {
            case GiornoSettimana.Lunedi:
                Console.WriteLine("Inizia la settimana!");
                break;
            case GiornoSettimana.Martedi:
                Console.WriteLine("Secondo giorno della settimana.");
                break;
            case GiornoSettimana.Mercoledi:
                Console.WriteLine("Metà settimana.");
                break;
            case GiornoSettimana.Giovedi:
                Console.WriteLine("Quasi venerdì.");
                break;
            case GiornoSettimana.Venerdi:
                Console.WriteLine("Ultimo giorno lavorativo!");
                break;
            case GiornoSettimana.Sabato:
                Console.WriteLine("Relax del weekend.");
                break;
            case GiornoSettimana.Domenica:
                Console.WriteLine("Riposo domenicale.");
                break;
        }
    }
}
