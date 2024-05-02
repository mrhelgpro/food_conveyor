using UnityEngine;

namespace _Game.Scripts.Services
{
    public class LevelManager : GameBehaviour
    {
        [SerializeField] private TaskController task;
        [SerializeField] private CanvasController canvas;

        private void Start() => GameManager.StartMenu();

        public void StartPlay() => GameManager.StartPlay();

        protected override void OnMenuHandler()
        {
            canvas.SetMenuWindow();
        }

        protected override void OnPlayHandler()
        {
            task.CreateNewTask();
            canvas.SetPlayWindow();
        }

        protected override void OnEndHandler()
        {
            canvas.SetEndWindow();
        }

        public void AddFood(Food food)
        {
            task.CreateAdditiveEffect(food);
        }
    }
}