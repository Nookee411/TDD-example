using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
using System.Collections.Generic;
using System.Linq;

namespace SystemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializationWithArray()
        {
            const int n = 3;
            double[] k = new double[n] { 1, 2, 3 };
            LinearEquation a = new Task2.LinearEquation(k);
            Assert.AreEqual(a[0], 2);
        }

        [TestMethod]
        public void InitializationWithString()
        {
            string k = "1 2 3";
            LinearEquation a = new LinearEquation(k);
            Assert.AreEqual(a[0], 2);
        }
        [TestMethod]
        public void InitializationWithList()
        {
            List<double> k = new List<double> { 1, 2, 3 };
            LinearEquation a = new LinearEquation(k);
            Assert.AreEqual(a[0], 2);
        }

        [TestMethod]
        public void DegreeTest()
        {
            LinearEquation a = new LinearEquation(new double[] { 1, 2, 3 });
            Assert.AreEqual(a.Degree, 1);
        }

        [TestMethod]

        public void RandomTest()
        {
            LinearEquation a = new LinearEquation(new double[] { 1, 2, 3 });
            a.SetRandom(10, -5);
            double max = double.MinValue, min = double.MaxValue;
            for (int i = 0; i <= a.Degree; i++)
            {
                if (a[i] < min)
                    min = a[i];
                if (a[i] > max)
                    max = a[i];
            }
            Assert.IsTrue(max < 10 && min > -5);
        }
        [TestMethod]
        public void EqualationTest()
        {
            LinearEquation a = new LinearEquation(new double[] { 1, 2, 3 });
            a.SetNum(1);
            double sum = 0;
            for (int i = 0; i <= a.Degree; i++)
            {
                sum += a[i];
            }
            Assert.AreEqual(sum,2);
        }
      
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing1()
        {
            int n = 3;
           var s = new SystemOfLinearEqualations(n);
            s.Add(new LinearEquation("1 2 3 15"));
            s.Add(new LinearEquation("2 4 3 20"));
            s.Add(new LinearEquation("5 6 7 33"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[-1]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing2()
        {
            int n = 3;
           var s = new SystemOfLinearEqualations(n);
            s.Add(new LinearEquation("1 2 3 15"));
            s.Add(new LinearEquation("2 4 3 20"));
            s.Add(new LinearEquation("5 6 7 33"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[12]);
        }        
    }
}
