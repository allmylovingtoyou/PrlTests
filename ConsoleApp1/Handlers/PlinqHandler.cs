using System.Diagnostics;

namespace ConsoleApp1.Handlers;

internal static class PlinqHandler
{
    public static void Work(IReadOnlyCollection<Action> actions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"PlinqHandler - Work() - start, degreeOfParallelism = {degreeOfParallelism}");
        actions
            .AsParallel()
            .WithDegreeOfParallelism(degreeOfParallelism)
            .ForAll(x => x.Invoke());
        stopwatch.Stop();
        Console.WriteLine($"PlinqHandler - Work() - end, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    public static void Work(IReadOnlyCollection<Func<int>> functions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"PlinqHandler - Work() - start, degreeOfParallelism = {degreeOfParallelism}");
        int[] result = functions
            .AsParallel()
            .WithDegreeOfParallelism(degreeOfParallelism)
            .Select(x => x.Invoke())
            .ToArray();
        stopwatch.Stop();
        Console.WriteLine($"PlinqHandler - Work() - end, resultSum = {result.Sum()}, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    public static async Task WorkAsyncBad(IReadOnlyCollection<Func<Task<int>>> functions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"PlinqHandler - WorkAsyncBad() - start, degreeOfParallelism = {degreeOfParallelism}");
        Task<int>[] tasks = functions
            .AsParallel()
            .WithDegreeOfParallelism(degreeOfParallelism)
            .Select(x => x.Invoke())
            .ToArray();

        int[] result = await Task.WhenAll(tasks);
        stopwatch.Stop();
        Console.WriteLine($"PlinqHandler - WorkAsyncBad() - end, resultSum = {result.Sum()}, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }

    public static async Task WorkAsyncSem(IReadOnlyCollection<Func<Task<int>>> functions, int degreeOfParallelism)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Console.WriteLine($"PlinqHandler - WorkAsyncSem() - start, degreeOfParallelism = {degreeOfParallelism}");
        var semaphore = new SemaphoreSlim(initialCount: degreeOfParallelism);
        Task<int>[] tasks = functions
            .AsParallel()
            // .WithDegreeOfParallelism(degreeOfParallelism)
            .Select(async x =>
            {
                await semaphore.WaitAsync();
                int result = await x.Invoke();
                semaphore.Release();

                return result;
            })
            .ToArray();

        int[] result = await Task.WhenAll(tasks);
        stopwatch.Stop();
        Console.WriteLine($"PlinqHandler - WorkAsyncSem() - end, resultSum = {result.Sum()}, time = {stopwatch.ElapsedMilliseconds} ms");
        Console.WriteLine();
    }
}