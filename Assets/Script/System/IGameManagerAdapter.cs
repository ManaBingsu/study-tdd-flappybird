namespace GameSystem
{
    interface IGameManagerAdapter
    {
        SystemDefine.EGameState GetState();
        void SetState(SystemDefine.EGameState state);
        void SetStateEvent(SystemDefine.EGameState state, SystemDefine.VoidEvent func);
    }
}


