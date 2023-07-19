using UnityEngine;

namespace FoodConveyor
{
    public class LevelManager : GameBehaviour
    {
        // Fields Task
        [SerializeField] private TaskController _task;
        [SerializeField] private CanvasController _canvas;

        // Methods
        private void Start() => GameManager.StartMenu();

        public void StartPlay() => GameManager.StartPlay();

        public override void OnMenuHandler()
        {
            _canvas.SetMenuWindow();
        }

        public override void OnPlayHandler()
        {
            _task.CreateNewTask();
            _canvas.SetPlayWindow();
        }

        public override void OnEndHandler()
        {
            _canvas.SetEndWindow();
        }

        public void AddFood(Food food)
        {
            _task.CreateAdditiveEffect(food);
        }
    }
}