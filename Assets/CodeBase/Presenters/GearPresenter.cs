using System.Numerics;
using CodeBase.Model;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Presenters
{
    public class GearPresenter<TGear> : MonoBehaviour
        where TGear : Gear
    {
        [SerializeField] private Transform _view;
        
        protected TGear Model { get; private set; }

        public void Construct(TGear model)
        {
            Model = model;
            OnConstructed();
            
            UpdateView();
        }

        private void Update()
        {
            if (Model == null)
                return;

            UpdateView();
        }

        protected virtual void OnConstructed()
        {
        }

        private void UpdateView()
        {
            transform.position = Model.Position.ToVector();
        }
    }
}