using System.Collections;
using System.Collections.Generic;
using GameSystem;
using UnityEngine;
using System;

namespace Pipe
{
    public interface IPipeAdapter
    {
        Vector2 GetPipePos();
        void SetSpeed(float speed);
        PipeDefine.EPipeState GetState();
        void SetState(PipeDefine.EPipeState state);
        void SetStateEvent(PipeDefine.EPipeState state, SystemDefine.VoidEvent func);
    }
}
