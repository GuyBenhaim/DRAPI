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
    
    public partial class Point_Periods
    {
        public int Point_Periods_ID { get; set; }
        public Nullable<int> Point_ID { get; set; }
        public Nullable<int> Generic_ID { get; set; }
        public Nullable<int> Route_ID { get; set; }
        public Nullable<int> Hierarchy { get; set; }
        public Nullable<int> Original_Route_ID { get; set; }
        public Nullable<int> Sub_Route_ID { get; set; }
        public Nullable<int> Sub_Route_ID2 { get; set; }
        public Nullable<int> Preferred_Order { get; set; }
        public Nullable<int> Order_ID { get; set; }
        public Nullable<int> Vehicle_ID { get; set; }
        public Nullable<int> Container_ID { get; set; }
        public Nullable<int> Run_Index { get; set; }
        public Nullable<bool> btIsMapRoute { get; set; }
        public string Sun { get; set; }
        public string Mon { get; set; }
        public string Tue { get; set; }
        public string Wed { get; set; }
        public string Thu { get; set; }
        public string Fri { get; set; }
        public string Sat { get; set; }
        public string Type { get; set; }
        public Nullable<int> Exclusion1_ID { get; set; }
        public Nullable<int> Exclusion2_ID { get; set; }
        public Nullable<int> Exclusion3_ID { get; set; }
        public Nullable<int> Exclusion4_ID { get; set; }
        public Nullable<int> Exclusion5_ID { get; set; }
        public Nullable<int> Org_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Drag_Points { get; set; }
        public string Start_Lat_Point { get; set; }
        public string Start_Long_Point { get; set; }
        public string End_Lat_Point { get; set; }
        public string End_Long_Point { get; set; }
        public string LatPoints { get; set; }
        public Nullable<int> Show { get; set; }
        public Nullable<System.DateTime> Standard_Time { get; set; }
        public string StdTime { get; set; }
        public string TravelMode { get; set; }
        public string Time_Span { get; set; }
        public Nullable<decimal> Location_Span { get; set; }
        public Nullable<int> Row { get; set; }
        public Nullable<decimal> Point_Orientation { get; set; }
        public string Point_Error { get; set; }
        public Nullable<decimal> Point_Time { get; set; }
        public Nullable<decimal> Point_Speed { get; set; }
        public Nullable<decimal> Point_Accl { get; set; }
        public Nullable<decimal> Point_Steering { get; set; }
        public Nullable<bool> Original { get; set; }
        public Nullable<bool> Hide { get; set; }
        public string sLongitude { get; set; }
        public string sLatitude { get; set; }
        public Nullable<int> StdTimeInt { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public Nullable<decimal> TW_Mins { get; set; }
        public Nullable<decimal> MaxSpeed { get; set; }
        public Nullable<decimal> Duration { get; set; }
        public Nullable<bool> Shared { get; set; }
        public Nullable<decimal> Range { get; set; }
        public Nullable<int> PickOrder_Index { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<System.DateTime> ActionUpdate { get; set; }
        public Nullable<decimal> TW_Update { get; set; }
        public Nullable<int> State0 { get; set; }
        public Nullable<decimal> Distance { get; set; }
        public Nullable<decimal> Time { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string RouteDesc { get; set; }
        public Nullable<int> StdMaxTimeInt { get; set; }
        public Nullable<decimal> ActionShiftMins { get; set; }
        public Nullable<System.DateTime> PlanningWinStart { get; set; }
        public Nullable<int> X { get; set; }
        public Nullable<int> Y { get; set; }
        public Nullable<decimal> MaxDuration { get; set; }
        public Nullable<bool> Specific { get; set; }
        public string ArrTime { get; set; }
        public string DepTime { get; set; }
        public string PointAdds { get; set; }
        public Nullable<int> Scope { get; set; }
        public Nullable<int> Plan_Index { get; set; }
        public string LatestDepTime { get; set; }
        public Nullable<decimal> MDistance { get; set; }
        public Nullable<decimal> MTime { get; set; }
        public Nullable<int> SetStep { get; set; }
        public Nullable<int> SetIndex { get; set; }
        public Nullable<int> DropOrder_Index { get; set; }
        public Nullable<int> SetSize { get; set; }
        public Nullable<int> StateTrial { get; set; }
        public Nullable<decimal> ActionShiftTrial { get; set; }
        public Nullable<decimal> TW_Trial { get; set; }
        public Nullable<double> Load_After { get; set; }
        public Nullable<int> Set_ID { get; set; }
        public Nullable<double> StdTimeFlt { get; set; }
        public Nullable<decimal> Slack { get; set; }
        public string cLatitude { get; set; }
        public string cLongitude { get; set; }
        public Nullable<int> cX { get; set; }
        public Nullable<int> cY { get; set; }
        public Nullable<int> Client_ID { get; set; }
        public string Mission { get; set; }
        public Nullable<System.DateTime> Updated_Time { get; set; }
        public Nullable<int> Facility_ID { get; set; }
        public Nullable<int> Concurrent { get; set; }
        public Nullable<int> ParentTask_Index { get; set; }
        public Nullable<bool> Keep_Vehicle { get; set; }
        public Nullable<bool> Keep_Order { get; set; }
        public Nullable<bool> Force_Vehicle { get; set; }
        public Nullable<int> Confidence { get; set; }
        public Nullable<int> Driver_ID { get; set; }
        public Nullable<int> Phase { get; set; }
        public Nullable<int> Delay { get; set; }
        public Nullable<int> Alert { get; set; }
        public Nullable<int> Skew { get; set; }
    
        public virtual Point Points { get; set; }
        public virtual Route Route { get; set; }
    }
}
