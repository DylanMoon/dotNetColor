namespace dotNetColor;

public readonly record struct Hsl(Hue Hue, Saturation Saturation, Lightness Lightness);

public readonly record struct Hsv(Hue Hue, Saturation Saturation, Value Value);

public readonly record struct Rgb(Red Red, Green Green, Blue Blue);

