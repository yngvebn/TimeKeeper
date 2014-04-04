using System;
using System.Collections.Generic;

namespace KeepTime.Contracts
{
    public class CalendarEntry
    {
        public CalendarEntry()
        {
            
        }
        public CalendarEntry(DateTime now)
        {
            Date = now.Date;
            CheckIn = now.TimeOfDay;
        }

        public DateTime Date { get; set; }
        public TimeSpan CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public IList<CalendarActivity> Activities { get; set; }
    }
}