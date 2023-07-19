using System;
using UnityEngine;
using TMPro;

namespace FoodConveyor
{
    [Serializable]
    public class TaskController
    {
        // Task Fields
        private FoodType _foodType;
        private int _requiredAmountOfFoods;
        private int _currentAmountOfFoods;
        private bool _isAllCorrect = true;

        // View Fields
        [SerializeField] private RectTransform _parentTransform;
        [SerializeField] private Transform _cartTransform;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _taskText;
        [SerializeField] private GameObject _additiveEffect;
        [SerializeField] private Animator _additiveAnimator;

        // Methods
        public void CreateNewTask()
        {
            // Reset Fields
            _isAllCorrect = true;
            _requiredAmountOfFoods = 0;
            _currentAmountOfFoods = 0;

            // Settings Fields
            int randomType = UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(FoodType)).Length);
            int randomAmount = UnityEngine.Random.Range(1, 5);

            _foodType = (FoodType)randomType;
            _requiredAmountOfFoods = randomAmount;

            // Update View
            _taskText.text = "Collect " + _requiredAmountOfFoods + " " + _foodType.ToString();
            _scoreText.text = "0";
        }

        public void CreateAdditiveEffect(Food food)
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(_cartTransform.position);

            GameObject instance = GameObject.Instantiate(_additiveEffect);
            RectTransform rectInstance = instance.GetComponent<RectTransform>();
            rectInstance.SetParent(_parentTransform);
            rectInstance.anchorMin = Vector2.zero;
            rectInstance.anchorMax = Vector2.zero;
            rectInstance.anchoredPosition = screenPosition;

            AdditiveEffect effect = instance.GetComponent<AdditiveEffect>();
            effect.AddFood(_scoreText.transform, this, food);
        }

        public void AddFood(Food food)
        {
            // Update Fields
            _currentAmountOfFoods++;

            if (_isAllCorrect == true) _isAllCorrect = food.Type == _foodType;

            if (_currentAmountOfFoods == _requiredAmountOfFoods)
            {
                GameManager.EndPlay(_isAllCorrect == true ? GameResult.Win : GameResult.Loss);
            }

            // Update View
            _scoreText.text = _currentAmountOfFoods.ToString();
            _additiveAnimator.Play("Add");
        }
    }
}