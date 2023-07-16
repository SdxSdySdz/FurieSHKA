using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using UnityEngine;

namespace CodeBase.Model
{
    public class FurieshkaSolver
    {
        public Furieshka Solve(ICurve curve, int gearsCount)
        {
            List<Circle> gears = new List<Circle>();
            int angularSpeed = 0;
            Complex radius = Integral.Integrate(
                t => EvaluateCoefficient(curve, angularSpeed, t), 
                0,
                1,
                1000
            );

            Circle gear = new Circle(radius, angularSpeed);
            gears.Add(gear);
            
            for (int i = 1; i < gearsCount; i++)
            {
                foreach (int sign in new [] {1, -1})
                {
                    angularSpeed = sign * i;
                    
                    radius = Integral.Integrate(
                        t => EvaluateCoefficient(curve, angularSpeed, t), 
                        0,
                        1,
                        1000
                    );

                    gear = new Circle(radius, angularSpeed);
                    gears.Add(gear);
                }
            }

            gears = gears.OrderByDescending(gear => gear.Radius.Magnitude).ToList();
            Furieshka furieshka = new Furieshka();
            foreach (var circle in gears)
            {
                furieshka.Add(circle);
            }

            return furieshka;
        }

        private Complex EvaluateCoefficient(ICurve curve, int n, double t)
        {
            return curve.Evaluate(t) * 
                   Complex.Exp(-2 * Math.PI * Complex.ImaginaryOne * n * t);
        }
    }
}