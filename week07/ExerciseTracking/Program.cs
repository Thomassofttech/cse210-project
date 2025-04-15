using System;
using System.Collections.Generic;

public class Program
{
    public static bool UseKilometers { get; } = false; // Set to true for metric system

    public static void Main(string[] args)
    {
        // Create activities
        var activities = new List<Activity>
        {
            new Running(new DateTime(2025, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2025, 11, 3), 30, 9.7),
            new Swimming(new DateTime(2025, 11, 3), 30, 20)
        };

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}