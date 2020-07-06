using NSubstitute.Exceptions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    public class ScoreManager : MonoBehaviour, IScoreManagerAdapter
    {
        private int score = 0;
        public int GetScore()
        {
            return score;
        }

        public void Initialize()
        {
            score = 10;
        }
    }
}
