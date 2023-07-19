using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class AdditiveEffect : MonoBehaviour
    {
        private Transform _target;
        private TaskController _task;
        private Food _food;

        [SerializeField] private float _speed = 2;
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

                if (distance > 10f)
                {
                    Vector3 direction = _target.position - _thisTransform.position;
                    Vector3 movement = direction.normalized * _speed * 100 * Time.deltaTime;
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