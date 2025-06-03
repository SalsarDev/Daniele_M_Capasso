using System;

public interface INotifier
{
    void Send(string message);
}

public class SmsNotifier : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine($"Messaggio inviato: {message}");
    }
}

public class AlertService
{
    public void SendAlert(string message, INotifier notifier)
    {
        notifier.Send(message);
    }
}

public class Program
{
    public static void Main()
    {
        var alertService = new AlertService();
        var smsNotifier = new SmsNotifier();

        alertService.SendAlert("Allarme attivato!", smsNotifier);
    }
}
