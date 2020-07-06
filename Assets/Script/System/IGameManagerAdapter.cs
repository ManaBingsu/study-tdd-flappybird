using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameSystem
{
    public interface IGameManagerAdapter
    {
        void SetState(GameManager.GameManagerState state);
    }
}


