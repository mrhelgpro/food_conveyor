using UnityEngine;

namespace FoodConveyor
{
    public enum SlotType { None, Hand, Storage }

    public interface ISlotable
    {
        public void AddToSlot(SlotType type, Transform parent);
        public Transform GetTransform { get; }
    }
}