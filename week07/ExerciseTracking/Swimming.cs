public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToKm = 1000;
    private const double KmToMiles = 0.62;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        double distanceKm = _laps * LapLengthMeters / MetersToKm;
        return Program.UseKilometers ? distanceKm : distanceKm * KmToMiles;
    }

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;
    public override double GetPace() => Minutes / GetDistance();
}