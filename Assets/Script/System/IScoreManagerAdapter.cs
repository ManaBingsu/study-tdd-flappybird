using System;

namespace GameSystem
{
    public interface IScoreManagerAdapter
    {
        void Initialize();
        int GetCurrentScore();
        int GetHighScore();
        void SetCurrentScore(int score);
        bool SetHighScore(int score);
        SystemDefine.EGameState GetState();
        void SetState(SystemDefine.EGameState state);
        SystemDefine.VoidEvent GetStateEvent(SystemDefine.EGameState state);
        SystemDefine.VoidEvent GetScoreEvent(SystemDefine.EScoreType type);
    }
}

