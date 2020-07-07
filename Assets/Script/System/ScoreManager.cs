using System;
using UnityEngine;

namespace GameSystem
{
    public class ScoreManager : MonoBehaviour, IScoreManagerAdapter
    {
        // Singleton
        public static ScoreManager _instance;

        // State
        [Header("State")]
        [SerializeField]
        private SystemDefine.EGameState gameState;

        // Current, High score
        [Header("Score")]
        [SerializeField]
        private int currentScore;
        [SerializeField]
        private int highScore;

        // SetScore event
        private event SystemDefine.VoidEvent setCurrentScoreEvent;
        private event SystemDefine.VoidEvent setHighScoreEvent;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Make singleton
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
            // Initialize score
            currentScore = 0;
            // Initialize event
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Start, StartEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Playing, PlayingEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Fall, FallEvent);
            // Change high score
            highScore = PlayerPrefs.GetInt("HighScore");
        }


        private void StartEvent()
        {
            SetState(SystemDefine.EGameState.Start);
            currentScore = 0;
        }

        private void PlayingEvent()
        {
            SetState(SystemDefine.EGameState.Playing);
        }

        private void FallEvent()
        {
            SetState(SystemDefine.EGameState.Fall);
            SetHighScore(currentScore);
        }

        public int GetCurrentScore()
        {
            return currentScore;
        }

        public int GetHighScore()
        {
            return highScore;
        }

        public void SetCurrentScore(int score)
        {
            // If not in playing state, return
            if (gameState != SystemDefine.EGameState.Playing)
                return;
            // Set new current score
            currentScore = score;
            // Run setScore event
            setCurrentScoreEvent?.Invoke();
        }

        public bool SetHighScore(int score)
        {
            if (score > highScore)
            {
                // Set new high score
                highScore = score;
                // Save high score
                PlayerPrefs.SetInt("HighScore", highScore);
                // Run setScore event
                setHighScoreEvent?.Invoke();
                return true;
            }
            else
            {
                return false;
            }
        }

        public SystemDefine.EGameState GetState()
        {
            return gameState;
        }

        public void SetStateEvent(SystemDefine.EGameState state, SystemDefine.VoidEvent func)
        {
            switch (state)
            {
                case SystemDefine.EGameState.Start:
                    startEvent += func;
                    break;
                case SystemDefine.EGameState.Playing:
                    playingEvent += func;
                    break;
                case SystemDefine.EGameState.Fall:
                    fallEvent += func;
                    break;
            }
        }

        public SystemDefine.VoidEvent GetScoreEvent(SystemDefine.EScoreType type)
        {
            switch (type)
            {
                case SystemDefine.EScoreType.Current:
                    return setCurrentScoreEvent;
                case SystemDefine.EScoreType.High:
                    return setHighScoreEvent;
                default:
                    return null;
            }
        }

        public void SetState(SystemDefine.EGameState state)
        {
            gameState = state;
            switch (gameState)
            {
                case SystemDefine.EGameState.Start:
                    startEvent?.Invoke();
                    break;
                case SystemDefine.EGameState.Playing:
                    playingEvent?.Invoke();
                    break;
                case SystemDefine.EGameState.Fall:
                    fallEvent?.Invoke();
                    break;
            }
        }


    }
}
