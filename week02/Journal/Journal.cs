using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> Entries { get; } = new List<Entry>();
    private List<string> Prompts { get; } = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What was the most challenging part of my day?",
        "What am I grateful for today?",
        "What did I learn today?"
    };

    public void AddEntry()
    {
        var random = new Random();
        string prompt = Prompts[random.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        
        Entry entry = new Entry
        {
            PromptText = prompt,
            EntryText = response,
            Date = DateTime.Now.ToShortDateString()
        };
        
        Entries.Add(entry);
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayAll()
    {
        if (Entries.Count == 0)
        {
            Console.WriteLine("No entries to display.\n");
            return;
        }

        foreach (var entry in Entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();
        
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                outputFile.WriteLine($"{entry.Date}~|~{entry.PromptText}~|~{entry.EntryText}");
            }
        }
        
        Console.WriteLine($"Journal saved to {filename}\n");
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();
        
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        Entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        
        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");
            
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    Date = parts[0],
                    PromptText = parts[1],
                    EntryText = parts[2]
                };
                Entries.Add(entry);
            }
        }
        
        Console.WriteLine($"Journal loaded from {filename}\n");
    }
}