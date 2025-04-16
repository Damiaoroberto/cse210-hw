using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0;

    public override double GetSpeed() => GetDistance() / _durationMinutes * 60;

    public override double GetPace() => _durationMinutes / GetDistance();
}