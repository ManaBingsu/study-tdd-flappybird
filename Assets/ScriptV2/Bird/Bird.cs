using NSubstitute.Routing.Handlers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace V2
{
    public class Bird : MonoBehaviour, IBird
    {
        // Data
        [SerializeField]
        private BirdData birdData;
        // Reference
        private BirdController birdController;
        private Rigidbody2D rigid;
        // Current state
        [SerializeField]
        public Vector2 position;
        public Vector2 Position { get => position; set => position = value; }
        // Value
        public Rigidbody2D Rigidbody => rigid;
        public float FlyingPower => birdData.flyingPower;
        public float MaxHeight => birdData.maxHeight;

        public BirdController BirdController => birdController;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
            birdController = new BirdController(this);
        }

        private void Update()
        {
            birdController.Flying();
        }
    }
}

