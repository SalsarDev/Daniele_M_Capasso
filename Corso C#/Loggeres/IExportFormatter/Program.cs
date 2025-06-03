using System;

public class Data
{
    public string Content { get; set; }
}

public interface IExportFormatter
{
    string Format(Data data);
}

public class JsonFormatter : IExportFormatter
{
    public string Format(Data data)
    {
        return $"\"{data.Content}\""; // Solo il contenuto
    }
}

public class XmlFormatter : IExportFormatter
{
    public string Format(Data data)
    {
        return $"{data.Content}"; // Solo il contenuto come tag
    }
}

public class DataExporter
{
    public void Export(Data data, IExportFormatter formatter)
    {
        string formatted = formatter.Format(data);
        Console.WriteLine("Esportazione:");
        Console.WriteLine(formatted);
    }
}

public class Program
{
    public static void Main()
    {
        var data = new Data { Content = "Esempio di contenuto" };
        var exporter = new DataExporter();

        var jsonFormatter = new JsonFormatter();
        var xmlFormatter = new XmlFormatter();

        exporter.Export(data, jsonFormatter);
        exporter.Export(data, xmlFormatter);
    }
}
