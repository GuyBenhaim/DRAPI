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
    
    public partial class Hierarchy
    {
        public int Hierarchy_ID { get; set; }
        public Nullable<int> Parent_Scenario_ID { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public Nullable<int> Parent_PPR_ID { get; set; }
        public Nullable<int> Parent_Action_Type_ID { get; set; }
        public Nullable<int> Child_ID { get; set; }
        public Nullable<int> Action_Type_Priority { get; set; }
    }
}
