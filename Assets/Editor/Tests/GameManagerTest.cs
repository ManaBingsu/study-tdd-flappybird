using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GameSystem;

namespace Tests
{
    public class GameManagerTest
    {
        GameManager gameManager;

        #region Initialize test
        [Test]
        public void IsGameManagerPrefabNotNull()
        {

        }
        [Test]
        public void HasSingleton()
        {

        }
        [Test]
        public void HasScoreManager()
        {

        }
        [Test]
        public void HasBirdManager()
        {

        }
        [Test]
        public void HasPipeManager()
        {

        }
        [Test]
        public void IsStateInitializedToStart()
        {

        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {

        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {

        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {

        }
        #endregion


        [SetUp]
        public void PrepareTest()
        {
            gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Test/GameManager")).GetComponent<GameManager>();
        }
        [TearDown]
        public void CleanUpTest()
        {
            MonoBehaviour.Destroy(gameManager);
        }
    }
}
