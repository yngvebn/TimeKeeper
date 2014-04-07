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

            foreach (var notCompleted in calendar.Entries.Where(e => e.Date < DateTime.Now.Date && !e.CheckOut.HasValue))
            {
                Console.WriteLine("Enter checkout-time for {0:dddd dd-MM-yyyy}:", notCompleted.Date);
                string checkout = null;
                while (checkout == null)
                {
                    checkout = Console.ReadLine();
                }

                if (checkout.Contains(":"))
                {
                    if (checkout.Length == 5) checkout = checkout + ":00";
                }
                else
                {
                    string hh = checkout.Substring(0, 2);
                    string mm = checkout.Substring(2, 2);
                    checkout = hh + ":" + mm + ":00";
                }
                notCompleted.CheckOut = TimeSpan.Parse(checkout);
            }

            var today = calendar.Entries.FirstOrDefault(c => c.Date.Date.Equals(DateTime.Now.Date));
            if (today == null)
            {
                today = new CalendarEntry(DateTime.Now);
                calendar.Entries.Add(today);
            }
            else
            {
                if (DateTime.Now.TimeOfDay.Subtract(today.CheckIn).TotalHours < 6)
                {
                    Console.WriteLine("Less than 6 hours? Are you sure? ([Y]/[N])");
                    string input = null;
                    while (input == null)
                    {
                        input = Console.ReadKey().Key.ToString();
                        if (input.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            Finalize(calendarFile, calendar);
                            Environment.Exit(1);
                        }
                    }
                }
                if (today.CheckOut.HasValue)
                    today.CheckOut = null;
                else
                    today.CheckOut = DateTime.Now.TimeOfDay;
            }

            Finalize(calendarFile, calendar);

        }

        private static void Finalize(string calendarFile, Calendar calendar)
        {
            File.WriteAllText(calendarFile, Newtonsoft.Json.JsonConvert.SerializeObject(calendar));
        }
    }
}
