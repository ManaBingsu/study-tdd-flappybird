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
        Action GetStateEvent(SystemDefine.EGameState state);
        Action GetScoreEvent(SystemDefine.EScoreType type);
    }
}

