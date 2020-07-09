using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;
using UnityEngine.UI;

namespace MainUI
{
    public class PlayingUI : MonoBehaviour
    {
        public Text currentScoreText;

        private void Awake()
        {
            InitEvent();
        }

        void InitEvent()
        {
            ScoreManager._instance.SetScoreEvent(SystemDefine.EScoreType.Current, UpdateCurrentScore);
        }

        public void UpdateCurrentScore()
        {
            currentScoreText.text = ScoreManager._instance.GetCurrentScore().ToString();
        }
    }
}

