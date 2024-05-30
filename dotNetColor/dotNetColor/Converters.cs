namespace dotNetColor;

public static class Converters
{
    public static Func<Hsv, Hsv> ScaleHsv(params IScaler[] scalers) => hsv => hsv.Scale(scalers);
    public static Func<Hsl, Hsl> ScaleHsl(params IScaler[] scalers) => hsl => hsl.Scale(scalers);
    public static Func<Rgb, Rgb> ScaleRgb(params IScaler[] scalers) => rgb => rgb.Scale(scalers);

    /// <summary>
    /// HSV values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// v -&gt; [0,1]</code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// h -> [0,360)
    /// s -> [0,1]
    /// l -> [0,1]</code></returns>
    public static Func<Hsv, Hsl> ConvertToHsl(this Func<Hsv, Hsv> scaler) => hsv => scaler(hsv).ToHsl();

    /// <summary>
    /// HSV values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// v -&gt; [0,1]</code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// r, g ,b -> [0,1]
    /// </code></returns>
    public static Func<Hsv, Rgb> ConvertToRgb(this Func<Hsv, Hsv> scaler) => hsv => scaler(hsv).ToRgb();

    /// <summary>
    /// HSL values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// l -&gt; [0,1]</code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// h -> [0,360)
    /// s -> [0,1]
    /// v -> [0,1]</code></returns>
    public static Func<Hsl, Hsv> ConvertToHsv(this Func<Hsl, Hsl> scaler) => hsl => scaler(hsl).ToHsv();

    /// <summary>
    /// HSL values MUST be in the following bounds:<code>
    /// h -&gt; [0,360),
    /// s -&gt; [0,1],
    /// l -&gt; [0,1]</code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// r, g ,b -> [0,1]
    /// </code></returns>
    public static Func<Hsl, Rgb> ConvertTRgb(this Func<Hsl, Hsl> scaler) => hsl => scaler(hsl).ToRgb();

    /// <summary>
    /// RGB values MUST be in the following bounds:<code>
    /// r,g,b -&gt; [0,1] </code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// h -> [0,360)
    /// s -> [0,1]
    /// v -> [0,1]</code></returns>
    public static Func<Rgb, Hsv> ConvertToHsv(this Func<Rgb, Rgb> scaler) => rgb => scaler(rgb).ToHsv();

    /// <summary>
    /// RGB values MUST be in the following bounds:<code>
    /// r,g,b -&gt; [0,1] </code>
    /// </summary>
    /// <returns>return values will be in the ranges:<code>
    /// h -> [0,360)
    /// s -> [0,1]
    /// l -> [0,1]</code></returns>
    public static Func<Rgb, Hsl> ConvertToHsl(this Func<Rgb, Rgb> scaler) => rgb => scaler(rgb).ToHsl();
    
    
    
    public static Func<Hsv, Hsl> Scale(this Func<Hsv, Hsl> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);

    public static Func<Hsv, Rgb> Scale(this Func<Hsv, Rgb> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);
    
    public static Func<Hsl, Hsv> Scale(this Func<Hsl, Hsv> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);

    public static Func<Hsl, Rgb> Scale(this Func<Hsl, Rgb> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);
    
    public static Func<Rgb, Hsv> Scale(this Func<Rgb, Hsv> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);
    
    public static Func<Rgb, Hsl> Scale(this Func<Rgb, Hsl> conversion, params IScaler[] scalers) =>
        hsv => conversion(hsv).Scale(scalers);
}