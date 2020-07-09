using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    [RequireComponent(typeof(StateMachine))]
    public class GameManager : MonoBehaviour
    {
        public StateMachine StateMachine { get; private set; }

        private void Awake()
        {
            StateMachine = GetComponent<StateMachine>();
            InitializeStateMachine();
        }
        private void InitializeStateMachine()
        {
            var states = new Dictionary<Type, BaseState>()
            {

            };

            StateMachine.SetStates(states);
        }
    }
}

