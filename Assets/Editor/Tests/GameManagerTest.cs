using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using GameSystem;
using Bird;

namespace Tests
{
    public class GameManagerTest
    {
        GameManager gameManager;

        // Start state
        [Test]
        public void Start_00IsScoreInitialize()
        {
            gameManager.SetState(GameManager.GameManagerState.Start);
            Assert.AreEqual(scoreManager.GetScore(), 0);
        }
        [Test]
        public void Start_01IsBirdPosInitialized()
        {  
            gameManager.SetState(GameManager.GameManagerState.Start);
            Assert.AreEqual(bird.GetBirdPos(), new Vector2(0, 0));
        }
        [Test]
        public void Start_02IsPipeGeneratorInitialized()
        {

        }
        [Test]
        public void Start_03IsUIInitialized()
        {

        }
        // Playing State
        [Test]
        public void Playing_00IsScoreInitialize()
        {

        }
        [Test]
        public void Playing_01IsPlayerInitialized()
        {

        }
        [Test]
        public void Playing_02IsPipeGeneratorInitialized()
        {

        }
        [Test]
        public void Playing_03IsUIInitialized()
        {

        }
        // End State
        [Test]
        public void End_00IsScoreInitialize()
        {

        }
        [Test]
        public void End_01IsPlayerInitialized()
        {

        }
        [Test]
        public void End_02IsPipeGeneratorInitialized()
        {

        }
        [Test]
        public void End_03IsUIInitialized()
        {

        }
        
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
