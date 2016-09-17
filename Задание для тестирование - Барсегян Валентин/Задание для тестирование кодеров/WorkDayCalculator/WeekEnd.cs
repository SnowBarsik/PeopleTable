using System;

namespace WorkDayCalculatorProj
{
    public class WeekEnd
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public WeekEnd(DateTime startDate, DateTime endDate)
        {
            if(startDate > endDate) throw new ArgumentOutOfRangeException();
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
