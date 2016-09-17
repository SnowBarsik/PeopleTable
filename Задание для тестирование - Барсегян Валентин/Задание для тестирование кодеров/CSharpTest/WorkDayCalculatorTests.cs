using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDayCalculatorProj;

namespace CSharpTest
{
    [TestClass]
    public class WorkDayCalculatorTests
    {

        [TestMethod]
        public void TestNoWeekEnd()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 10;

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, null);

            //assert
            Assert.AreEqual(startDate.AddDays(count), result);
        }



        [TestMethod]
        public void TestDayCountZero() 
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 0;

            WeekEnd oneDayWeekEnd = new WeekEnd(new DateTime(2016, 12, 1), new DateTime(2016, 12, 1));

            WeekEnd[] weekEnds = {oneDayWeekEnd};

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate, result);
        }

        [TestMethod]
        public void TestDayCountOne()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 1;

            WeekEnd oneDayWeekEnd = new WeekEnd(new DateTime(2016, 12, 2), new DateTime(2016, 12, 2));

            WeekEnd[] weekEnds = { oneDayWeekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(2), result);
        }

        [TestMethod]
        public void TestDayCountTwo()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 2;

            WeekEnd oneDayWeekEnd = new WeekEnd(new DateTime(2016, 12, 2), new DateTime(2016, 12, 2));

            WeekEnd[] weekEnds = { oneDayWeekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(3), result);
        }

        [TestMethod]
        public void TestSingleWeekendLongerThenDayCount()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 6;

            WeekEnd longestWeekends = new WeekEnd(new DateTime(2016, 11, 20), new DateTime(2016, 12, 10));

            WeekEnd[] weekEnds = { longestWeekends };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(15), result);
        }

        [TestMethod]
        public void TestWeekendsStartsOnStartDay()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 7;

            WeekEnd weekEnd = new WeekEnd(new DateTime(2016, 12, 1), new DateTime(2016, 12, 3));

            WeekEnd[] weekEnds = { weekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(9), result); //count + weekends = 9 (i.e.: 7 + 2 = 9)
        }

        [TestMethod]
        public void TestWeekendsEndOnDayCount()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 7;

            WeekEnd weekEnd = new WeekEnd(new DateTime(2016, 12, 3), new DateTime(2016, 12, 8));

            WeekEnd[] weekEnds = { weekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(13), result); //count + weekends = 14 (i.e.: 7 + 6 = 13)
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDayCountArgOutOfRange()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = -1;

            WeekEnd oneDayWeekEnd = new WeekEnd(new DateTime(2016, 12, 1), new DateTime(2016, 12, 1));

            WeekEnd[] weekEnds = { oneDayWeekEnd };

            //act
            new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //wait for exception
        }

        [TestMethod]
        public void TestWeekendsStartBeforStartDay()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 7;

            WeekEnd weekEnd = new WeekEnd(new DateTime(2016, 11, 20), new DateTime(2016, 12, 3));

            WeekEnd[] weekEnds = { weekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(9), result); // count + weekends = 9 (e.i.: 7 + 2 = 9)
        }

        [TestMethod]
        public void TestWeekendsEndAfterDayCount()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 1);
            int count = 7;

            WeekEnd weekEnd = new WeekEnd(new DateTime(2016, 12, 4), new DateTime(2016, 12, 15));

            WeekEnd[] weekEnds = { weekEnd };

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(19), result); // count + weekends = 12 (e.i.: 7 + 12 = 19)
        }

        [TestMethod]
        public void TestWeekendsLongerThenDayCount()
        {
            //arrange
            DateTime startDate = new DateTime(2016, 12, 4);
            int count = 12;

            WeekEnd[] weekEnds = new WeekEnd[20];

            for (int i = 0; i < 16; i++)
            {
                WeekEnd oneDayWeekEnd = new WeekEnd(new DateTime(2016, 12, i + 1), new DateTime(2016, 12, i + 1));
                weekEnds[i] = oneDayWeekEnd;
            }

            //act
            DateTime result = new WorkDayCalculator().Calculate(startDate, count, weekEnds);

            //assert
            Assert.AreEqual(startDate.AddDays(24), result);
        }
    }
}
