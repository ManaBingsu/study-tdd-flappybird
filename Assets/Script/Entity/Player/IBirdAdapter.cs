using UnityEngine;
using GameSystem;
using System;

namespace Bird
{
    public interface IBirdAdapter
    {
        BirdController GetBird();
        Vector2 GetBirdPos();
        float GetBirdGravityScale();
        bool Flying();
        BirdDefine.EBirdState GetState();
        void SetState(BirdDefine.EBirdState state);
        SystemDefine.VoidEvent GetStateEvent(BirdDefine.EBirdState state);
    }
}
