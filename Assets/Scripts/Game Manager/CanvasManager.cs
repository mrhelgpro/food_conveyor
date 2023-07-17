using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace FoodConveyor
{
    public class CanvasManager : GameBehaviour
    {
        [SerializeField] private GameObject _menuCanvas;
        [SerializeField] private GameObject _playCanvas;
        [SerializeField] private GameObject _gameOverCanvas;
        [SerializeField] private GameObject _winCanvas;
        [SerializeField] private GameObject _lossCanvas;
        [SerializeField] TextMeshProUGUI _scoreText;
        [SerializeField] TextMeshProUGUI _taskText;

        private void Update()
        {
            _scoreText.text = LevelManager.GetCurrentAmountOfFoods.ToString();
            _taskText.text = "Collect " + LevelManager.GetTaskAmountOfFoods + " " + LevelManager.GetTaskFoodType.ToString();
        }

        public override void OnMenuHandler() 
        {
            _menuCanvas.SetActive(true);
            _playCanvas.SetActive(false);
            _gameOverCanvas.SetActive(false);
        }

        public override void OnPlayHandler()
        {
            _menuCanvas.SetActive(false);
            _playCanvas.SetActive(true);
            _gameOverCanvas.SetActive(false);
        }

        public override void OnEndHandler(GameResult result)
        {
            _menuCanvas.SetActive(false);
            _playCanvas.SetActive(false);
            _gameOverCanvas.SetActive(true);

            if (result == GameResult.Win)
            {
                _winCanvas.SetActive(true);
                _lossCanvas.SetActive(false);
            }
            else
            {
                _winCanvas.SetActive(false);
                _lossCanvas.SetActive(true);
            }
        }

        public override void OnNextLevelHandler()
        {
            _menuCanvas.SetActive(false);
            _playCanvas.SetActive(false);
            _gameOverCanvas.SetActive(false);
        }
    }
}

