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
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        bool ReminderOn { get; set; }
        SchedReminderTypes RemindBeforeStartType { get; set; }
        SchedRangeEndTypes EndDateSpecifiedAs { get; set; }
        SchedRecurPatterns RecurrencePattern { get; set; }
        SchedRecurPatternModes RecurrencePatternMode { get; set; }
    }

    [Serializable]
    public abstract class Schedule : ISchedule
    {
        public Schedule()
        {
            RecurrencePatternMode = SchedRecurPatternModes.Simple;
        }

        protected int RemindBeforeMinutes { get; set; }

        public bool ReminderOn { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public SchedRangeEndTypes EndDateSpecifiedAs { get; set; }
        public SchedRecurPatterns RecurrencePattern { get; set; }
        public SchedRecurPatternModes RecurrencePatternMode { get; set; }

        public SchedReminderTypes RemindBeforeStartType
        {
            get
            {
                return RemindBeforeStartType;
            }
            set
            {
                RemindBeforeStartType = value;
                switch (value)
                {
                    case SchedReminderTypes.ZeroMinutes:
                        {
                            RemindBeforeMinutes = 0;
                            break;
                        }
                    case SchedReminderTypes.FiveMinutes:
                        {
                            RemindBeforeMinutes = 5;
                            break;
                        }
                    case SchedReminderTypes.TenMinutes:
                        {
                            RemindBeforeMinutes = 10;
                            break;
                        }
                    case SchedReminderTypes.FifteenMinutes:
                        {
                            RemindBeforeMinutes = 15;
                            break;
                        }
                    case SchedReminderTypes.ThirtyMinutes:
                        {
                            RemindBeforeMinutes = 30;
                            break;
                        }
                    case SchedReminderTypes.OneHour:
                        {
                            RemindBeforeMinutes = 60;
                            break;
                        }
                    case SchedReminderTypes.TwoHours:
                        {
                            RemindBeforeMinutes = 120;
                            break;
                        }
                    case SchedReminderTypes.ThreeHours:
                        {
                            RemindBeforeMinutes = 180;
                            break;
                        }
                }

            }

        }
    }

    [Serializable]
    public class DailySchedule : Schedule
    {
        public DailySchedule()
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
        {
            RecurrencePattern = SchedRecurPatterns.Weekly;
            RecurEveryNoOfWeeks = 1;
        }

        public int RecurEveryNoOfWeeks { get; set; }
        public bool onMondays { get; set; }
        public bool onTuesdays { get; set; }
        public bool onWednesdays { get; set; }
        public bool onThursdays { get; set; }
        public bool onFridays { get; set; }
        public bool onSaturdays { get; set; }
        public bool onSundays { get; set; }
    }

    [Serializable]
    public class MonthlySchedule : Schedule
    {
        public MonthlySchedule()
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
        {
            RecurrencePattern = SchedRecurPatterns.Yearly;
        }

        public int onMonth { get; set; }
        public int OnDay { get; set; }
        //public SchedCounters Counter { get; set; }
        //public SchedDayTypes DayType { get; set; }
    }

}
