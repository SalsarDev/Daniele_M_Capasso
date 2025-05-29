using System;
using System.Collections.Generic;

public sealed class Logger
{
    private static Logger instance;

    private List<string> logs = new List<string>();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Logger();
            }
            return instance;
        }
    }

    public void Log(string message)
    {
        logs.Add(message);
    }

    public List<string> GetLogs()
    {
        return logs;
    }
}

class Program
{
    static void Main()
    {
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;

        logger1.Log("Messaggio 1:");
        logger2.Log("Messaggio 2:");

        Console.WriteLine("Log:");
        foreach (var log in Logger.Instance.GetLogs())
        {
            Console.WriteLine(log);
        }
    }
}
