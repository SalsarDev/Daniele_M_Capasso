using System;
using System.Collections.Generic;

// Observer
public interface INewsSubscriber
{
    void Update(string news);
}

public class NewsAgency
{
    private static NewsAgency _instance;
    private string _news;
    private List<INewsSubscriber> _subscribers = new List<INewsSubscriber>();

    // Singleton
    private NewsAgency() { }

    public static NewsAgency GetInstance()
    {
        if (_instance == null)
            _instance = new NewsAgency();
        return _instance;
    }

    public void Subscribe(INewsSubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(INewsSubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public string News
    {
        get => _news;
        set
        {
            _news = value;
            NotifySubscribers();
        }
    }

    private void NotifySubscribers()
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(_news);
        }
    }
}

// 1
public class MobileApp : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine("Notification on mobile: " + news);
    }
}

// 2
public class EmailClient : INewsSubscriber
{
    public void Update(string news)
    {
        Console.WriteLine("Email sent: " + news);
    }
}


class Program
{
    static void Main()
    {
        var agency = NewsAgency.GetInstance();

        var mobile = new MobileApp();
        var email = new EmailClient();

        agency.Subscribe(mobile);
        agency.Subscribe(email);

        agency.News = "Breaking News:";
    }
}

