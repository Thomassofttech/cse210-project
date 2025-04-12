using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            
            Console.WriteLine("Welcome to Eternal Quest!");
            Console.WriteLine("A program to help you track and achieve your goals!");
            
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMain Menu:");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Record Goal Progress");
                Console.WriteLine("3. Create New Goal");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Save Goals");
                Console.WriteLine("6. Load Goals");
                Console.WriteLine("7. Quit");
                
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        manager.DisplayGoals();
                        break;
                    case "2":
                        manager.RecordGoalProgress();
                        break;
                    case "3":
                        manager.CreateNewGoal();
                        break;
                    case "4":
                        manager.DisplayScore();
                        break;
                    case "5":
                        manager.SaveGoals();
                        break;
                    case "6":
                        manager.LoadGoals();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            
            Console.WriteLine("\nGoodbye! Keep working on your eternal quest!");
        }
    }
}