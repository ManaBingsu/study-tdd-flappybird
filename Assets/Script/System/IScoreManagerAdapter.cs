using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public interface IScoreManagerAdapter
    {
        void Initialize();
        int GetScore();
    }
}

