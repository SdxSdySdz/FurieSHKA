namespace CodeBase.Model
{
    public static class DoubleExtensions
    {
        public static bool IsOutOfRange(this double x, double min, double max)
        {
            return x < min || x > max;
        }

        public static bool IsInRange(this double x, double min, double max)
        {
            return x >= min && x <= max;
        }
    }
}