using Cinemachine;
using UnityEngine;

namespace _Game.Scripts.Services
{
    public class CameraManager : GameBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera menuCamera;
        [SerializeField] private CinemachineVirtualCamera playCamera;
        [SerializeField] private CinemachineVirtualCamera gameOverCamera;

        protected override void OnMenuHandler()
        {
            menuCamera.Priority = 1;
            playCamera.Priority = 0;
            gameOverCamera.Priority = 0;
        }

        protected override void OnPlayHandler()
        {
            menuCamera.Priority = 0;
            playCamera.Priority = 1;
            gameOverCamera.Priority = 0;
        }

        protected override void OnEndHandler()
        {
            menuCamera.Priority = 0;
            playCamera.Priority = 0;
            gameOverCamera.Priority = 1;
        }
    }
}