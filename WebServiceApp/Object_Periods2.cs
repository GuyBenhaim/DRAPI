using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebServiceApp 
{
    public class Object_Periods2 : BusinessObject
    {
        private int _iObjPeriodID;
        public int iObjPeriodID
        {
            get { return _iObjPeriodID; }
            set { _iObjPeriodID = value; }
        }

        private int? _Object_ID;
        public int? Object_ID
        {
            get { return _Object_ID; }
            set { _Object_ID = value; }
        }
        private int? _Point_ID;
        public int? Point_ID
        {
            get { return _Point_ID; }
            set { _Point_ID = value; }
        }


        private int? _ObjectType_ID;
        public int? ObjectType_ID
        {
            get { return _ObjectType_ID; }
            set { _ObjectType_ID = value; }
        }
        private int? _Object_Action_ID;
        public int? Object_Action_ID
        {
            get { return _Object_Action_ID; }
            set { _Object_Action_ID = value; }
        }

        private DateTime? _Start_Date;
        public DateTime? Start_Date
        {
            get { return _Start_Date; }
            set { _Start_Date = value; }
        }

        private DateTime? _End_Date;
        public DateTime? End_Date
        {
            get { return _End_Date; }
            set { _End_Date = value; }
        }

        private bool _Sun;
        public bool Sun
        {
            get { return _Sun; }
            set { _Sun = value; }
        }

        private bool _Mon;
        public bool Mon
        {
            get { return _Mon; }
            set { _Mon = value; }
        }
        private bool _Tue;
        public bool Tue
        {
            get { return _Tue; }
            set { _Tue = value; }
        }
        private bool _Wed;
        public bool Wed
        {
            get { return _Wed; }
            set { _Wed = value; }
        }
        private bool _Thu;
        public bool Thu
        {
            get { return _Thu; }
            set { _Thu = value; }
        }
        private bool _Fri;
        public bool Fri
        {
            get { return _Fri; }
            set { _Fri = value; }
        }
        private bool _Sat;
        public bool Sat
        {
            get { return _Sat; }
            set { _Sat = value; }
        }

        private int? _Org_ID;
        public int? Org_ID
        {
            get { return _Org_ID; }
            set { _Org_ID = value; }
        }

        private int? _Route_ID;
        public int? Route_ID
        {
            get { return _Route_ID; }
            set { _Route_ID = value; }
        }
        private int? _User_ID;
        public int? User_ID
        {
            get { return _User_ID; }
            set { _User_ID = value; }
        }

        public Object_Periods2()
        { }
        public int InsertUpdate()
        {
            DatabaseGateway da = new DatabaseGateway();
            int result = 0;

            var resultOut = da.ExecuteScalar("proc_Object_Periodssave", _iObjPeriodID, _Object_ID, _Point_ID, _ObjectType_ID, _Object_Action_ID, _Start_Date, _End_Date, _Sun, _Mon, _Tue, _Wed, _Thu, _Fri, _Sat, _Route_ID);
            result = Convert.ToInt32(Convert.ToString(resultOut).Trim());
            return result;
        }

        public DataTable GetAll()
        {
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_Object_PeriodsLoadAll");
            return dt;
        }

        public void Delete(int objectID, int pointID)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Object_PeriodsDelete", objectID, pointID);
        }

       
    }
}