using System;
using System.Collections.Generic;
using WebServiceApp.DataModel;

namespace WebServiceApp.Repository
{
    public interface IPointPeriodsRepository : IDisposable
    {
        IEnumerable<Point_Periods> GetPointPeriods();
        Point_Periods GetPoint_PeriodsByID(int pointPeriodsId);
        void InsertPoint_Periods(Point_Periods pointPeriods);
        void DeletePoint_Periods(int pointPeriodsId);
        void UpdatePoint_Periods(Point_Periods pointPeriods);
        void Save();
        IEnumerable<Point_Periods> GetPoint_PeriodsByRouteID(int routeId);
    }
}