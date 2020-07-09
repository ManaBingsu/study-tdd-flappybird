using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public interface IBird
    {
        // Value
        float FlyingPower { get; }
        Vector2 Position { get; set; }
        float MaxHeight { get; }
        // Component
        Rigidbody2D Rigidbody { get; }
        BirdController BirdController { get; }
    }
}

