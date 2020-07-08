using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem;

namespace MainUI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        GameObject startUI;
        [SerializeField]
        GameObject playingUI;
        [SerializeField]
        GameObject fallUI;

        private void Awake()
        {
            InitEvent();
        }

        void InitEvent()
        {
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Start, StartEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Playing, PlayingEvent);
            GameManager._instance.SetStateEvent(SystemDefine.EGameState.Fall, FallEvent);

            // Child event
        }

        void StartEvent()
        {
            startUI.SetActive(true);
            playingUI.SetActive(false);
            fallUI.SetActive(false);
        }
        void PlayingEvent()
        {
            startUI.SetActive(false);
            playingUI.SetActive(true);
            fallUI.SetActive(false);
        }
        void FallEvent()
        {
            startUI.SetActive(false);
            playingUI.SetActive(false);
            fallUI.SetActive(true);
        }
    }
}


