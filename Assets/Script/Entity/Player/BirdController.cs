using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace Bird
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    public class BirdController : MonoBehaviour, IBirdAdapter
    {
        [Header("Stat")]
        [SerializeField]
        private BirdStat birdStat;

        [Header("State")]
        [SerializeField]
        private BirdDefine.EBirdState birdState;

        // Reference
        private Rigidbody2D rigidBody;
        private SpriteRenderer spriteRenderer;
        private Animator animator;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        // Gravity
        private float birdGravity;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            // Create BirdStat object
            birdStat = Instantiate(birdStat) as BirdStat;
            // Set reference
            rigidBody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            // Set gravity
            birdGravity = birdStat.GetBirdGravity();
            // Event to Manager
            SystemDefine.VoidEvent startEvent = BirdManager._instance.GetStateEvent(BirdDefine.EBirdManagerState.Start);
            startEvent += StartEvent;
            SystemDefine.VoidEvent playingEvent = BirdManager._instance.GetStateEvent(BirdDefine.EBirdManagerState.Playing);
            playingEvent += PlayingEvent;
            SystemDefine.VoidEvent fallEvent = BirdManager._instance.GetStateEvent(BirdDefine.EBirdManagerState.Fall);
            fallEvent += FallEvent;
        }

        private void StartEvent()
        {
            SetState(BirdDefine.EBirdState.Start);
            transform.position = new Vector2(0, 0);
            rigidBody.gravityScale = 0f;
        }
        private void PlayingEvent()
        {
            SetState(BirdDefine.EBirdState.Playing);
            rigidBody.gravityScale = birdGravity;
        }

        private void FallEvent()
        {
            SetState(BirdDefine.EBirdState.Fall);
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            rigidBody.gravityScale = 0f;
        }

        public bool Flying()
        {
            // Get current Y location
            float currentY = transform.position.y;
            // If current y location higher than Y bound, Jump fail
            if (currentY > BirdManager._instance.GetBoundY())
            {
                return false;
            }
            // Set Y speed 0
            rigidBody.velocity = new Vector2(0, 0);
            // Power jump!
            rigidBody.AddForce(new Vector2(0, birdStat.GetFlyingPower()), ForceMode2D.Impulse);
            // Jump success
            return true;
        }

        public BirdController GetBird()
        {
            return this;
        }

        public float GetBirdGravityScale()
        {
            return rigidBody.gravityScale;
        }

        public Vector2 GetBirdPos()
        {
            return transform.position;
        }

        public BirdDefine.EBirdState GetState()
        {
            return birdState;
        }

        public SystemDefine.VoidEvent GetStateEvent(BirdDefine.EBirdState state)
        {
            switch (state)
            {
                case BirdDefine.EBirdState.Start:
                    return startEvent;
                case BirdDefine.EBirdState.Playing:
                    return playingEvent;
                case BirdDefine.EBirdState.Fall:
                    return fallEvent;
                default:
                    return null;
            }
        }

        public void SetState(BirdDefine.EBirdState state)
        {
            birdState = state;
            switch (birdState)
            {
                case BirdDefine.EBirdState.Start:
                    startEvent?.Invoke();
                    break;
                case BirdDefine.EBirdState.Playing:
                    playingEvent?.Invoke();
                    break;
                case BirdDefine.EBirdState.Fall:
                    fallEvent?.Invoke();
                    break;
            }
        }


    }
}

