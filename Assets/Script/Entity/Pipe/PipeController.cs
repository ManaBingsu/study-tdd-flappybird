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
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        private void Awake()
        {
            Initialize();
        }

        void FixedUpdate()
        {
            if (IsOutOfBound())
            {
                PipeManager._instance.EnqueueToPipeQueue(this);
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
            PipeManager._instance.SetPipeSPeedEvent(SetSpeedEvent);
            pipeSpeed = PipeManager._instance.GetPipeSpeed();
        }
        private void StartEvent()
        {
            SetState(PipeDefine.EPipeState.Start);
            SetSpeed(PipeManager._instance.GetPipeSpeed());
            PipeManager._instance.EnqueueToPipeQueue(this);
        }
        private void PlayingEvent()
        {
            SetState(PipeDefine.EPipeState.Playing);
            SetSpeed(PipeManager._instance.GetPipeSpeed());
        }

        private void FallEvent()
        {
            SetState(PipeDefine.EPipeState.Fall);
            SetSpeed(PipeManager._instance.GetPipeSpeed());
        }

        private void SetSpeedEvent(float speed)
        {
            SetSpeed(speed);
        }

        private void Move()
        {
            //rigid.position += new Vector3(-pipeSpeed, 0, 0) * Time.deltaTime;
            rigidBody.MovePosition(transform.position + new Vector3(-pipeSpeed, 0, 0) * Time.deltaTime);
            //rigidBody.AddForce(new Vector3(-pipeSpeed, 0f, 0f));
        }

        public void SetSpeed(float speed)
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
                case PipeDefine.EPipeState.Start:
                    startEvent += func;
                    break;
                case PipeDefine.EPipeState.Playing:
                    playingEvent += func;
                    break;
                case PipeDefine.EPipeState.Fall:
                    fallEvent += func;
                    break;
            }
        }

        public void SetState(PipeDefine.EPipeState state)
        {
            pipeState = state;
            switch (pipeState)
            {
                case PipeDefine.EPipeState.Start:
                    startEvent?.Invoke();
                    break;
                case PipeDefine.EPipeState.Playing:
                    playingEvent?.Invoke();
                    break;
                case PipeDefine.EPipeState.Fall:
                    fallEvent?.Invoke();
                    break;
            }
        }
    }
}

