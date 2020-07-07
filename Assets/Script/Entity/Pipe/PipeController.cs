using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Pipe
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PipeController : MonoBehaviour, IPipeAdapter
    {
        [Header("State")]
        [SerializeField]
        private PipeDefine.EPipeState pipeState;

        // Pipe speed
        private float pipeSpeed;

        // Reference
        Rigidbody2D rigidBody;

        // State event
        private event SystemDefine.VoidEvent offEvent;
        private event SystemDefine.VoidEvent onEvent;

        private void Awake()
        {
            Initialize();
        }

        void FixedUpdate()
        {
            if (IsOutOfBound())
            {
                SetState(PipeDefine.EPipeState.Off);
            }
            else
            {
                Move();
            }
        }

        private void Initialize()
        {
            SystemDefine.VoidEventFloat func = PipeManager._instance.GetPipeSpeedEvent();
            func += new SystemDefine.VoidEventFloat(SetSpeed);
            rigidBody = GetComponent<Rigidbody2D>();
            // Event to Manager
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Start, StartEvent);
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Playing, PlayingEvent);
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Fall, FallEvent);
            pipeSpeed = PipeManager._instance.GetPipeSpeed();
            gameObject.SetActive(false);
        }
        private void StartEvent()
        {
            pipeSpeed = 0f;
        }
        private void PlayingEvent()
        {
            pipeSpeed = PipeManager._instance.GetPipeSpeed();
        }

        private void FallEvent()
        {
            gameObject.SetActive(false);
            pipeSpeed = 0f;
        }

        private void Move()
        {
            transform.position += new Vector3(-pipeSpeed, 0, 0) * Time.deltaTime;
        }

        private void SetSpeed(float speed)
        {
            pipeSpeed = speed;
        }

        public void SetPipeSpeed(float speed)
        {
            pipeSpeed = speed;
        }

        private bool IsOutOfBound()
        {
            if (transform.position.x < PipeManager._instance.GetBoundX())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Vector2 GetPipePos()
        {
            return transform.position;
        }

        public PipeDefine.EPipeState GetState()
        {
            return pipeState;
        }

        public void SetStateEvent(PipeDefine.EPipeState state, SystemDefine.VoidEvent func)
        {
            switch (state)
            {
                case PipeDefine.EPipeState.Off:
                    offEvent += func;
                    break;
                case PipeDefine.EPipeState.On:
                    onEvent += func;
                    break;
            }
        }

        public void SetState(PipeDefine.EPipeState state)
        {
            pipeState = state;
            switch (pipeState)
            {
                case PipeDefine.EPipeState.Off:
                    // Return to queue
                    PipeManager._instance.EnqueueToPipeQueue(this);
                    offEvent?.Invoke();
                    break;
                case PipeDefine.EPipeState.On:
                    onEvent?.Invoke();
                    break;
            }
        }
    }
}

