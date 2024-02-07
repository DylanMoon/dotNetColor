using System.Collections.ObjectModel;
using dotNetColor.Comparers;
using Xunit.Abstractions;

namespace dotNetColor.Tests;

public class Tests
{
     private readonly ITestOutputHelper _testOutputHelper;

    public Tests(ITestOutputHelper testOutputHelper) =>
        _testOutputHelper = testOutputHelper;

    //Constants
    public const double Zero = 0d;
    public const double OneHalf = 1 / 2d;
    public const double OneThird = 1 / 3d;
    public const double TwoThird = 2 / 3d;
    public const double OneFourth = 1 / 4d;
    public const double OneSixth = 1 / 6d;
    public const double FiveSixth = 5 / 6d;
    public const double OneTwelfth = 1 / 12d;
    public const double One = 1d;

    //Scalars
    public const double Scalar360 = 360d;
    public const double Scalar1Over360 = 1 / 360d;
    public const double Scalar1 = 1d;


    public static readonly IEnumerable<object[]> Equivalencies = new Collection<object[]>()
    {
        new object[]
            {"Red", new Hsv(Zero, One, One), new Hsl(Zero, One, OneHalf), new Rgb(One, Zero, Zero)},
        new object[]
            {"Green", new Hsv(OneThird, One, One), new Hsl(OneThird, One, OneHalf), new Rgb(Zero, One, Zero)},
        new object[]
            {"Blue", new Hsv(TwoThird, One, One), new Hsl(TwoThird, One, OneHalf), new Rgb(Zero, Zero, One)},
        new object[]
            {"Yellow", new Hsv(OneSixth, One, One), new Hsl(OneSixth, One, OneHalf), new Rgb(One, One, Zero)},
        new object[]
            {"Cyan", new Hsv(OneHalf, One, One), new Hsl(OneHalf, One, OneHalf), new Rgb(Zero, One, One)},
        new object[]
            {"Magenta", new Hsv(FiveSixth, One, One), new Hsl(FiveSixth, One, OneHalf), new Rgb(One, Zero, One)},
        new object[]
            {"White", new Hsv(Zero, Zero, One), new Hsl(Zero, Zero, One), new Rgb(One, One, One)},
        new object[]
        {
            "Dark Orange", new Hsv(OneTwelfth, One, OneHalf), new Hsl(OneTwelfth, One, OneFourth),
            new Rgb(OneHalf, OneFourth, Zero)
        },
    };


    [Theory]
    [MemberData(nameof(Equivalencies))]
    public void TestHsvConversions(string colorName, Hsv hsv, Hsl hsl, Rgb rgb)
    {
        // convert hsv to rgb and hsl
        Assert.Equal(rgb, hsv.Scale(Scalar360, Scalar1, Scalar1).ToRgb(), new RgbComparer());
        Assert.Equal(hsl, hsv.Scale(Scalar360, Scalar1, Scalar1).ToHsl().Scale(Scalar1Over360, Scalar1, Scalar1), new HslComparer());
    }

    [Theory]
    [MemberData(nameof(Equivalencies))]
    public void TestHslConversions(string colorName, Hsv hsv, Hsl hsl, Rgb rgb)
    {
        //convert hsl to hsv and rgb
        Assert.Equal(hsv, hsl.Scale(Scalar360, Scalar1, Scalar1).ToHsv().Scale(Scalar1Over360, Scalar1, Scalar1), new HsvComparer());
        Assert.Equal(rgb, hsl.Scale(Scalar360, Scalar1, Scalar1).ToRgb(), new RgbComparer());
    }

    [Theory]
    [MemberData(nameof(Equivalencies))]
    public void TestRgbConversions(string colorName, Hsv hsv, Hsl hsl, Rgb rgb)
    {
        //convert rgb to hsv and hsl
        Assert.Equal(hsv, rgb.ToHsv().Scale(Scalar1Over360, Scalar1, Scalar1), new HsvComparer());
        Assert.Equal(hsl, rgb.ToHsl().Scale(Scalar1Over360, Scalar1, Scalar1), new HslComparer());
    }


    [Fact]
    public void ColorTestRed0()
    {
        var initialHsv = new Hsv(0, 1, 1);
        var scaledHsv = initialHsv.Scale(360, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(0, 1, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(1, 0, 0), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(255, 0, 0), scaledRgb);
    }

    [Fact]
    public void ColorTestRed360()
    {
        var initialHsv = new Hsv(1, 1, 1);
        var scaledHsv = initialHsv.Scale(360, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(360, 1, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(1, 0, 0), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(255, 0, 0), scaledRgb);
    }

    [Fact]
    public void ColorTestGreen()
    {
        var initialHsv = new Hsv(0.333333333333, 1, 1);
        var scaledHsv = initialHsv.Scale(360, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(120, 1, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(0, 1, 0), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(0, 255, 0), scaledRgb);
    }

    [Fact]
    public void ColorTestBlue()
    {
        var initialHsv = new Hsv(.66666666666, 1, 1);
        var scaledHsv = initialHsv.Scale(360, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(240, 1, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(0, 0, 1), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(0, 0, 255), scaledRgb);
    }

    [Fact]
    public void ColorTest0Saturation()
    {
        var initialHsv = new Hsv(0, 0, 1);
        var scaledHsv = initialHsv.Scale(360, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(0, 0, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(1, 1, 1), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(255, 255, 255), scaledRgb);
    }

    [Fact]
    public void ColorTest50Saturation()
    {
        var initialHsv = new Hsv(0, .5, 1);
        var scaledHsv = initialHsv.Scale(360d, 1d, 1d).RoundHue();
        Assert.Equal(new Hsv(0, .5, 1), scaledHsv);
        var initialRgb = scaledHsv.ToRgb();
        Assert.Equal(new Rgb(1, .5, .5), initialRgb);
        var scaledRgb = initialRgb.Scale(255).Round();
        Assert.Equal(new Rgb(255, 128, 128), scaledRgb);
    }
}