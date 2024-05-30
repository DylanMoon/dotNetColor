namespace dotNetColor;

public interface IScaler { double Value { get; } }

public record HueScaler(double Value):IScaler;
public record SaturationScaler(double Value):IScaler;
public record ValueScaler(double Value):IScaler;
public record LightnessScaler(double Value):IScaler;
public record RedScaler(double Value):IScaler;
public record GreenScaler(double Value):IScaler;
public record BlueScaler(double Value):IScaler;