//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebServiceApp.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Object
    {
        public Object()
        {
            this.Object_Periods = new HashSet<Object_Periods>();
        }
    
        public int Object_ID { get; set; }
        public string Obj_Name { get; set; }
        public Nullable<System.DateTime> Obj_Creation_Date { get; set; }
        public string Obj_Description { get; set; }
        public string Obj_Address { get; set; }
        public string Obj_Address_Coordinates { get; set; }
        public string Obj_Language { get; set; }
        public Nullable<bool> Obj_Permits_SMS { get; set; }
        public Nullable<bool> Obj_Interested { get; set; }
        public string Obj_MSISDN { get; set; }
        public Nullable<int> Obj_Comm_Ch_Type { get; set; }
        public string Obj_Comm_Ch_Address { get; set; }
        public string Obj_Comm_Ch_Gateway { get; set; }
        public Nullable<int> Obj_Active { get; set; }
        public Nullable<int> Obj_Parent_User_ID { get; set; }
        public Nullable<int> Obj_Parent_Org_ID { get; set; }
        public Nullable<int> Obj_Parent_Type_ID { get; set; }
        public Nullable<bool> Obj_Friend { get; set; }
        public string Obj_Pic { get; set; }
        public Nullable<int> Obj_RF_ID { get; set; }
        public Nullable<int> Obj_Point_ID { get; set; }
        public Nullable<int> Object_Type_ID { get; set; }
        public string Gender { get; set; }
        public string Obj_Snd { get; set; }
    
        public virtual ICollection<Object_Periods> Object_Periods { get; set; }
    }
}
