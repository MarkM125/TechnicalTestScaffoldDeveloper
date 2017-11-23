using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTestScaffoldDeveloper;
using System.Collections.Generic;
using TechnicalTestScaffoldDeveloper.Models;

namespace TechnicalTestScaffoldingUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class ScoreTests
        {
            [TestMethod]
            public void CheckScore_Run1()
            {
                Assert.AreEqual(6, Score.CalculateScore(new List<int>() { 2, 3, 3, 3, 10 }).Value);
                Assert.AreEqual(6, Score.CalculateScore(new List<int>() { 3, 2, 3, 3, 10 }).Value);
                Assert.AreEqual(6, Score.CalculateScore(new List<int>() { 3, 3, 2, 3, 10 }).Value);
                Assert.AreEqual(6, Score.CalculateScore(new List<int>() { 3, 3, 3, 2, 10 }).Value);
                Assert.AreEqual(6, Score.CalculateScore(new List<int>() { 10, 3, 3, 2, 3 }).Value);
            }

            [TestMethod]
            public void CheckScore_Run2()
            {
                Assert.AreEqual(1, Score.CalculateScore(new List<int>() { 1, 2, 3, 4, 5 }).Value);
            }

            [TestMethod]
            public void CheckScore_Run3()
            {
                Assert.AreEqual(11, Score.CalculateScore(new List<int>() { 7, 7, 7, 8, 8 }).Value);
            }

            [TestMethod]
            public void Test_CountCombinationsWhichAdd()
            {
                Assert.AreEqual(3, Score.CountCombinationsWhichAdd(new List<int>() { 3, 3, 3, 2, 10 }, 15));
                Assert.AreEqual(2, Score.CountCombinationsWhichAdd(new List<int>() { 10, 5, 2, 3 }, 15));
                Assert.AreEqual(0, Score.CountCombinationsWhichAdd(new List<int>() { 8, 8, 8 }, 15));
            }

            [TestMethod]
            public void Test_CountMatching()
            {
                bool validity;
                Assert.AreEqual(3, Score.CountMatching(new List<int>() { 3, 3, 3, 2, 10 }, out validity));
                Assert.IsTrue(validity);
                Assert.AreEqual(0, Score.CountMatching(new List<int>() { 10, 5, 2, 3 }, out validity));
                Assert.IsTrue(validity);
                Assert.AreEqual(3, Score.CountMatching(new List<int>() { 8, 8, 8 }, out validity));
                Assert.IsTrue(validity);
                Assert.AreEqual(2, Score.CountMatching(new List<int>() { 8, 8 }, out validity));
                Assert.IsTrue(validity);
                Assert.AreEqual(4, Score.CountMatching(new List<int>() { 8, 8, 8, 8 }, out validity));
                Assert.IsTrue(validity);
                Assert.AreEqual(5, Score.CountMatching(new List<int>() { 8, 8, 8, 8, 8 }, out validity));
                Assert.IsFalse(validity);
                Assert.AreEqual(5, Score.CountMatching(new List<int>() { 7, 7, 7, 8, 8 }, out validity));
                Assert.IsTrue(validity);
            }
        }
    }
}
