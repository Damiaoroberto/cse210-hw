using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _xp = 0;
    private int _level = 1;

    public void Start()
    {
        string choice = "";
        while (choice != "6")
        {
            Console.WriteLine($"\nCurrent Score: {_score} | XP: {_xp} | Level: {_level} ({GetRank()})");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": Console.WriteLine("👋 Goodbye!"); break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string desc = Console.ReadLine();
        Console.Write("Enter points for completion: ");
        int points = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case "1": _goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": _goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                Console.Write("How many times to complete? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points on completion? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("⚠️ Invalid goal type.");
                break;
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
            index++;
        }
    }

    private void SaveGoals()
    {
        Console.Write("Enter filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score},{_xp},{_level}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("✅ Goals saved successfully.");
    }

   
    private void LoadGoals()
{
    Console.Write("Enter filename to load goals: ");
    string filename = Console.ReadLine();

    if (!File.Exists(filename))
    {
        Console.WriteLine("❌ File not found.");
        return;
    }

    _goals.Clear();

    string[] lines = File.ReadAllLines(filename);
    string[] stats = lines[0].Split(",");
    _score = int.Parse(stats[0]);
    _xp = int.Parse(stats[1]);
    _level = int.Parse(stats[2]);

    for (int i = 1; i < lines.Length; i++)
    {
        if (string.IsNullOrWhiteSpace(lines[i])) continue;

        string[] parts = lines[i].Split(":");
        if (parts.Length != 2)
        {
            Console.WriteLine($"⚠️ Skipping invalid line: {lines[i]}");
            continue;
        }

        string type = parts[0];
        string[] data = parts[1].Split(",");

        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])));
                    break;
                case "EternalGoal":
                    _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                    break;
                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(data[0], data[1], int.Parse(data[2]),
                        int.Parse(data[4]), int.Parse(data[3]), int.Parse(data[5])));
                    break;
                default:
                    Console.WriteLine($"⚠️ Unknown goal type: {type}");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error loading goal on line {i + 1}: {ex.Message}");
        }
    }

    Console.WriteLine("📂 Goals loaded successfully.");
}


    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 1 && index <= _goals.Count)
        {
            int oldScore = _score;
            _goals[index - 1].RecordEvent(ref _score);
            int earnedPoints = _score - oldScore;
            AddExperience(earnedPoints);
        }
        else
        {
            Console.WriteLine("⚠️ Invalid goal number.");
        }
    }

    private void AddExperience(int amount)
    {
        _xp += amount;
        int newLevel = (_xp / 100) + 1;

        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"🏅 Level up! You're now level {_level}!");

            if (_level == 5)
            {
                _score += 50;
                Console.WriteLine("🎉 Level 5 Bonus: 50 points!");
            }
            else if (_level == 10)
            {
                _score += 100;
                Console.WriteLine("🏆 Level 10 Bonus: 100 points!");
            }
        }
    }

    private string GetRank()
    {
        if (_level >= 15) return "Legend";
        if (_level >= 10) return "Champion";
        if (_level >= 5) return "Adventurer";
        return "Novice";
    }
}
