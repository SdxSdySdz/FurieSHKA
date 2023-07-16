using System;
using System.Collections.Generic;
using System.Numerics;
using CodeBase.Model;
using CodeBase.Presenters;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase
{
    public class Test : MonoBehaviour
    {
        [SerializeField] private FurieshkaPresenter _furieshkaPresenter;
        
        private void Start()
        {
            FurieshkaSolver solver = new FurieshkaSolver();

            /*List<Complex> vertices = new List<Complex>()
            {
                new Complex(0, 0),
                new Complex(0, 1),
                new Complex(1, 0),
            };*/
            
            List<Complex> vertices = new List<Complex>()
            {
                new Complex(0, 0),
                new Complex(1, 1),
                new Complex(2, 0),
            };
            Polyline curve = new Polyline(vertices, isClosed: true);

            // Debug.LogError(Integral.Integrate(f, -5, 5, 1000));

            Furieshka furieshka = solver.Solve(curve, 5);
            /*Furieshka furieshka = new Furieshka();
            furieshka.Add(new Circle(1, 1));
            furieshka.Add(new Circle(1.0/4, 4));*/
            _furieshkaPresenter.Construct(furieshka);

            PolylinePresenter polylinePresenter = Object.FindObjectOfType<PolylinePresenter>();
            polylinePresenter.Construct(curve);
            
            Debug.LogError(Integral.Integrate(f, 0, 1, 1000));
        }

        private Complex f(double t)
        {
            return Complex.Exp(-2 * Math.PI * Complex.ImaginaryOne * 10 * t);
        }
    }
}