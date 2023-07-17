using Cinemachine;
using UnityEngine;

namespace FoodConveyor
{
    public class CameraManager : GameBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _menuCamera;
        [SerializeField] private CinemachineVirtualCamera _playCamera;
        [SerializeField] private CinemachineVirtualCamera _gameOverCamera;

        public override void OnMenuHandler()
        {
            _menuCamera.Priority = 1;
            _playCamera.Priority = 0;
            _gameOverCamera.Priority = 0;
        }

        public override void OnPlayHandler()
        {
            _menuCamera.Priority = 0;
            _playCamera.Priority = 1;
            _gameOverCamera.Priority = 0;
        }

        public override void OnEndHandler(GameResult result)
        {
            _menuCamera.Priority = 0;
            _playCamera.Priority = 0;
            _gameOverCamera.Priority = 1;
        }

        public override void OnNextLevelHandler()
        {
            _menuCamera.Priority = 0;
            _playCamera.Priority = 0;
            _gameOverCamera.Priority = 0;
        }
    }
}