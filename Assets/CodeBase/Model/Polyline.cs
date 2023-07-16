using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Model
{
    public class Polyline : ICurve
    {
        private readonly List<Complex> _vertices;
        private readonly double[] _lengths;
        private readonly double _length;

        public Polyline(IEnumerable<Complex> vertices, bool isClosed = false)
        {
            _vertices = vertices.ToList();

            if (_vertices.Count < 2)
                throw new ArgumentOutOfRangeException(nameof(vertices));
            
            if (isClosed)
                _vertices.Add(_vertices[0]);

            _lengths = CalculateLengths(_vertices);
            _length = _lengths.Sum();
        }

        public List<Complex> Vertices => _vertices;

        public Complex Evaluate(double t)
        {
            if (t.IsOutOfRange(0, 1))
                throw new ArgumentOutOfRangeException(nameof(t));
            
            double scaledT = ScaleTimeToCorrespondingSegment(t, out int segmentIndex);
            Complex interpolation = InterpolateSegment(segmentIndex, scaledT);

            return interpolation;
        }

        private double[] CalculateLengths(List<Complex> vertices)
        {
            double[] lengths = new double[vertices.Count - 1];
            for (int i = 0; i < lengths.Length; i++)
            {
                lengths[i] = (vertices[i + 1] - vertices[i]).Magnitude;
            }

            return lengths;
        }

        private double ScaleTimeToCorrespondingSegment(double t, out int segmentIndex)
        {
            double sum = 0;
            double scaledT = 0;
            segmentIndex = 0;
            double segmentLength = 0;

            for (int i = 0; i < _lengths.Length; i++)
            {
                sum += _lengths[i];
                
                if (t * _length <= sum)
                {
                    segmentIndex = i;
                    segmentLength = _lengths[i];
                    break;
                }
            }

            scaledT = (t * _length - (sum - segmentLength)) / segmentLength;
            return scaledT;
        }

        private Complex InterpolateSegment(int index, double t)
        {
            return _vertices[index] + t * (_vertices[index + 1] - _vertices[index]);
        }
    }
}