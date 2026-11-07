using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is currently empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                string safePrompt = EscapeCsvField(entry._promptText);
                string safeEntry = EscapeCsvField(entry._entryText);
                writer.WriteLine($"\"{entry._date}\",{safePrompt},{safeEntry}");
            }
        }
        Console.WriteLine("Journal saved to CSV successfully!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("Error: File not found.");
            return;
        }

        _entries.Clear();
        using (StreamReader reader = new StreamReader(file))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                List<string> fields = ParseCsvLine(line);
                if (fields.Count >= 3)
                {
                    Entry entry = new Entry(fields[0], fields[1], fields[2]);
                    _entries.Add(entry);
                }
            }
        }
        Console.WriteLine("Journal loaded from CSV successfully!");
    }

    private string EscapeCsvField(string field)
    {
        if (field.Contains("\""))
        {
            field = field.Replace("\"", "\"\"");
        }
        return $"\"{field}\"";
    }

    private List<string> ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (c == '"')
            {
                if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField += '"';
                    i++;
                }
                else
                {
                    inQuotes = !inQuotes;
                }
            }
            else if (c == ',' && !inQuotes)
            {
                fields.Add(currentField);
                currentField = "";
            }
            else
            {
                currentField += c;
            }
        }
        fields.Add(currentField);
        return fields;
    }
}
