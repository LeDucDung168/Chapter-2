﻿class Program
{
    public static void Main()
    {
        //Wait for the task to complete
        Task[] tasks = new Task[5];
        String taskData = "Hello";
        for (int i = 0; i < 5; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                Console.WriteLine($"Task = {Task.CurrentId}, obj={taskData}, ThreadId={Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(1000);
            });
        }
        try
        {
            Task.WaitAll(tasks);
        }
        catch (AggregateException exe)
        {
            Console.WriteLine("One or more exceptions occurred: ");
            foreach (var ex in exe.Flatten().InnerExceptions)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        Console.WriteLine("Status of completed tasks:");
        foreach(var t in tasks)
        {
            Console.WriteLine("Task #{0}: {1}", t.Id, t.Status);
        }
    }
}
