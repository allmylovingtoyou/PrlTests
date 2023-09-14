using System.Collections.Concurrent;
using System.Diagnostics;

namespace ConsoleApp1.Handlers;

internal static class TplHandler
{
    public static void WorkForEach(IReadOnlyCollection<Action> actions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"TplHandler - WorkForEach() - start, degreeOfParallelism = {degreeOfParallelism}");
        var options = new ParallelOptions { MaxDegreeOfParallelism = degreeOfParallelism };
        Parallel.ForEach<Action>(
            actions,
            options,
            action => { action.Invoke(); });
        stopwatch.Stop();
        Console.WriteLine($"TplHandler - WorkForEach() - end, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    public static void WorkForEach(IReadOnlyCollection<Func<int>> functions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"TplHandler - WorkForEach() - start, degreeOfParallelism = {degreeOfParallelism}");
        var options = new ParallelOptions { MaxDegreeOfParallelism = degreeOfParallelism };
        var result = new ConcurrentBag<int>();
        Parallel.ForEach(
            functions,
            options,
            func =>
            {
                int fResult = func.Invoke();
                result.Add(fResult);
            });
        stopwatch.Stop();
        Console.WriteLine($"TplHandler - WorkForEach() - end, resultSum = {result.Sum()}, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    public static async Task WorkForEachAsync(IReadOnlyCollection<Func<Task<int>>> functions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"TplHandler - WorkForEachAsync() - start, degreeOfParallelism = {degreeOfParallelism}");
        var options = new ParallelOptions { MaxDegreeOfParallelism = degreeOfParallelism };
        var result = new ConcurrentBag<int>();
        await Parallel.ForEachAsync(
            functions,
            options,
            async (func, ct) =>
            {
                int fResult = await func.Invoke();
                result.Add(fResult);
            });
        stopwatch.Stop();
        Console.WriteLine($"TplHandler - WorkForEachAsync() - end, resultSum = {result.Sum()}, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}