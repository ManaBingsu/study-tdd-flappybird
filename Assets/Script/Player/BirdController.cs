using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Bird
{
    public class BirdController : MonoBehaviour, IBirdAdapter
    {
        public bool Flying()
        {
            throw new System.NotImplementedException();
        }

        public BirdController GetBird()
        {
            throw new System.NotImplementedException();
        }

        public float GetBirdGravityScale()
        {
            throw new System.NotImplementedException();
        }

        public Vector2 GetBirdPos()
        {
            throw new System.NotImplementedException();
        }

        public BirdDefine.EBirdState GetState()
        {
            throw new System.NotImplementedException();
        }

        public Action GetStateEvent(BirdDefine.EBirdState state)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void SetState(BirdDefine.EBirdState state)
        {
            throw new System.NotImplementedException();
        }
    }
}

