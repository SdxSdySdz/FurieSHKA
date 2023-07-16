using System;
using System.Numerics;

namespace CodeBase.Model
{
    public static class Integral
    {
        public static Complex Integrate(Func<double, Complex> f, double from, double to, int segmentsCount)
        {
            double h = (to - from) / segmentsCount;

            Complex sum = (f(from) + f(to)) / 2;
            for (int i = 1; i < segmentsCount; i++)
            {
                double t = from + i * h;
                sum += f(t);
            }

            return sum * h;
        }
    }
}