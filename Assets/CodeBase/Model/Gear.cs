using System.Numerics;

namespace CodeBase.Model
{
    public abstract class Gear
    {
        protected readonly double AngularSpeed;
        
        public Complex Position;

        protected Gear(double angularSpeed)
        {
            AngularSpeed = angularSpeed;
            Position = Complex.Zero;
        }

        public abstract Complex Evaluate(double t);
        
        protected bool IsTimeIncorrect(double t)
        {
            return t.IsOutOfRange(0, 1);
        }
    }
}