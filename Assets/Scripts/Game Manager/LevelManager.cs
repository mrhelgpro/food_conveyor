using UnityEngine;

namespace FoodConveyor
{
    public class LevelManager : GameBehaviour
    {
        // Fields Task
        [SerializeField] private TaskController _task;
        [SerializeField] private CanvasController _canvas;
        [SerializeField] private Player _player;

        public override void OnMenuHandler()
        {
            _canvas.SetMenuWindow();
            _player.SetMenu();
        }

        public override void OnPlayHandler()
        {
            _task.CreateNewTask();
            _canvas.SetPlayWindow();
            _player.SetPlay();
        }

        public override void OnEndHandler(GameResult result)
        {
            _canvas.SetEndWindow(result);
            _player.SetEnd(result);
        }

        public override void OnNextLevelHandler()
        {
            OnPlayHandler();
        }

        public void AddFood(Food food)
        {
            //_task.AddFood(food);
            _task.CreateAdditiveEffect(food);
        }
    }
}

