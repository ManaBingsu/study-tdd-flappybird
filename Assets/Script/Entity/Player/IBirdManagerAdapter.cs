using GameSystem;

namespace Bird
{
    public interface IBirdManagerAdapter
    {
        BirdDefine.EBirdManagerState GetState();
        float GetBoundY();
        void SetState(BirdDefine.EBirdManagerState state);
        SystemDefine.VoidEvent GetStateEvent(BirdDefine.EBirdManagerState state);
    }
}

