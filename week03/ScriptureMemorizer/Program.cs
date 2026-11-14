using System; 
using System.Collections.Generic; 

/* 
Program:                Scripture Memorizer

Author:                 Solomon Umoh

Description:            A program that displays the full scripture 
                        and then hides a few words at a time until 
                        the complete scripture is hidden.


Exceeding Requirement:  1. HideRandomWord() only selects from words not yet hidden
                        2. The program stores a list of multiple single verse and multi verse
                        scriptures and randomly selects one each time the program runs 
                        3. Users can type the word "hint" to reveal one random hidden word
                        if they get stuck


*/

class Program
{
    static void Main(string[] args)
    {
        // build a library of scriptures, both single verse and range of verses
        List<Scripture> library = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."
            ),
            new Scripture(
                new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy."
            )
        };


        // pick random scripture from library
        Random random = new Random();
        Scripture currentScripture = library[random.Next(library.Count)];


        string userInput = "";


        // main loops runs until user types "quit" or all words are hidden
        while (userInput.ToLower() != "quit" && !currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words, type 'hint' to reveal a word, or type 'quit' to exit the program:");

            userInput = Console.ReadLine();

            if (userInput.ToLower() == "hint")
            {
                currentScripture.RevealHint();
            }
            else if (userInput.ToLower() != "quit")
            {
                currentScripture.HideRandomWords(3);
            }
        }


        // final display once all words are hidden
        if (currentScripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Great job! All words are now hidden.");
        }
    }
}
