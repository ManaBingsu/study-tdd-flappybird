using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public class InputSystem : InputController, IInputSystem
    {
        private IInput inputManager;

        public InputSystem(IInput inputManager)
        {
            this.inputManager = inputManager;

        }
        public KeyCode SystemResetGameKey => inputManager.InputData.systemResetGameKey;
        public KeyCode SystemMenuKey => inputManager.InputData.systemMenuKey;

        public override void RunInput()
        {
            if (Input.GetKeyDown(SystemResetGameKey))
            {
                // Reset 행동
            }
            if (Input.GetKeyDown(SystemMenuKey))
            {
                // 메뉴 여는 키
            }
        }
    }
}

