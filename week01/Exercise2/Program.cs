using System;

class Program
{
    static void Main(string[] args)
    {
        //  prompt the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();
        
        // convert the input string to an integer
        int percent = int.Parse(input);

        // variables to hold our letter grade and sign
        string letter = "";
        string sign = "";

        // determine the base letter grade
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

        // determine the '+' or '-' sign using remainder (%) operator
        int lastDigit = percent % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = ""; 
        }

        // handle exceptional cases like No A+, No F+, No F-
        if (letter == "A" && sign == "+")
        {
            sign = ""; 
        }
        else if (letter == "F")
        {
            sign = ""; 
        }

        // single print statement for grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // separate if statement to determine if they passed
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard and you'll get it next time.");
        }
    }
}
