using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public interface IInputBird
    {
        KeyCode BirdFlyingKey { get; }
        void InputFlying();
    }
}

