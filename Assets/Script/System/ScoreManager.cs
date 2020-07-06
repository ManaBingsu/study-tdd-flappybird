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
            // Set new current score
            currentScore = score;
            // Run setScore event
            setCurrentScoreEvent();
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
                setHighScoreEvent();
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

        public SystemDefine.VoidEvent GetStateEvent(SystemDefine.EGameState state)
        {
            switch (state)
            {
                case SystemDefine.EGameState.Start:
                    return startEvent;
                case SystemDefine.EGameState.Playing:
                    return playingEvent;
                case SystemDefine.EGameState.Fall:
                    return fallEvent;
                default:
                    return null;
            }
        }

        public void Initialize()
        {
            currentScore = 0;

        }

        public void SetState(SystemDefine.EGameState state)
        {
            gameState = state;
            switch (gameState)
            {
                case SystemDefine.EGameState.Start:
                    startEvent();
                    break;
                case SystemDefine.EGameState.Playing:
                    playingEvent();
                    break;
                case SystemDefine.EGameState.Fall:
                    fallEvent();
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
    }
}
