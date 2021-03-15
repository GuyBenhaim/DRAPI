using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Mapping : BusinessObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _initiate_Session;
        public string Initiate_Session
        {
            get { return _initiate_Session; }
            set { _initiate_Session = value; }
        }

        private string _action_Load;
        public string Action_Load
        {
            get { return _action_Load; }
            set { _action_Load = value; }
        }

        private string _action_Offload;
        public string Action_Offload
        {
            get { return _action_Offload; }
            set { _action_Offload = value; }
        }

        private string _action_Not;
        public string Action_Not
        {
            get { return _action_Not; }
            set { _action_Not = value; }
        }

        private string _action_Correction;
        public string Action_Correction
        {
            get { return _action_Correction; }
            set { _action_Correction = value; }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private string _terminate_Session;
        public string Terminate_Session
        {
            get { return _terminate_Session; }
            set { _terminate_Session = value; }
        }

        private string _webUI;
        public string WebUI
        {
            get { return _webUI; }
            set { _webUI = value; }
        }

        private string _bat;
        public string Bat
        {
            get { return _bat; }
            set { _bat = value; }
        }

        private string _comm;
        public string Comm
        {
            get { return _comm; }
            set { _comm = value; }
        }

        private string _alert1;
        public string Alert1
        {
            get { return _alert1; }
            set { _alert1 = value; }
        }

        private string _alert2;
        public string Alert2
        {
            get { return _alert2; }
            set { _alert2 = value; }
        }

        public Mapping()
        { }

        private Mapping(DataRow row)
            : base(row)
        { }

        public static Mapping Create(int id)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Mapping_GetByID", id);
            if (dt.Rows.Count > 0)
                return new Mapping(dt.Rows[0]);
            else
                return null;
        }

        public static Mapping Create(DataRow row)
        {
            if (row != null)
                return new Mapping(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("Id"))
                    this._id = (int)row["Id"];
                if (row.Table.Columns.Contains("Initiate_Session") && row["Initiate_Session"] != DBNull.Value)
                    this._initiate_Session = (string)row["Initiate_Session"];
                else
                    this._initiate_Session = null;
                if (row.Table.Columns.Contains("Action_Load") && row["Action_Load"] != DBNull.Value)
                    this._action_Load = (string)row["Action_Load"];
                else
                    this._action_Load = null;
                if (row.Table.Columns.Contains("Action_Offload") && row["Action_Offload"] != DBNull.Value)
                    this._action_Offload = (string)row["Action_Offload"];
                else
                    this._action_Offload = null;
                if (row.Table.Columns.Contains("Action_Not") && row["Action_Not"] != DBNull.Value)
                    this._action_Not = (string)row["Action_Not"];
                else
                    this._action_Not = null;
                if (row.Table.Columns.Contains("Action_Correction") && row["Action_Correction"] != DBNull.Value)
                    this._action_Correction = (string)row["Action_Correction"];
                else
                    this._action_Correction = null;
                if (row.Table.Columns.Contains("Location") && row["Location"] != DBNull.Value)
                    this._location = (string)row["Location"];
                else
                    this._location = null;
                if (row.Table.Columns.Contains("Terminate_Session") && row["Terminate_Session"] != DBNull.Value)
                    this._terminate_Session = (string)row["Terminate_Session"];
                else
                    this._terminate_Session = null;
                if (row.Table.Columns.Contains("WebUI") && row["WebUI"] != DBNull.Value)
                    this._webUI = (string)row["WebUI"];
                else
                    this._webUI = null;
                if (row.Table.Columns.Contains("Bat") && row["Bat"] != DBNull.Value)
                    this._bat = (string)row["Bat"];
                else
                    this._bat = null;
                if (row.Table.Columns.Contains("Comm") && row["Comm"] != DBNull.Value)
                    this._comm = (string)row["Comm"];
                else
                    this._comm = null;
                if (row.Table.Columns.Contains("Alert1") && row["Alert1"] != DBNull.Value)
                    this._alert1 = (string)row["Alert1"];
                else
                    this._alert1 = null;
                if (row.Table.Columns.Contains("Alert2") && row["Alert2"] != DBNull.Value)
                    this._alert2 = (string)row["Alert2"];
                else
                    this._alert2 = null;
            }
        }

        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            result = (int)da.ExecuteScalar("proc_MappingSave", _id, _initiate_Session, _action_Load, _action_Offload, _action_Not, _action_Correction, _location, _terminate_Session, _webUI, _bat, _comm, _alert1, _alert2);
            return result;
        }

        public static List<Mapping> GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Mapping_GetAll");
            return CreateListFromTable<Mapping>(dt);
        }

        public static void Delete(int id)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Mapping_Delete", id);
        }

    }
}