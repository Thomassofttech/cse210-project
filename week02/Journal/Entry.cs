public class Entry
{
    public string PromptText { get; set; }
    public string EntryText { get; set; }
    public string Date { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine();
    }
}