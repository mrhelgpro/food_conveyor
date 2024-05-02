using System;
using UnityEngine;

namespace _Game.Scripts.Services
{
    [Serializable]
    public class CanvasController
    {
        [Header("Main Windows")]
        [SerializeField] private GameObject menuCanvas;
        [SerializeField] private GameObject playCanvas;
        [SerializeField] private GameObject endCanvas;
        
        [Header("Result Windows")]
        [SerializeField] private GameObject winCanvas;
        [SerializeField] private GameObject lossCanvas;

        public void SetMenuWindow() => SetActive(menuCanvas);

        public void SetPlayWindow() => SetActive(playCanvas);

        public void SetEndWindow()
        {
            SetActive(endCanvas);

            if (GameManager.GetResult == GameResult.Win)
            {
                winCanvas.SetActive(true);
                lossCanvas.SetActive(false);
            }
            else
            {
                winCanvas.SetActive(false);
                lossCanvas.SetActive(true);
            }
        }

        private void SetActive(GameObject window)
        {
            menuCanvas.SetActive(false);
            playCanvas.SetActive(false);
            endCanvas.SetActive(false);

            window.SetActive(true);
        }
    }
}