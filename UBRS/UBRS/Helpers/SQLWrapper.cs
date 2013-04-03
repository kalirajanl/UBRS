using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using UBRS.Common;
using UBRS.Models;

namespace UBRS.DAL
{

    #region Data Classes for SQLWrapper

    public class SelectQueryData
    {
        public SelectQueryData()
        {
            FieldNames = "*";
            FilterCondition = "";
            OrderBy = "";
            GroupBy = "";
        }

        public string TableName { get; set; }
        public string FieldNames { get; set; }
        public string FilterCondition { get; set; }
        public string OrderBy { get; set; }
        public string GroupBy { get; set; }

        public string GetSQL()
        {
            string cmdText = "";
            cmdText = "Select " + FieldNames + " From [" + TableName + "]";
            if (!FilterCondition.Trim().Equals(""))
            {
                cmdText += " Where " + FilterCondition;
            }
            if (!GroupBy.Trim().Equals(""))
            {
                cmdText += " Group By " + GroupBy;
            }
            if (!OrderBy.Trim().Equals(""))
            {
                cmdText += " Order By " + OrderBy;
            }
            return cmdText;
        }
    }

    public class FieldData
    {
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public SqlDbType FieldType { get; set; }
    }

    public interface IBaseQueryData
    {
        string TableName{ get; set; }
        List<FieldData> Fields{ get; set; }
        List<FieldData> KeyFields{ get; set; }
        string GetSQL();
    }

    public class InsertQueryData : IBaseQueryData
    {

        public string TableName { get; set; }
        public List<FieldData> Fields { get; set; }
        public List<FieldData> KeyFields { get; set; }
        
        public InsertQueryData()
        {
            TableName = "";
            Fields = new List<FieldData>();
            KeyFields = null;
        }

        public string GetSQL()
        {
            string cmdText = "";
            if ((!TableName.Trim().Equals("")) && (Fields.Count > 0))
            {
                cmdText = "INSERT " + TableName + "(";

                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "[" + Fields[i].FieldName + "]";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += ") Values (";
                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "'" + Fields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += ")";
            }
            return cmdText;
        }
    }

    public class UpdateQueryData : IBaseQueryData
    {
        public string TableName { get; set; }
        public List<FieldData> Fields { get; set; }
        public List<FieldData> KeyFields { get; set; }

        public UpdateQueryData()
        {
            TableName = "";
            Fields = new List<FieldData>();
            KeyFields = new List<FieldData>();
        }

        public string GetSQL()
        {
            string cmdText = "";
            if ((!TableName.Trim().Equals("")) && (Fields.Count > 0) && (KeyFields.Count > 0))
            {
                cmdText = "UPDATE " + TableName + " SET ";

                for (int i = 0; i <= Fields.Count - 1; i++)
                {
                    cmdText += "[" + Fields[i].FieldName + "] = ";
                    cmdText += "'" + Fields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= Fields.Count - 2)
                    {
                        cmdText += ",";
                    }
                }
                cmdText += " WHERE ";
                for (int i = 0; i <= KeyFields.Count - 1; i++)
                {
                    cmdText += "[" + KeyFields[i].FieldName + "] = ";
                    cmdText += "'" + KeyFields[i].FieldValue.Replace("'", "''") + "'";
                    if (i <= KeyFields.Count - 2)
                    {
                        cmdText += " AND ";
                    }
                }
            }
            return cmdText;
        }
    }

    public class DeleteQueryData : IBaseQueryData
    {
        public string TableName { get; set; }
        public List<FieldData> Fields { get; set; }
        public List<FieldData> KeyFields { get; set; }

        public DeleteQueryData()
        {
            TableName = "";
            Fields = null;
            KeyFields = new List<FieldData>();
        }

        public string GetSQL()
        {
            string cmdText = "";
            cmdText = "DELETE FROM " + TableName;
            cmdText += " WHERE ";
            for (int i = 0; i <= KeyFields.Count - 1; i++)
            {
                cmdText += "[" + KeyFields[i].FieldName + "] = ";
                cmdText += "'" + KeyFields[i].FieldValue.Replace("'", "''") + "'";
                if (i <= KeyFields.Count - 2)
                {
                    cmdText += " AND ";
                }
            }

            return cmdText;
        }
    }

    #endregion

    public static class SQLWrapper
    {
        public static DataTable GetDataTable(SelectQueryData queryData, int tableIndex=0)
        {
            return GetDataTable(queryData.GetSQL());
        }

        public static DataTable GetDataTable(string queryText, int tableIndex = 0)
        {
            DataTable dtResult = null;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc = db.GetSqlStringCommand(queryText);
                DataSet ds = db.ExecuteDataSet(dbc);
                conn.Close();
                conn.Dispose();
                if (ds != null)
                {
                    if (ds.Tables[tableIndex] != null)
                    {
                        dtResult = ds.Tables[tableIndex];
                    }
                }
            }
            return dtResult;
        }

        public static bool ExecuteQuery(string queryText)
        {
            bool returnValue = false;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand dbc = db.GetSqlStringCommand(queryText);
                db.ExecuteNonQuery(dbc);
                conn.Close();
                conn.Dispose();
                returnValue = true;
            }
            return returnValue;
        }


        public static bool ExecuteQuery(IBaseQueryData queryData)
        {
            return ExecuteQuery(queryData.GetSQL());
        }

        public static bool ExecuteQuery( List<IBaseQueryData> queryDatum)
        {
            bool returnValue = false;
            Database db = DatabaseFactory.CreateDatabase(ConfigReader.ActiveConnectionStringKey);
            using (DbConnection conn = db.CreateConnection())
            {
                // open the connection and begin transaction
                conn.Open();
                DbTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i <= queryDatum.Count - 1; i++)
                    {
                        IBaseQueryData queryData = queryDatum[i];
                        DbCommand dbc = db.GetSqlStringCommand(queryData.GetSQL());
                        db.ExecuteNonQuery(dbc, trans);
                    }
                    // Commit the transaction.
                    trans.Commit();
                    returnValue = true;
                }
                catch (Exception ex)
                {
                    // Roll back the transaction. 
                    trans.Rollback();
                    throw ex;
                }
                conn.Close();
            }
            return returnValue;
        }

    }
}
