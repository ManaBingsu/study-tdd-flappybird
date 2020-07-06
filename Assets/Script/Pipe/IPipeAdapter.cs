using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pipe
{
    public interface IPipeAdapter
    {
        void Initialize();
        Vector2 GetPipePos();
        PipeDefine.EPipeState GetState();
        void SetState(PipeDefine.EPipeState state);
        Action GetStateEvent(PipeDefine.EPipeState state);
    }
}
