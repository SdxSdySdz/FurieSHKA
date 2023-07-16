using CodeBase.Model;
using UnityEngine;

namespace CodeBase.Presenters
{
    public class CurvePresenter<TCurve> : MonoBehaviour
        where TCurve : ICurve
    {
        protected TCurve Model;

        public void Construct(TCurve curve)
        {
            Model = curve;
        }
    }
}