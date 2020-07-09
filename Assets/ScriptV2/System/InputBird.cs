using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public class InputBird : InputController, IInputBird
    {
        private IInput inputManager;
        private IBirdController birdController;
        public KeyCode BirdFlyingKey => inputManager.InputData.birdFlyingKey;

        public InputBird(IInput inputManager, IBirdController birdController)
        {
            this.inputManager = inputManager;
            this.birdController = birdController;
        }
        public override void RunInput()
        {
            if (Input.GetKeyDown(BirdFlyingKey))
            {
                // 새 날다
                InputFlying();
            }
        }

        public void InputFlying()
        {
           birdController.Flying();
        }
    }
}

