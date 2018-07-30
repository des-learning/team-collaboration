using Microsoft.VisualStudio.TestTools.UnitTesting;
using SewaAlat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SewaAlat.Tests
{
    [TestClass()]
    public class SewaAlatTests
    {
        private SewaAlat sewa;

        public SewaAlatTests()
        {
            sewa = new SewaAlat();
        }

        [TestMethod()]
        public void HitungBiayaSewaTest()
        {
            double expectedResult = 400_000.0;
            double result = sewa.HitungBiayaSewa(8);

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void HitungBiayaSewaNolTest()
        {
            double result = sewa.HitungBiayaSewa(0.0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void HitungBiayaSewaMinusTest()
        {
            double result = sewa.HitungBiayaSewa(-1);
        }

        [TestMethod()]
        public void HitungBiayaSewaMinimumChargeTest()
        {
            double expectedResult = 200_000.0;
            double[] masaSewa = { 1.0, 2.0, 2.5, 0.5, 4.0 };

            foreach (double ms in masaSewa)
            {
                Assert.AreEqual(expectedResult, sewa.HitungBiayaSewa(ms));
            }
        }

        [TestMethod()]
        public void HitungBiayaSewaLevel1()
        {
            /* Dictionary<Double, Double> expectedValues = new Dictionary<double, double>
            {
                {8.0, 400_000}, {6.0, 300_000.0}, {5.0, 250_000.0}, {6.5, 325_000.0}
            };
            foreach(KeyValuePair<Double, Double> entry in expectedValues)
            {
                Assert.AreEqual(entry.Value, sewa.HitungBiayaSewa(entry.Key));
            } */
            for (double i = 4.1; i <= 8.0; i+=0.1) {
                double expected = i * 50_000.0;
                Assert.AreEqual(expected, sewa.HitungBiayaSewa(i));
            }
        }

        [TestMethod()]
        public void HitungBiayaSewaLevel2()
        {
            double[] expectedResults = { 460_000.0, 520_000.0, 430_000.0, 640_000.0 };
            double[] masaSewa = { 9.0, 10.0, 8.5, 12.0 };
            for (int i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], sewa.HitungBiayaSewa(masaSewa[i]));
            }
        }

        [TestMethod()]
        public void HitungBiayaSewaLevel3()
        {
            double[] expectedResults = { 715_000.0, 677_500.0, 647_500.0, 1_015_000.0 };
            double[] masaSewa = { 13.0, 12.5, 12.1, 17.0 };
            for (int i = 0; i < expectedResults.Length; i++)
            {
                Assert.AreEqual(expectedResults[i], sewa.HitungBiayaSewa(masaSewa[i]));
            }
        }
    }
}