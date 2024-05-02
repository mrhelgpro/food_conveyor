using System;
using TMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Game.Scripts.Services
{
    [Serializable]
    public class TaskController
    {
        private const string CollectText = "Collect";
        private const string AddState = "Add";
        
        [SerializeField] private Transform cartTransform;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI taskText;
        [SerializeField] private RectTransform parentRectTransform;
        [SerializeField] private GameObject additiveEffect;
        [SerializeField] private Animator additiveAnimator;
        
        private FoodType _foodType;
        private int _requiredAmountOfFoods;
        private int _currentAmountOfFoods;
        private bool _isAllCorrect = true;

        public void CreateNewTask()
        {
            _isAllCorrect = true;
            _requiredAmountOfFoods = 0;
            _currentAmountOfFoods = 0;
            
            int randomType = UnityEngine.Random.Range(0, Enum.GetValues(typeof(FoodType)).Length);
            int randomAmount = UnityEngine.Random.Range(1, 5);

            _foodType = (FoodType)randomType;
            _requiredAmountOfFoods = randomAmount;
            
            taskText.text = CollectText + " " + _requiredAmountOfFoods + " " + _foodType;
            scoreText.text = _currentAmountOfFoods.ToString();
        }

        public void CreateAdditiveEffect(Food food)
        {
            if (Camera.main != null)
            {
                Vector3 screenPosition = Camera.main.WorldToScreenPoint(cartTransform.position);

                GameObject instance = Object.Instantiate(additiveEffect);
                RectTransform rectInstance = instance.GetComponent<RectTransform>();
                rectInstance.SetParent(parentRectTransform);
                rectInstance.anchorMin = Vector2.zero;
                rectInstance.anchorMax = Vector2.zero;
                rectInstance.anchoredPosition = screenPosition;

                AdditiveEffect effect = instance.GetComponent<AdditiveEffect>();
                effect.AddFood(scoreText.transform, this, food);
            }
        }

        public void AddFood(Food food)
        {
            _currentAmountOfFoods++;

            if (_isAllCorrect) _isAllCorrect = food.foodType == _foodType;

            if (_currentAmountOfFoods == _requiredAmountOfFoods)
            {
                GameManager.EndPlay(_isAllCorrect ? GameResult.Win : GameResult.Loss);
            }

            scoreText.text = _currentAmountOfFoods.ToString();
            
            additiveAnimator.Play(AddState);
        }
    }
}