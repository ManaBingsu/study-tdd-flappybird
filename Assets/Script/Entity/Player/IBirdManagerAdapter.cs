using UnityEngine;
using GameSystem;

namespace Bird
{
    public interface IBirdManagerAdapter
    {
        BirdController GetBird();
        Vector2 GetBirdFirstPos();
        float GetBoundY();
        BirdDefine.EBirdManagerState GetState();

        void SetState(BirdDefine.EBirdManagerState state);
        void SetStateEvent(BirdDefine.EBirdManagerState state, SystemDefine.VoidEvent func);
    }
}

