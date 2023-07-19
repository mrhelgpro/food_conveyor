using System;
using UnityEngine;

namespace FoodConveyor
{
    public enum GameMode { Menu, Play, End }
    public enum GameResult { Win, Loss }

    public static class GameManager
    {       
        private static GameMode _mode = GameMode.Menu;
        private static GameResult _result;

        // Actions    
        public static event Action OnMenuEvent;
        public static event Action OnPlayEvent;
        public static event Action OnEndEvent;

        // Properties
        public static GameResult GetResult => _result;
        public static GameMode GetMode => _mode;
        public static bool IsMenu => _mode == GameMode.Play;
        public static bool IsPlay => _mode == GameMode.Play;
        public static bool IsEnd => _mode == GameMode.Play;

        public static void StartMenu()
        {
            _mode = GameMode.Menu;
            OnMenuEvent?.Invoke();
        }

        public static void StartPlay()
        {
            _mode = GameMode.Play;
            OnPlayEvent?.Invoke();
        }

        public static void EndPlay(GameResult result)
        {
            _mode = GameMode.End;
            _result = result;

            OnEndEvent?.Invoke();
        }
    }

    public abstract class GameBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            GameManager.OnMenuEvent += OnMenuHandler;
            GameManager.OnPlayEvent += OnPlayHandler;
            GameManager.OnEndEvent += OnEndHandler;
        }

        private void OnDisable()
        {
            GameManager.OnMenuEvent -= OnMenuHandler;
            GameManager.OnPlayEvent -= OnPlayHandler;
            GameManager.OnEndEvent -= OnEndHandler;
        }

        public virtual void OnMenuHandler() { }
        public virtual void OnPlayHandler() { }
        public virtual void OnEndHandler() { }
    }
}