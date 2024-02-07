using static dotNetColor.Constants;

namespace dotNetColor;

public static class RgbExtensions
{
    /// <summary>
    /// RGB values MUST be scaled:<code>
    /// r,g,b -> [0,1]</code>
    /// </summary>
    /// <param name="rgb"></param>
    /// <returns>return values will be in the ranges:<code>
    /// h -> [0,360)
    /// s -> [0,1]
    /// v -> [0,1]</code>
    /// </returns>
    public static Hsv ToHsv(this Rgb rgb)
    {
        var xMax = Math.Max(rgb.Red, Math.Max(rgb.Green, rgb.Blue));
        var chroma = xMax - Math.Min(rgb.Red, Math.Min(rgb.Green, rgb.Blue));
        var hue = rgb.GetHue(chroma, xMax);
        return new Hsv(hue, xMax == 0d ? 0d : chroma / xMax, xMax);
    }

    /// <summary>
    /// RGB values MUST be scaled:<code>
    /// r,g,b -&gt; [0,1] </code>
    /// </summary>
    /// <param name="rgb"></param>
    /// <returns></returns>
    public static Hsl ToHsl(this Rgb rgb)
    {
        var xMax = Math.Max(rgb.Red, Math.Max(rgb.Green, rgb.Blue));
        var xMin = Math.Min(rgb.Red, Math.Min(rgb.Green, rgb.Blue));
        var lightness = (xMax + xMin) / 2d;   
        return new Hsl(rgb.GetHue(xMax - xMin, xMax), Math.Abs(lightness - 1d) < Tolerance || lightness == 0d
            ? 0d
            : (xMax - lightness) / Math.Min(lightness, 1d - lightness), lightness);
    }

    private static double GetHue(this Rgb rgb, double chroma, double xMax)
    {
        if (chroma == 0d) return 0d;
        if (Math.Abs(xMax - rgb.Red) < Tolerance)
        {
            var hue = 60d * ((rgb.Green - rgb.Blue) / chroma % 6d);
            return hue < 0d ? 360d + hue : hue;
        }
        if (Math.Abs(xMax - rgb.Green) < Tolerance) return 60d * ((rgb.Blue - rgb.Red) / chroma + 2d);
        return 60d * ((rgb.Red - rgb.Green) / chroma + 4d);
    }
        
    public static Rgb Scale(this Rgb rgb, double scaler) =>
        new Rgb(rgb.Red * scaler, rgb.Green * scaler, rgb.Blue * scaler);

    public static Rgb Round(this Rgb rgb) =>
        new Rgb(Math.Round(rgb.Red), Math.Round(rgb.Green), Math.Round(rgb.Blue));
}