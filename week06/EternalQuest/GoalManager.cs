using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalScore;
        private int _level;
        private List<int> _levelThresholds;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _totalScore = 0;
            _level = 1;
            _levelThresholds = new List<int> { 0, 500, 1500, 3000, 5000, 7500, 10000 };
        }

        public void DisplayGoals()
        {
            Console.WriteLine("\nYour Goals:");
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetProgressString()}");
            }
        }

        public void RecordGoalProgress()
        {
            DisplayGoals();
            if (_goals.Count == 0) return;

            Console.Write("Select a goal to record progress: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= _goals.Count)
            {
                Goal selectedGoal = _goals[choice - 1];
                selectedGoal.RecordProgress();
                _totalScore += selectedGoal.Points;
                CalculateLevel();

                Console.WriteLine($"\nProgress recorded for '{selectedGoal.Name}'!");
                Console.WriteLine($"You earned {selectedGoal.Points} points!");

                // Check for level up
                if (_level < _levelThresholds.Count && _totalScore >= _levelThresholds[_level])
                {
                    Console.WriteLine($"\nLEVEL UP! You reached level {_level + 1}!");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
            }
        }

        public void CreateNewGoal()
        {
            Console.WriteLine("\nSelect Goal Type:");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeating)");
            Console.WriteLine("3. Checklist Goal (requires multiple completions)");
            Console.Write("Enter your choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for completing: ");
            int points = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("Enter target count: ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("Enter bonus points: ");
                    int bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine("New goal created successfully!");
        }

        public void DisplayScore()
        {
            Console.WriteLine($"\nCurrent Score: {_totalScore} points");
            Console.WriteLine($"Current Level: {_level}");

            if (_level < _levelThresholds.Count - 1)
            {
                int nextLevelPoints = _levelThresholds[_level + 1];
                int pointsNeeded = nextLevelPoints - _totalScore;
                Console.WriteLine($"Points needed for next level: {pointsNeeded}");
            }
            else
            {
                Console.WriteLine("You've reached the maximum level!");
            }
        }

        public void SaveGoals()
        {
            Console.Write("Enter filename to save goals: ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_totalScore);
                outputFile.WriteLine(_level);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }

        public void LoadGoals()
        {
            Console.Write("Enter filename to load goals: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(filename);

            _totalScore = int.Parse(lines[0]);
            _level = int.Parse(lines[1]);

            for (int i = 2; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] details = parts[1].Split(',');

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(details[0], details[1], int.Parse(details[2])));
                        _goals[^1].RecordProgress(); // Mark complete if needed
                        break;
                    case "EternalGoal":
                        EternalGoal eternal = new EternalGoal(details[0], details[1], int.Parse(details[2]));
                        for (int j = 0; j < int.Parse(details[3]); j++)
                        {
                            eternal.RecordProgress();
                        }
                        _goals.Add(eternal);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal checklist = new ChecklistGoal(details[0], details[1], 
                            int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[3]));
                        for (int j = 0; j < int.Parse(details[5]); j++)
                        {
                            checklist.RecordProgress();
                        }
                        _goals.Add(checklist);
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully!");
            DisplayScore();
        }

        private void CalculateLevel()
        {
            for (int i = _levelThresholds.Count - 1; i >= 0; i--)
            {
                if (_totalScore >= _levelThresholds[i])
                {
                    _level = i + 1;
                    break;
                }
            }
        }
    }
}