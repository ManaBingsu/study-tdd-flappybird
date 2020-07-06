using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GameSystem
{
    public class GameManager : MonoBehaviour, IGameManagerAdapter
    {
        public Action initAction;
       
        public void SetState(GameManagerState state)
        {
            if (state == GameManagerState.Start)
            {
                initAction();
            }

        }

        public void Initialized()
        {
            initAction += new Action(() => Debug.Log("dd"));
            initAction += new Action(() => Debug.Log("aa"));
        }

        public enum GameManagerState { Start, Playing, End }
    }
}

