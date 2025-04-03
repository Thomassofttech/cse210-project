using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    // Base Activity class containing shared functionality
    public abstract class Activity
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }
        protected static int TotalActivitiesCompleted { get; set; } = 0;

        // Common starting message for all activities
        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} Activity");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }

        // Common ending message for all activities
        protected void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good job! You have completed another activity.");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the {Name} Activity for {Duration} seconds.");
            ShowSpinner(3);
            TotalActivitiesCompleted++;
            Console.WriteLine($"Total activities completed this session: {TotalActivitiesCompleted}");
            ShowSpinner(3);
        }

        // Show a spinner animation for the specified number of seconds
        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds * 2; i++)
            {
                Console.Write("\b \b");
                switch (i % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Thread.Sleep(500);
            }
            Console.Write("\b \b");
        }

        // Show a countdown timer for the specified number of seconds
        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"\r{i} ");
                Thread.Sleep(1000);
            }
            Console.Write("\r  \r");
        }

        // Abstract method to be implemented by derived classes
        public abstract void Run();
    }

    // Breathing Activity class
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            Name = "Breathing";
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);
            
            while (DateTime.Now < endTime)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(4);
                
                if (DateTime.Now >= endTime) break;
                
                Console.WriteLine();
                Console.Write("Breathe out... ");
                ShowCountdown(6);
            }
            
            DisplayEndingMessage();
        }
    }

    // Reflection Activity class
    public class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            Name = "Reflection";
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            // Select a random prompt
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press Enter to continue.");
            Console.ReadLine();
            
            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);
            
            // Keep track of used questions to avoid repeats until all are used
            List<string> unusedQuestions = new List<string>(_questions);
            
            while (DateTime.Now < endTime)
            {
                if (unusedQuestions.Count == 0)
                {
                    unusedQuestions = new List<string>(_questions);
                }
                
                string question = unusedQuestions[random.Next(unusedQuestions.Count)];
                unusedQuestions.Remove(question);
                
                Console.Write($"> {question} ");
                ShowSpinner(5);
                Console.WriteLine();
            }
            
            DisplayEndingMessage();
        }
    }

    // Listing Activity class
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

        public ListingActivity()
        {
            Name = "Listing";
            Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }

        public override void Run()
        {
            DisplayStartingMessage();
            
            // Select a random prompt
            Random random = new Random();
            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine("List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.Write("You may begin in: ");
            ShowCountdown(5);
            Console.WriteLine();
            
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(Duration);
            
            List<string> items = new List<string>();
            
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items!");
            
            DisplayEndingMessage();
        }
    }

    // Main program class
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program Menu");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an activity (1-4): ");
                
                string choice = Console.ReadLine();
                
                Activity activity = null;
                
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        ShowSpinner(2);
                        continue;
                }
                
                activity.Run();
            }
        }
        
        // Helper method to show spinner (duplicated here for the Program class)
        private static void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds * 2; i++)
            {
                Console.Write("\b \b");
                switch (i % 4)
                {
                    case 0: Console.Write("/"); break;
                    case 1: Console.Write("-"); break;
                    case 2: Console.Write("\\"); break;
                    case 3: Console.Write("|"); break;
                }
                Thread.Sleep(500);
            }
            Console.Write("\b \b");
        }
    }
}