using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public string GetName() => _name;
    public int GetDuration() => _duration;

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, in seconds, would you like for your session? ");
        
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a valid positive number of seconds: ");
        }

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds)
    {
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            // handle multi-digit numbers
            string backspaces = new string('\b', i.ToString().Length);
            string spaces = new string(' ', i.ToString().Length);
            Console.Write(backspaces + spaces + backspaces);
        }
    }

    // ensure no prompt/question repeats until all have been used
    protected string GetUniqueRandomItem(List<string> sourceList, List<string> unusedPool)
    {
        if (unusedPool.Count == 0)
        {
            unusedPool.AddRange(sourceList);
        }

        Random random = new Random();
        int index = random.Next(unusedPool.Count);
        string selected = unusedPool[index];
        unusedPool.RemoveAt(index);

        return selected;
    }
}
