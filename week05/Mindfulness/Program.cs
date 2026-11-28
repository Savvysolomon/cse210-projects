/*
Program:                Mindfulness

Author:                 Solomon Umoh

Description:            A program that provides three different kinds of mindfulness opportunities and could give guidance and structure to the users

Additional Requirements:
   1. I implemented a pool system in the base Activity class (GetUniqueRandomItem) so that no prompt 
      or reflection question is repeated until every item in the list has been used at least once 
      during the session.
   2. I created the GratitudeActivity class and ensure it inherits from Activity 
   3. I added automatic saving and loading to 'ActivityLog.txt' to track 
      the number of times each activity has been completed and total mindful 
      seconds across sessions.
 */

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static string _logFile = "ActivityLog.txt";
    private static Dictionary<string, int> _activityCounts = new Dictionary<string, int>();
    private static int _totalSeconds = 0;

    static void Main(string[] args)
    {
        LoadLog();

        // instantiate outside the loop so non-repeating prompt persist during the session
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();
        GratitudeActivity gratitude = new GratitudeActivity();

        string choice = "";

        while (choice != "6")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start sensory gratitude activity");
            Console.WriteLine("  5. View mindfulness log");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    breathing.Run();
                    RecordActivity(breathing);
                    break;
                case "2":
                    reflecting.Run();
                    RecordActivity(reflecting);
                    break;
                case "3":
                    listing.Run();
                    RecordActivity(listing);
                    break;
                case "4":
                    gratitude.Run();
                    RecordActivity(gratitude);
                    break;
                case "5":
                    DisplayLog();
                    break;
                case "6":
                    Console.WriteLine("\nThank you for taking time to be mindful today. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please select 1-6.");
                    Thread.Sleep(1500);
                    break;
            }
        }
    }

    static void RecordActivity(Activity activity)
    {
        string name = activity.GetName();
        if (_activityCounts.ContainsKey(name))
        {
            _activityCounts[name]++;
        }
        else
        {
            _activityCounts[name] = 1;
        }

        _totalSeconds += activity.GetDuration();
        SaveLog();
    }

    static void SaveLog()
    {
        using (StreamWriter writer = new StreamWriter(_logFile))
        {
            writer.WriteLine(_totalSeconds);
            foreach (var entry in _activityCounts)
            {
                writer.WriteLine($"{entry.Key}|{entry.Value}");
            }
        }
    }

    static void LoadLog()
    {
        if (!File.Exists(_logFile)) return;

        string[] lines = File.ReadAllLines(_logFile);
        if (lines.Length > 0 && int.TryParse(lines[0], out int savedSeconds))
        {
            _totalSeconds = savedSeconds;
        }

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            if (parts.Length == 2 && int.TryParse(parts[1], out int count))
            {
                _activityCounts[parts[0]] = count;
            }
        }
    }

    static void DisplayLog()
    {
        Console.Clear();
        Console.WriteLine("=== Mindfulness Activity Log ===\n");
        Console.WriteLine($"Total Mindful Time: {_totalSeconds} seconds\n");

        if (_activityCounts.Count == 0)
        {
            Console.WriteLine("No activities completed yet.");
        }
        else
        {
            foreach (var entry in _activityCounts)
            {
                Console.WriteLine($"- {entry.Key}: completed {entry.Value} time(s)");
            }
        }

        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}
