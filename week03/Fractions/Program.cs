using System;

class Program
{
    static void Main(string[] args)
    {
        // Test constructors
        Fraction f1 = new Fraction();       // 1/1
        Fraction f2 = new Fraction(5);      // 5/1
        Fraction f3 = new Fraction(3, 4);   // 3/4
        Fraction f4 = new Fraction(1, 3);   // 1/3

        // Test getters and setters
        f1.SetTop(2);
        f1.SetBottom(3);
        Console.WriteLine($"Fraction 1: {f1.GetFractionString()}"); // 2/3
        Console.WriteLine($"Decimal Value: {f1.GetDecimalValue()}"); // ~0.6667

        // Test methods
        Console.WriteLine($"Fraction 2: {f2.GetFractionString()}"); // 5/1
        Console.WriteLine($"Decimal Value: {f2.GetDecimalValue()}"); // 5.0

        Console.WriteLine($"Fraction 3: {f3.GetFractionString()}"); // 3/4
        Console.WriteLine($"Decimal Value: {f3.GetDecimalValue()}"); // 0.75

        Console.WriteLine($"Fraction 4: {f4.GetFractionString()}"); // 1/3
        Console.WriteLine($"Decimal Value: {f4.GetDecimalValue()}"); // ~0.3333
    }
}