using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using V2;

namespace Tests
{
    public class InputManagerTest
    {
        [Test]
        public void Playing_IsBirdFlyingWhenInputBirdFlyingKey()
        {
            var inputManager = Substitute.For<IInput>();
            var bird = Substitute.For<IBird>();
            var birdController = Substitute.For<IBirdController>();
            InputBird inputBird = new InputBird(inputManager, birdController);
            
            inputBird.InputFlying();
            birdController.Received().Flying();
        }

    }
}
