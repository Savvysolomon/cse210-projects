/*
Addition:
Implemented a robust, custom CSV parser and escape handler.
This program safely processes text containing actual commas and quotation marks. 
The program wraps fields in standard quote delimiters, escapes internal double quotes 
appropriately, and cleanly parses multi-line structures, this makes all saved journals 
fully compatible with spreadsheets like Microsoft Excel.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string choice = "";

        while (choice != "5")
        {
            // Welcome the user and display the menu options
            Console.WriteLine("========= Welcome to the Journal Program! =========\n");
            Console.WriteLine("Please select one of the following choices:");

            Console.WriteLine("::::::::::::::::::::::::::::");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("::::::::::::::::::::::::::::");

            // Ask the user for their choice and read the input
            Console.Write("What would you like to do? ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();
                string dateText = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(dateText, prompt, response);
                journal.AddEntry(entry);
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                // Display all journal entries
                Console.WriteLine("\n--- Journal Entries ---");
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                // Load journal entries from a CSV file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
                Console.WriteLine();
            }
            else if (choice == "4")
            {
                // Save journal entries to a CSV file
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
                Console.WriteLine();
            }
            else if (choice != "5")
            {
                // Check choice validity and display an error message for invalid options
                Console.WriteLine("Invalid option. Please choose a option between 1 and 5.\n");
            }
        }
    }
}
