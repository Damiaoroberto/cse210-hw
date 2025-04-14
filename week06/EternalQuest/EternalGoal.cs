public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) 
        : base(name, description, points) {}

    public override void RecordEvent(ref int score)
    {
        score += _points;
        Console.WriteLine($"🔄 You recorded an eternal goal and earned {_points} points!");
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString() => $"[∞] {_shortName} ({_description})";

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}
