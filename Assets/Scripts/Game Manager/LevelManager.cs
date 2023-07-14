using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public class LevelManager : GameBehaviour
    {
        // Fields Task
        private static FoodType _taskFoodType;
        private static int _taskAmountOfFoods;
        private static bool _isTaskCorrect = true;

        // Fields Buffer    
        private static List<Food> _foods = new List<Food>();

        // Properties
        public static FoodType GetTaskFoodType => _taskFoodType;
        public static int GetCurrentAmountOfFoods => _foods.Count;
        public static int GetTaskAmountOfFoods => _taskAmountOfFoods;

        public override void OnPlayHandler()
        {
            int randomType = Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
            int randomAmount = Random.Range(1, 5);

            _taskFoodType = (FoodType)randomType;
            _taskAmountOfFoods = randomAmount;

            Debug.Log("Random Food Type: " + _taskFoodType + " Amount: " + _taskAmountOfFoods);
        }

        public override void OnNextLevelHandler()
        {
            _foods.Clear();
        }

        public static void AddFood(Food food)
        {
            _foods.Add(food);

            if (_isTaskCorrect == true) _isTaskCorrect = food.Type == _taskFoodType;

            if (_foods.Count == _taskAmountOfFoods)
            {
                GameManager.EndPlay(_isTaskCorrect == true ? GameResult.Win : GameResult.Loss);
            }
        }
    }
}

