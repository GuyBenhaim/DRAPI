using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data;

using WebServiceApp.DataModel;

namespace WebServiceApp.Repository
{
    public class PointPeriodsRepository : IPointPeriodsRepository, IDisposable
    {
        Entities context;

        public PointPeriodsRepository(Entities context)
        {
            this.context = context;
        }

        public IEnumerable<WebServiceApp.DataModel.Point_Periods> GetPointPeriods()
        {
            return context.Point_Periods.ToList();
        }

        public Point_Periods GetPoint_PeriodsByID(int pointPeriodsId)
        {
            return context.Point_Periods.Find(pointPeriodsId);
        }

        // Select the points to be sent to the planner based on their Route_ID 
        public IEnumerable<Point_Periods> GetPoint_PeriodsByRouteID(int routeId)
        {
            return context.Point_Periods.Where(p => p.Route_ID == routeId).OrderBy(u => u.Preferred_Order).ToList();
        }

        // Select the points to be sent to the planner based on their Sub_Route_ID2
        public IEnumerable<Point_Periods> GetPoint_PeriodsByBoth(int routeID, int subrouteID)
        {
            return context.Point_Periods.Where(p => p.Route_ID == routeID && p.Sub_Route_ID == subrouteID).OrderBy(u => u.Preferred_Order).ToList();
        }

        /* Same as done for Point_Periods; but not working .... public IEnumerable<Object_Periods> GetObject_PeriodsByRouteID(int routeId)
        {
            return context.Object_Periods .Where(p => routeId == p.Route_ID).ToList();
        }
        */
        public void InsertPoint_Periods(Point_Periods pointPeriods)
        {
            // context.Points.Add(pointPeriods.Point);
            context.Point_Periods.Add(pointPeriods);
        }

        public void DeletePoint_Periods(int pointPeriodsId)
        {
            Point_Periods pointPeriods = context.Point_Periods.Find(pointPeriodsId);
            context.Point_Periods.Remove(pointPeriods);
        }

        public void UpdatePoint_Periods(Point_Periods pointPeriods)
        {
            context.Entry(pointPeriods).State = EntityState.Modified;
        }

        public int CreateSpecificPP(int RouteID)
        {
            return context.Create_PointPeriods(RouteID);
        }

        public List<Load_MAP_Route_Result> GetByID(int RouteID)
        {
            return context.Load_MAP_Route(RouteID.ToString(), "0").ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}