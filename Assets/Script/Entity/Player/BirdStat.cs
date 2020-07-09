using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bird
{
    [CreateAssetMenu(fileName = "Bird stat data", menuName = "V1/BirdStatData")]
    public class BirdStat : ScriptableObject
    {
        [SerializeField]
        private float flyingPower;
        public float GetFlyingPower()
        {
            return flyingPower;
        }
        [SerializeField]
        private float birdGravity;
        public float GetBirdGravity()
        {
            return birdGravity;
        }
    }
}

