using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _senses;

    public GratitudeActivity() : base(
        "Sensory Gratitude Activity",
        "This activity will help ground you in the present moment by guiding you to notice and appreciate small details around you using your five senses.")
    {
        _senses = new List<string>
        {
            "Notice 5 things you can SEE right now and appreciate their purpose or beauty...",
            "Notice 4 things you can FEEL (your feet on the floor, warmth, clothing)...",
            "Notice 3 things you can HEAR in the background without judging them...",
            "Notice 2 things you can SMELL or enjoy the freshness of the air...",
            "Think of 1 thing you are deeply GRATEFUL for today..."
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        int stepTime = Math.Max(3, GetDuration() / _senses.Count);

        foreach (string sensePrompt in _senses)
        {
            if (DateTime.Now >= endTime) break;

            Console.WriteLine($"\n{sensePrompt}");
            ShowSpinner(stepTime);
        }

        DisplayEndingMessage();
    }
}
