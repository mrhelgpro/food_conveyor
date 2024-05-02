using _Game.Scripts.Services;
using UnityEngine;

namespace _Game.Scripts.Components
{
    public class MoveToTarget : MonoBehaviour
    {
        private const float Tolerance = 0.1f;
        public GameMode gameMode = GameMode.Menu;

        public Transform target;
        public float speed = 3;

        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
        }

        private void Update()
        {
            if (GameManager.GetMode == gameMode)
            {
                float distance = Vector3.Distance(_thisTransform.position, target.position);

                if (distance > Tolerance)
                {
                    Vector3 direction = target.position - _thisTransform.position;
                    Vector3 movement = direction.normalized * (speed * Time.deltaTime);
                    _thisTransform.position += movement;
                }
            }
        }
    }
}