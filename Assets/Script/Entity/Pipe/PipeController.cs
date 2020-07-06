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
            SystemDefine.VoidEvent startEvent = PipeManager._instance.GetStateEvent(PipeDefine.EPipeManagerState.Start);
            startEvent += StartEvent;
            SystemDefine.VoidEvent playingEvent = PipeManager._instance.GetStateEvent(PipeDefine.EPipeManagerState.Playing);
            playingEvent += PlayingEvent;
            SystemDefine.VoidEvent fallEvent = PipeManager._instance.GetStateEvent(PipeDefine.EPipeManagerState.Fall);
            fallEvent += FallEvent;
        }
        private void StartEvent()
        {
            SetState(PipeDefine.EPipeState.On);
            pipeSpeed = 0f;
        }
        private void PlayingEvent()
        {

        }

        private void FallEvent()
        {
            PipeManager._instance.EnqueueToPipeQueue(this);
            pipeSpeed = 0f;
        }

        private void Move()
        {
            rigidBody.velocity = new Vector2(-pipeSpeed, 0);
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

        public SystemDefine.VoidEvent GetStateEvent(PipeDefine.EPipeState state)
        {
            switch (state)
            {
                case PipeDefine.EPipeState.Off:
                    return offEvent;
                case PipeDefine.EPipeState.On:
                    return onEvent;
                default:
                    return null;
            }
        }

        private void PipeOnEvent()
        {

        }

        private void PipeOffEvent()
        {
            PipeManager._instance.EnqueueToPipeQueue(this);
        }

        public void SetState(PipeDefine.EPipeState state)
        {
            pipeState = state;
            switch (pipeState)
            {
                case PipeDefine.EPipeState.Off:
                    PipeOffEvent();
                    offEvent?.Invoke();
                    break;
                case PipeDefine.EPipeState.On:
                    PipeOnEvent();
                    onEvent?.Invoke();
                    break;
            }
        }

    }
}

