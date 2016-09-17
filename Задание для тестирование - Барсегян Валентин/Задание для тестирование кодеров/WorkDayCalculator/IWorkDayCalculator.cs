using System;

namespace WorkDayCalculatorProj
{
    public interface IWorkDayCalculator
    {
        DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds);
    }
}
