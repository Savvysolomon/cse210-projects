using System;

class Program
{
    static void Main(string[] args)
    {
        // ask for first name and store the input
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // ask for last name and store the input
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // print the names 
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");


    }
}