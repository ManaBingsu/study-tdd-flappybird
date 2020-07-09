using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    [CreateAssetMenu(fileName = "Bird stat data", menuName = "V2/BirdStatData")]
    public class BirdData : ScriptableObject
    {
        public float flyingPower;
        public float maxHeight;
    }
}

