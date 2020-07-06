using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Pipe
{
    public class PipeManager : MonoBehaviour, IPipeManagerAdapter
    {
        // Singleton
        public static PipeManager _instance;

        // PipeManager state
        [Header("State")]
        [SerializeField]
        private PipeDefine.EPipeManagerState managerState;

        // PipeManager Create delay
        [Header("Value")]
        [SerializeField]
        private float createDelay;

        // Start Pos X
        [SerializeField]
        private float startPosX;

        // Left Bound X
        [SerializeField]
        private float boundX;

        // Random position min max
        [SerializeField]
        private float generatePosMin;
        [SerializeField]
        private float generatePosMax;

        // Pipe default move speed
        [SerializeField]
        private float pipeSpeed;

        // Pipe current speed
        private float pipeCurrentSpeed;

        // Pipe prefab
        [Header("Pipe prefab")]
        [SerializeField]
        private GameObject pipePrefab;

        // Pipe Queue
        [SerializeField]
        private Queue<PipeController> pipeQueue;

        // Pipe Generator Coroutine
        private Coroutine pipeGenertor;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        // Speed change event
        private event SystemDefine.VoidEventFloat pipeSpeedEvent;

        void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
            Initialize();
        }

        private void Initialize()
        {
            pipeQueue = new Queue<PipeController>();
            SetPipeSpeed(0);
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
            SetState(PipeDefine.EPipeManagerState.Start);
            pipeGenertor = null;
            pipeCurrentSpeed = 0;
        }
        private void PlayingEvent()
        {
            SetState(PipeDefine.EPipeManagerState.Playing);
            pipeGenertor = StartCoroutine(GeneratePipes());
            pipeCurrentSpeed = pipeSpeed;
        }

        private void FallEvent()
        {
            SetState(PipeDefine.EPipeManagerState.Fall);
            StopCoroutine(GeneratePipes());
            pipeCurrentSpeed = 0;
        }

        private IEnumerator GeneratePipes()
        {
            float progress = 0f;
            while (managerState == PipeDefine.EPipeManagerState.Playing)
            {
                progress += Time.deltaTime;
                if (progress > createDelay)
                {
                    DequeuePipeRandomly();
                }
                yield return null;
            }
        }

        private void DequeuePipeRandomly()
        {
            // If queue is empty, than create more pipe
            if (pipeQueue.Count == 0)
            {
                PipeController newPipe = Instantiate(pipePrefab).GetComponent<PipeController>();
                pipeQueue.Enqueue(newPipe);
                newPipe.transform.parent = this.gameObject.transform;
            }
            PipeController pipe = pipeQueue.Dequeue();
            // Set pipe state On
            pipe.SetState(PipeDefine.EPipeState.On);
            // Random position
            pipe.transform.position = new Vector3(startPosX, UnityEngine.Random.Range(generatePosMin, generatePosMax));
            // Set Pipe Speed
            pipe.SetPipeSpeed(pipeCurrentSpeed);
        }

        public float GetPipeSpeed()
        {
            return pipeSpeed;
        }
        public void SetPipeSpeed(float speed)
        {
            if (pipeSpeed != speed)
            {
                pipeSpeed = speed;
                pipeSpeedEvent(pipeSpeed);
            }        
        }
        public SystemDefine.VoidEventFloat GetPipeSpeedEvent()
        {
            return pipeSpeedEvent;
        }
        public float GetStartPosX()
        {
            return startPosX;
        }
        public float GetBoundX()
        {
            return boundX;
        }
        public Coroutine GetGeneratorCoroutine()
        {
            return pipeGenertor;
        }
        public Queue<PipeController> GetPipeQueue()
        {
            return pipeQueue;
        }
        public void EnqueueToPipeQueue(PipeController pipe)
        {
            pipe.SetState(PipeDefine.EPipeState.Off);
            pipe.transform.parent = this.transform;
            pipeQueue.Enqueue(pipe);
        }

        public PipeDefine.EPipeManagerState GetState()
        {
            return managerState;
        }

        public SystemDefine.VoidEvent GetStateEvent(PipeDefine.EPipeManagerState state)
        {
            switch (state)
            {
                case PipeDefine.EPipeManagerState.Start:
                    return startEvent;
                case PipeDefine.EPipeManagerState.Playing:
                    return playingEvent;
                case PipeDefine.EPipeManagerState.Fall:
                    return fallEvent;
                default:
                    return null;
            }
        }

        public void SetState(PipeDefine.EPipeManagerState state)
        {
            managerState = state;
            switch (managerState)
            {
                case PipeDefine.EPipeManagerState.Start:
                    startEvent?.Invoke();
                    break;
                case PipeDefine.EPipeManagerState.Playing:
                    playingEvent?.Invoke();
                    break;
                case PipeDefine.EPipeManagerState.Fall:
                    fallEvent?.Invoke();
                    break;
            }
        }

        // Pass pipe
        public void PassPipe()
        {
            int currentScore = ScoreManager._instance.GetCurrentScore();
            ScoreManager._instance.SetCurrentScore(currentScore + 1);
        }

        // Collided with pipe
        public void CollidedPipe()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
        }
    }
}

