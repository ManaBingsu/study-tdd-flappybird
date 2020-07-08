using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GameSystem;
using Pipe;

namespace Tests
{
    public class PipeTest
    {
        PipeController pipe;
        #region Initialize test
        [Test]
        public void Init_IsStateInitializedToOff()
        {
            Assert.AreEqual(0, 1);
        }
        [Test]
        public void Init_IsActiveFalseWhenInitialized()
        {
            Assert.AreEqual(false, pipe.gameObject.activeSelf);
        }
        #endregion
        #region State.On, Inbound test
        [UnityTest]
        public IEnumerator On_InBound_IsStateOnWhenInBound()
        {
            Assert.AreEqual(0, 1);
            yield return null;
        }
        [UnityTest]
        public IEnumerator On_InBound_IsActiveTrueWhenInBound()
        {
            Assert.AreEqual(0, 1);
            yield return null;
        }
        #endregion
        #region State.On, OutBound test
        [UnityTest]
        public IEnumerator On_OutBound_IsStateSetOffWhenOutOfBound()
        {
            Assert.AreEqual(0, 1);
            yield return null;
        }
        #endregion
        #region State.Off test
        [Test]
        public void Off_IsReturnToQueueWhenOff()
        {
            Assert.AreEqual(0, 1);
        }
        [Test]
        public void Off_IsSetActiveFalseWhenOff()
        {
            Assert.AreEqual(0, 1);
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
            pipe = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Pipe")).GetComponent<PipeController>();
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

