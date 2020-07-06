using System;

namespace GameSystem
{
    interface IGameManagerAdapter
    {
        SystemDefine.EGameState GetState();
        void SetState(SystemDefine.EGameState state);
        Action GetStateEvent(SystemDefine.EGameState state);
    }
}


