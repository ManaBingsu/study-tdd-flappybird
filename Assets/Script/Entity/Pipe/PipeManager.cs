using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using System.Linq;

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

        [SerializeField]
        // Pipe current speed
        private float currentPipeSpeed;

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
            // Initialize event
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Start, StartEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Playing, PlayingEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Fall, FallEvent);
            // Init pipe speed
            currentPipeSpeed = pipeSpeed;
            // Init Pipe prefab
 
            pipePrefab = Instantiate((Resources.Load<GameObject>("Prefab/Pipe")));  
            PipeController initPipe = pipePrefab.GetComponent<PipeController>();
            initPipe.transform.parent = this.gameObject.transform;
        }
        public GameObject GetPipePrefab()
        {
            return pipePrefab;
        }
        private void StartEvent()
        {
            currentPipeSpeed = 0;
            SetState(PipeDefine.EPipeManagerState.Start);
            pipeGenertor = null;
            SetPipeSpeed(currentPipeSpeed);
        }
        private void PlayingEvent()
        {
            currentPipeSpeed = pipeSpeed;
            SetState(PipeDefine.EPipeManagerState.Playing);
            pipeGenertor = StartCoroutine(GeneratePipes());
            SetPipeSpeed(currentPipeSpeed);
        }
        private void FallEvent()
        {
            currentPipeSpeed = 0;
            SetState(PipeDefine.EPipeManagerState.Fall);
            StopCoroutine(GeneratePipes());

            SetPipeSpeed(currentPipeSpeed);
        }

        private IEnumerator GeneratePipes()
        {

            DequeuePipeRandomly();
            float progress = 0f;
            while (managerState == PipeDefine.EPipeManagerState.Playing)
            {
                progress += Time.deltaTime;
                if (progress > createDelay)
                {
                    DequeuePipeRandomly();
                    progress = 0f;
                }
                yield return null;
            }
        }

        private void DequeuePipeRandomly()
        {
            PipeController newPipe;
            // If queue is empty, than create more pipe
            if (pipeQueue.Count < 1)
            {
                newPipe = Instantiate(pipePrefab).GetComponent<PipeController>();
                newPipe.transform.parent = this.gameObject.transform;
                EnqueueToPipeQueue(newPipe);
            }
            PipeController pipe = pipeQueue.Dequeue();
            // Set pipe Active true
            pipe.gameObject.SetActive(true);
            // Set pipe state to PlayingState
            pipe.SetState(PipeDefine.EPipeState.Playing);
            // Random position
            pipe.transform.position = new Vector3(startPosX, UnityEngine.Random.Range(generatePosMin, generatePosMax));
        }

        public float GetPipeSpeed()
        {
            return currentPipeSpeed;
        }
        public void SetPipeSpeed(float speed)
        {
            if (currentPipeSpeed != speed)
            {
                currentPipeSpeed = speed;
                pipeSpeedEvent?.Invoke(currentPipeSpeed);
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
        public void EnqueueToPipeQueue(PipeController pipe)
        {
            pipe.transform.position = new Vector3(startPosX, UnityEngine.Random.Range(generatePosMin, generatePosMax));
            pipe.gameObject.SetActive(false);
            // Enqueue
            pipeQueue.Enqueue(pipe);
        }

        public PipeDefine.EPipeManagerState GetState()
        {
            return managerState;
        }

        public void SetStateEvent(PipeDefine.EPipeManagerState state, SystemDefine.VoidEvent func)
        {
            switch (state)
            {
                case PipeDefine.EPipeManagerState.Start:
                    startEvent += func;
                    break;
                case PipeDefine.EPipeManagerState.Playing:
                    playingEvent += func;
                    break;
                case PipeDefine.EPipeManagerState.Fall:
                    fallEvent += func;
                    break;
            }
        }
        public void SetPipeSPeedEvent(SystemDefine.VoidEventFloat func)
        {
            pipeSpeedEvent += func;
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

        public Queue<PipeController> GetPipeQueue()
        {
            return pipeQueue;
        }
    }
}

