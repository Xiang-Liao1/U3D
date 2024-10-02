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
    public class TreasureHuntSystemTests
    {
        [TestMethod]
        public void testMaxTreasureValue_WithValidInput()
        {
            int[] treasures = { 1, 8, 2, 6, 1, 10 };
            int result = TreasureHuntSystem.MaxTreasureValue(treasures);
            Assert.AreEqual(24, result);  
        }

        [TestMethod]
        public void testMaxTreasureValue_WithTwoElementArray()
        {
            int[] treasures = { 1, 2 };
            int result = TreasureHuntSystem.MaxTreasureValue(treasures);
            Assert.AreEqual(2, result);  // 
        }

        [TestMethod]
        public void testMaxTreasureValue_WithIdenticalValues()
        {
            int[] treasures = { 3, 3, 3, 3 };
            int result = TreasureHuntSystem.MaxTreasureValue(treasures);
            Assert.AreEqual(6, result);  // 
        }

        [TestMethod]
        public void testMaxTreasureValue_WithOneElementArray()
        {
            int[] treasures = { 3};
            int result = TreasureHuntSystem.MaxTreasureValue(treasures);
            Assert.AreEqual(3, result);  // 
        }

        [TestMethod]
        public void testMaxTreasureValue_WithEmptyArray()
        {
            int[] treasures = { };
            int result = TreasureHuntSystem.MaxTreasureValue(treasures);
            Assert.AreEqual(0, result);  // 空数组应返回 0
        }
        
    }
}