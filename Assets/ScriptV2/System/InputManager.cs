using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public class InputManager : MonoBehaviour, IInput
    {
        // Data
        [SerializeField]
        private InputData inputData;
        public InputData InputData => inputData;
        // Input class
        private Dictionary<Type, InputController> inputControllers;

        Bird bird;

        private void Awake()
        {
            InitializeInputControllers();
        }

        private void InitializeInputControllers()
        {
            inputControllers = new Dictionary<Type, InputController>
            {
                {typeof(InputSystem), new InputSystem(this) },
                {typeof(InputBird), new InputBird(this, bird.BirdController) },
            };
        }

        private void Update()
        {
            foreach(KeyValuePair<Type, InputController> input in inputControllers)
            {
                input.Value.RunInput();
            }

        }
    }
    public abstract class InputController
    {
        public abstract void RunInput();
    }

}

