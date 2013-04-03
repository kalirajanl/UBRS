using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBRS.Common;
using UBRS.Models;

namespace UBRS.DAL
{
    public class DALBillInstance
    {
        private static string baseQueryText = "SELECT BillInstanceID, a.BillID, InstanceDate,InstanceCompleted,BillAmount,BillerName,BillTitle From BillInstance a INNER JOIN Bill b ON a.BillID = b.BillID INNER JOIN Biller c ON b.BillerID = c.BillerID ";

        public static List<BillInstanceItem> GetBillInstancesByID(long billID)
        {
            List<BillInstanceItem> instances = new List<BillInstanceItem>();
            string queryText = baseQueryText + "WHERE BillInstanceID = '" + billID.ToString() + "' ";
            queryText += "ORDER BY InstanceDate, BillTitle";
            DataTable dt = SQLWrapper.GetDataTable(queryText);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillInstanceItem instance = loadBillInstance(dt, i);
                if (instance != null)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }

        public static bool MarkAsCompleted(long billInstanceID)
        {
            bool returnValue = false;
            IBaseQueryData query = new UpdateQueryData();
            query.TableName = "BillInstance";
            query.KeyFields.Add(new FieldData { FieldName = "BillInstanceID", FieldValue = billInstanceID.ToString(), FieldType = SqlDbType.BigInt });
            query.Fields.Add(new FieldData { FieldName = "InstanceCompleted", FieldValue = "1", FieldType = SqlDbType.Bit });
            returnValue = SQLWrapper.ExecuteQuery(query);
            return returnValue;
        }

        public static bool MarkAsNotCompleted(long billInstanceID)
        {
            bool returnValue = false;
            IBaseQueryData query = new UpdateQueryData();
            query.TableName = "BillInstance";
            query.KeyFields.Add(new FieldData { FieldName = "BillInstanceID", FieldValue = billInstanceID.ToString(), FieldType = SqlDbType.BigInt });
            query.Fields.Add(new FieldData { FieldName = "InstanceCompleted", FieldValue = "0", FieldType = SqlDbType.Bit });
            returnValue = SQLWrapper.ExecuteQuery(query);
            return returnValue;
        }

        public static List<BillInstanceItem> GetBillsByDate(DateTime asofdate)
        {
            List<BillInstanceItem> instances = new List<BillInstanceItem>();
            string queryText = baseQueryText + "WHERE InstanceDate = '" + asofdate.ToString(Constants.DATE_FORMAT_SQL) + "' ";
            queryText += "ORDER BY InstanceDate, BillTitle";
            DataTable dt = SQLWrapper.GetDataTable(queryText);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillInstanceItem instance = loadBillInstance(dt, i);
                if (instance != null)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }

        public static List<BillInstanceItem> GetDueBills(DateTime asofdate)
        {
            List<BillInstanceItem> instances = new List<BillInstanceItem>();
            string queryText = baseQueryText + "WHERE InstanceCompleted = 0 AND InstanceDate = '" + asofdate.ToString(Constants.DATE_FORMAT_SQL) + "' ";
            queryText += "ORDER BY InstanceDate, BillTitle";
            DataTable dt = SQLWrapper.GetDataTable(queryText);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillInstanceItem instance = loadBillInstance(dt, i);
                if (instance != null)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }

        public static List<BillInstanceItem> GetOverDueBills(DateTime asofdate)
        {
            List<BillInstanceItem> instances = new List<BillInstanceItem>();
            string queryText = baseQueryText + "WHERE InstanceCompleted = 0 AND InstanceDate <= '" + asofdate.ToString(Constants.DATE_FORMAT_SQL) + "' ";
            queryText += "ORDER BY InstanceDate, BillTitle";
            DataTable dt = SQLWrapper.GetDataTable(queryText);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillInstanceItem instance = loadBillInstance(dt, i);
                if (instance != null)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }

        public static List<BillInstanceItem> GetUpcomingBills(DateTime asofdate)
        {
            List<BillInstanceItem> instances = new List<BillInstanceItem>();
            string queryText = baseQueryText + "WHERE InstanceCompleted = 0 AND InstanceDate >= '" + asofdate.ToString(Constants.DATE_FORMAT_SQL) + "' ";
            queryText += "ORDER BY InstanceDate, BillTitle";
            DataTable dt = SQLWrapper.GetDataTable(queryText);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillInstanceItem instance = loadBillInstance(dt, i);
                if (instance != null)
                {
                    instances.Add(instance);
                }
            }
            return instances;
        }
     
        public static IBaseQueryData GetDeleteBillInstancesByIDQuery(long billID)
        {
            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "BillInstance";
            query.KeyFields.Add(new FieldData { FieldName = "BillID", FieldValue = billID.ToString(), FieldType = SqlDbType.BigInt });
            return query;
        }

        public static bool UpsertBillInstances(long billID)
        {
            bool returnValue = false;
            List<BillInstanceItem> itms = GetBillInstancesByID(billID);
            List<IBaseQueryData> queryData = GetUpsertBillInstanceQueryData(billID, itms);
            returnValue = SQLWrapper.ExecuteQuery(queryData);
            return returnValue;
        }

        public static List<IBaseQueryData> GetUpsertBillInstanceQueryData(long billID, List<BillInstanceItem> itms)
        {
            long billInstanceID = getNextBillInstanceID();
            List<BillInstanceItem> oldInstances = GetBillInstancesByID(billID);
            List<IBaseQueryData> queryData = new List<IBaseQueryData>();

            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "BillInstance";
            query.KeyFields.Add(new FieldData { FieldName = "BillID", FieldValue = billID.ToString(), FieldType = SqlDbType.BigInt });

            queryData.Add(query);

            for (int i = 0; i <= itms.Count - 1; i++)
            {
                query = new InsertQueryData();
                query.TableName = "BillInstance";
                query.Fields.Add(new FieldData { FieldName = "BillInstanceID", FieldValue = billInstanceID.ToString(), FieldType = SqlDbType.BigInt });
                query.Fields.Add(new FieldData { FieldName = "BillID", FieldValue = billID.ToString(), FieldType = SqlDbType.BigInt });
                query.Fields.Add(new FieldData { FieldName = "InstanceDate", FieldValue = itms[i].InstanceDate.ToString(Constants.DATE_FORMAT_SQL), FieldType = SqlDbType.Date });
                bool isCompleted = false;
                if (itms != null)
                {
                    if (itms[i] != null)
                    {
                        isCompleted = itms[i].IsCompleted;
                    }
                }
                BillInstanceItem tmpItem = oldInstances.FindAll(x => x.BillID == billID && x.InstanceDate == itms[i].InstanceDate).FirstOrDefault();
                if (tmpItem != null)
                {
                    isCompleted = tmpItem.IsCompleted;
                }
                query.Fields.Add(new FieldData { FieldName = "InstanceCompleted", FieldValue = isCompleted.ToString(), FieldType = SqlDbType.Bit });
                queryData.Add(query);
                billInstanceID++;
            }
            return queryData;
        }

        #region Private Methods

        private static BillInstanceItem loadBillInstance(DataTable dt, int rowNo)
        {
            BillInstanceItem billinstance = null;
            if (dt != null)
            {
                if (dt.Rows.Count > rowNo)
                {
                    billinstance = new BillInstanceItem();
                    billinstance.ID = (Int64)dt.Rows[rowNo]["BillInstanceID"];
                    billinstance.BillID = (Int64)dt.Rows[rowNo]["BillID"];
                    billinstance.BillerName = dt.Rows[rowNo]["BillerName"].ToString();
                    billinstance.BillTitle = dt.Rows[rowNo]["BillTitle"].ToString();
                    billinstance.InstanceDate = Convert.ToDateTime(dt.Rows[rowNo]["InstanceDate"]);
                    billinstance.IsCompleted = Convert.ToBoolean(dt.Rows[rowNo]["InstanceCompleted"]);
                    billinstance.Amount = (decimal)dt.Rows[rowNo]["BillAmount"];
                }
            }
            return billinstance;
        }

        private static long getNextBillInstanceID()
        {
            long billInstanceID = 1;
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "BillInstance", FieldNames = "Max(BillInstanceID)" });
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                    {
                        billInstanceID = Convert.ToInt64(dt.Rows[0][0]) + 1;
                    }
                }
            }
            return billInstanceID;
        }



        #endregion
    }
}
