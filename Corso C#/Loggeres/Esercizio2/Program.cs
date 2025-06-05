using System;

enum LivelloAccesso
{
    Ospite,
    Utente,
    Amministratore
}

class Program
{
    static void Main()
    {
        StampaPrivilegi(LivelloAccesso.Utente);
    }

    static void StampaPrivilegi(LivelloAccesso livello)
    {
        switch (livello)
        {
            case LivelloAccesso.Ospite:
                Console.WriteLine("Accesso limitato. Solo lettura.");
                break;
            case LivelloAccesso.Utente:
                Console.WriteLine("Accesso completo ai contenuti.");
                break;
            case LivelloAccesso.Amministratore:
                Console.WriteLine("Accesso completo e gestione del sistema.");
                break;
        }
    }
}
