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
            Assert.AreEqual(PipeDefine.EPipeState.Off, pipe.GetState());
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
            pipe.SetState(PipeDefine.EPipeState.On);
            pipe.transform.position = new Vector2(PipeManager._instance.GetBoundX() + 10f, 0f);
            float time = 0f;
            while (time <= 3f)
            {
                time += Time.deltaTime;
                yield return null;
            }
            Assert.AreEqual(PipeDefine.EPipeState.On, pipe.GetState());
        }
        [UnityTest]
        public IEnumerator On_InBound_IsActiveTrueWhenInBound()
        {
            pipe.SetState(PipeDefine.EPipeState.On);
            pipe.transform.position = new Vector2(PipeManager._instance.GetBoundX() + 10f, 0f);
            float time = 0f;
            while (time <= 3f)
            {
                time += Time.deltaTime;
                yield return null;
            }
            Assert.AreEqual(true, pipe.gameObject.activeSelf);
        }
        #endregion
        #region State.On, OutBound test
        [UnityTest]
        public IEnumerator On_OutBound_IsStateSetOffWhenOutOfBound()
        {
            pipe.SetState(PipeDefine.EPipeState.On);
            pipe.transform.position = new Vector2(PipeManager._instance.GetBoundX() - 3f, 0f);
            float time = 0f;
            while (time <= 3f)
            {
                time += Time.deltaTime;
                yield return null;
            }
            Assert.AreEqual(PipeDefine.EPipeState.Off, pipe.GetState());
        }
        #endregion
        #region State.Off test
        [Test]
        public void Off_IsReturnToQueueWhenOff()
        {
            pipe.SetState(PipeDefine.EPipeState.On);
            pipe.SetState(PipeDefine.EPipeState.Off);
            Assert.IsNotNull(PipeManager._instance.GetPipeQueue());
        }
        [Test]
        public void Off_IsSetActiveFalseWhenOff()
        {
            pipe.SetState(PipeDefine.EPipeState.Off);
            Assert.AreEqual(false, pipe.gameObject.activeSelf);
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

