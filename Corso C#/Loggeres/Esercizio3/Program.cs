using System;

enum TipoTransazione
{
    Acquisto,
    Rimborso,
    Trasferimento
}

class Program
{
    static void Main()
    {
        CalcolaCommissione(TipoTransazione.Acquisto, 100);
    }

    static void CalcolaCommissione(TipoTransazione tipo, decimal importo)
    {
        decimal commissione = 0;

        switch (tipo)
        {
            case TipoTransazione.Acquisto:
                commissione = importo * 0.05m;
                break;
            case TipoTransazione.Rimborso:
                commissione = importo * 0.02m;
                break;
            case TipoTransazione.Trasferimento:
                commissione = importo * 0.03m;
                break;
        }

        Console.WriteLine($"Commissione per {tipo}: {commissione} euro");
    }
}
