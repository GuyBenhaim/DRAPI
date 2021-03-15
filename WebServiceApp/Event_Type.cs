using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Event_Type : BusinessObject
    {
        private int _event_Type_ID;
        public int Event_Type_ID
        {
            get { return _event_Type_ID; }
            set { _event_Type_ID = value; }
        }

        private string _event_Type_Name;
        public string Event_Type_Name
        {
            get { return _event_Type_Name; }
            set { _event_Type_Name = value; }
        }

        private string _event_Type_Category;
        public string Event_Type_Category
        {
            get { return _event_Type_Category; }
            set { _event_Type_Category = value; }
        }

        private string _event_Severity;
        public string Event_Severity
        {
            get { return _event_Severity; }
            set { _event_Severity = value; }
        }

        private bool? _event_Visibility;
        public bool? Event_Visibility
        {
            get { return _event_Visibility; }
            set { _event_Visibility = value; }
        }

        private string _event_Icon;
        public string Event_Icon
        {
            get { return _event_Icon; }
            set { _event_Icon = value; }
        }

        public Event_Type()
        { }

        private Event_Type(DataRow row)
            : base(row)
        { }

        public static Event_Type Create(int event_Type_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Event_Type_GetByID", event_Type_ID);
            if (dt.Rows.Count > 0)
                return new Event_Type(dt.Rows[0]);
            else
                return null;
        }

        public static Event_Type Create(DataRow row)
        {
            if (row != null)
                return new Event_Type(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("Event_Type_ID"))
                    this._event_Type_ID = (int)row["Event_Type_ID"];
                if (row.Table.Columns.Contains("Event_Type_Name") && row["Event_Type_Name"] != DBNull.Value)
                    this._event_Type_Name = (string)row["Event_Type_Name"];
                else
                    this._event_Type_Name = null;
                if (row.Table.Columns.Contains("Event_Type_Category") && row["Event_Type_Category"] != DBNull.Value)
                    this._event_Type_Category = (string)row["Event_Type_Category"];
                else
                    this._event_Type_Category = null;
                if (row.Table.Columns.Contains("Event_Severity") && row["Event_Severity"] != DBNull.Value)
                    this._event_Severity = (string)row["Event_Severity"];
                else
                    this._event_Severity = null;
                if (row.Table.Columns.Contains("Event_Visibility") && row["Event_Visibility"] != DBNull.Value)
                    this._event_Visibility = (bool?)row["Event_Visibility"];
                else
                    this._event_Visibility = null;
                if (row.Table.Columns.Contains("Event_Icon") && row["Event_Icon"] != DBNull.Value)
                    this._event_Icon = (string)row["Event_Icon"];
                else
                    this._event_Icon = null;
            }
        }

        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            result = (int)da.ExecuteScalar("proc_Event_TypeSave", _event_Type_ID, _event_Type_Name, _event_Type_Category, _event_Severity, _event_Visibility, _event_Icon);
            return result;
        }

        public static List<Event_Type> GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Event_Type_GetAll");
            return CreateListFromTable<Event_Type>(dt);
        }

        public static void Delete(int event_Type_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Event_Type_Delete", event_Type_ID);
        }
    }
}