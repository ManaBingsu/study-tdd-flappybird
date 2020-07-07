using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;
using GameSystem;
using Bird;
using Input;
using Pipe;

namespace Tests
{
    public class Birdtest
    {
        GameObject gameManager;
        GameObject inputManager;
        GameObject birdManager;
        GameObject scoreManager;
        GameObject birdObject;
       
        BirdController bird;
        #region Initialize test
        [Test]
        public void Init_IsStateInitializedToStart()
        {
            Assert.AreEqual(BirdDefine.EBirdState.Start, bird.GetState());
        }
        [Test]
        public void Init_IsPosSetToFirstPosWhenInitialized()
        {
            Assert.AreEqual(bird.GetBirdPos(), BirdManager._instance.GetBirdFirstPos());
        }
        #endregion
        #region State.Start test
        [Test]
        public void Start_IsStateSetToStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(BirdDefine.EBirdState.Start, bird.GetState());
        }
        [Test]
        public void Start_IsPosSetToFirstPosWhenStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(bird.GetBirdPos(), BirdManager._instance.GetBirdFirstPos());
        }
        [UnityTest]
        public IEnumerator Start_IsPosFixedToFirstPosWhenStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Time.timeScale = 20f;
            Vector2 birdFirstPos = BirdManager._instance.GetBirdFirstPos();
            float time = 0f;
            while (time < 10f)
            {
                time += Time.deltaTime;
                Assert.AreEqual(birdFirstPos, bird.GetBirdPos());
                yield return null;
            }
            Time.timeScale = 1f;
        }
        [Test]
        public void Start_IsGravitySetZero()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(bird.GetBirdGravityScale(), 0);
        }
        #endregion
        #region State.Playing test
        [Test]
        public void Playing_IsStateSetToPlaying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(BirdDefine.EBirdState.Playing, bird.GetState());
        }
        [Test]
        public void Playing_IsGravitySetRight()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(bird.GetBirdStat().GetBirdGravity(), bird.GetBirdGravityScale());
        }
        [UnityTest]
        public IEnumerator Playing_IsBirdFlyingWhenRunFlying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            bird.Flying();
            bird.Flying();
            bird.Flying();
            bird.Flying();
            yield return null;
            yield return null;
            yield return null;
            Assert.AreNotEqual(BirdManager._instance.GetBirdFirstPos(), bird.GetBirdPos());
        }
        [UnityTest]
        public IEnumerator Playing_IsBirdFlyingWhenPressAssignedKey()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            InputManager._instance.PressFlying();
            yield return null;
            yield return null;
            yield return null;
            Assert.AreNotEqual(BirdManager._instance.GetBirdFirstPos(), bird.GetBirdPos());
        }
        [Test]
        public void Playing_IsBirdCantFlyingAtOutOfBound()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            bird.transform.position = new Vector2(0, BirdManager._instance.GetBoundY() + 0.5f);
            Assert.IsFalse(bird.Flying());
        }
        [UnityTest]
        public IEnumerator Playing_IsBirdGetScoreWhenPassingPipe()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            // Create Pipe mock object
            GameObject pipeMock = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Mock/PipeMock"), new Vector2(0, 0), Quaternion.identity);
            // Set test environment
            bird.SetBirdGravityScale(0f);
            bird.SetBirdPos(new Vector2(-3f, 0f));
            // Testing
            Time.timeScale = 20f;
            float time = 0f;
            while (time < 3f)
            {
                time += Time.deltaTime;
                bird.transform.position += new Vector3(0.01f, 0f, 0f) * Time.timeScale;
                yield return null;
            }
            Object.Destroy(pipeMock);
            Assert.AreEqual(1, ScoreManager._instance.GetCurrentScore());
            Time.timeScale = 1f;
        }
        [UnityTest]
        public IEnumerator Playing_IsBirdGetScoreCorrectlyWhenPassingSeveralPipe()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            // Create Pipe mock object
            GameObject pipeMock1 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Mock/PipeMock"), new Vector2(0, 0), Quaternion.identity);
            GameObject pipeMock2 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Mock/PipeMock"), new Vector2(4, 0), Quaternion.identity);
            GameObject pipeMock3 = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Mock/PipeMock"), new Vector2(8, 0), Quaternion.identity);
            // Set test environment
            bird.SetBirdGravityScale(0f);
            bird.SetBirdPos(new Vector2(-3f, 0f));
            // Testing
            Time.timeScale = 20f;
            float time = 0f;
            while (time < 10f)
            {
                time += Time.deltaTime;
                bird.transform.position += new Vector3(0.01f, 0f, 0f) * Time.timeScale;
                yield return null;
            }
            Assert.AreEqual(3, ScoreManager._instance.GetCurrentScore());
            Time.timeScale = 1f;
        }
        [UnityTest]
        public IEnumerator Playing_IsBirdStateSetFallWhenCollidedWithPipe()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            // Create Pipe mock object
            GameObject pipeMock = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Mock/PipeMock"), new Vector2(0, 0), Quaternion.identity);
            // Set test environment
            bird.SetBirdGravityScale(0f);
            bird.SetBirdPos(new Vector2(-3f, 3f));
            // Testing
            Time.timeScale = 10f;
            float time = 0f;
            while (time < 3f)
            {
                time += Time.deltaTime;
                bird.transform.position += new Vector3(0.01f, 0f, 0f) * Time.timeScale;
                yield return null;
            }
            Object.Destroy(pipeMock);
            Assert.AreEqual(SystemDefine.EGameState.Fall, GameManager._instance.GetState());
            Time.timeScale = 1f;
        }
        [Test]
        public void Playing_IsBirdStateSetFallWhenCollidedWithFloor()
        {
            Assert.AreEqual(0, 1);
        }
        #endregion
        #region State.Fall test
        [Test]
        public void Fall_IsStateSetToFall()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(BirdDefine.EBirdState.Fall, bird.GetState());
        }
        [UnityTest]
        public IEnumerator Fall_CantMoveWhilePressedAssignedKey()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            // Set test environment
            bird.SetBirdGravityScale(0f);
            Vector2 birdFirstPos = bird.GetBirdPos();
            // Testing
            Time.timeScale = 20f;
            float time = 0f;
            while (time < 3f)
            {
                time += Time.deltaTime;
                InputManager._instance.PressFlying();
                yield return null;
            }
            Assert.AreEqual(birdFirstPos, bird.GetBirdPos());
            Time.timeScale = 1f;
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            CleanUpTest();
            if (GameManager._instance == null)
            {
                gameManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager"));
            }
            if (BirdManager._instance == null)
            {
                birdManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/BirdManager"));
            }
            if (ScoreManager._instance == null)
            {
                scoreManager = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/ScoreManager"));
            }
            if (InputManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/InputManager"));
            }
            bird = BirdManager._instance.GetBird();
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
