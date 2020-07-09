using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public class BirdController : IBirdController
    {
        private IBird bird;
        private Rigidbody2D rigidbody;
        public BirdController()
        {

        }
        public BirdController(IBird bird)
        {
            this.bird = bird;
            rigidbody = bird.Rigidbody;
        }
        public void Flying()
        {
            // 날다!
        }
    }
}

