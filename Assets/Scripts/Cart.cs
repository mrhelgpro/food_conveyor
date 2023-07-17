using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class Cart : GameBehaviour
    {
        [SerializeField] private List<Transform> _slots = new List<Transform>();
        [SerializeField] private List<ISlotable> _items = new List<ISlotable>();

        public override void OnPlayHandler()
        {
            foreach (ISlotable slotable in _items)
            {
                Destroy(slotable.GetTransform.gameObject);
            }

            _items.Clear();
        }

        public void AddToCart(ISlotable slotable)
        {
            if (_slots.Count > _items.Count)
            {
                _items.Add(slotable);
                slotable.AddToSlot(SlotType.Storage, _slots[_items.Count - 1]);

                LevelManager.AddFood(slotable.GetTransform.GetComponent<Food>());

                return;
            }

            slotable.AddToSlot(SlotType.None, null);
        }
    }
}