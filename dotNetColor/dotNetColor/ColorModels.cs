using static dotNetColor.Constants;
namespace dotNetColor;

public record struct Hsl(double Hue, double Saturation, double Lightness);

public record struct Hsv(double Hue, double Saturation, double Value);

public record struct Rgb(double Red, double Green, double Blue);

