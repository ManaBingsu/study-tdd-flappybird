using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using V2;

namespace Tests
{
    public class GameManagerTest
    {
        [Test]
        public void IsStateChangedToStartWhenInput()
        {
            var gameManager = Substitute.For<IGameManager>();
            
        }
    }
}
