using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

namespace WebServiceApp
{
    public class DatabaseGateway
    {
        /// <summary>
        /// Queries for datatable with paging.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="TotalRecords">The total records.</param>
        /// <param name="parameters">The sproc parameters.</param>
        /// <returns></returns>
        public DataTable QueryForDataTablePaged(string sprocName, int currentPage, int recordsPerPage, out int TotalRecords, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        dbCom.Parameters.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1]));
                    }
                }

                db.AddInParameter(dbCom, "@PageNumber", DbType.Int32, currentPage);
                db.AddInParameter(dbCom, "@PageSize", DbType.Int32, recordsPerPage);
                db.AddOutParameter(dbCom, "@TotalRecords", DbType.Int32, 8);

                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                    TotalRecords = (int)db.GetParameterValue(dbCom, "@TotalRecords");
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }

        /// <summary>
        /// Queries for datatable with paging. (Specifically when common table expression CTE used in procedure)
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="TotalRecords">The total records.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataTable QueryForDataTablePagedCTE(string sprocName, int currentPage, int recordsPerPage, out int TotalRecords, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        dbCom.Parameters.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1]));
                    }
                }

                db.AddInParameter(dbCom, "@PageNumber", DbType.Int32, currentPage);
                db.AddInParameter(dbCom, "@PageSize", DbType.Int32, recordsPerPage);

                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                    if (table != null && table.Rows.Count > 0)
                        TotalRecords = (int)table.Rows[0]["TotalRecords"];
                    else
                        TotalRecords = 0;
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }

        /// <summary>
        /// Queries for datatable.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataTable QueryForDataTable(string sprocName, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName, parameters);
                dbCom.CommandTimeout = 240;
                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }


        /// <summary>
        /// Queries for datatable.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataTable QueryForDataTable(string sprocName, out int outParameter, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName, parameters);
                dbCom.CommandTimeout = 240;
                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                    outParameter = (int)db.GetParameterValue(dbCom, "@UserTypeOrder");
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }

        /// <summary>
        /// Executes query ExecuteNonQuery way.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sprocName, params object[] parameters)
        {
            int results = 0;
            results = DatabaseFactory.CreateDatabase().ExecuteNonQuery(sprocName, parameters);
            return results;
        }

        /// <summary>
        /// Executes query and returns the dataset.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public DataSet ExecuteDataset(string sprocName, params object[] parameters)
        {
            DataSet ds = DatabaseFactory.CreateDatabase().ExecuteDataSet(sprocName, parameters);
            return ds;
        }

        /// <summary>
        /// Executes query and return the scalar value.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public object ExecuteScalar(string sprocName, params object[] parameters)
        {
            object retValue = DatabaseFactory.CreateDatabase().ExecuteScalar(sprocName, parameters);
            return retValue;
        }


        /// <summary>
        /// Queries for datatable with paging.
        /// </summary>
        /// <param name="sprocName">Name of the sproc.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="recordsPerPage">The records per page.</param>
        /// <param name="TotalRecords">The total records.</param>
        /// <param name="parameters">The sproc parameters.</param>
        /// <returns></returns>
        public DataTable QueryForDataTablePagedOptions(string sprocName, int currentPage, int recordsPerPage, out int TotalRecords, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("OptionsDataConnection");

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName);
                if (parameters != null)
                {
                    for (int i = 0; i < parameters.Length; i += 2)
                    {
                        dbCom.Parameters.Add(new SqlParameter(parameters[i].ToString(), parameters[i + 1]));
                    }
                }

                db.AddInParameter(dbCom, "@PageNumber", DbType.Int32, currentPage);
                db.AddInParameter(dbCom, "@PageSize", DbType.Int32, recordsPerPage);
                db.AddOutParameter(dbCom, "@TotalRecords", DbType.Int32, 8);

                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                    TotalRecords = (int)db.GetParameterValue(dbCom, "@TotalRecords");
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }
        public DataTable QueryForDataTableOptions(string sprocName, params object[] parameters)
        {
            DataTable table = new DataTable();
            Database db = DatabaseFactory.CreateDatabase("OptionsDataConnection");

            DbCommand dbCom = null;
            try
            {
                dbCom = db.GetStoredProcCommand(sprocName, parameters);
                dbCom.CommandTimeout = 240;
                using (IDataReader reader = db.ExecuteReader(dbCom))
                {
                    table.Load(reader);
                }
            }
            finally
            {
                if (dbCom != null)
                    dbCom.Dispose();
            }
            return table;
        }
    }
}