using UnityEngine;

namespace FoodConveyor
{
    public enum FoodType { Banana, Cherry, Watermelon, Cheese, Hamburger, Hotdog, Olive }

    public class Food : MonoBehaviour
    {
        public FoodType Type = FoodType.Banana;

        private void OnMouseDown()
        {
            if (GameManager.GetMode == GameMode.Play)
            {
                Player player = FindAnyObjectByType<Player>();
                player.AddToHand(gameObject);
            }
        }
    }
}