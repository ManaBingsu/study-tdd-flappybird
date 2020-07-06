using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GameSystem
{
    public class GameManager : MonoBehaviour, IGameManagerAdapter
    {
        // Singleton
        public static GameManager _instance;

        // State
        [Header("State")]
        [SerializeField]
        private SystemDefine.EGameState gameState;

        // State event
        private Action startEvent;
        private Action playingEvent;
        private Action fallEvent;

        public SystemDefine.EGameState GetState()
        {
            return gameState;
        }

        public Action GetStateEvent(SystemDefine.EGameState state)
        {
            switch(state)
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
    }
}

