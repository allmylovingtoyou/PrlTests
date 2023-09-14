namespace ConsoleApp1;

internal static class Work
{
    public static List<Action> VoidTasks = new List<Action>
    {
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(2)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(4)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(2)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(2)).Wait(),
        () => Task.Delay(TimeSpan.FromSeconds(1)).Wait()
    };

    public static readonly List<Func<int>> SyncFunc = new List<Func<int>>
    {
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(4)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(1)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(2)).Wait();

            return 1;
        },
        () =>
        {
            Task.Delay(TimeSpan.FromSeconds(3)).Wait();

            return 1;
        }
    };

    public static readonly List<Func<Task<int>>> AsyncFunc = new List<Func<Task<int>>>
    {
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(4));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return 1;
        },
        async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(3));

            return 1;
        }
    };
}