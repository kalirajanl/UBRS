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
    public class DALBiller
    {
        public static List<BillerItem> GetBillers()
        {
            List<BillerItem> billers = new List<BillerItem>();
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Biller" }, 0);
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                BillerItem biller = loadBiller(dt, i);
                if (biller != null)
                {
                    billers.Add(biller);
                }
            }
            return billers;
        }

        public static BillerItem GetBillerByID(int billerID)
        {
            List<BillerItem> billers = GetBillers();
            return billers.FirstOrDefault(x => x.ID == billerID);
        }

        public static int AddBiller(BillerItem itm)
        {
            bool returnValue = false;
            int billerID = 0;
            if (itm != null)
            {
                billerID = getNextBillerID();
                IBaseQueryData query = new InsertQueryData();
                query.TableName = "Biller";
                query.Fields.Add(new FieldData { FieldName = "BillerID", FieldValue = billerID.ToString(), FieldType = SqlDbType.BigInt });
                query.Fields.Add(new FieldData { FieldName = "BillerName", FieldValue = itm.Name, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "AddressLine1", FieldValue = itm.AddressLine1, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "AddressLine2", FieldValue = itm.AddressLine2, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "City", FieldValue = itm.City, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Zip", FieldValue = itm.Zip, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "State", FieldValue = itm.State, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Country", FieldValue = itm.Country, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Notes", FieldValue = itm.Notes, FieldType = SqlDbType.VarChar });

                returnValue = SQLWrapper.ExecuteQuery(query);
            }
            if (returnValue)
            {
                return billerID;
            }
            else
            {
                return 0;
            }
        }

        public static bool UpdateBiller(BillerItem itm)
        {
            bool returnValue = false;
            if (itm != null)
            {
                IBaseQueryData query = new UpdateQueryData();
                query.TableName = "Biller";
                query.KeyFields.Add(new FieldData { FieldName = "BillerID", FieldValue = itm.ID.ToString(), FieldType = SqlDbType.BigInt });
                query.Fields.Add(new FieldData { FieldName = "BillerName", FieldValue = itm.Name, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "AddressLine1", FieldValue = itm.AddressLine1, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "AddressLine2", FieldValue = itm.AddressLine2, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "City", FieldValue = itm.City, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Zip", FieldValue = itm.Zip, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "State", FieldValue = itm.State, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Country", FieldValue = itm.Country, FieldType = SqlDbType.VarChar });
                query.Fields.Add(new FieldData { FieldName = "Notes", FieldValue = itm.Notes, FieldType = SqlDbType.VarChar });

                returnValue = SQLWrapper.ExecuteQuery(query);

            }
            return returnValue;
        }

        public static bool DeleteBiller(int billerID)
        {
            bool returnValue = true;

            List<IBaseQueryData> queryData = DALBill.GetDeleteBillQuerysByBiller(billerID);

            IBaseQueryData query = new DeleteQueryData();
            query.TableName = "Biller";
            query.KeyFields.Add(new FieldData { FieldName = "BillerID", FieldValue = billerID.ToString(), FieldType = SqlDbType.BigInt });
            queryData.Add(query);
            
            returnValue = SQLWrapper.ExecuteQuery(queryData);

            return returnValue;
        }


        #region Private Methods

        private static BillerItem loadBiller(DataTable dt, int rowNo)
        {
            BillerItem biller = null;
            if (dt != null)
            {
                if (dt.Rows.Count > rowNo)
                {
                    biller = new BillerItem();
                    biller.ID = (Int32)dt.Rows[rowNo]["BillerID"];
                    biller.Name = dt.Rows[rowNo]["BillerName"].ToString();
                    biller.AddressLine1 = dt.Rows[rowNo]["AddressLine1"].ToString();
                    biller.AddressLine2 = dt.Rows[rowNo]["AddressLine2"].ToString();
                    biller.City = dt.Rows[rowNo]["City"].ToString();
                    biller.Zip = dt.Rows[rowNo]["Zip"].ToString();
                    biller.State = dt.Rows[rowNo]["State"].ToString();
                    biller.Country = dt.Rows[rowNo]["Country"].ToString();
                    biller.Notes = dt.Rows[rowNo]["Notes"].ToString();
                }
            }
            return biller;
        }

        private static int getNextBillerID()
        {
            int billerID = 1;
            DataTable dt = SQLWrapper.GetDataTable(new SelectQueryData { TableName = "Biller", FieldNames = "Max(BillerID)" });
            if (dt != null)
            {
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0][0] != DBNull.Value)
                    {
                        billerID = Convert.ToInt32(dt.Rows[0][0]) + 1;
                    }
                }
            }
            return billerID;
        }

        #endregion
    }
}
