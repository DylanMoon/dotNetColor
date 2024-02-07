namespace dotNetColor.Comparers;

public sealed class HsvComparer : IEqualityComparer<Hsv>
{
    private double Tolerance { get; init; }

    public HsvComparer(double tolerance = Constants.Tolerance) => Tolerance = tolerance;

    public bool Equals(Hsv x, Hsv y)
    {
        return Math.Abs(x.Hue - y.Hue) < Tolerance &&
               Math.Abs(x.Saturation - y.Saturation) < Tolerance &&
               Math.Abs(x.Value - y.Value) < Tolerance;
    }

    public int GetHashCode(Hsv obj)
    {
        return HashCode.Combine(obj.Hue, obj.Saturation, obj.Value);
    }
}