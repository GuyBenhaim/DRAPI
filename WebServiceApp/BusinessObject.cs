using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public interface IBusinessObject
    {
        int ID { get; }
    }

    public class BusinessObject : IBusinessObject
    {
        #region "Fields"
        /// <summary>
        /// Business object unique identifier.
        /// </summary>
        protected int objectId;

        #endregion "Fields"

        #region "Properties"

        /// <summary>
        /// Gets or sets the business object unique identifier.
        /// </summary>
        public int ID
        {
            get { return objectId; }
        }

        #endregion "Properties"

        #region "Contructors"

        /// <summary>
        /// Initialize a new instance of the business class.
        /// </summary>
        public BusinessObject()
        {
        }

        public BusinessObject(int pid)
        {
            this.objectId = pid;
        }

        public BusinessObject(DataRow row)
        {
            Load(row);
        }
        #endregion "Contructors"

        #region Read from DataRow
        /// <summary>
        /// Reads from the specified DataRow and returns a nullable integer value.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>

        protected Nullable<int> GetNullableInt(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? new Nullable<int>() : (int)row[columnName];
        }


        /// <summary>
        /// Reads from the specified DataRow and returns a nullable DateTime value.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <param name="allowNull"></param>
        /// <returns></returns>
        protected Nullable<DateTime> GetNullableDateTime(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? new Nullable<DateTime>() : (DateTime)row[columnName];
        }

        /// <summary>
        /// Reads from the specified DataRow and returns a nullable decimal value.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected Nullable<decimal> GetNullableDecimal(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? new Nullable<decimal>() : (decimal)row[columnName];
        }


        /// <summary>
        /// Reads from the specified DataRow and returns a nullable double value.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected Nullable<double> GetNullableDouble(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? new Nullable<double>() : (double)row[columnName];
        }


        protected Nullable<bool> GetNullableBool(DataRow row, string columnName)
        {
            return row.IsNull(columnName) ? new Nullable<bool>() : (bool)row[columnName];
        }

        /// <summary>
        /// Reads the string value of the specified 'columnName' from the DataRow parameter.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        /// 
        protected string GetString(DataRow row, string columnName)
        {
            return row.IsNull(columnName)
                ? String.Empty : row[columnName].ToString();

        }

        /// <summary>
        /// Reads the value of the specified 'columnName' from the DataRow parameter.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        protected T GetValue<T>(DataRow row, string columnName)
        {
            if (row.IsNull(columnName))
                return default(T);
            else
                return (T)row[columnName];
        }

        #endregion

        /// <summary>
        /// Creates the list from table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">The DataTable.</param>
        /// <returns></returns>
        protected static List<T> CreateListFromTable<T>(DataTable dt) where T : BusinessObject, new()
        {
            List<T> list = new List<T>();

            if (dt != null)
                foreach (DataRow row in dt.Rows)
                {
                    T t = new T();
                    t.Load(row);

                    list.Add(t);
                }

            return list;
        }

        #region "CRUD methods"

        /// <summary>
        /// Virtual method which should be overriden by inherited types that support loading.
        /// </summary>
        /// <param name="row">The datarow.</param>
        protected virtual void Load(DataRow row)
        {
            throw new NotSupportedException("The object of type '" + this.GetType().Name +
                "' does not support loading from IDataReader.");
        }

        #endregion "CRUD methods"
    }
}