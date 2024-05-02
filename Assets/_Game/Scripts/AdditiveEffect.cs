using _Game.Scripts.Services;
using UnityEngine;

namespace _Game.Scripts
{
    public class AdditiveEffect : MonoBehaviour
    {
        private const float Tolerance = 10f;
        private const float Speed = 2000;
        
        private Transform _target;
        private TaskController _task;
        private Food _food;
        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (_target)
            {
                float distance = Vector3.Distance(_thisTransform.position, _target.position);

                if (distance > Tolerance)
                {
                    Vector3 direction = _target.position - _thisTransform.position;
                    Vector3 movement = direction.normalized * (Speed * Time.deltaTime);
                    _thisTransform.position += movement;
                }
                else
                {
                    _task.AddFood(_food);

                    Destroy(gameObject);
                }
            }
        }

        public void AddFood(Transform uiTarget, TaskController task, Food food)
        {
            _target = uiTarget;
            _task = task;
            _food = food;

            gameObject.SetActive(true);
        }
    }
}