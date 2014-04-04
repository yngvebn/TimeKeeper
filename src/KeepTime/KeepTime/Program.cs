using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using KeepTime.Contracts;

namespace KeepTime
{
    class Program
    {
        static void Main(string[] args)
        {
            string calendarFile = ConfigurationManager.AppSettings["dataFile"];
            if (!File.Exists(calendarFile))
            {
                using (var file = File.Create(calendarFile))
                {

                };
            }
            string allEntries = File.ReadAllText(calendarFile);
            var calendar = Newtonsoft.Json.JsonConvert.DeserializeObject<Calendar>(allEntries);
            if (calendar == null) calendar = new Calendar();
            if (calendar.Entries == null) calendar.Entries = new List<CalendarEntry>();

            var today = calendar.Entries.FirstOrDefault(c => c.Date.Date.Equals(DateTime.Now.Date));
            if (today == null)
            {
                today = new CalendarEntry(DateTime.Now);
                calendar.Entries.Add(today);
            }
            else
            {
                if (today.CheckOut.HasValue)
                    today.CheckOut = null;
                else
                    today.CheckOut = DateTime.Now.TimeOfDay;
            }

            File.WriteAllText(calendarFile, Newtonsoft.Json.JsonConvert.SerializeObject(calendar));

        }
    }
}
