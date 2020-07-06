namespace GameSystem
{
    interface IGameManagerAdapter
    {
        SystemDefine.EGameState GetState();
        void SetState(SystemDefine.EGameState state);
        SystemDefine.VoidEvent GetStateEvent(SystemDefine.EGameState state);
    }
}


