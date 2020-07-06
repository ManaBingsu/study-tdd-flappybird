using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class Birdtest
    {
        #region Initialize test
        [Test]
        public void IsStateInitializedToStart()
        {

        }
        [Test]
        public void IsPosSetToZero()
        {

        }
        #endregion
        #region State.Start test
        [Test]
        public void IsStateSetToStart()
        {

        }
        [Test]
        public void IsPosSetToZeroFixedWhenStart()
        {

        }
        [Test]
        public void IsGravitySetZero()
        {

        }
        #endregion
        #region State.Playing test
        [Test]
        public void IsStateSetToPlaying()
        {

        }
        [Test]
        public void IsGravitySetRight()
        {

        }
        [Test]
        public void IsBirdFlyingWhenPressAssignedKey()
        {

        }
        [Test]
        public void IsBirdCantFlyingAtOutOfBound()
        {

        }
        [Test]
        public void IsBirdGetScoreWhenPassingPipe()
        {

        }
        [Test]
        public void IsBirdGetScoreCorrectlyWhenPassingSeveralPipe()
        {

        }
        [Test]
        public void IsBirdStateSetFallWhenCollidedWithPipe()
        {

        }
        [Test]
        public void IsBirdStateSetFallWhenCollidedWithFloor()
        {

        }
        #endregion
        #region State.Fall test
        [Test]
        public void IsStateSetToFall()
        {
        }
        [Test]
        public void CantMoveWhilePressedAssignedKey()
        {

        }    
        #endregion
    }
}
