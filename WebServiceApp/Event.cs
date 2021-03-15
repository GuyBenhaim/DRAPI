using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Events : BusinessObject
    {
        private int _event_ID;
        public int Event_ID
        {
            get { return _event_ID; }
            set { _event_ID = value; }
        }

        private int _route_ID;
        public int Route_ID
        {
            get { return _route_ID; }
            set { _route_ID = value; }
        }

        private int? _event_Type_ID;
        public int? Event_Type_ID
        {
            get { return _event_Type_ID; }
            set { _event_Type_ID = value; }
        }

        private int _Event_TextRoute_ID;
        public int Event_TextRoute_ID
        {
            get { return _Event_TextRoute_ID; }
            set { _Event_TextRoute_ID = value; }
        }
        private string _EventName;
        public string EventName
        {
            get { return _EventName; }
            set { _EventName = value; }
        }

        private int? _user_ID;
        public int? User_ID
        {
            get { return _user_ID; }
            set { _user_ID = value; }
        }

        private int? _device_ID;
        public int? Device_ID
        {
            get { return _device_ID; }
            set { _device_ID = value; }
        }

        private DateTime? _event_Time;
        public DateTime? Event_Time
        {
            get { return _event_Time; }
            set { _event_Time = value; }
        }

        private string _event_Location;
        public string Event_Location
        {
            get { return _event_Location; }
            set { _event_Location = value; }
        }

        private string _event_Bearing;
        public string Event_Bearing
        {
            get { return _event_Bearing; }
            set { _event_Bearing = value; }
        }

        private int? _object_ID;
        public int? Object_ID
        {
            get { return _object_ID; }
            set { _object_ID = value; }
        }

        private DateTime? _event_CreatedDate;
        public DateTime? Event_CreatedDate
        {
            get { return _event_CreatedDate; }
            set { _event_CreatedDate = value; }
        }

        public Events()
        { }

        private Events(DataRow row)
            : base(row)
        { }

        public static Events Create(int event_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Event_GetByID", event_ID);
            if (dt.Rows.Count > 0)
                return new Events(dt.Rows[0]);
            else
                return null;
        }

        public static Events Create(DataRow row)
        {
            if (row != null)
                return new Events(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("Event_ID"))
                    this._event_ID = (int)row["Event_ID"];
                if (row.Table.Columns.Contains("Event_Type_ID") && row["Event_Type_ID"] != DBNull.Value)
                    this._event_Type_ID = (int?)row["Event_Type_ID"];
                else
                    this._event_Type_ID = null;
                if (row.Table.Columns.Contains("Event_TextRoute_ID") && row["Event_TextRoute_ID"] != DBNull.Value)
                    this._Event_TextRoute_ID = (int)row["Event_TextRoute_ID"];
                else
                    this._Event_TextRoute_ID = 0;

                if (row.Table.Columns.Contains("User_ID") && row["User_ID"] != DBNull.Value)
                    this._user_ID = (int?)row["User_ID"];
                else
                    this._user_ID = null;
                if (row.Table.Columns.Contains("Device_ID") && row["Device_ID"] != DBNull.Value)
                    this._device_ID = (int?)row["Device_ID"];
                else
                    this._device_ID = null;
                if (row.Table.Columns.Contains("Event_Time") && row["Event_Time"] != DBNull.Value)
                    this._event_Time = (DateTime?)row["Event_Time"];
                else
                    this._event_Time = null;
                if (row.Table.Columns.Contains("Event_Location") && row["Event_Location"] != DBNull.Value)
                    this._event_Location = (string)row["Event_Location"];
                else
                    this._event_Location = null;
                if (row.Table.Columns.Contains("Event_Bearing") && row["Event_Bearing"] != DBNull.Value)
                    this._event_Bearing = (string)row["Event_Bearing"];
                else
                    this._event_Bearing = null;
                if (row.Table.Columns.Contains("Object_ID") && row["Object_ID"] != DBNull.Value)
                    this._object_ID = (int?)row["Object_ID"];
                else
                    this._object_ID = null;

                if (row.Table.Columns.Contains("Event_CreatedDate") && row["Event_CreatedDate"] != DBNull.Value)
                    this._event_CreatedDate = (DateTime?)row["Event_CreatedDate"];
                else
                    this._event_CreatedDate = null;
            }
        }

        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            result = Convert.ToInt32(da.ExecuteScalar("proc_EventSave", _event_ID, _event_Type_ID, _Event_TextRoute_ID, _user_ID, _device_ID, _event_Time, _event_Location, _event_Bearing, _object_ID, _event_CreatedDate));
            //result = Convert.ToInt32(output.ToString().Trim());
            return result;
        }

        public List<Events> GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Event_GetAll");
            return CreateListFromTable<Events>(dt);
        }

        public void Delete(int event_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Event_Delete", event_ID);
        }

    }
}