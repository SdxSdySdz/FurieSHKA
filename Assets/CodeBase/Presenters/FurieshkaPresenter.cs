using System.Collections.Generic;
using CodeBase.Model;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace CodeBase.Presenters
{
    public class FurieshkaPresenter : MonoBehaviour
    {
        [SerializeField] private float _timeMultiplier;
        [SerializeField] private CirclePresenter _gearPresenterPrefab;
        
        private Furieshka _model;
        private float _time;
        private List<CirclePresenter> _gearPresenters;
        private List<Vector2> _tail;

        public void Construct(Furieshka model)
        {
            _model = model;
            _tail = new List<Vector2>();
            _gearPresenters = new List<CirclePresenter>();
            foreach (var gear in _model.Gears)
            {
                CirclePresenter gearPresenter = Instantiate(
                    _gearPresenterPrefab,
                    transform.position,
                    Quaternion.identity
                );
                
                gearPresenter.Construct(gear as Circle);
                
                _gearPresenters.Add(gearPresenter);
            }
        }

        private void Update()
        {
            if (_model == null)
                return;
            
            Vector2 dot = _model.Evaluate((_time * _timeMultiplier) % 1f).ToVector();
            _tail.Add(dot);
            _time += Time.deltaTime;
        }

        private void OnDrawGizmos()
        {
            if (_tail == null)
                return;
            Gizmos.color = Color.yellow;
            for (int i = 0; i < _tail.Count - 1; i++)
            {
                Gizmos.DrawLine(_tail[i], _tail[i + 1]);
            }
        }
    }
}