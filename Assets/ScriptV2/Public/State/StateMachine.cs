using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace V2
{
    public class StateMachine : MonoBehaviour
    {
        private Dictionary<Type, BaseState> states;
        public BaseState CurrentState { get; private set; }
        public event Action<BaseState> OnStateChanged;

        public void SetStates(Dictionary<Type, BaseState> states)
        {
            this.states = states;
        }

        private void Update()
        {
            if (CurrentState == null)
            {
                CurrentState = states.Values.First();
            }
            var nextState = CurrentState?.Tick();
            if (nextState != null &&
                nextState != CurrentState?.GetType())
            {
                SwicthToNewState(nextState);
            }
        }

        private void SwicthToNewState(Type nextState)
        {
            CurrentState = states[nextState];
            OnStateChanged?.Invoke(CurrentState);
        }
    }
}

