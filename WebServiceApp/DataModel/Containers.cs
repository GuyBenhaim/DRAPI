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
    
    public partial class Containers
    {
        public Containers()
        {
            this.Container_Periods = new HashSet<Container_Periods>();
        }
    
        public int Container_ID { get; set; }
        public string Container_Name { get; set; }
        public Nullable<int> Container_Type_ID { get; set; }
        public Nullable<System.DateTime> Container_Creation_Date { get; set; }
        public string Container_Description { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> Trial_Capacity { get; set; }
        public string Capacities_List { get; set; }
        public Nullable<int> Employer_ID { get; set; }
        public string Container_Address { get; set; }
        public string Container_Address_Coordinates { get; set; }
        public string Container_Language { get; set; }
        public Nullable<bool> Container_Permits_SMS { get; set; }
        public Nullable<bool> Container_Interested { get; set; }
        public string Container_MSISDN { get; set; }
        public string Container_Email { get; set; }
        public Nullable<int> Container_Comm_Ch_Type { get; set; }
        public string Container_Comm_Ch_Address { get; set; }
        public string Container_Comm_Ch_Gateway { get; set; }
        public Nullable<bool> Container_Active { get; set; }
        public Nullable<int> Terminal_ID { get; set; }
        public Nullable<int> Container_Parent_ID { get; set; }
        public string Container_Password { get; set; }
        public string License_Code { get; set; }
        public Nullable<System.DateTime> Approval_Date { get; set; }
        public Nullable<System.DateTime> Approval_Expiry { get; set; }
        public string Approval_Interval { get; set; }
        public string Container_Picture { get; set; }
        public Nullable<int> RF_ID { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Parent_org_id { get; set; }
        public Nullable<int> Start_Point_ID { get; set; }
        public Nullable<int> End_Point_ID { get; set; }
        public Nullable<int> Sub_Route_ID { get; set; }
        public Nullable<double> TimeFactor { get; set; }
        public Nullable<double> CostFactor { get; set; }
        public Nullable<double> FixedCost { get; set; }
        public Nullable<double> DelayCostFactor { get; set; }
        public Nullable<int> SpcfPoint_ID { get; set; }
        public Nullable<int> SpcfPoint2ID { get; set; }
        public Nullable<int> scope { get; set; }
        public Nullable<int> Max_Range { get; set; }
        public Nullable<int> Remaning_Range { get; set; }
        public Nullable<int> Max_Time { get; set; }
        public Nullable<int> Remaining_Time { get; set; }
        public Nullable<int> Start_Time_Offset { get; set; }
        public Nullable<int> End_Time_Margin { get; set; }
        public Nullable<System.DateTime> Schd_Start_Time { get; set; }
        public Nullable<System.DateTime> Schd_End_Time { get; set; }
        public Nullable<double> Latitude_Now { get; set; }
        public Nullable<double> Longitude_Now { get; set; }
        public Nullable<int> Last_Index { get; set; }
        public Nullable<double> Last_Load { get; set; }
        public Nullable<double> Current_Offset { get; set; }
        public string Types_List { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Marker_Color { get; set; }
        public Nullable<double> Last_Time { get; set; }
        public string Anchor_Address { get; set; }
        public Nullable<double> Anchor_Lat { get; set; }
        public Nullable<double> Anchor_Lng { get; set; }
        public Nullable<int> Radius { get; set; }
        public Nullable<int> User2_ID { get; set; }
        public string Skills_List { get; set; }
        public Nullable<int> Route_ID { get; set; }
        public Nullable<int> Anchoring { get; set; }
        public string Start_Address { get; set; }
        public string End_Address { get; set; }
        public Nullable<double> Start_Latitude { get; set; }
        public Nullable<double> Start_Longitude { get; set; }
        public Nullable<double> End_Latitude { get; set; }
        public Nullable<double> End_Longitude { get; set; }
        public Nullable<bool> New_Address { get; set; }
        public Nullable<bool> CapacitiesUpdated { get; set; }
    
        public virtual ICollection<Container_Periods> Container_Periods { get; set; }
        public virtual Containers Containers1 { get; set; }
        public virtual Containers Containers2 { get; set; }
    }
}
