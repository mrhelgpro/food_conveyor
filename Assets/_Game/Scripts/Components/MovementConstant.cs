using _Game.Scripts.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Game.Scripts.Components
{
    public class MovementConstant : MonoBehaviour
    {
        [FormerlySerializedAs("GameMode")] public GameMode gameMode = GameMode.Menu;

        [FormerlySerializedAs("Direction")] public Vector3 direction;
        [FormerlySerializedAs("Rotation")] public Vector3 rotation;

        private Transform _thisTransform;

        private void Awake()
        {
            _thisTransform = transform;
        }

        private void Update()
        {
            if (GameManager.GetMode == gameMode)
            {
                float deltaTime = Time.deltaTime;
                _thisTransform.position += direction * deltaTime;
                _thisTransform.Rotate(rotation * deltaTime);
            }
        }
    }
}