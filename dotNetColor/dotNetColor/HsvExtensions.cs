using static dotNetColor.Constants;

namespace dotNetColor;

public static class HsvExtensions
{
    /// <summary>
    /// HSV values MUST be scaled:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// v -&gt; [0,1]</code>
    /// </summary>
    /// <param name="hsv"></param>
    /// <returns></returns>
    public static Rgb ToRgb(this Hsv hsv)
    {
        return new Rgb(F(5d), F(3d), F(1d));

        double F(double n)
        {
            var k = (n + hsv.Hue / 60d) % 6d;
            return hsv.Value - hsv.Value * hsv.Saturation * Math.Max(0d, Math.Min(k, Math.Min(4d - k, 1d)));
        }
    }

    /// <summary>
    /// HSV values MUST be scaled:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// v -&gt; [0,1]</code>
    /// </summary>
    /// <param name="hsv"></param>
    /// <returns></returns>
    public static Hsl ToHsl(this Hsv hsv)
    {
        var lightness = L(hsv.Saturation, hsv.Value);
        return new Hsl(hsv.Hue,
            IsOneOrZero(lightness) ? 0d : (hsv.Value - lightness) / Math.Min(lightness, 1d - lightness), lightness);

        double L(double saturation, double value) => value * (1d - saturation / 2d);

        bool IsOneOrZero(double value)
        {
            return Math.Abs(value - 0d) < Tolerance || Math.Abs(1d - value) < Tolerance;
        }
    }

    public static Hsv Scale(this Hsv hsv, double hueScaler, double saturationScaler, double valueScaler) =>
        new Hsv(hsv.Hue * hueScaler, hsv.Saturation * saturationScaler, hsv.Value * valueScaler);

    public static Hsv Round(this Hsv hsv) =>
        new Hsv(Math.Round(hsv.Hue), Math.Round(hsv.Saturation), Math.Round(hsv.Value));

    public static Hsv RoundHue(this Hsv hsv) => hsv with {Hue = Math.Round(hsv.Hue)};
}