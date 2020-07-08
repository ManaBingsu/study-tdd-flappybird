using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSystem;

namespace MainUI
{
    public class ResultUI : MonoBehaviour
    {
        public Text highScoreText;
        public Text currentScoreText;

        private void Awake()
        {
            InitEvent();
        }

        void InitEvent()
        {
            ScoreManager._instance.SetStateEvent(SystemDefine.EGameState.Fall, UpdateEvent);
        }

        void UpdateEvent()
        {
            highScoreText.text = ScoreManager._instance.GetHighScore().ToString();
            currentScoreText.text = ScoreManager._instance.GetCurrentScore().ToString();
        }
    }
}
