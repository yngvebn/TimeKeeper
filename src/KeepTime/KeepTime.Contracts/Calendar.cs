using System.Collections.Generic;

namespace KeepTime.Contracts
{
    public class Calendar
    {
        public IList<CalendarEntry> Entries { get; set; } 
    }
}