using UnityEngine;

namespace FoodConveyor
{
    public class MovementConstant : MonoBehaviour
    {
        public GameMode GameMode = GameMode.Menu;

        public Vector3 Direction;
        public Vector3 Rotation;

        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
        }

        private void Update()
        {
            if (GameManager.GetMode == GameMode)
            {
                float deltaTime = Time.deltaTime;
                _thisTransform.position += Direction * deltaTime;
                _thisTransform.Rotate(Rotation * deltaTime);
            }
        }
    }
}