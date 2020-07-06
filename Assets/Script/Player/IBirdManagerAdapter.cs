using System;

namespace Bird
{
    public interface IBirdManagerAdapter
    {
        void Initialize();
        BirdDefine.EBirdState GetState();
        void SetState(BirdDefine.EBirdState state);
        Action GetStateEvent(BirdDefine.EBirdManagerState state);
    }
}

