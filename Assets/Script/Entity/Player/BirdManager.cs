using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Bird
{
    public class BirdManager : MonoBehaviour, IBirdManagerAdapter
    {
        // Singleton
        public static BirdManager _instance;

        // Bird
        private BirdController bird;

        [Header("State")]
        [SerializeField]
        private BirdDefine.EBirdManagerState birdState;

        [Header("boundY")]
        [SerializeField]
        private float boundY;

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
            Initialized();
        }

        void Initialized()
        {
            // Event to Manager
            SystemDefine.VoidEvent startEvent = GameManager._instance.GetStateEvent(SystemDefine.EGameState.Start);
            startEvent += StartEvent;
            SystemDefine.VoidEvent playingEvent = GameManager._instance.GetStateEvent(SystemDefine.EGameState.Start);
            playingEvent += PlayingEvent;
            SystemDefine.VoidEvent fallEvent = GameManager._instance.GetStateEvent(SystemDefine.EGameState.Start);
            fallEvent += FallEvent;
        }
        private void StartEvent()
        {
            SetState(BirdDefine.EBirdManagerState.Start);

        }
        private void PlayingEvent()
        {
            SetState(BirdDefine.EBirdManagerState.Playing);
        }

        private void FallEvent()
        {
            SetState(BirdDefine.EBirdManagerState.Fall);
        }

        public BirdDefine.EBirdManagerState GetState()
        {
            return birdState;
        }

        public SystemDefine.VoidEvent GetStateEvent(BirdDefine.EBirdManagerState state)
        {
            switch (state)
            {
                case BirdDefine.EBirdManagerState.Start:
                    return startEvent;
                case BirdDefine.EBirdManagerState.Playing:
                    return playingEvent;
                case BirdDefine.EBirdManagerState.Fall:
                    return fallEvent;
                default:
                    return null;
            }
        }

        public float GetBoundY()
        {
            return boundY;
        }

        public void SetState(BirdDefine.EBirdManagerState state)
        {
            birdState = state;
            switch (birdState)
            {
                case BirdDefine.EBirdManagerState.Start:
                    startEvent?.Invoke();
                    break;
                case BirdDefine.EBirdManagerState.Playing:
                    playingEvent?.Invoke();
                    break;
                case BirdDefine.EBirdManagerState.Fall:
                    fallEvent?.Invoke();
                    break;
            }
        }
    }
}

