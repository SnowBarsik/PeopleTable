using System;

namespace WorkDayCalculatorProj
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (dayCount < 0) throw new ArgumentOutOfRangeException();
            if (dayCount == 0) return startDate;

            if (weekEnds == null) return startDate.AddDays(dayCount);

            //int allDays = dayCount;
            foreach (var weekEnd in weekEnds)
            {
                if(weekEnd == null) continue;

                if (weekEnd.StartDate > startDate && weekEnd.StartDate <= startDate.AddDays(dayCount)) //if first day of the weekend is in range of dayCount
                {
                    dayCount += (int)weekEnd.EndDate
                        .Subtract(weekEnd.StartDate)
                        .TotalDays;
                    dayCount++;
                }
                else if (weekEnd.EndDate > startDate) //if last day of the weekened is in range of dayCount
                {
                    dayCount += (int)weekEnd.EndDate
                        .Subtract(startDate)
                        .TotalDays;
                }
            }

            return startDate.AddDays(dayCount); 
        }
    }
}