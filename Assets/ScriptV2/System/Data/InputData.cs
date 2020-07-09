using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    [CreateAssetMenu(fileName = "Input data", menuName = "V2/Input")]
    public class InputData : ScriptableObject
    {
        [Header("System")]
        public KeyCode systemResetGameKey;
        public KeyCode systemMenuKey;
        [Header("Bird")]
        public KeyCode birdFlyingKey;
    }
}

