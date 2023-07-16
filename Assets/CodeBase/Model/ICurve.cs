using System.Numerics;

namespace CodeBase.Model
{
    public interface ICurve
    {
        Complex Evaluate(double t);
    }
}