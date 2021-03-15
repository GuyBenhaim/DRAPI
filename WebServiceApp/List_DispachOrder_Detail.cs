using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApp
{
    public class List_DispachOrder_Detail
    {
        private int _Alert_ID;
        public int Alert_ID
        {
            get { return _Alert_ID; }
            set { _Alert_ID = value; }
        }
        private string _Alert_Text;
        public string Alert_Text
        {
            get { return _Alert_Text; }
            set { _Alert_Text = value; }
        }
        private int _Alert_Type_ID;
        public int Alert_Type_ID
        {
            get { return _Alert_Type_ID; }
            set { _Alert_Type_ID = value; }
        }
        private int _route_ID;
        public int Route_ID
        {
            get { return _route_ID; }
            set { _route_ID = value; }
        }
        private int _session_ID;
        public int Session_ID
        {
            get { return _session_ID; }
            set { _session_ID = value; }
        }
        private int _User_ID;
        public int User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }
        private int _User_Type_ID;
        public int User_Type_ID
        {
            get { return _User_Type_ID; }
            set { _User_Type_ID = value; }
        }
        private int _Last_Level;
        public int Last_Level
        {
            get { return _Last_Level; }
            set { _Last_Level = value; }
        }
        private int _Dispach_OrderID;
        public int Dispach_OrderID
        {
            get { return _Dispach_OrderID; }
            set { _Dispach_OrderID = value; }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }        
        }

        private int _ObjectID;
        public int ObjectID
        {
            get { return _ObjectID; }
            set { _ObjectID = value; }
        }
    }
}