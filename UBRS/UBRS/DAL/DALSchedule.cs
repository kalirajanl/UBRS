using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBRS.Models;
using UBRS.Common;

namespace UBRS.DAL
{
    public class DALSchedule
    {

        public static ISchedule GetScheduleByID(long scheduleID)
        {
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName="Schedules", FilterCondition = "ScheduleID = " + scheduleID.ToString()});
            return loadSchedule(dt, 0);
        }

        public static long AddSchedule(ISchedule itm)
        {
            long itmID = getNextScheduleID();
            IBaseQueryData query = new InsertQueryData();
            query.TableName = "Schedules";
            query.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = itmID.ToString(), FieldType = SqlDbType.BigInt });

            if (itm.GetType() == typeof(YearlySchedule))
            {
                YearlySchedule ySched = (YearlySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "4", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = ySched.StartDate.ToString(Constants.DATE_FORMAT_SQL) , FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = ySched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = ySched.RecurEveryNoOfYears.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnDay", FieldValue = ySched.OnDay.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnMonth", FieldValue = ySched.OnMonth.ToString(), FieldType = SqlDbType.Int });
            }
            else if (itm.GetType() == typeof(MonthlySchedule))
            {
                MonthlySchedule mSched = (MonthlySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "3", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = mSched.RecurEveryNoOfMonths.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = mSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = mSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "OnDay", FieldValue = mSched.OnDay.ToString(), FieldType = SqlDbType.Int });
            }
                else if (itm.GetType() == typeof(WeeklySchedule))
            {
                WeeklySchedule wSched = (WeeklySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "2", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = wSched.RecurEveryNoOfWeeks.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = wSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = wSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "OnMondays", FieldValue = wSched.OnMondays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnTuesdays", FieldValue = wSched.OnTuesdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnWednesdays", FieldValue = wSched.OnWednesdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnThursdays", FieldValue = wSched.OnThursdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnFridays", FieldValue = wSched.OnFridays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnSaturdays", FieldValue = wSched.OnSaturdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnSundays", FieldValue = wSched.OnSundays.ToString(), FieldType = SqlDbType.Int });
            }
            else
            {
                DailySchedule dSched = (DailySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "1", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = dSched.RecurEveryNoOfDays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = dSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = dSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "WeekDaysOnly", FieldValue = dSched.WeekDaysOnly.ToString(), FieldType = SqlDbType.Bit });
            }
            if (!SQLWrapper.ExecuteQuery(query))
            {
                itmID = 0;
            }
            return itmID;
        }

        public static bool UpdateSchedule(ISchedule itm)
        {
            bool returnValue = false;
            IBaseQueryData query = new UpdateQueryData();
            query.TableName = "Schedules";
            query.KeyFields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = itm.ScheduleID.ToString(), FieldType = SqlDbType.BigInt });

            if (itm.GetType() == typeof(YearlySchedule))
            {
                YearlySchedule ySched = (YearlySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "4", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = ySched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = ySched.RecurEveryNoOfYears.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = ySched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "OnDay", FieldValue = ySched.OnDay.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnMonth", FieldValue = ySched.OnMonth.ToString(), FieldType = SqlDbType.Int });
            }
            else if (itm.GetType() == typeof(MonthlySchedule))
            {
                MonthlySchedule mSched = (MonthlySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "3", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = mSched.RecurEveryNoOfMonths.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = mSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = mSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "OnDay", FieldValue = mSched.OnDay.ToString(), FieldType = SqlDbType.Int });
            }
            else if (itm.GetType() == typeof(WeeklySchedule))
            {
                WeeklySchedule wSched = (WeeklySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "2", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = wSched.RecurEveryNoOfWeeks.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = wSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = wSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "OnMondays", FieldValue = wSched.OnMondays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnTuesdays", FieldValue = wSched.OnTuesdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnWednesdays", FieldValue = wSched.OnWednesdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnThursdays", FieldValue = wSched.OnThursdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnFridays", FieldValue = wSched.OnFridays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnSaturdays", FieldValue = wSched.OnSaturdays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "OnSundays", FieldValue = wSched.OnSundays.ToString(), FieldType = SqlDbType.Int });
            }
            else
            {
                DailySchedule dSched = (DailySchedule)itm;
                query.Fields.Add(new FieldData { FieldName = "RecurType", FieldValue = "1", FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "RecurUnits", FieldValue = dSched.RecurEveryNoOfDays.ToString(), FieldType = SqlDbType.Int });
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = dSched.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "EndDate", FieldValue = dSched.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "WeekDaysOnly", FieldValue = dSched.WeekDaysOnly.ToString(), FieldType = SqlDbType.Bit });
            }
            returnValue = SQLWrapper.ExecuteQuery(query);
            return returnValue;
        }

        public static bool DeleteScheduleByID(long scheduleID)
        {
            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "Schedules";
            query.KeyFields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = scheduleID.ToString(), FieldType = SqlDbType.BigInt });
            return SQLWrapper.ExecuteQuery(query);
        }

        public static IBaseQueryData GetDeleteScheduleByIDQuery(long scheduleID)
        {
            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "Schedules";
            query.KeyFields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = scheduleID.ToString(), FieldType = SqlDbType.BigInt });
            return query;
        }

        #region Private Methods

        private static ISchedule loadSchedule(DataTable dt, int rowNo)
        {
            ISchedule sched = null;
            if (dt != null)
            {
                if (dt.Rows.Count > rowNo)
                {
                    int RecurType = Convert.ToInt32(dt.Rows[rowNo]["RecurType"]);
                    switch (RecurType)
                    {
                        case 4:
                            {
                                YearlySchedule ySched = new YearlySchedule();
                                ySched.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                                ySched.EndDate = Convert.ToDateTime(dt.Rows[rowNo]["EndDate"]);
                                ySched.RecurrencePatternMode = Common.SchedRecurPatternModes.Simple;
                                ySched.EndDateSpecifiedAs = Common.SchedRangeEndTypes.ByEndDate;
                                ySched.OnDay = Convert.ToInt32(dt.Rows[rowNo]["OnDay"]);
                                ySched.OnMonth = Convert.ToInt32(dt.Rows[rowNo]["OnMonth"]);
                                ySched.RecurrencePattern = Common.SchedRecurPatterns.Yearly;
                                ySched.RecurEveryNoOfYears = Convert.ToInt32(dt.Rows[rowNo]["RecurUnits"]);
                                sched = ySched;
                                break;
                            }
                        case 3:
                            {
                                MonthlySchedule mSched = new MonthlySchedule();
                                mSched.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                                mSched.EndDate = Convert.ToDateTime(dt.Rows[rowNo]["EndDate"]);
                                mSched.RecurrencePatternMode = Common.SchedRecurPatternModes.Simple;
                                mSched.EndDateSpecifiedAs = Common.SchedRangeEndTypes.ByEndDate;
                                mSched.OnDay = Convert.ToInt32(dt.Rows[rowNo]["OnDay"]);
                                mSched.RecurrencePattern = Common.SchedRecurPatterns.Monthly;
                                mSched.RecurEveryNoOfMonths = Convert.ToInt32(dt.Rows[rowNo]["RecurUnits"]);
                                sched = mSched;
                                break;
                            }
                        case 2:
                            {
                                WeeklySchedule wSched = new WeeklySchedule();
                                wSched.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                                wSched.EndDate = Convert.ToDateTime(dt.Rows[rowNo]["EndDate"]);
                                wSched.RecurrencePatternMode = Common.SchedRecurPatternModes.Simple;
                                wSched.EndDateSpecifiedAs = Common.SchedRangeEndTypes.ByEndDate;
                                wSched.OnMondays = Convert.ToBoolean(dt.Rows[rowNo]["OnMondays"]);
                                wSched.OnTuesdays = Convert.ToBoolean(dt.Rows[rowNo]["OnTuesdays"]);
                                wSched.OnWednesdays = Convert.ToBoolean(dt.Rows[rowNo]["OnWednesdays"]);
                                wSched.OnThursdays = Convert.ToBoolean(dt.Rows[rowNo]["OnThursdays"]);
                                wSched.OnFridays = Convert.ToBoolean(dt.Rows[rowNo]["OnFridays"]);
                                wSched.OnSaturdays = Convert.ToBoolean(dt.Rows[rowNo]["OnSaturdays"]);
                                wSched.OnSundays = Convert.ToBoolean(dt.Rows[rowNo]["OnSundays"]);
                                wSched.RecurrencePattern = Common.SchedRecurPatterns.Weekly;
                                wSched.RecurEveryNoOfWeeks = Convert.ToInt32(dt.Rows[rowNo]["RecurUnits"]);
                                sched = wSched;
                                break;
                            }
                        default:
                            {
                                DailySchedule dSched = new DailySchedule();
                                dSched.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                                dSched.EndDate = Convert.ToDateTime(dt.Rows[rowNo]["EndDate"]);
                                dSched.RecurrencePatternMode = Common.SchedRecurPatternModes.Simple;
                                dSched.EndDateSpecifiedAs = Common.SchedRangeEndTypes.ByEndDate;
                                dSched.RecurrencePattern = Common.SchedRecurPatterns.Daily;
                                dSched.RecurEveryNoOfDays = Convert.ToInt32(dt.Rows[rowNo]["RecurUnits"]);
                                dSched.WeekDaysOnly = Convert.ToBoolean(dt.Rows[rowNo]["WeekDaysOnly"]);
                                sched = dSched;
                                break;
                            }
                    }
                }
            }
            return sched;
        }

        private static long getNextScheduleID()
        {
            long scheduleID = 1;
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Schedules", FieldNames = "Max(ScheduleID)" });
            if (dt == null)
            {
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                    {
                        scheduleID = Convert.ToInt64(dt.Rows[0][0]) + 1;
                    }
                }
            }
            return scheduleID;
        }

        #endregion

    }
}
