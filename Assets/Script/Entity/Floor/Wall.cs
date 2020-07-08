using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pipe;

namespace Wall
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Wall : MonoBehaviour
    {
        [SerializeField]
        private float initPosX;
        [SerializeField]
        private float repeatPosX;
        [SerializeField]
        private float boundPosX;
        private float wallSpeed;


        private void Awake()
        {
            // Event to Manager
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Start, StartEvent);
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Playing, PlayingEvent);
            PipeManager._instance.SetStateEvent(PipeDefine.EPipeManagerState.Fall, FallEvent);
            PipeManager._instance.SetPipeSPeedEvent(SetSpeedEvent);
            // Init initPos
            initPosX = transform.position.x;
        }

        private void Update()
        {
            if (IsOutOfBound())
            {
                transform.position = new Vector3(repeatPosX, -6, 0);
            }
            else
            {
                Move();
            }
        }

        private void StartEvent()
        {
            SetSpeed(PipeManager._instance.GetPipeSpeed());
            transform.position = new Vector3(initPosX, -6, 0);
        }
        private void PlayingEvent()
        {
            SetSpeed(PipeManager._instance.GetPipeSpeed());
        }

        private void FallEvent()
        {
            SetSpeed(PipeManager._instance.GetPipeSpeed());
        }
        private void SetSpeedEvent(float speed)
        {
            SetSpeed(speed);
        }

        public void SetSpeed(float speed)
        {
            wallSpeed = speed;
        }

        private void Move()
        {
            transform.position += new Vector3(-wallSpeed, 0, 0) * Time.deltaTime;
        }

        private bool IsOutOfBound()
        {
            if (transform.position.x < boundPosX)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

