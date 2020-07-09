using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public interface IGameManager
    {
        SystemDefine.GameState CurrentState { get; }
    }
}

