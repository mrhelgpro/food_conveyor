using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class MovementConstant : MonoBehaviour
    {
        public Vector3 Direction;
        public Vector3 Rotation;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        public void Update()
        {
            if (GameManager.IsPlay)
            {
                _transform.position += Direction * Time.deltaTime;
                _transform.Rotate(Rotation * Time.deltaTime);
            }
        }
    }
}