using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Bird
{
    public class BirdController : MonoBehaviour, IBirdAdapter
    {
        public Vector2 GetBirdPos()
        {
            return transform.position;
        }

        public void Initialize()
        {
            transform.position = new Vector2(0, 0);
        }
    }
}

