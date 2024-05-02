using _Game.Scripts.Interfaces;
using _Game.Scripts.Services;
using UnityEngine;

namespace _Game.Scripts
{
    public enum FoodType { Banana, Cherry, Cheese, Hamburger, Hotdog }

    public class Food : MonoBehaviour, ISlotable
    {
        private const float DestroyPosition = -2;
    
        public FoodType foodType = FoodType.Banana;
    
        [Header("Slot")]
        [SerializeField] private Vector3 handPosition;
        [SerializeField] private Transform skinTransform;
    
    
        [Header("Conveyor")]
        [SerializeField] private Vector3 moveDirection;
    
        private SlotType _currentSlotType = SlotType.None;
        private Collider _thisCollider;
        private Player _player;
    
        public Transform GetTransform { get; private set; }

        private void Awake()
        {
            GetTransform = transform;
            _thisCollider = GetComponent<Collider>();
            _player = FindAnyObjectByType<Player>();
        }

        private void OnMouseDown()
        {
            if (GameManager.IsPlay == false) return;
        
            _player.AddToHand(this);
        }

        private void Update()
        {
            if (GameManager.IsPlay == false) return;
            if (_currentSlotType != SlotType.None) return;
        
            GetTransform.position += moveDirection * Time.deltaTime;

            if (GetTransform.position.x < DestroyPosition) Destroy(gameObject);
        }
    
        public void AddToSlot(SlotType type, Transform parent)
        {             
            Vector3 skinPosition = type == SlotType.Hand ? handPosition : Vector3.zero;

            GetTransform.parent = parent;
            GetTransform.localPosition = Vector3.zero;
            GetTransform.localRotation = Quaternion.identity;
            skinTransform.localPosition = skinPosition;
            _thisCollider.enabled = type == SlotType.None;
            _currentSlotType = type;
        }
    }
}