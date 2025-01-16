class Program
{
    static void PrintNumber(string message)
    {
        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine($"{message}: {i}");
            Thread.Sleep(1000);
        }
    }
    static void Main()
    {
        Thread.CurrentThread.Name = "Main";
        //Create a task and pass a delegate to the method
        Task task1 = new Task(() => PrintNumber("Task 1"));
        task1.Start();
        // create a task and pass a delegate to the method
        Task task2 = Task.Run(delegate { PrintNumber("Task 2"); });
        // Create a task by using a Action delegate
        Task task3 = new Task(new Action(() => { PrintNumber("Task 3"); }));
        task3.Start();
        Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");
        Console.ReadKey();
    }
}
