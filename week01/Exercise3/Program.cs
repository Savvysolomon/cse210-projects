using System;

class Program
{
    static void Main(string[] args)
    {
        // variable to track if the user wants to play again
        string playAgain = "yes";

        // loop to restart the entire game if they type "yes"
        while (playAgain.ToLower() == "yes")
        {
            // generate a random number from 1 to 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101); 

            // variables to track game state
            int guess = -1;
            int guessCount = 0; 

            Console.WriteLine("\nI have picked a magic number between 1 and 100.");

            // loop keeps going until the guess matches the magic number
            while (guess != magicNumber)
            {
                // ask the user for their guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                
                // increment the guess counter
                guessCount++;

                // determine if the guess is higher, lower, or correct
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // inform the user how many guesses they took
            Console.WriteLine($"It took you {guessCount} guesses.");

            // ask the user if they want to play again
            Console.Write("Do you want to play again (yes/no)? ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thank you for playing! Goodbye.");
    }
}
