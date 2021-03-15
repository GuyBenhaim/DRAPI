﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;

    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Point> Points { get; set; }
        public DbSet<Actions_Type> Actions_Type { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<User_Periods> User_Periods { get; set; }
        public DbSet<RouteType> RouteTypes { get; set; }
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Object> Objects { get; set; }
        public DbSet<Point_Type> Point_Type { get; set; }
        public DbSet<Object_Types> Object_Types { get; set; }
        public DbSet<Hierarchy> Hierarchy { get; set; }
        public DbSet<Box_State> Box_State { get; set; }
        public DbSet<Point_Periods> Point_Periods { get; set; }
        public DbSet<CTConfig> CTConfig { get; set; }
        public DbSet<Arry> Arry { get; set; }
        public DbSet<ArryMul> ArryMul { get; set; }
        public DbSet<Container_Periods> Container_Periods { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<ARConfig> ARConfig { get; set; }
        public DbSet<Containers> Containers { get; set; }
        public DbSet<Object_Vector> Object_Vector { get; set; }
        public DbSet<Object_Periods> Object_Periods { get; set; }
        public DbSet<SegmentTracking> SegmentTracking { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<AdminState> AdminState { get; set; }
        public DbSet<Object_Periods_Files> Object_Periods_Files { get; set; }
    
        public virtual int Create_PointPeriods(Nullable<int> route_ID)
        {
            var route_IDParameter = route_ID.HasValue ?
                new ObjectParameter("Route_ID", route_ID) :
                new ObjectParameter("Route_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Create_PointPeriods", route_IDParameter);
        }
    
        public virtual ObjectResult<Load_MAP_Route_Result> Load_MAP_Route(string iD, string containerId)
        {
            var iDParameter = iD != null ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(string));
    
            var containerIdParameter = containerId != null ?
                new ObjectParameter("ContainerId", containerId) :
                new ObjectParameter("ContainerId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Load_MAP_Route_Result>("Load_MAP_Route", iDParameter, containerIdParameter);
        }
    }
}