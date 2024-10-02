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
    public class EnergyFieldSystemTests
    {
        [TestMethod]
        public void TestMaxEnergyField_WithValidInput()
        {
            int[] heights = { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            double result = EnergyFieldSystem.MaxEnergyField(heights);
            Assert.AreEqual(52.5, result, 0.001);  // 根据梯形面积计算，最⼤梯形⾯积应为 52.5
        }

        [TestMethod]
        public void TestMaxEnergyField_WithSmallInput()
        {
            int[] heights = { 1, 2 };
            double result = EnergyFieldSystem.MaxEnergyField(heights);
            Assert.AreEqual(1.5, result, 0.001);  // 最⼤梯形⾯积应为 1.5
        }

        [TestMethod]
        public void TestMaxEnergyField_WithIdenticalHeights()
        {
            int[] heights = { 3, 3, 3, 3 };
            double result = EnergyFieldSystem.MaxEnergyField(heights);
            Assert.AreEqual(9, result, 0.001);  // 最⼤梯形⾯积应为 9
        }

        [TestMethod]
        public void TestMaxEnergyField_WithDecreasingHeights()
        {
            int[] heights = { 10, 8, 6, 4, 2 };
            double result = EnergyFieldSystem.MaxEnergyField(heights);
            Assert.AreEqual(24, result, 0.001);  // 最⼤梯形⾯积应为 30
        }

        [TestMethod]
        public void TestMaxEnergyField_WithEmptyArray()
        {
            int[] heights = { };
            double result = EnergyFieldSystem.MaxEnergyField(heights);
            Assert.AreEqual(0, result);  // 空数组应返回 0
        }

        
    }
}