using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pipe
{
    public class PipeManager : MonoBehaviour, IPipeAdapter
    {
        public Vector2 GetPipePos()
        {
            throw new System.NotImplementedException();
        }

        public PipeDefine.EPipeState GetState()
        {
            throw new System.NotImplementedException();
        }

        public Action GetStateEvent(PipeDefine.EPipeState state)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public void SetState(PipeDefine.EPipeState state)
        {
            throw new System.NotImplementedException();
        }

    }
}

