using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _items = new List<string>();
    private readonly object _lock = new object();

    public ListingActivity()
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        DisplayStartMessage();

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(prompt);
        Console.WriteLine("Get ready to list items...");
        ShowCountdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;

        Task inputTask = Task.Run(() => CollectUserInput(token), token);

        while (DateTime.Now < endTime && !inputTask.IsCompleted)
        {
            Thread.Sleep(100); // Reduce CPU usage
        }

        if (!inputTask.IsCompleted)
        {
            cts.Cancel();
            Console.WriteLine("\nTime's up!");
        }

        lock (_lock)
        {
            Console.WriteLine($"You listed {_items.Count} items!");
        }

        DisplayEndMessage();
    }

    private void CollectUserInput(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                lock (_lock)
                {
                    _items.Add(input);
                }
            }
        }
    }
}
