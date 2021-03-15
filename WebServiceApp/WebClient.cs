using System;
using System.Linq;
using System.Threading;
using WebServiceApp.Repository;
using WebServiceApp.ServiceReference2;
using WebServiceApp.DataModel;
using WebServiceApp;
using System.Collections.Generic;

namespace WebServiceApp
{
    public class PlanningClient
    {
        private int i = 0;
        private PointPeriodsRepository pointPeriodsRepository;
        string filePath = @"C:\Users\guy\Google Drive\Routes\Projects\Proto\Server\log.txt";

        public PlanningClient()
        {
            pointPeriodsRepository = new PointPeriodsRepository(new Entities());
        }

        // routeId used to fill the request to Planner from PPD; saveId used to save the response into PPD
        // mode=0 select points with routeID based on Route_ID in PPR; mode=1 select points based on Sub_Route_ID2 
        public int PreparePlan(int mode, List<Point_Periods> cl_h2_pprs, int originalRouteID, int hierarchy, int newRouteID, int subRouteID /*actually new specific H1 PPRID*/, 
                               int containerID, int orderID, DateTime startTime, int maxPO)
        {
            RoutePoint[] routePoints;
            using (var dbContext2 = new Entities())
            {
                try
                {
                    if (cl_h2_pprs.Count() < 2 ) { return -1; }
                    // routePoints = pointPeriodsRepository.GetPoint_PeriodsByRouteID(originalSubRouteID).Select(routePointsSelector).ToArray();
                    routePoints = cl_h2_pprs.Select(routePointsSelector).ToArray();
                    // else { routePoints = pointPeriodsRepository.GetPoint_PeriodsByBoth(GetSubRouteID, GetSubrouteID2).Select(routePointsSelector).ToArray(); }
                    var client = new RoutePlannerServiceImplClient();
                    var pathresponse = client.preparePlan(routePoints).OrderBy(u => u.time).ToList();

                    int total_time = pathresponse.Max(pr => int.Parse(pr.time));
                    if (mode == 0) {  return total_time; }

                    else
                    {
                        foreach (var pathPoint in pathresponse)
                        {   // When mode=1 the points shall be saved into PPR with Sub_Route_ID2 = routeID;
                            // Send also the value max_po by which to increment all preferred order, before saving them
                            var h2PointPeriod = new Point_Periods
                            {
                                Container_ID = containerID,
                                Order_ID = orderID,
                                Route_ID = newRouteID,
                                Original_Route_ID = originalRouteID, // Identified the H1 generic route (Replaces the 0 in the received set).
                                // If the Point_ID was null in the Planner Response (i.e. a Path Point) assign Point_ID=1, for original point of the Sub_Route use its Point_ID;
                                Point_ID = pathPoint.original == true ? Convert.ToInt32(pathPoint.pointid) : 1,
                                btIsMapRoute = true,
                                Hierarchy = hierarchy,
                                Sub_Route_ID = subRouteID, // PathP saves the generic/parent PPRID, later used to identify its generic OPRs and attach to the specific H2 Route.
                                Sub_Route_ID2 = int.Parse(pathPoint.periodid ?? "0"), //PathP returns the generic H2 PPRID to identify the returned point as matching
                                Point_Periods_ID = Convert.ToInt32(pathPoint.periodid),
                                sLongitude = pathPoint.point_Coordinates.Split(';')[0], // Must store in PPR, as there is no Point created in DB
                                sLatitude = pathPoint.point_Coordinates.Split(';')[1],
                                Point_Orientation = Math.Round(decimal.Parse(pathPoint.point_Orientation), 5),
                                Point_Speed = Math.Round(Convert.ToDecimal(pathPoint.point_Speed), 5),
                                Point_Accl = Math.Round(Convert.ToDecimal(pathPoint.point_Accl), 5),
                                Point_Steering = Math.Round(Convert.ToDecimal(pathPoint.point_Steering), 5),
                                // Increment by the highest Preferred_Order of the last planner response, after processing previous Sub_Route
                                Preferred_Order = pathPoint.preferred_Order == null ? default(int) : (maxPO + int.Parse(pathPoint.preferred_Order)),
                                Hide = bool.Parse(pathPoint.hide),
                                Original = pathPoint.original,
                                Point_Error = pathPoint.error, // Relevant only for definitive end/way points
                                Point_Time = Math.Round(decimal.Parse(pathPoint.time), 5),
                                StdTime = startTime.AddSeconds(Convert.ToDouble(pathPoint.time)).ToString("yyyy-MM-dd HH:mm:ss")
                            };
                            dbContext2.Point_Periods.Add(h2PointPeriod);
                        }
                        dbContext2.SaveChanges();
                    // dbContext.Point_Periods.Where(u => u.Sub_Route_ID == ppr.Point_Periods_ID && u.Original_Route_ID == 0).ToList().ForEach(u => dbContext.Point_Periods.Remove(u));
                        
                    // Point = "point", was earlier used with virtual Point parameter in Point_Periods in generating aux entries in DB.Points to obey FK contstraint of PPR.
                    }
                  return total_time;  // Return the updated max_po after adding the PathPoints
                }
                catch (Exception ex) {return -1;} // WebService.ErrorLog(filePath, e.ToString()); // Logger.Error(e, "Webservice call failed")   
            }
        }

        private RoutePoint routePointsSelector(Point_Periods pointPeriods)
        {
            var pointsRow = pointPeriods.Points;
            var routePoint = new RoutePoint()
            {
                req_id = GetNextReqId(),
                pointid = pointPeriods.Point_ID ?? default(int),
                periodid = pointPeriods.Point_Periods_ID,
                point_Orientation = (double)(pointsRow.Point_Orientation ?? 0),
                point_Coordinates = string.Format("{0};{1}", pointsRow.sLongitude, pointsRow.sLatitude),//pointsRow.sLatitude,
                preferred_Order = pointPeriods.Preferred_Order ?? 0,
                time = DateTime.Now.ToString("HH:mm:ss"),
                weekday = DateTime.Today.ToString("ddd"),
                hide = false
            };
            return routePoint;
        }

        private int GetNextReqId()
        {
            return Interlocked.Increment(ref i);
        }
    }
}
