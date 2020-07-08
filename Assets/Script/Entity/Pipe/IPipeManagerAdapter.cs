using System.Collections.Generic;
using UnityEngine;
using System;
using GameSystem;

namespace Pipe
{
    public interface IPipeManagerAdapter
    {
        void EnqueueToPipeQueue(PipeController pipe);
        GameObject GetPipePrefab();
        float GetPipeSpeed();
        void SetPipeSpeed(float speed);
        Queue<PipeController> GetPipeQueue();
        SystemDefine.VoidEventFloat GetPipeSpeedEvent();
        void SetPipeSPeedEvent(SystemDefine.VoidEventFloat func);
        float GetStartPosX();
        float GetBoundX();
        Coroutine GetGeneratorCoroutine();
        PipeDefine.EPipeManagerState GetState();
        void SetState(PipeDefine.EPipeManagerState state);
        void SetStateEvent(PipeDefine.EPipeManagerState state, SystemDefine.VoidEvent func);
    }
}

