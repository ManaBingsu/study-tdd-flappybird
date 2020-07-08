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
        private CircleCollider2D collider;

        // State event
        private event SystemDefine.VoidEvent startEvent;
        private event SystemDefine.VoidEvent playingEvent;
        private event SystemDefine.VoidEvent fallEvent;

        private void Awake()
        {
            Initialize();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("ScoreWall"))
            {
                int currentScore = ScoreManager._instance.GetCurrentScore();
                ScoreManager._instance.SetCurrentScore(currentScore + 1);
            }
        }

        private void Initialize()
        {
            // Create BirdStat object
            birdStat = Instantiate(birdStat) as BirdStat;
            // Set reference
            rigidBody = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            collider = GetComponent<CircleCollider2D>();
            // Set first pos
            transform.position = BirdManager._instance.GetBirdFirstPos();
            // Set first gravity
            rigidBody.gravityScale = 0f;
            // Initialize event
            BirdManager._instance.SetStateEvent(BirdDefine.EBirdManagerState.Start, StartEvent);
            BirdManager._instance.SetStateEvent(BirdDefine.EBirdManagerState.Playing, PlayingEvent);
            BirdManager._instance.SetStateEvent(BirdDefine.EBirdManagerState.Fall, FallEvent);
        }

        private void StartEvent()
        {
            SetState(BirdDefine.EBirdState.Start);
            transform.position = BirdManager._instance.GetBirdFirstPos();
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = 0f;
            collider.enabled = true;
        }
        private void PlayingEvent()
        {
            SetState(BirdDefine.EBirdState.Playing);
            rigidBody.velocity = Vector2.zero;
            rigidBody.gravityScale = birdStat.GetBirdGravity();
        }

        private void FallEvent()
        {
            SetState(BirdDefine.EBirdState.Fall);
            collider.enabled = false;
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
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
        public void SetBirdGravityScale(float scale)
        {
            rigidBody.gravityScale = scale;
        }
        public BirdStat GetBirdStat()
        {
            return birdStat;
        }
        public Vector2 GetBirdPos()
        {
            return transform.position;
        }

        public void SetBirdPos(Vector2 pos)
        {
            transform.position = pos;
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

