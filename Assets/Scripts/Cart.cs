using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class Cart : GameBehaviour
    {
        [SerializeField] private List<Transform> _slots = new List<Transform>();
        [SerializeField] private List<Transform> _items = new List<Transform>();

        public override void OnPlayHandler()
        {
            foreach (Transform item in _items)
            {
                Destroy(item.gameObject);
            }

            _items.Clear();
        }

        public void AddToCart(Transform item)
        {
            item.GetComponent<Collider>().enabled = false;

            if (_slots.Count > _items.Count)
            {
                _items.Add(item);
                item.parent = _slots[_items.Count -1];
                item.localPosition = Vector3.zero;
                LevelManager.AddFood(item.GetComponent<Food>());

                return;
            }

            item.parent = null;
        }
    }
}