using System;

class Program
{
    static void Main(string[] args)
    {
        // call the welcome message function
        DisplayWelcome();

        // call the function to prompt for username and save string return value
        string userName = PromptUserName();

        // call the function to prompt for favorite number and save integer return value
        int userNumber = PromptUserNumber();

        // pass favorite number into squaring function and save integer result
        int squaredNumber = SquareNumber(userNumber);

        // pass both name and squared result into display function
        DisplayResult(userName, squaredNumber);
    }

    // display welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // prompt username - asks for and returns user's name as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // prompt user number - asks for and returns user's favorite number as an integer
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // square number - accepts an integer as a parameter, returns that number squared as an integer
    static int SquareNumber(int numberToSquare)
    {
        int square = numberToSquare * numberToSquare;
        return square;
    }

    // display result - accepts user's name and squared number and displays them
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
