using System;
using System.Numerics;

namespace CodeBase.Model
{
    public class Circle : Gear
    {
        private const double PI2 = 2 * Math.PI;

        private readonly Complex _radius;
    
        public Circle(Complex radius, double angularSpeed) : base(angularSpeed)
        {
            _radius = radius;
        }

        public Complex Radius => _radius;
        
        public override Complex Evaluate(double t)
        {
            if (IsTimeIncorrect(t))
                throw new ArgumentOutOfRangeException(nameof(t));
        
            return _radius * Complex.Exp(PI2 * AngularSpeed * Complex.ImaginaryOne * t);
            return Complex.FromPolarCoordinates(_radius.Magnitude, AngularSpeed * PI2 * t);
        }
    }
}