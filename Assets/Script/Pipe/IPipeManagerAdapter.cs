using System.Collections.Generic;
using UnityEngine;
using System;

namespace Pipe
{
    public interface IPipeManagerAdapter
    {
        void Initialize();
        Queue<Pipe> GetPipeQueue();

        Coroutine GetGeneratorCoroutine();

        PipeDefine.EPipeManagerState GetState();
        void SetState(PipeDefine.EPipeManagerState state);
        Action GetStateEvent(PipeDefine.EPipeState state);
    }
}

