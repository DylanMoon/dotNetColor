// See https://aka.ms/new-console-template for more information

using dotNetColor;

Console.WriteLine("Hello, World!");



var @in = Converters.ScaleHsv(
        new HueScaler(360d)
        )
    .ConvertToRgb().Scale(
        new RedScaler(255), 
        new GreenScaler(255),
        new BlueScaler(255)
        );

var @out = Converters.ScaleRgb(
    new RedScaler(1 / 255d),
    new GreenScaler(1 / 255d),
    new BlueScaler(1 / 255d)
    )
    .ConvertToHsv().Scale(
        new HueScaler(1/360d)
    );

 var (red, green, blue) = @in(new Hsv(1,1,1));
 
 Console.WriteLine(@in(new Hsv(1,1,1)));