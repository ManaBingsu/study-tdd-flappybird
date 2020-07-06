using System.Collections.Generic;
using UnityEngine;
using System;
using GameSystem;

namespace Pipe
{
    public interface IPipeManagerAdapter
    {
        void EnqueueToPipeQueue(PipeController pipe);
        float GetPipeSpeed();
        void SetPipeSpeed(float speed);
        SystemDefine.VoidEventFloat GetPipeSpeedEvent();
        float GetStartPosX();
        float GetBoundX();
        Coroutine GetGeneratorCoroutine();
        PipeDefine.EPipeManagerState GetState();
        void SetState(PipeDefine.EPipeManagerState state);
        SystemDefine.VoidEvent GetStateEvent(PipeDefine.EPipeManagerState state);
    }
}

