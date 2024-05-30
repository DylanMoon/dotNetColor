using static dotNetColor.Constants;
namespace dotNetColor;

public static class HslExtensions
{
    /// <summary>
    /// HSL values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// l -&gt; [0,1]</code>
    /// </summary>
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
    /// HSL values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// l -&gt; [0,1]</code>
    /// </summary>
    /// <returns></returns>
    public static Hsv ToHsv(this Hsl hsl)
    {
        var value = V(hsl.Saturation, hsl.Lightness);
        return new Hsv(hsl.Hue, IsZero(hsl.Saturation) ? 0d : 2d * (1d - hsl.Lightness / value), value);
        
        Value V(double saturation, double lightness) =>
            lightness + saturation * Math.Min(lightness, 1d - lightness);

        bool IsZero(double v)
        {
            return Math.Abs(v - 0d) < Tolerance;
        }
    }

    public static Hsl Scale(this Hsl hsl, params IScaler[] scalers) =>
        hsl.Scale(scalers.AsEnumerable());

    public static Hsl Scale(this Hsl hsl, IEnumerable<IScaler> scalers) =>
        scalers.Aggregate(hsl, (hslAcc, scaler) => hslAcc.ApplyScaler(scaler));

    private static Hsl ApplyScaler(this Hsl hsv, IScaler scaler) => scaler switch
    {
        HueScaler hueScaler => hsv with {Hue = hsv.Hue.Value * hueScaler.Value},
        SaturationScaler saturationScaler => hsv with {Saturation = hsv.Saturation.Value * saturationScaler.Value},
        LightnessScaler lightnessScaler => hsv with {Lightness = hsv.Lightness.Value * lightnessScaler.Value},
        _ => hsv,
    };
    
    public static Hsl Round(this Hsl hsl) =>
        new Hsl(Math.Round(hsl.Hue.Value), Math.Round(hsl.Saturation), Math.Round(hsl.Lightness));

    public static Hsl RoundHue(this Hsl hsl) => hsl with {Hue = Math.Round(hsl.Hue)};
}