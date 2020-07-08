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

        [Header("Bird first pos")]
        [SerializeField]
        private Vector2 birdFirstPos;

        [Header("boundY")]
        [SerializeField]
        private float boundY;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        void Awake()
        {
            Initialize();
        }

        void Update()
        {
            if (bird.GetBirdPos().y < -10)
                bird.SetBirdGravityScale(0);
        }

        void Initialize()
        {
            // Make singleton
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
            // Event to Manager
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Start, StartEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Playing, PlayingEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Fall, FallEvent);
            // Initialize bird
            bird = Instantiate(Resources.Load<GameObject>("Prefab/Bird")).GetComponent<BirdController>();
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

        public BirdController GetBird()
        {
            return bird;
        }

        public Vector2 GetBirdFirstPos()
        {
            return birdFirstPos;
        }

        public BirdDefine.EBirdManagerState GetState()
        {
            return birdState;
        }

        public void SetStateEvent(BirdDefine.EBirdManagerState state, SystemDefine.VoidEvent func)
        {
            switch (state)
            {
                case BirdDefine.EBirdManagerState.Start:
                    startEvent += func;
                    break;
                case BirdDefine.EBirdManagerState.Playing:
                    playingEvent += func;
                    break;
                case BirdDefine.EBirdManagerState.Fall:
                    fallEvent += func;
                    break;
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

