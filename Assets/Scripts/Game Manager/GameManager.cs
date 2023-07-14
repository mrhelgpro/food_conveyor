using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FoodConveyor
{
    public enum GameMode { Menu, Play, GameOver }
    public enum GameResult { Win, Loss }

    public class GameManager : MonoBehaviour
    {       
        private static GameMode _mode = GameMode.Menu;

        // Fields    
        private static List<GameBehaviour> _gameBehaviourList = new List<GameBehaviour>();

        // Properties
        public static GameMode GetMode => _mode;

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
        }

        public static void StartPlay()
        {
            _mode = GameMode.Play;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnPlayHandler();
        }

        public static void EndPlay(GameResult result)
        {
            _mode = GameMode.GameOver;

            foreach (GameBehaviour gameBehaviour in _gameBehaviourList) gameBehaviour.OnGameOverHandler(result);
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
        public virtual void OnGameOverHandler(GameResult result) { }
        public virtual void OnNextLevelHandler() { }
    }
}