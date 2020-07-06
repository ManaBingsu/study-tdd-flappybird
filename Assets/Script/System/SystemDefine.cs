using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class SystemDefine
    {
        // State
        public enum EGameState { Start, Playing, Fall, NULL }
        public enum EScoreType { Current, High, NULL }

        // Delegate
        public delegate void VoidEvent();
        public delegate void VoidEventFloat(float value);
    }
}

