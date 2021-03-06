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
    
    public partial class Session
    {
        public int Session_ID { get; set; }
        public Nullable<System.DateTime> Creation_Date { get; set; }
        public Nullable<System.DateTime> Termination_Date { get; set; }
        public Nullable<int> Route_ID { get; set; }
        public Nullable<int> Object_Vector_ID { get; set; }
        public Nullable<int> Carrier_ID { get; set; }
        public Nullable<int> Org_ID { get; set; }
        public string Admin_State { get; set; }
        public Nullable<bool> Alarm_State { get; set; }
        public string Route_Location { get; set; }
        public string Route_Vel { get; set; }
        public string Route_Dir { get; set; }
        public string Route_Elevation { get; set; }
        public string Last_Point_ID { get; set; }
        public string Next_Point_ID { get; set; }
        public Nullable<int> Controller_ID { get; set; }
        public Nullable<int> Controller_Device_ID { get; set; }
        public Nullable<int> Route_Container_ID { get; set; }
        public Nullable<int> Count_Load { get; set; }
        public Nullable<int> Count_Offload { get; set; }
        public Nullable<int> Worst_Alarm_ID { get; set; }
        public Nullable<System.DateTime> Last_Comms_Time { get; set; }
        public string Comms_State { get; set; }
        public Nullable<int> Bat_State { get; set; }
        public Nullable<int> Route_Bearing { get; set; }
        public Nullable<int> Event_Charging { get; set; }
        public Nullable<int> Container_Status_Type_ID { get; set; }
        public string NFC_Tag { get; set; }
        public string Device_IMEI { get; set; }
        public string Message_Type_ID { get; set; }
        public Nullable<int> Count_Type1 { get; set; }
        public Nullable<int> Count_Type2 { get; set; }
        public Nullable<int> Count_Type3 { get; set; }
        public Nullable<int> Count_Type4 { get; set; }
        public Nullable<int> Segment_K { get; set; }
        public Nullable<bool> MonitorState { get; set; }
        public string DEndSeg0 { get; set; }
        public int User_Id { get; set; }
        public int Container_ID { get; set; }
        public Nullable<int> Admin_State_Value { get; set; }
    }
}
