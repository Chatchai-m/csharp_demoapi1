using _2Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow.AddHours(7);

        public CultureInfo CultureInfo => new CultureInfo("en-US");

        public DateTime UnixTime => new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public DateTime FromString(string date, string? time)
        {
            var dateArray = date.Split("-");

            if (string.IsNullOrEmpty(time))
            {
                time = Now.ToString("HH:mm");
            }

            var timeArray = time.Split(":");
            return new DateTime(Convert.ToInt16(dateArray[0]), Convert.ToInt16(dateArray[1]), Convert.ToInt16(dateArray[2]), Convert.ToInt16(timeArray[0]), Convert.ToInt16(timeArray[1]), 0);
        }

        public DateTime ToUTC(DateTime currentDate)
        {
            return currentDate.AddHours(-7);
        }
    }
}
