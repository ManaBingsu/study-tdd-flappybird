using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
using UnityEditor.VersionControl;

namespace Tests
{
    public class BirdTest
    {
        [Test]
        public void _00IsBirdFlyWhenPressedSpace()
        {
            Assert.AreEqual(1, 1);
        }
        [Test]
        public void _01IsBirdDieWhenCollidedWithPipe()
        {
            Assert.AreEqual(1, 2);
        }
    }
}
