using System;

class Program
{
    static void Main(string[] args)
     {
        // Call the DisplayWelcome function
        DisplayWelcome();

        // Call the PromptUserName function and save the return value
        string userName = PromptUserName();

        // Call the PromptUserNumber function and save the return value
        int userNumber = PromptUserNumber();

        // Call the SquareNumber function and save the return value
        int squaredNumber = SquareNumber(userNumber);

        // Call the DisplayResult function
        DisplayResult(userName, squaredNumber);
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Function to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Function to prompt the user for their favorite number and return it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Function to square a number and return the result
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}