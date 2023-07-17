using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public enum GameMode { Menu, Play, End }
    public enum GameResult { Win, Loss }

    public class GameManager : MonoBehaviour
    {       
        private static GameMode _mode = GameMode.Menu;

        // Fields    
        private static List<GameBehaviour> _gameBehaviourList = new List<GameBehaviour>();
        public static event System.Action OnMenuEvent;

        // Properties
        public static bool IsMenu => _mode == GameMode.Play;
        public static bool IsPlay => _mode == GameMode.Play;
        public static bool IsEnd => _mode == GameMode.Play;

        // Methods
        private void Start()
        {
            _gameBehaviourList.AddRange(FindObjectsOfType<GameBehaviour>());

            StartMenu();
        }

        public static void StartMenu()
        {
            _mode = GameMode.Menu;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnMenuHandler();

            OnMenuEvent?.Invoke();
        }

        public static void StartPlay()
        {
            _mode = GameMode.Play;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnPlayHandler();

            OnMenuEvent?.Invoke();
        }

        public static void EndPlay(GameResult result)
        {
            _mode = GameMode.End;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnEndHandler(result);
        }

        public static void NextLevel()
        {
            _mode = GameMode.Play;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnNextLevelHandler();
            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnPlayHandler();
        }
    }

    public abstract class GameBehaviour : MonoBehaviour
    {
        public virtual void OnMenuHandler() { }
        public virtual void OnPlayHandler() { }
        public virtual void OnEndHandler(GameResult result) { }
        public virtual void OnNextLevelHandler() { }
    }
}