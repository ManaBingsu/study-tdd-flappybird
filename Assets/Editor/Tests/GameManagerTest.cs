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
        #region Initialize test
        [Test]
        public void IsGameManagerPrefabNotNull()
        {
            Assert.IsNotNull(GameManager._instance);
        }
        [Test]
        public void HasSingleton()
        {
            Assert.IsNotNull(GameManager._instance);
        }
        [Test]
        public void IsStateInitializedToStart()
        {
            Assert.AreEqual(GameManager._instance.GetState(), SystemDefine.EGameState.Start);
        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual((int)GameManager._instance.GetState(), (int)SystemDefine.EGameState.Start);
        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(GameManager._instance.GetState(), SystemDefine.EGameState.Playing);
        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(GameManager._instance.GetState(), SystemDefine.EGameState.Fall);
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            if (GameManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager"));
            }
        }

        [TearDown]
        public void CleanUpTest()
        {
            GameManager._instance = null;
        }
    }
}
