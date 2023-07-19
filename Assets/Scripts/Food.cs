using UnityEngine;

namespace FoodConveyor
{
    public enum FoodType { Banana, Cherry, Cheese, Hamburger, Hotdog }

    public class Food : MonoBehaviour, ISlotable
    {
        public FoodType Type = FoodType.Banana;

        [Header("Slotable")]
        [SerializeField] private Vector3 _handPosition;
        [SerializeField] private Transform _skinTransform;
        private SlotType _currentSlotType = SlotType.None;

        [Header("Conveyor")]
        [SerializeField] private Vector3 _moveDirection;

        // Buffer
        private Transform _thisTransform;
        private Collider _thisCollider;

        private void Awake()
        {
            _thisTransform = transform;
            _thisCollider = GetComponent<Collider>();
        }

        private void OnMouseDown()
        {
            if (GameManager.IsPlay)
            {
                Player player = FindAnyObjectByType<Player>();
                player.AddToHand(this);
            }
        }

        private void Update()
        {
            if (GameManager.IsPlay)
            {
                if (_currentSlotType == SlotType.None)
                {
                    _thisTransform.position += _moveDirection * Time.deltaTime;

                    if (_thisTransform.position.x < -2) Destroy(gameObject);
                }
            }
        }

        // ISlotable
        public void AddToSlot(SlotType type, Transform parent)
        {             
            Vector3 skinPosition = type == SlotType.Hand ? _handPosition : Vector3.zero;

            _thisTransform.parent = parent;
            _thisTransform.localPosition = Vector3.zero;
            _thisTransform.localRotation = Quaternion.identity;
            _skinTransform.localPosition = skinPosition;
            _thisCollider.enabled = type == SlotType.None;
            _currentSlotType = type;
        }

        public Transform GetTransform => _thisTransform;
    }
}