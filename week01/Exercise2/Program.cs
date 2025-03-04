using System;

class Program
{
    static void Main(string[] args)
    {
       Console.WriteLine("What is your grade percentage?");
       string answer = Console.ReadLine();
       int percent = int.Parse(answer);

        string letter = "";

     if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Print the letter grade
        Console.WriteLine($"Your letter grade is: {letter}");

        // Check if the user passed the course
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't worry, keep working hard for next time!");
        }
    }
}
    