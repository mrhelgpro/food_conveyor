using System.Collections.Generic;
using _Game.Scripts.Interfaces;
using _Game.Scripts.Services;
using UnityEngine;

namespace _Game.Scripts
{
    public class Cart : GameBehaviour
    {
        [SerializeField] private List<Transform> slots = new ();
        private readonly List<ISlotable> _items = new ();

        private LevelManager _levelManager;

        private void Start()
        {
            _levelManager = FindAnyObjectByType<LevelManager>();
        }

        protected override void OnPlayHandler()
        {
            foreach (ISlotable slot in _items)
            {
                Destroy(slot.GetTransform.gameObject);
            }

            _items.Clear();
        }

        public void AddToCart(ISlotable slot)
        {
            if (slots.Count > _items.Count)
            {
                _items.Add(slot);
                slot.AddToSlot(SlotType.Storage, slots[_items.Count - 1]);

                _levelManager.AddFood(slot.GetTransform.GetComponent<Food>());

                return;
            }

            slot.AddToSlot(SlotType.None, null);
        }
    }
}