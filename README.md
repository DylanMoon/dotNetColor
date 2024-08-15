# dotNetColor
This library was built to streamline color conversions between two or more systems.

## Example:

System 1 models color internally as HSV with the following ranges:
* Hue: [0-1]
* Saturation: [0-1]
* Value: [0-1]

System 2 models color internally as RGB with the following ranges:
* Red: [0-255]
* Green: [0-255]
* Blue: [0-255]

To convert from System 1 to System 2:
```cpp
var System1_To_System2 = Converters.ScaleHsv(new HueScalar(360d))
    .ConvertToRgb().Scale(
        new RedScalar(255), 
        new GreenScalar(255),
        new BlueScalar(255));
```
The above code snippet will return a mapping function with the signature Hsv -> Rgb.

To convert from System 2 to System 1:
```cpp
var System2_To_System1 = Converters.ScaleRgb(
    new RedScaler(1 / 255d),
    new GreenScaler(1 / 255d),
    new BlueScaler(1 / 255d)
    )
    .ConvertToHsv().Scale(
        new HueScaler(1/360d)
    );
```
The above code snippet will return a mapping function with the signature Rgb -> Hsv.

An example of usage would be:
```cpp
var input = new Hsv(0,1,1);
var output = System1_To_System2(input);
// can also optionally call: 
// var output = System1_To_System2?.Invoke(input);
```
In the above example output would be equal to:
```cpp
Rgb {Red = Red {Value = 255}, Green = Green {Value = 0}, Blue = Blue {Value = 0}}
```

The resulting structures can be either deconstructed or each value accessed directly.
```cpp
var (red, green, blue) = output;
```
In the above code, red, green, and blue can now be accessed individually and each includes an implicit conversion to double