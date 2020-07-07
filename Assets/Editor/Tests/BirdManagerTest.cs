using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GameSystem;
using Bird;

namespace Tests
{
    public class BirdManagerTest
    {
        #region Initialize test
        [Test]
        public void HasSingleton()
        {
            Assert.IsNotNull(BirdManager._instance);
        }
        [Test]
        public void IsStateInitializedToStart()
        {
            Assert.AreEqual(BirdDefine.EBirdManagerState.Start, BirdManager._instance.GetState());
        }
        [Test]
        public void HasBird()
        {
            Assert.IsNotNull(BirdManager._instance.GetBird());
        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStartWhenGameManagerStateSetToStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(BirdDefine.EBirdManagerState.Start, BirdManager._instance.GetState());
        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlayingWhenGameManagerStateSetToPlaying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(BirdDefine.EBirdManagerState.Playing, BirdManager._instance.GetState());
        }

        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFalltWhenGameManagerStateSetToFall()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(BirdDefine.EBirdManagerState.Fall, BirdManager._instance.GetState());
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            if (GameManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager"));
            }
            if (BirdManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/BirdManager"));
            }
        }

        [TearDown]
        public void CleanUpTest()
        {
            GameObject[] gameObjectList = GameObject.FindObjectsOfType<GameObject>();
            for (int i = 0; i < gameObjectList.Length; i++)
            {
                GameObject gameObject = gameObjectList[i];
                MonoBehaviour.DestroyImmediate(gameObject);
            }
        }
    }
}
