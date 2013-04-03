using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBRS.Models;
using UBRS.Common;

namespace UBRS.DAL
{
    public class DALBill
    {
        public static List<BillItem> GetBills()
        {
            List<BillItem> bills = new List<BillItem>();
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Bill"}, 0);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillItem bill = loadBill(dt, i);
                if (bill != null)
                {
                    bills.Add(bill);
                }
            }
            return bills;
        }

        public static List<BillItem> GetBillsByBiller(int billerID)
        {
            List<BillItem> bills = new List<BillItem>();
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Bill", FilterCondition = "BillerID = " + billerID.ToString() }, 0);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillItem bill = loadBill(dt, i);
                if (bill != null)
                {
                    bills.Add(bill);
                }
            }
            return bills;
        }

        public static BillItem GetBillByID(long billID)
        {
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Bill", FilterCondition = "BillID = " + billID.ToString()}, 0);
            return loadBill(dt, 0);
        }

        public static long AddBill(BillItem itm)
        {
            bool returnValue = false;
            long billID = 0;
            if (itm != null)
            {
                billID = getNextBillID();
                long scheduleID = 0;
                List<DateTime> schedules = null;
                if (itm.BillSchedule != null)
                {
                    scheduleID = DALSchedule.AddSchedule(itm.BillSchedule);
                    schedules = ScheduleHelper.GetInstanceDates(itm.BillSchedule, itm.StartDate, itm.EndDate);
                }
                else
                {
                    schedules = new List<DateTime>();
                    schedules.Add(itm.StartDate);
                }

                IBaseQueryData query = new InsertQueryData();
                query.TableName = "Bill";
                query.Fields.Add(new FieldData { FieldName = "BillID", FieldValue = billID.ToString(), FieldType = SqlDbType.BigInt });
                if (itm.Biller != null)
                {
                    query.Fields.Add(new FieldData { FieldName = "BillerID", FieldValue = itm.Biller.ID.ToString(), FieldType = SqlDbType.Int });
                }
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = itm.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "FinishDate", FieldValue = itm.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "BillAmount", FieldValue = itm.Amount.ToString(Constants.CURRENCY_FORMAT_SQL), FieldType = SqlDbType.Money });
                query.Fields.Add(new FieldData { FieldName = "Notes", FieldValue = itm.Notes, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "BillTitle", FieldValue = itm.BillTitle, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = scheduleID.ToString(), FieldType = SqlDbType.BigInt });

                List<BillInstanceItem> itms = new List<BillInstanceItem>();
                for (int j = 0; j <= schedules.Count - 1; j++)
                {
                    itms.Add(new BillInstanceItem { BillID = billID, InstanceDate = schedules[j] });
                }

                List<IBaseQueryData> queryData = DALBillInstance.GetUpsertBillInstanceQueryData(billID, itms);
                queryData.Insert(0, query);

                returnValue = SQLWrapper.ExecuteQuery(queryData);

            }
            if (returnValue)
            {
                return billID;
            }
            else
            {
                return 0;
            }
        }

        public static bool UpdateBill(BillItem itm)
        {
            bool returnValue = false;
            if (itm != null)
            {
                long scheduleID = 0;
                if (itm.BillSchedule == null)
                {
                    scheduleID = 0;
                    BillItem olditm = GetBillByID(itm.ID);
                    if (olditm != null)
                    {
                        if (olditm.BillSchedule != null)
                        {
                            DALSchedule.DeleteScheduleByID(olditm.BillSchedule.ScheduleID);
                        }
                    }
                }
                else
                {
                    scheduleID = itm.BillSchedule.ScheduleID;
                    if (scheduleID == 0)
                    {
                        BillItem olditm = GetBillByID(itm.ID);
                        if (olditm != null)
                        {
                            if (olditm.BillSchedule != null)
                            {
                                DALSchedule.DeleteScheduleByID(olditm.BillSchedule.ScheduleID);
                            }
                        }
                        scheduleID = DALSchedule.AddSchedule(itm.BillSchedule);
                        returnValue = (scheduleID > 0);
                    }
                    else
                    {
                        returnValue = DALSchedule.UpdateSchedule(itm.BillSchedule);
                    }
                }

                List<DateTime> schedules = null;
                if (itm.BillSchedule != null)
                {
                    schedules = ScheduleHelper.GetInstanceDates(itm.BillSchedule, itm.StartDate, itm.EndDate);
                }
                else
                {
                    schedules = new List<DateTime>();
                    schedules.Add(itm.StartDate);
                }
                IBaseQueryData query = new UpdateQueryData();
                query.TableName = "Bill";
                query.KeyFields.Add(new FieldData { FieldName = "BillID", FieldValue = itm.ID.ToString(), FieldType = SqlDbType.BigInt });
                if (itm.Biller != null)
                {
                    query.Fields.Add(new FieldData { FieldName = "BillerID", FieldValue = itm.Biller.ID.ToString(), FieldType = SqlDbType.Int });
                }
                query.Fields.Add(new FieldData { FieldName = "StartDate", FieldValue = itm.StartDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "FinishDate", FieldValue = itm.EndDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.DateTime });
                query.Fields.Add(new FieldData { FieldName = "BillAmount", FieldValue = itm.Amount.ToString(Constants.CURRENCY_FORMAT_SQL), FieldType = SqlDbType.Money });
                query.Fields.Add(new FieldData { FieldName = "Notes", FieldValue = itm.Notes, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "BillTitle", FieldValue = itm.BillTitle, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "ScheduleID", FieldValue = scheduleID.ToString(), FieldType = SqlDbType.BigInt });

                List<BillInstanceItem> itms = new List<BillInstanceItem>();
                for (int j = 0; j <= schedules.Count - 1; j++)
                {
                    itms.Add(new BillInstanceItem { BillID = itm.ID , InstanceDate = schedules[j] });
                }

                List<IBaseQueryData> queryData = DALBillInstance.GetUpsertBillInstanceQueryData(itm.ID, itms);
                queryData.Insert(0, query);

                returnValue = SQLWrapper.ExecuteQuery(queryData);

            }
            return returnValue;
        }

        public static bool DeleteBill(long billID)
        {
            bool returnValue = true;
            List<IBaseQueryData> queryData = GetDeleteBillQuerysByBillID(billID);
            returnValue = SQLWrapper.ExecuteQuery(queryData);
            return returnValue;
        }

        public static List<IBaseQueryData> GetDeleteBillQuerysByBillID(long billID)
        {
            List<IBaseQueryData> queryData = new List<IBaseQueryData>();
            BillItem olditm = GetBillByID(billID);
            if (olditm != null)
            {
                if (olditm.BillSchedule != null)
                {
                    queryData.Add(DALSchedule.GetDeleteScheduleByIDQuery(olditm.BillSchedule.ScheduleID));
                }
            }
            queryData.Add(DALBillInstance.GetDeleteBillInstancesByIDQuery(billID));
            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "Bill";
            query.KeyFields.Add(new FieldData { FieldName = "BillID", FieldValue = billID.ToString(), FieldType = SqlDbType.BigInt });
            queryData.Add(query);
            return queryData;
        }

        public static bool DeleteBillByBiller(int billerID)
        {
            bool returnValue = true;
            List<IBaseQueryData> queryData = GetDeleteBillQuerysByBiller(billerID);
            returnValue = SQLWrapper.ExecuteQuery(queryData);
            return returnValue;
        }

        public static List<IBaseQueryData> GetDeleteBillQuerysByBiller(int billerID)
        {
            List<IBaseQueryData> queryData = new List<IBaseQueryData>();
            List<BillItem> oldbills = GetBillsByBiller(billerID);
            for (int i = 0; i <= oldbills.Count - 1; i++)
            {
                List<IBaseQueryData> tmpquey = GetDeleteBillQuerysByBillID(oldbills[i].ID);
                for (int k = 0; k <= tmpquey.Count - 1; k++)
                {
                    queryData.Add(tmpquey[k]);
                }
            }
            return queryData;
        }

        #region Private Methods

        private static BillItem loadBill(DataTable dt, int rowNo)
        {
            BillItem bill = null;
            if (dt != null)
            {
                if (dt.Rows.Count > rowNo)
                {
                    bill = new BillItem();
                    bill.ID = (long)dt.Rows[rowNo]["BillID"];
                    bill.StartDate = Convert.ToDateTime(dt.Rows[rowNo]["StartDate"]);
                    bill.EndDate = Convert.ToDateTime(dt.Rows[rowNo]["FinishDate"]);
                    bill.Amount = Convert.ToDecimal(dt.Rows[rowNo]["BillAmount"]);
                    bill.BillTitle = dt.Rows[rowNo]["BillTitle"].ToString().Trim();
                    bill.Notes = dt.Rows[rowNo]["Notes"].ToString();
                    bill.Biller = DALBiller.GetBillerByID(Convert.ToInt32(dt.Rows[rowNo]["BillerID"]));
                    if (dt.Rows[rowNo]["ScheduleID"] != DBNull.Value)
                    {
                        bill.BillSchedule = DALSchedule.GetScheduleByID(Convert.ToInt64(dt.Rows[rowNo]["ScheduleID"]));
                    }
                }
            }
            return bill;
        }

        private static long getNextBillID()
        {
            long billID = 1;
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Bill", FieldNames = "Max(BillID)" });
            if (dt!= null)
            {
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                    {
                        billID = Convert.ToInt64(dt.Rows[0][0]) + 1;
                    }
                }
            }
            return billID;
        }

       

        #endregion
    }

}
