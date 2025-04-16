using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 4, 16), 30, 5.0),
            new Cycling(new DateTime(2025, 4, 16), 30, 20.0),
            new Swimming(new DateTime(2025, 4, 16), 30, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
