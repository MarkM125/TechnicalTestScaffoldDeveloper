using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTestScaffoldDeveloper;
using System.Collections.Generic;

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
                Assert.AreEqual(6, CardsTest.CalculateScore(new int[] { 3, 3, 3, 2, 10 }).score);
            }

            [TestMethod]
            public void CheckScore_Run2()
            {
                Assert.AreEqual(1, CardsTest.CalculateScore(new int[] { 1, 2,3,4,5}).score);
            }

            [TestMethod]
            public void CheckScore_Run3()
            {
                Assert.AreEqual(10, CardsTest.CalculateScore(new int[] { 7,7,7,8,8 }).score);
            }

            [TestMethod]
            public void Test_CountCombinationsWhichAdd()
            {
                Assert.AreEqual(3, CardsTest.CountCombinationsWhichAdd(new List<int>(){ 3, 3, 3, 2, 10 }, 15));
                Assert.AreEqual(2, CardsTest.CountCombinationsWhichAdd(new List<int>(){ 10, 5, 2, 3 }, 15));
                Assert.AreEqual(0, CardsTest.CountCombinationsWhichAdd(new List<int>(){ 8, 8, 8 }, 15));
            }

            [TestMethod]
            public void Test_CountMatching()
            {
                Assert.AreEqual(3, CardsTest.CountMatching(new List<int>() { 3, 3, 3, 2, 10 }));
                Assert.AreEqual(0, CardsTest.CountMatching(new List<int>() { 10, 5, 2, 3 }));
                Assert.AreEqual(3, CardsTest.CountMatching(new List<int>() { 8, 8, 8 }));
            }

        }
    }
}
