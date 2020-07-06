using UnityEngine;
using System;

namespace Bird
{
    public interface IBirdAdapter
    {
        void Initialize();
        BirdController GetBird();
        Vector2 GetBirdPos();
        float GetBirdGravityScale();
        bool Flying();
        BirdDefine.EBirdState GetState();
        void SetState(BirdDefine.EBirdState state);
        Action GetStateEvent(BirdDefine.EBirdState state);
    }
}
