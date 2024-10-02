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
    public class TalentAssessmentSystemTests
    {
        [TestMethod()]
        public void FindMedianTalentIndexTest_WithEven()
        {
            int[] fires = { 1, 3, 7, 9, 11 };
            int[] ices = { 2, 4, 8, 10, 12};
            double result = TalentAssessmentSystem.FindMedianTalentIndex(fires, ices);
            Assert.AreEqual(7.5, result,0.0001);
        }

        [TestMethod()]
        public void FindMedianTalentIndexTest_WithOdd()
        {
            int[] fires = { 1, 3, 7, 9, 11 };
            int[] ices = { 2, 4, 8, 10, 12 ,14};
            double result = TalentAssessmentSystem.FindMedianTalentIndex(fires, ices);
            Assert.AreEqual(8, result, 0.0001);
        }

        [TestMethod()]
        public void FindMedianTalentIndexTest_WithOneNull()
        {
            int[] fires = { };
            int[] ices = { 2, 4, 8, 10, 12};
            double result = TalentAssessmentSystem.FindMedianTalentIndex(fires, ices);
            Assert.AreEqual(8, result, 0.0001);
        }

        [TestMethod()]
        public void FindMedianTalentIndexTest_WithAllNull()
        {
            int[] fires = { };
            int[] ices = {  };
            double result = TalentAssessmentSystem.FindMedianTalentIndex(fires, ices);
            Assert.AreEqual(0, result, 0.0001);
        }

        [TestMethod()]
        public void FindMedianTalentIndexTest_WithSame()
        {
            int[] fires = { 1,3,5,8};
            int[] ices = {1,3,5,8 };
            double result = TalentAssessmentSystem.FindMedianTalentIndex(fires, ices);
            Assert.AreEqual(4, result, 0.0001);
        }
    }
}