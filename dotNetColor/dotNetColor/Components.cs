namespace dotNetColor;

    public readonly record struct Hue(double Value)
    {
        public static implicit operator double(Hue val) => val.Value;
        public static implicit operator Hue(double val) => new Hue(val);
    };

    public readonly record struct Saturation(double Value)
    {
        public static implicit operator double(Saturation val) => val.Value;
        public static implicit operator Saturation(double val) => new Saturation(val);
    };

    public readonly record struct Value(double Val)
    {
        public static implicit operator double(Value val) => val.Val;
        public static implicit operator Value(double val) => new Value(val);
    };

    public readonly record struct Lightness(double Value)
    {
        public static implicit operator double(Lightness val) => val.Value;
        public static implicit operator Lightness(double val) => new Lightness(val);
    };

    public readonly record struct Red(double Value)
    {
        public static implicit operator double(Red val) => val.Value;
        public static implicit operator Red(double val) => new Red(val);
    };

    public readonly record struct Green(double Value)
    {
        public static implicit operator double(Green val) => val.Value;
        public static implicit operator Green(double val) => new Green(val);
    };

    public readonly record struct Blue(double Value)
    {
        public static implicit operator double(Blue val) => val.Value;
        public static implicit operator Blue(double val) => new Blue(val);
    };