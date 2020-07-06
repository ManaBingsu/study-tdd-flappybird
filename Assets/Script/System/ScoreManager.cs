using NSubstitute.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

namespace GameSystem
{
    public class ScoreManager : MonoBehaviour, IScoreManagerAdapter
    {
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
        Action setCurrentScoreEvent;
        Action setHighScoreEvent;

        // State event
        private Action startEvent;
        private Action playingEvent;
        private Action fallEvent;

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

        public Action GetStateEvent(SystemDefine.EGameState state)
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
            throw new System.NotImplementedException();
        }

        public void SetState(SystemDefine.EGameState state)
        {
            throw new System.NotImplementedException();
        }

        public Action GetScoreEvent(SystemDefine.EScoreType type)
        {
            throw new NotImplementedException();
        }
    }
}
