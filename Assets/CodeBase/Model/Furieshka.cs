using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace CodeBase.Model
{
    public class Furieshka
    {
        private readonly List<Gear> _gears;

        public Furieshka()
        {
            _gears = new List<Gear>();
        }

        public List<Gear> Gears => _gears;

        public void Add(Gear gear)
        {
            _gears.Add(gear);
        }

        public Complex Evaluate(double t)
        {
            if (t.IsOutOfRange(0, 1))
                throw new ArgumentOutOfRangeException();
            
            if (_gears.Count == 0)
                return Complex.Zero;
            
            _gears[0].Position = Complex.Zero;
            Complex sum = _gears[0].Evaluate(t);
            
            for (int i = 1; i < _gears.Count; i++)
            {
                _gears[i].Position = sum;
                sum += _gears[i].Evaluate(t);
            }
            
            return sum;
        }
    }
}