using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bird;
using GameSystem;

namespace Input
{
    public class InputManager : MonoBehaviour, IInputManagerAdapter
    {
        // Singleton
        public static InputManager _instance;
        [Header("Flying key")]
        [SerializeField]
        private KeyCode flyingKey;

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            if(UnityEngine.Input.GetKeyUp(GetFlyingKey()))
            {
                PressFlying();
            }
        }

        private void Initialize()
        {
            // Make singleton
            if (_instance == null)
                _instance = this;
            else
                Destroy(this.gameObject);
        }

        public KeyCode GetFlyingKey()
        {
            return flyingKey;
        }

        public void PressFlying()
        {
            if (GameManager._instance.GetState() == SystemDefine.EGameState.Fall)
            {
                GameManager._instance.SetState(SystemDefine.EGameState.Start);
                return;
            }
            else if(GameManager._instance.GetState() == SystemDefine.EGameState.Start)
            {
                GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            }
            BirdManager._instance.GetBird().Flying();
        }
    }
}

