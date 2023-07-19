using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace FoodConveyor
{
    [Serializable]
    public class CanvasController
    {
        [Header("Main Windows")]
        [SerializeField] private GameObject _menuCanvas;
        [SerializeField] private GameObject _playCanvas;
        [SerializeField] private GameObject _endCanvas;
        
        [Header("Result Windows")]
        [SerializeField] private GameObject _winCanvas;
        [SerializeField] private GameObject _lossCanvas;

        public void SetMenuWindow() => SetActive(_menuCanvas);

        public void SetPlayWindow() => SetActive(_playCanvas);

        public void SetEndWindow()
        {
            SetActive(_endCanvas);

            if (GameManager.GetResult == GameResult.Win)
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

        private void SetActive(GameObject window)
        {
            _menuCanvas.SetActive(false);
            _playCanvas.SetActive(false);
            _endCanvas.SetActive(false);

            window.SetActive(true);
        }
    }
}

