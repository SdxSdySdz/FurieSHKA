using CodeBase.Model;
using UnityEngine;

namespace CodeBase.Presenters
{
    public class PolylinePresenter : CurvePresenter<Polyline>
    {
        [SerializeField] private bool _isGizmosNeeded;
        
        private void OnDrawGizmos()
        {
            if (_isGizmosNeeded == false || Model == null)
                return;
            
            for (int i = 0; i < Model.Vertices.Count - 1; i++)
            {
                Gizmos.DrawLine(Model.Vertices[i].ToVector(), Model.Vertices[i + 1].ToVector());
            }

            Gizmos.color = Color.red;
            int n = 30;
            for (int i = 0; i < n; i++)
            {
                double t = (double)i / n;
                double nextT = (double)(i+1) / n;
                Vector2 from = Model.Evaluate(t).ToVector();
                Vector2 to = Model.Evaluate(nextT).ToVector();
                Gizmos.DrawLine(from, to);
            }
        }
    }
}