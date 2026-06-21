using System;

public class Logger
{
    public static void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }

    public static void Error(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }
}