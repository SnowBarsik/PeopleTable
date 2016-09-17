using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkDayCalculatorProj;

namespace CSharpTest
{
    [TestClass]
    public class WeekEndTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestNegativeWeekends()
        {
            //act
            WeekEnd wrongWeekEnd = new WeekEnd(new DateTime(2016, 12, 2), new DateTime(2016, 12, 1));

            //wait for exception
        }
    }
}
