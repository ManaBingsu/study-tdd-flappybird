using NSubstitute.Routing.Handlers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;


        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
        }

        private void Initialize()
        {
            // Make singleton
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }
        public SystemDefine.EGameState GetState()
        {
            return gameState;
        }

        public void SetStateEvent(SystemDefine.EGameState state, SystemDefine.VoidEvent func)
        {
            switch(state)
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

