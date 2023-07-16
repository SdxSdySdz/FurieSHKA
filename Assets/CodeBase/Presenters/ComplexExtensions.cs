using System.Numerics;
using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Presenters
{
    public static class ComplexExtensions
    {
        public static Vector2 ToVector(this Complex number)
        {
            return new Vector2((float)number.Real, (float)number.Imaginary);
        }
    }
}