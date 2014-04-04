using System;
using System.Linq;
using System.Text;

namespace KeepTime.Contracts
{
    public class CalendarActivity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? TimeSpent { get; set; }
    }
}
