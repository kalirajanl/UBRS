using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using UBRS.Common;

namespace UBRS.Models
{
    public interface ISchedule
    {
        long ScheduleID { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        SchedRangeEndTypes EndDateSpecifiedAs { get; set; }
        SchedRecurPatterns RecurrencePattern { get; set; }
        SchedRecurPatternModes RecurrencePatternMode { get; set; }

        #region Reminder related attributes starts

        //bool ReminderOn { get; set; }
        //SchedReminderTypes RemindBeforeStartType { get; set; }
        
        #endregion
    }

    [Serializable]
    public abstract class Schedule : ISchedule
    {
        public Schedule()
        {
            RecurrencePatternMode = SchedRecurPatternModes.Simple;
        }

        public long ScheduleID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SchedRangeEndTypes EndDateSpecifiedAs { get; set; }
        public SchedRecurPatterns RecurrencePattern { get; set; }
        public SchedRecurPatternModes RecurrencePatternMode { get; set; }

        #region Reminder related attributes

        //protected int RemindBeforeMinutes { get; set; }
        //public bool ReminderOn { get; set; }
        //public SchedReminderTypes RemindBeforeStartType
        //{
        //    get
        //    {
        //        return RemindBeforeStartType;
        //    }
        //    set
        //    {
        //        RemindBeforeStartType = value;
        //        switch (value)
        //        {
        //            case SchedReminderTypes.ZeroMinutes:
        //                {
        //                    RemindBeforeMinutes = 0;
        //                    break;
        //                }
        //            case SchedReminderTypes.FiveMinutes:
        //                {
        //                    RemindBeforeMinutes = 5;
        //                    break;
        //                }
        //            case SchedReminderTypes.TenMinutes:
        //                {
        //                    RemindBeforeMinutes = 10;
        //                    break;
        //                }
        //            case SchedReminderTypes.FifteenMinutes:
        //                {
        //                    RemindBeforeMinutes = 15;
        //                    break;
        //                }
        //            case SchedReminderTypes.ThirtyMinutes:
        //                {
        //                    RemindBeforeMinutes = 30;
        //                    break;
        //                }
        //            case SchedReminderTypes.OneHour:
        //                {
        //                    RemindBeforeMinutes = 60;
        //                    break;
        //                }
        //            case SchedReminderTypes.TwoHours:
        //                {
        //                    RemindBeforeMinutes = 120;
        //                    break;
        //                }
        //            case SchedReminderTypes.ThreeHours:
        //                {
        //                    RemindBeforeMinutes = 180;
        //                    break;
        //                }
        //        }

        //       }

        //}

        #endregion 
    }

    [Serializable]
    public class DailySchedule : Schedule
    {
        public DailySchedule() : base()
        {
            RecurrencePattern = SchedRecurPatterns.Daily;
            RecurEveryNoOfDays = 1;
            WeekDaysOnly = false;
        }

        public int RecurEveryNoOfDays { get; set; }
        public bool WeekDaysOnly { get; set; }
    }

    [Serializable]
    public class WeeklySchedule : Schedule
    {
        public WeeklySchedule()
            : base()
        {
            RecurrencePattern = SchedRecurPatterns.Weekly;
            RecurEveryNoOfWeeks = 1;
        }

        public int RecurEveryNoOfWeeks { get; set; }
        public bool OnMondays { get; set; }
        public bool OnTuesdays { get; set; }
        public bool OnWednesdays { get; set; }
        public bool OnThursdays { get; set; }
        public bool OnFridays { get; set; }
        public bool OnSaturdays { get; set; }
        public bool OnSundays { get; set; }
    }

    [Serializable]
    public class MonthlySchedule : Schedule
    {
        public MonthlySchedule()
            : base()
        {
            RecurrencePattern = SchedRecurPatterns.Monthly;
            RecurEveryNoOfMonths = 1;
        }

        public int RecurEveryNoOfMonths { get; set; }
        public int OnDay { get; set; }
        //public SchedCounters Counter { get; set; }
        //public SchedDayTypes DayType { get; set; }
    }

    [Serializable]
    public class YearlySchedule : Schedule
    {
        public YearlySchedule()
            : base()
        {
            RecurrencePattern = SchedRecurPatterns.Yearly;
            RecurEveryNoOfYears = 1;
        }

        public int RecurEveryNoOfYears { get; set; }
        public int OnMonth { get; set; }
        public int OnDay { get; set; }
        //public SchedCounters Counter { get; set; }
        //public SchedDayTypes DayType { get; set; }
    }


    public class ScheduleHelper
    {
        public static List<DateTime> GetInstanceDates(ISchedule sched, DateTime startDate, DateTime finishDate)
        {
            List<DateTime> dates = null;
            if (sched == null)
            {
                dates = new List<DateTime>();
                for (DateTime tmpdate = startDate; tmpdate <= finishDate; tmpdate = tmpdate.AddDays(1))
                {
                    dates.Add(tmpdate);
                }
            }
            else if (sched.GetType() == typeof(YearlySchedule))
            {
                YearlySchedule ySched = (YearlySchedule)sched;
                dates = getYearlyInstanceDates(ySched, startDate, finishDate);
            }
            else if (sched.GetType() == typeof(MonthlySchedule))
            {
                MonthlySchedule mSched = (MonthlySchedule)sched;
                dates = getMonthlyInstanceDates(mSched, startDate, finishDate);
            }
            else if (sched.GetType() == typeof(WeeklySchedule))
            {
                WeeklySchedule wSched = (WeeklySchedule)sched;
                dates = getWeeklyInstanceDates(wSched, startDate, finishDate);
            }
            else
            {
                DailySchedule dSched = (DailySchedule)sched;
                dates = getDailyInstanceDates(dSched, startDate, finishDate);
            }
            if (dates.Count <= 0)
            {
                dates.Add(startDate);
            }
            return dates;
        }

        #region Private Methods

        private static List<DateTime> getYearlyInstanceDates(YearlySchedule sched, DateTime startDate, DateTime finishDate)
        {
            List<DateTime> dates = new List<DateTime>();
            if (startDate <= finishDate)
            {
                DateTime tmpDate = Convert.ToDateTime(getMonthText(sched.OnMonth) + "/" + sched.OnDay.ToString() + "/" + startDate.Year.ToString());
                while (tmpDate <= finishDate)
                {
                    if (tmpDate >= startDate)
                    {
                        dates.Add(tmpDate);
                    }
                    tmpDate = tmpDate.AddYears(sched.RecurEveryNoOfYears);
                }
            }
            return dates;
        }

        private static string getMonthText(int monthNumber)
        {
            string returnValue = "Jan";
            switch (monthNumber)
            {
                case 1: { returnValue = "Jan"; break; }
                case 2: { returnValue = "Feb"; break; }
                case 3: { returnValue = "Mar"; break; }
                case 4: { returnValue = "Apr"; break; }
                case 5: { returnValue = "May"; break; }
                case 6: { returnValue = "Jun"; break; }
                case 7: { returnValue = "Jul"; break; }
                case 8: { returnValue = "Aug"; break; }
                case 9: { returnValue = "Se["; break; }
                case 10: { returnValue = "Oct"; break; }
                case 11: { returnValue = "Nov"; break; }
                case 12: { returnValue = "Dec"; break; }
            }
            return returnValue;
        }

        private static List<DateTime> getMonthlyInstanceDates(MonthlySchedule sched, DateTime startDate, DateTime finishDate)
        {
            List<DateTime> dates = new List<DateTime>();
            if (startDate <= finishDate)
            {
                DateTime tmpDate = Convert.ToDateTime(startDate.ToString("MMM") + "/" + sched.OnDay.ToString() + "/" + startDate.Year.ToString());
                while (tmpDate <= finishDate)
                {
                    if (tmpDate >= startDate)
                    {
                        dates.Add(tmpDate);
                    }
                    tmpDate = tmpDate.AddMonths(sched.RecurEveryNoOfMonths);
                }
            }
            return dates;
        }

        private static List<DateTime> getWeeklyInstanceDates(WeeklySchedule sched, DateTime startDate, DateTime finishDate)
        {
            List<DateTime> dates = new List<DateTime>();
            if (startDate <= finishDate)
            {
                DateTime tmpDate = startDate;
                while (tmpDate <= finishDate)
                {
                    if (tmpDate >= startDate)
                    {
                        for (int i = 0; i <= 6; i++)
                        {
                            bool addDay = isInstanceDay(tmpDate.AddDays(i) , sched, startDate, finishDate);
                            if (addDay)
                            {
                                dates.Add(tmpDate.AddDays(i));
                            }
                        }
                    }
                    tmpDate = tmpDate.AddDays(7 * sched.RecurEveryNoOfWeeks);
                }
            }
            return dates;
        }

        private static bool isInstanceDay(DateTime tmpDate, WeeklySchedule sched, DateTime startDate, DateTime finishDate)
        {
            bool addDay = false;
            if (tmpDate <= finishDate)
            {
                switch (tmpDate.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        {
                            if (sched.OnMondays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            if (sched.OnTuesdays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            if (sched.OnWednesdays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            if (sched.OnThursdays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            if (sched.OnFridays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            if (sched.OnSaturdays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            if (sched.OnSundays)
                            {
                                addDay = true;
                            }
                            break;
                        }
                }
            }
            return addDay;
        }

        private static List<DateTime> getDailyInstanceDates(DailySchedule sched, DateTime startDate, DateTime finishDate)
        {
            List<DateTime> dates = new List<DateTime>();
            if (startDate <= finishDate)
            {
                DateTime tmpDate = startDate;
                while (tmpDate <= finishDate)
                {
                    if (tmpDate >= startDate)
                    {
                        bool addDay = false;
                       
                        if (!sched.WeekDaysOnly)
                        {
                            addDay = true;
                        }
                        else
                        {
                            switch (tmpDate.DayOfWeek)
                            {
                                case DayOfWeek.Monday:
                                case DayOfWeek.Tuesday:
                                case DayOfWeek.Wednesday:
                                case DayOfWeek.Thursday:
                                case DayOfWeek.Friday:
                                    {
                                        addDay = true;
                                        break;
                                    }
                                default:
                                    {
                                        addDay = false;
                                        break;
                                    }

                            }
                        }
                        if (addDay)
                        {
                            dates.Add(tmpDate);
                        }
                    }
                    tmpDate = tmpDate.AddDays(sched.RecurEveryNoOfDays);
                }
            }
            return dates;
        }

        #endregion

    }
}
