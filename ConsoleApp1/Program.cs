// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

using ConsoleApp1;
using ConsoleApp1.Handlers;

Console.WriteLine("Hello, World!");


//Actions
// SerialHandler.Work(Work.VoidTasks);
// PlinqHandler.Work(Work.VoidTasks, degreeOfParallelism: 2);
// TplHandler.WorkForEach(Work.VoidTasks, degreeOfParallelism: 2);

// PlinqHandler.Work(Work.VoidTasks, degreeOfParallelism: 20);
// TplHandler.WorkForEach(Work.VoidTasks, degreeOfParallelism: 20);


//Sync Functions
// PlinqHandler.Work(Work.SyncFunc, degreeOfParallelism: 2);
// TplHandler.WorkForEach(Work.SyncFunc, degreeOfParallelism: 2);
//
// PlinqHandler.Work(Work.SyncFunc, degreeOfParallelism: 20);
// TplHandler.WorkForEach(Work.SyncFunc, degreeOfParallelism: 20);

//Functions
// await PlinqHandler.WorkAsyncBad(Work.AsyncFunc, degreeOfParallelism: 2);
// await TplHandler.WorkForEachAsync(Work.AsyncFunc, degreeOfParallelism: 2);
//
// await PlinqHandler.WorkAsyncBad(Work.AsyncFunc, degreeOfParallelism: 20);
// await TplHandler.WorkForEachAsync(Work.AsyncFunc, degreeOfParallelism: 20);

await PlinqHandler.WorkAsyncSem(Work.AsyncFunc, degreeOfParallelism: 20);
await TplHandler.WorkForEachAsync(Work.AsyncFunc, degreeOfParallelism: 20);