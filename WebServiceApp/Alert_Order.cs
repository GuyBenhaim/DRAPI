using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Alert_Order : BusinessObject
    {
        private int _Alert_Order_ID;
        public int Alert_Order_ID 
        {
            get { return _Alert_Order_ID; }
            set { _Alert_Order_ID = value; }
        }

        private int? _Alert_Type_ID;
        public int? Alert_Type_ID
        {
            get { return _Alert_Type_ID; }
            set { _Alert_Type_ID = value; }
        }

        private int? _User_Type_ID;
        public int? User_Type_ID
        {
            get { return _User_Type_ID; }
            set { _User_Type_ID = value; }
        }
        private int? _Dispatch_Order;
        public int? Dispatch_Order
        {
            get { return _Dispatch_Order; }
            set { _Dispatch_Order = value; }
        }

        private DateTime? _Can_Clear;
        public DateTime? Can_Clear
        {
            get { return _Can_Clear; }
            set { _Can_Clear = value; }
        }

          

        public Alert_Order()
        { }

        private Alert_Order(DataRow row)
            : base(row)
        { }

        public static Alert_Order Create(int event_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Event_GetByID", event_ID);
            if (dt.Rows.Count > 0)
                return new Alert_Order(dt.Rows[0]);
            else
                return null;
        }

        public static Alert_Order Create(DataRow row)
        {
            if (row != null)
                return new Alert_Order(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("Alert_Order_ID"))
                    this._Alert_Order_ID = (int)row["Alert_Order_ID"];

                if (row.Table.Columns.Contains("Alert_Type_ID") && row["Alert_Type_ID"] != DBNull.Value)
                    this._Alert_Type_ID = (int?)row["Alert_Type_ID"];
                else
                    this._Alert_Type_ID = null;

                if (row.Table.Columns.Contains("User_Type_ID") && row["User_Type_ID"] != DBNull.Value)
                    this._User_Type_ID = (int)row["User_Type_ID"];
                else
                    this._User_Type_ID = 0;

                if (row.Table.Columns.Contains("Dispatch_Order") && row["Dispatch_Order"] != DBNull.Value)
                    this._Dispatch_Order = (int)row["Dispatch_Order"];
                else
                    this.Dispatch_Order = null;

                if (row.Table.Columns.Contains("Can_Clear") && row["Can_Clear"] != DBNull.Value)
                    this._Can_Clear = (DateTime?)row["Can_Clear"];
                else
                    this.Can_Clear = null;               
            }
        }

        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;

            var resultOut = da.ExecuteScalar("proc_Alert_OrderSave", _Alert_Order_ID, _Alert_Type_ID, _User_Type_ID, _Dispatch_Order, _Can_Clear);
            result = Convert.ToInt32(Convert.ToString(resultOut).Trim());
            return result;
        }

        public DataTable GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Alert_Order_GetAll");
            return dt;
        }

        public void Delete(int event_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Alert_Order_Delete", event_ID);
        }
    }
}