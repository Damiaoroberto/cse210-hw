using System;

public class Running : Activity
{
    private double _distanceKm;

    public Running(DateTime date, int durationMinutes, double distanceKm)
        : base(date, durationMinutes)
    {
        _distanceKm = distanceKm;
    }

    public override double GetDistance() => _distanceKm;

    public override double GetSpeed() => _distanceKm / _durationMinutes * 60;

    public override double GetPace() => _durationMinutes / _distanceKm;
}