namespace dotNetColor.Comparers;

public sealed class HslComparer : IEqualityComparer<Hsl>
{
    private double Tolerance { get; init; }

    public HslComparer(double tolerance = Constants.Tolerance) => Tolerance = tolerance;

    public bool Equals(Hsl x, Hsl y)
    {
        return Math.Abs(x.Hue - y.Hue) < Tolerance &&
               Math.Abs(x.Saturation - y.Saturation) < Tolerance &&
               Math.Abs(x.Lightness - y.Lightness) < Tolerance;
    }

    public int GetHashCode(Hsl obj)
    {
        return HashCode.Combine(obj.Hue, obj.Saturation, obj.Lightness);
    }
}