using UnityEngine;
using GameSystem;
using System;

namespace Bird
{
    public interface IBirdAdapter
    {
        BirdController GetBird();
        Vector2 GetBirdPos();
        void SetBirdPos(Vector2 pos);
        float GetBirdGravityScale();
        void SetBirdGravityScale(float scale);
        BirdStat GetBirdStat();
        bool Flying();
        BirdDefine.EBirdState GetState();
        void SetState(BirdDefine.EBirdState state);
        SystemDefine.VoidEvent GetStateEvent(BirdDefine.EBirdState state);
    }
}
