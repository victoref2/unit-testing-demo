using System;
using System.IO;

public class Logger
{
    private readonly string logFilePath;

    public Logger()
    {
        string binPath = AppDomain.CurrentDomain.BaseDirectory;
        string logDirectory = Path.Combine(binPath, "Logs");
        Directory.CreateDirectory(logDirectory);
        logFilePath = Path.Combine(logDirectory, $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
    }

    public void Log(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFilePath, true))
        {
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }
}
