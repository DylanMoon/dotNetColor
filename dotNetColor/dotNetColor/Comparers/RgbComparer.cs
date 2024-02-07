namespace dotNetColor.Comparers;

public sealed class RgbComparer : IEqualityComparer<Rgb>
{
    private double Tolerance { get; init; }

    public RgbComparer(double tolerance = Constants.Tolerance) => Tolerance = tolerance;

    public bool Equals(Rgb x, Rgb y)
    {
        return Math.Abs(x.Red - y.Red) < Tolerance &&
               Math.Abs(x.Green - y.Green) < Tolerance &&
               Math.Abs(x.Blue - y.Blue) < Tolerance;
    }

    public int GetHashCode(Rgb obj)
    {
        return HashCode.Combine(obj.Red, obj.Green, obj.Blue);
    }
}