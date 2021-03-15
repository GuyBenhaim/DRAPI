using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Alerts : BusinessObject
    {
        private int _alert_ID;
        public int Alert_ID
        {
            get { return _alert_ID; }
            set { _alert_ID = value; }
        }

        private int? _alert_Type_ID;
        public int? Alert_Type_ID
        {
            get { return _alert_Type_ID; }
            set { _alert_Type_ID = value; }
        }

        private int? _route_ID;
        public int? Route_ID
        {
            get { return _route_ID; }
            set { _route_ID = value; }
        }
        private int? _Session_ID;
        public int? Session_ID
        {
            get { return _Session_ID; }
            set { _Session_ID = value; }
        }

        private DateTime? _Alert_Time;
        public DateTime? Alert_Time
        {
            get { return _Alert_Time; }
            set { _Alert_Time = value; }
        }

        private string _Alert_Location;
        public string Alert_Location
        {
            get { return _Alert_Location; }
            set { _Alert_Location = value; }
        }

        private string _Alert_Bearing;
        public string Alert_Bearing
        {
            get { return _Alert_Bearing; }
            set { _Alert_Bearing = value; }
        }

        private int? _Object_ID;
        public int? Object_ID
        {
            get { return _Object_ID; }
            set { _Object_ID = value; }
        }

        private int? _Org_ID;
        public int? Org_ID
        {
            get { return _Org_ID; }
            set { _Org_ID = value; }
        }

        private int? _Status_ID;
        public int? Status_ID
        {
            get { return _Status_ID; }
            set { _Status_ID = value; }
        }
        private int? _Last_Level;
        public int? Last_Level
        {
            get { return _Last_Level; }
            set { _Last_Level = value; }
        }

        private int? _Action_Ok;
        public int? Action_Ok
        {
            get { return _Action_Ok; }
            set { _Action_Ok = value; }
        }


        public Alerts()
        { }

        private Alerts(DataRow row)
            : base(row)
        { }

        public static Alerts Create(int alert_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Alert_GetByID", alert_ID);
            if (dt.Rows.Count > 0)
                return new Alerts(dt.Rows[0]);
            else
                return null;
        }

        public static Alerts Create(DataRow row)
        {
            if (row != null)
                return new Alerts(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("alert_ID"))
                    this._alert_ID = (int)row["alert_ID"];

                if (row.Table.Columns.Contains("alert_Type_ID") && row["alert_Type_ID"] != DBNull.Value)
                    this._alert_Type_ID = (int?)row["alert_Type_ID"];
                else
                    this._alert_Type_ID = null;

                if (row.Table.Columns.Contains("Route_ID") && row["Route_ID"] != DBNull.Value)
                    this._route_ID = (int)row["Route_ID"];
                else
                    this._route_ID = 0;

                if (row.Table.Columns.Contains("Session_ID") && row["Session_ID"] != DBNull.Value)
                    this._Session_ID = (int)row["Session_ID"];
                else
                    this._Session_ID = null;

                if (row.Table.Columns.Contains("Alert_Time") && row["Alert_Time"] != DBNull.Value)
                    this._Alert_Time = (DateTime?)row["Alert_Time"];
                else
                    this._Alert_Time = null;

                if (row.Table.Columns.Contains("Alert_Location") && row["Alert_Location"] != DBNull.Value)
                    this._Alert_Location = (string)row["Alert_Location"];
                else
                    this._Alert_Location = null;

                if (row.Table.Columns.Contains("Alert_Bearing") && row["Alert_Bearing"] != DBNull.Value)
                    this._Alert_Bearing = (string)row["Alert_Bearing"];
                else
                    this._Alert_Bearing = null;

                if (row.Table.Columns.Contains("Object_ID") && row["Object_ID"] != DBNull.Value)
                    this._Object_ID = (int)row["Object_ID"];
                else
                    this._Object_ID = null;

                if (row.Table.Columns.Contains("Org_ID") && row["Org_ID"] != DBNull.Value)
                    this._Org_ID = (int?)row["Org_ID"];
                else
                    this._Org_ID = null;

                if (row.Table.Columns.Contains("Status_ID") && row["Status_ID"] != DBNull.Value)
                    this._Status_ID = (int?)row["Status_ID"];
                else
                    this._Status_ID = null;
                if (row.Table.Columns.Contains("Last_Level") && row["Last_Level"] != DBNull.Value)
                    this._Last_Level = (int?)row["Last_Level"];
                else
                    this._Last_Level = null;

                if (row.Table.Columns.Contains("Action_Ok") && row["Action_Ok"] != DBNull.Value)
                    this._Action_Ok = (int?)row["Action_Ok"];
                else
                    this._Action_Ok = null;
            }
        }

        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            var resultOut = da.ExecuteScalar("proc_AlertInsert", _alert_ID, _alert_Type_ID, _route_ID, _Session_ID, _Alert_Time, _Alert_Location, _Alert_Bearing, _Object_ID, _Org_ID, _Status_ID, 0, _Action_Ok);
            result = Convert.ToInt32(Convert.ToString(resultOut).Trim());
            return result;
        }

        public List<Alerts> GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Alert_GetAll");
            return CreateListFromTable<Alerts>(dt);
        }

        public void Delete(int event_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Alert_Delete", event_ID);
        }
        public DataTable Get_DispachDetail()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Get_DispachDetail");
            return dt;

        }

        //public DataTable Get_DispachOrder()
        //{
        //    DatabaseGateway da = new DatabaseGateway();
        //    DataTable dt = da.QueryForDataTable("proc_Get_DispachDetail");
        //    return dt;        
        //}

        public void Alert_Clear(int Alert_ID, int Alert_Status)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Alert_Status", Alert_ID, Alert_Status);
        }

        public void Update_LastLevel(int Alert_ID, int DispatOrderID)
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            var resultOut = da.ExecuteScalar("proc_UpdateLastLevel", Alert_ID, DispatOrderID);
            result = Convert.ToInt32(Convert.ToString(resultOut).Trim());

        }




    }
}