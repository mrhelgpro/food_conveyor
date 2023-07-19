using UnityEngine;

namespace FoodConveyor
{
    public class MoveToTarget : MonoBehaviour
    {
        public GameMode GameMode = GameMode.Menu;

        public Transform Target;
        public float Speed = 1;

        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
        }

        private void Update()
        {
            if (GameManager.GetMode == GameMode)
            {
                float distance = Vector3.Distance(_thisTransform.position, Target.position);

                if (distance > 0.1f)
                {
                    Vector3 direction = Target.position - _thisTransform.position;
                    Vector3 movement = direction.normalized * Speed * Time.deltaTime;
                    _thisTransform.position += movement;
                }
            }
        }
    }
}