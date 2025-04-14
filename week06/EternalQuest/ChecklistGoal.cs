public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int completed)
        : this(name, description, points, target, bonus)
    {
        _amountCompleted = completed;
    }

    public override void RecordEvent(ref int score)
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            score += _points;

            if (_amountCompleted == _target)
            {
                score += _bonus;
                Console.WriteLine($"🎯 Checklist complete! Bonus {_bonus} points awarded.");
            }
            else
            {
                Console.WriteLine($"✅ You earned {_points} points. Progress: {_amountCompleted}/{_target}");
            }
        }
        else
        {
            Console.WriteLine("🏁 This checklist goal is already completed!");
        }
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        return $"{status} {_shortName} ({_description}) — Completed {_amountCompleted}/{_target} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}
