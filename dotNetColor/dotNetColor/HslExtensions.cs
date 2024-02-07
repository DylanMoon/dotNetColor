using static dotNetColor.Constants;
namespace dotNetColor;

public static class HslExtensions
{
    /// <summary>
    /// HSL values MUST be scaled:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// v -&gt; [0,1]</code>
    /// </summary>
    /// <param name="hsl"></param>
    /// <returns></returns>
    public static Rgb ToRgb(this Hsl hsl)
    {
        return new Rgb(F(0d), F(8d), F(4d));

        double F(double n)
        {
            var k = (n + hsl.Hue / 30d) % 12d;
            var a = hsl.Saturation * Math.Min(hsl.Lightness, 1d - hsl.Lightness);
            return hsl.Lightness - a * Math.Max(-1d, Math.Min(k - 3d, Math.Min(9d - k, 1d)));
        }
    }
        
    /// <summary>
    /// HSL values MUST be scaled:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// l -&gt; [0,1]</code>
    /// </summary>
    /// <param name="hsl"></param>
    /// <returns></returns>
    public static Hsv ToHsv(this Hsl hsl)
    {
        var value = V(hsl.Saturation, hsl.Lightness);
        return new Hsv(hsl.Hue, IsZero(hsl.Saturation) ? 0d : 2d * (1d - hsl.Lightness / value), value);
        double V(double saturation, double lightness) =>
            lightness + saturation * Math.Min(lightness, 1d - lightness);

        bool IsZero(double v)
        {
            return Math.Abs(v - 0d) < Tolerance;
        }
    }

    public static Hsl Scale(this Hsl hsl, double hueScaler, double saturationScaler, double lightnessScaler) =>
        new Hsl(hsl.Hue * hueScaler, hsl.Saturation * saturationScaler, hsl.Lightness * lightnessScaler);

    public static Hsl Round(this Hsl hsl) =>
        new Hsl(Math.Round(hsl.Hue), Math.Round(hsl.Saturation), Math.Round(hsl.Lightness));

    public static Hsl RoundHue(this Hsl hsl) => hsl with {Hue = Math.Round(hsl.Hue)};
}