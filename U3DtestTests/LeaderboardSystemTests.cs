using Microsoft.VisualStudio.TestTools.UnitTesting;
using U3Dtest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U3Dtest.Tests
{
    [TestClass()]
    public class LeaderboardSystemTests
    {
        [TestMethod()]
        public void TestGetTopScores_WithValidInput()
        {
            int[] scores = { 100, 200, 150, 180, 250 };
            int m = 3;
            List<int> expected = new List<int> { 250, 200, 180 };

            CollectionAssert.AreEqual(expected, LeaderboardSystem.GetTopScores(scores, m));
        }

        [TestMethod()]
        public void TestGetTopScores_WithEmptyArray()
        {
            int[] scores = { };
            int m = 3;
            List<int> result = LeaderboardSystem.GetTopScores(scores, m);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod()]
        public void TestGetTopScores_WithMLargerThanArrayLength()
        {
            int[] scores = { 100, 200, 150 };
            int m = 5;
            List<int> expected = new List<int> { 200, 150, 100 };
            List<int> result = LeaderboardSystem.GetTopScores(scores, m);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestGetTopScores_WithMEqualToZero()
        {
            int[] scores = { 100, 200, 150 };
            int m = 0;
            List<int> result = LeaderboardSystem.GetTopScores(scores, m);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod()]
        public void TestGetTopScores_WithOneElementArray()
        {
            int[] scores = { 150 };
            int m = 1;
            List<int> expected = new List<int> { 150 };
            List<int> result = LeaderboardSystem.GetTopScores(scores, m);
            CollectionAssert.AreEqual(expected, result);
        }


        /*
         * ProTest
         */
        
        [TestMethod()]
        public void TestGetTopScoresPro_WithValidInput()
        {
            int[] scores = { 100, 200, 150, 180, 250 };
            int m = 3;
            List<int> expected = new List<int> { 250, 200, 180 };

            CollectionAssert.AreEqual(expected, LeaderboardSystem.GetTopScoresPro(scores, m));
        }

        [TestMethod()]
        public void TestGetTopScoresPro_WithEmptyArray()
        {
            int[] scores = { };
            int m = 3;
            List<int> result = LeaderboardSystem.GetTopScoresPro(scores, m);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod()]
        public void TestGetTopScoresPro_WithMLargerThanArrayLength()
        {
            int[] scores = { 100, 200, 150 };
            int m = 5;
            List<int> expected = new List<int> { 200, 150, 100 };
            List<int> result = LeaderboardSystem.GetTopScoresPro(scores, m);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void TestGetTopScoresPro_WithMEqualToZero()
        {
            int[] scores = { 100, 200, 150 };
            int m = 0;
            List<int> result = LeaderboardSystem.GetTopScoresPro(scores, m);
            CollectionAssert.AreEqual(new List<int>(), result);
        }

        [TestMethod()]
        public void TestGetTopScoresPro_WithOneElementArray()
        {
            int[] scores = { 150 };
            int m = 1;
            List<int> expected = new List<int> { 150 };
            List<int> result = LeaderboardSystem.GetTopScoresPro(scores, m);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}