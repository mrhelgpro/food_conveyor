using UnityEngine;

namespace _Game.Scripts
{
    public class DirectionRig : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Update()
        {
            transform.localEulerAngles = new Vector3(90, target.eulerAngles.y - 180, 0);
        }
    }
}