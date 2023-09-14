using System.Diagnostics;

namespace ConsoleApp1.Handlers;

internal static class SerialHandler
{
    public static void Work(IReadOnlyCollection<Action> actions)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"SerialHandler - Work() - start");
        foreach (Action action in actions)
        {
            action.Invoke();
        }

        stopwatch.Stop();
        Console.WriteLine($"SerialHandler - Work() - end, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}