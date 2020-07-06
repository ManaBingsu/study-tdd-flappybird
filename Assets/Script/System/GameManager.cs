using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GameSystem
{
    public class GameManager : MonoBehaviour, IGameManagerAdapter
    {
        // Delegate
        delegate void EventHandler();
        // Singleton
        public static GameManager _instance;

        // State
        [Header("State")]
        [SerializeField]
        private SystemDefine.EGameState gameState;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        public SystemDefine.EGameState GetState()
        {
            return gameState;
        }

        public SystemDefine.VoidEvent GetStateEvent(SystemDefine.EGameState state)
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

