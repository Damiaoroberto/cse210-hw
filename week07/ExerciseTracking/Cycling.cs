using System;

public class Cycling : Activity
{
    private double _speedKph;

    public Cycling(DateTime date, int durationMinutes, double speedKph)
        : base(date, durationMinutes)
    {
        _speedKph = speedKph;
    }

    public override double GetDistance() => _speedKph * _durationMinutes / 60;

    public override double GetSpeed() => _speedKph;

    public override double GetPace() => 60 / _speedKph;
}