using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp
{
    public class Points : BusinessObject
    {
        private int _point_ID;
        public int Point_ID
        {
            get { return _point_ID; }
            set { _point_ID = value; }
        }

        private int? _point_Number;
        public int? Point_Number
        {
            get { return _point_Number; }
            set { _point_Number = value; }
        }

        private int _route_ID;
        public int Route_ID
        {
            get { return _route_ID; }
            set { _route_ID = value; }
        }

        private int? _preferred_Order;
        public int? Preferred_Order
        {
            get { return _preferred_Order; }
            set { _preferred_Order = value; }
        }

        private string _point_Name;
        public string Point_Name
        {
            get { return _point_Name; }
            set { _point_Name = value; }
        }

        private string _user_Message;
        public string User_Message
        {
            get { return _user_Message; }
            set { _user_Message = value; }
        }

        private string _notification;
        public string Notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

        private DateTime? _creation_Date;
        public DateTime? Creation_Date
        {
            get { return _creation_Date; }
            set { _creation_Date = value; }
        }

        private DateTime? _activation_Date;
        public DateTime? Activation_Date
        {
            get { return _activation_Date; }
            set { _activation_Date = value; }
        }

        private DateTime? _expiry_Date;
        public DateTime? Expiry_Date
        {
            get { return _expiry_Date; }
            set { _expiry_Date = value; }
        }

        private string _point_Coordinates;
        public string Point_Coordinates
        {
            get { return _point_Coordinates; }
            set { _point_Coordinates = value; }
        }

        private int? _distance;
        public int? Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        private DateTime? _interval;
        public DateTime? Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        private double? _monetary;
        public double? Monetary
        {
            get { return _monetary; }
            set { _monetary = value; }
        }

        private int? _action_ID;
        public int? Action_ID
        {
            get { return _action_ID; }
            set { _action_ID = value; }
        }

        private int? _load_OK;
        public int? Load_OK
        {
            get { return _load_OK; }
            set { _load_OK = value; }
        }

        private DateTime? _load_Time;
        public DateTime? Load_Time
        {
            get { return _load_Time; }
            set { _load_Time = value; }
        }

        private int? _offload_OK;
        public int? Offload_OK
        {
            get { return _offload_OK; }
            set { _offload_OK = value; }
        }

        private DateTime? _offload_Time;
        public DateTime? Offload_Time
        {
            get { return _offload_Time; }
            set { _offload_Time = value; }
        }

        private byte[] _point_Pic;
        public byte[] Point_Pic
        {
            get { return _point_Pic; }
            set { _point_Pic = value; }
        }

        private int? _s;
        public int? S
        {
            get { return _s; }
            set { _s = value; }
        }

        private int? _r;
        public int? R
        {
            get { return _r; }
            set { _r = value; }
        }

        private int? _load_OffloadN;
        public int? Load_OffloadN
        {
            get { return _load_OffloadN; }
            set { _load_OffloadN = value; }
        }

        public Points()
        { }

        private Points(DataRow row)
            : base(row)
        { }

        public static Points Create(int point_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Points_GetByID", point_ID);
            if (dt.Rows.Count > 0)
                return new Points(dt.Rows[0]);
            else
                return null;
        }

        public static Points Create(DataRow row)
        {
            if (row != null)
                return new Points(row);
            else
                return null;
        }

        protected override void Load(DataRow row)
        {
            if (row != null)
            {
                if (row.Table.Columns.Contains("Point_ID"))
                    this._point_ID = (int)row["Point_ID"];
                if (row.Table.Columns.Contains("Point_Number") && row["Point_Number"] != DBNull.Value)
                    this._point_Number = (int?)row["Point_Number"];
                else
                    this._point_Number = null;
                if (row.Table.Columns.Contains("Route_ID"))
                    this._route_ID = (int)row["Route_ID"];
                if (row.Table.Columns.Contains("Preferred_Order") && row["Preferred_Order"] != DBNull.Value)
                    this._preferred_Order = (int?)row["Preferred_Order"];
                else
                    this._preferred_Order = null;
                if (row.Table.Columns.Contains("Point_Name") && row["Point_Name"] != DBNull.Value)
                    this._point_Name = (string)row["Point_Name"];
                else
                    this._point_Name = null;
                if (row.Table.Columns.Contains("User_Message") && row["User_Message"] != DBNull.Value)
                    this._user_Message = (string)row["User_Message"];
                else
                    this._user_Message = null;
                if (row.Table.Columns.Contains("Notification") && row["Notification"] != DBNull.Value)
                    this._notification = (string)row["Notification"];
                else
                    this._notification = null;
                if (row.Table.Columns.Contains("Creation_Date") && row["Creation_Date"] != DBNull.Value)
                    this._creation_Date = (DateTime?)row["Creation_Date"];
                else
                    this._creation_Date = null;
                if (row.Table.Columns.Contains("Activation_Date") && row["Activation_Date"] != DBNull.Value)
                    this._activation_Date = (DateTime?)row["Activation_Date"];
                else
                    this._activation_Date = null;
                if (row.Table.Columns.Contains("Expiry_Date") && row["Expiry_Date"] != DBNull.Value)
                    this._expiry_Date = (DateTime?)row["Expiry_Date"];
                else
                    this._expiry_Date = null;
                if (row.Table.Columns.Contains("Point_Coordinates") && row["Point_Coordinates"] != DBNull.Value)
                    this._point_Coordinates = (string)row["Point_Coordinates"];
                else
                    this._point_Coordinates = null;
                if (row.Table.Columns.Contains("Distance") && row["Distance"] != DBNull.Value)
                    this._distance = (int?)row["Distance"];
                else
                    this._distance = null;
                if (row.Table.Columns.Contains("Interval") && row["Interval"] != DBNull.Value)
                    this._interval = (DateTime?)row["Interval"];
                else
                    this._interval = null;
                if (row.Table.Columns.Contains("Monetary") && row["Monetary"] != DBNull.Value)
                    this._monetary = (double?)row["Monetary"];
                else
                    this._monetary = null;
                if (row.Table.Columns.Contains("Action_ID") && row["Action_ID"] != DBNull.Value)
                    this._action_ID = (int?)row["Action_ID"];
                else
                    this._action_ID = null;
                if (row.Table.Columns.Contains("Load_OK") && row["Load_OK"] != DBNull.Value)
                    this._load_OK = (int?)row["Load_OK"];
                else
                    this._load_OK = null;
                if (row.Table.Columns.Contains("Load_Time") && row["Load_Time"] != DBNull.Value)
                    this._load_Time = (DateTime?)row["Load_Time"];
                else
                    this._load_Time = null;
                if (row.Table.Columns.Contains("Offload_OK") && row["Offload_OK"] != DBNull.Value)
                    this._offload_OK = (int?)row["Offload_OK"];
                else
                    this._offload_OK = null;
                if (row.Table.Columns.Contains("Offload_Time") && row["Offload_Time"] != DBNull.Value)
                    this._offload_Time = (DateTime?)row["Offload_Time"];
                else
                    this._offload_Time = null;
                if (row.Table.Columns.Contains("Point_Pic") && row["Point_Pic"] != DBNull.Value)
                    this._point_Pic = (byte[])row["Point_Pic"];
                else
                    this._point_Pic = null;
                if (row.Table.Columns.Contains("S") && row["S"] != DBNull.Value)
                    this._s = (int?)row["S"];
                else
                    this._s = null;
                if (row.Table.Columns.Contains("R") && row["R"] != DBNull.Value)
                    this._r = (int?)row["R"];
                else
                    this._r = null;
                if (row.Table.Columns.Contains("Load_OffloadN") && row["Load_OffloadN"] != DBNull.Value)
                    this._load_OffloadN = (int?)row["Load_OffloadN"];
                else
                    this._load_OffloadN = null;
            }
        }

        public int Insert()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            result = (int)da.ExecuteScalar("proc_Points_Insert", _point_ID, _point_Number, _route_ID, _preferred_Order, _point_Name, _user_Message, _notification, _creation_Date, _activation_Date, _expiry_Date, _point_Coordinates, _distance, _interval, _monetary, _action_ID, _load_OK, _load_Time, _offload_OK, _offload_Time, _point_Pic, _s, _r, _load_OffloadN);
            return result;
        }

        public int Update()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;
            result = (int)da.ExecuteScalar("proc_Points_Update", _point_ID, _point_Number, _route_ID, _preferred_Order, _point_Name, _user_Message, _notification, _creation_Date, _activation_Date, _expiry_Date, _point_Coordinates, _distance, _interval, _monetary, _action_ID, _load_OK, _load_Time, _offload_OK, _offload_Time, _point_Pic, _s, _r, _load_OffloadN);
            return result;
        }

        public static List<Points> GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Points_GetAll");
            return CreateListFromTable<Points>(dt);
        }

        public static void Delete(int point_ID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Points_Delete", point_ID);
        }

    }
}