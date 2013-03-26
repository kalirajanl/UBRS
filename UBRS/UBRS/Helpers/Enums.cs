using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace UBRS.Common
{

    #region UI Related Enums

    public enum PageMode
    {
        Add,
        Edit,
        View
    };

    #endregion
    
    #region Scheduler Related Enums

    public enum SchedRangeEndTypes
    {
        NoEndDate = 1,
        NoOfTimes = 2,
        ByEndDate = 3
    };

    public enum SchedRecurPatterns
    {
        Daily = 1,
        Weekly = 2,
        Monthly = 3,
        Yearly = 4
    };

    public enum SchedRecurPatternModes
    {
        Simple = 1,
        Advanced = 2
    };

    public enum SchedCounters
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4,
        Last = 5
    }

    public enum SchedDayTypes
    {
        AnyDay = 0,
        CalendarDay = 1,
        WeekDay = 2,
        WeekEndDay = 3,
        Monday = 4,
        Tuesday = 5,
        Wednesday = 6,
        Thursday = 7,
        Friday = 8,
        Saturday = 9,
        Sunday = 10
    }

    public enum SchedReminderTypes
    {
        ZeroMinutes = 1,
        FiveMinutes = 2,
        TenMinutes = 3,
        FifteenMinutes = 4,
        ThirtyMinutes = 5,
        OneHour = 6,
        TwoHours = 7,
        ThreeHours = 8
    }

    #endregion

    #region DataHelper Related Enums

    public enum DataSourceMode
    {
        UnKnown = 0,
        MSSQLServerCE = 1,
        Oracle = 2
    }

    #endregion
}
