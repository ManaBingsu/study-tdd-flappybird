using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Pipe;
using GameSystem;
using UnityEditor.VersionControl;

namespace Tests
{
    public class PipeManagerTest
    {
        #region Initialize test
        [Test]
        public void IsStateInitializedToStart()
        {
            Assert.AreEqual(PipeDefine.EPipeManagerState.Start, PipeManager._instance.GetState());
        }
        [Test]
        public void HasPipePrefab()
        {
            Assert.IsNotNull(PipeManager._instance.GetPipePrefab());
        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(PipeDefine.EPipeManagerState.Start, PipeManager._instance.GetState());
        }
        public void IsPipeQueuePipesSetActiveFalseWhenStart()
        {
            Assert.AreEqual(0, 1);
        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(PipeDefine.EPipeManagerState.Playing, PipeManager._instance.GetState());
        }
        [Test]
        public void IsPipeGenerateCoroutineStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.IsNotNull(PipeManager._instance.GetGeneratorCoroutine());
        }
        [Test]
        public void IsPipeSpeedChangeWhenChangeManagerValue()
        {
            float firstValue = PipeManager._instance.GetPipeSpeed();
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            PipeManager._instance.SetPipeSpeed(8f);
            Assert.AreNotEqual(firstValue, PipeManager._instance.GetPipeSpeed());
        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(PipeDefine.EPipeManagerState.Fall, PipeManager._instance.GetState());
        }
        public void IsPipeGenerateCoroutineStop()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.IsNull(PipeManager._instance.GetGeneratorCoroutine());
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            if (GameManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager"));
            }
            if (PipeManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/PipeManager"));
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
