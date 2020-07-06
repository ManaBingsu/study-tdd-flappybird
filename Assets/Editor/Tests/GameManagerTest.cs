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
            Assert.IsNotNull(gameManager);
        }
        [Test]
        public void HasSingleton()
        {
            Assert.IsNotNull(gameManager);
        }
        [Test]
        public void IsStateInitializedToStart()
        {
            Assert.AreEqual(gameManager.GetState(), SystemDefine.EGameState.Start);
        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {
            gameManager.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual((int)gameManager.GetState(), (int)SystemDefine.EGameState.Start);
        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {
            gameManager.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(gameManager.GetState(), SystemDefine.EGameState.Playing);
        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {
            gameManager.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(gameManager.GetState(), SystemDefine.EGameState.Fall);
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager")).GetComponent<GameManager>();
        }

        [TearDown]
        public void CleanUpTest()
        {
            MonoBehaviour.Destroy(gameManager);
            GameManager._instance = null;
        }
    }
}
