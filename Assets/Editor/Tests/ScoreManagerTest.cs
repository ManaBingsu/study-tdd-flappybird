using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using GameSystem;

namespace Tests
{
    public class ScoreManagerTest
    {
        #region Initialize test
        [Test]
        public void IsStateInitializedToStart()
        {
            Assert.AreEqual(SystemDefine.EGameState.Start, ScoreManager._instance.GetState());
        }
        [Test]
        public void IsScoreSetToZero()
        {
            Assert.AreEqual(0, ScoreManager._instance.GetCurrentScore());
        }
        [Test]
        public void IsHighScoreSetToSavedHighScore()
        {
            Assert.AreEqual(PlayerPrefs.GetInt("HighScore"), ScoreManager._instance.GetHighScore());
        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(SystemDefine.EGameState.Start, ScoreManager._instance.GetState());
        }
        [Test]
        public void IsScoreSetToZeroWhenStart()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            ScoreManager._instance.SetCurrentScore(10);
            GameManager._instance.SetState(SystemDefine.EGameState.Start);
            Assert.AreEqual(0, ScoreManager._instance.GetCurrentScore());
        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            Assert.AreEqual(SystemDefine.EGameState.Playing, ScoreManager._instance.GetState());
        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(SystemDefine.EGameState.Fall, ScoreManager._instance.GetState());
        }
        [Test]
        public void IsHighScoreChangedWhenBirdGetAHighestScore()
        {
            int currentHighScore = ScoreManager._instance.GetHighScore();
            GameManager._instance.SetState(SystemDefine.EGameState.Playing);
            ScoreManager._instance.SetCurrentScore(999);
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreNotEqual(currentHighScore, ScoreManager._instance.GetHighScore());
        }
        [Test]
        public void IsScoreSaved()
        {
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            ScoreManager._instance.SetCurrentScore(999);
            GameManager._instance.SetState(SystemDefine.EGameState.Fall);
            Assert.AreEqual(ScoreManager._instance.GetHighScore(), PlayerPrefs.GetInt("HighScore"));
        }
        #endregion
        [SetUp]
        public void PrepareTest()
        {
            PlayerPrefs.SetInt("HighScore", 99);
            if (GameManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/GameManager"));
            }
            if (ScoreManager._instance == null)
            {
                MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/ScoreManager"));
            }
        }

        [TearDown]
        public void CleanUpTest()
        {
            PlayerPrefs.SetInt("HighScore", 99);
            GameObject[] gameObjectList = GameObject.FindObjectsOfType<GameObject>();
            for (int i = 0; i < gameObjectList.Length; i++)
            {
                GameObject gameObject = gameObjectList[i];
                MonoBehaviour.DestroyImmediate(gameObject);
            }
        }
    }
}
