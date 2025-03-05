using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); // Generates a random number between 1 and 100

        int guess = -1; // Initialize guess to a value that won't match the magic number

        // Loop until the user guesses the correct number
        while (guess != magicNumber)
        {
            // Ask the user for their guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine()); // Read and parse the user's guess

            // Check if the guess is higher, lower, or correct
            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}