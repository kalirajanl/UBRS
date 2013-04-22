using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UBRS.Common
{
    public static class UBRSValidators
    {

        public static bool IsValidDateText(string dateText)
        {
            bool returnValue = true;
            try
            {
                DateTime date = Convert.ToDateTime(dateText);
            }
            catch
            {
                returnValue = false;
            }
            return returnValue;
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = dt.DayOfWeek - startOfWeek;
            if (diff < 0)
            {
                diff += 7;
            }

            return dt.AddDays(-1 * diff).Date;
        }

        public static DateTime StartOfMonth(this DateTime dt)
        {
            return Convert.ToDateTime("01/" + dt.Month + "/" + dt.Year).Date;
        }

        public static DateTime EndOfMonth(this DateTime dt)
        {
            return StartOfMonth(dt.AddDays(35)).AddDays(-1);
        }

        public static int NoOfWeeksInMonth(int year, int month)
        {
            DayOfWeek wkstart = DayOfWeek.Monday;

            DateTime first = new DateTime(year, month, 1);
            int firstwkday = (int)first.DayOfWeek;
            int otherwkday = (int)wkstart;

            int offset = ((otherwkday + 7) - firstwkday) % 7;

            double weeks = (double)(DateTime.DaysInMonth(year, month) - offset) / 7d;

            return (int)Math.Ceiling(weeks);
        } 
    }
}