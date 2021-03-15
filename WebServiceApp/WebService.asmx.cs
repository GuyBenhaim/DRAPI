using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Xml;
using System.Globalization;
using System.IO;
using WebServiceApp.ServiceGetAllPoints;
using System.Configuration;
using System.Data;
using System.Device.Location;
using WebServiceApp.DataModel;
using WebServiceApp.Repository;
using System.Data.Entity;
using System.Net;
using System.Xml.Linq;
using Accord.MachineLearning;
using Accord.Math.Distances;

namespace WebServiceApp
{
    /// Summary description for WebService
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService : System.Web.Services.WebService
    {
        private PointPeriodsRepository pointPeriodsRepository; // Add decleration for handling the Reposiroty methods
        string filePath = @"C:\Users\guy\Google Drive\Routes\Projects\Proto\Server\log.txt";
        public void ErrorLog(string sPathName, string sErrMsg)
        {
            try
            {
                StreamWriter sw = new StreamWriter(sPathName, true);
                sw.WriteLine(sErrMsg);
                sw.Flush();
                sw.Close();
            }
            catch (Exception)
            {
            }
        }

        public class ClusterRule
        {
            public int P { get; set; }
            public int? C { get; set; }
            public int? K1 { get; set; }
            public int? K2 { get; set; }
        }

        class Twins // Nor in AandR
        {
            public int PPR_ID { get; set; }
            public int? Set_ID { get; set; }
            public int? Preferred_Order { get; set; }
            public int? Container_ID { get; set; }
            public int? SetIndex { get; set; }
            public int? X { get; set; }
            public int? Y { get; set; }
            public int? PickOrder_Index { get; set; }
            public int? State0 { get; set; }
        }

        private static void ReadArray(int[,] array, bool printonlyGreaterThenValue = false)
        {
            // Get upper bounds for the array
            int bound0 = array.GetUpperBound(0);
            int bound1 = array.GetUpperBound(1);

            // Use for-loops to iterate over the array elements
            for (int variable1 = 0; variable1 <= bound0; variable1++)
            {
                for (int variable2 = 0; variable2 <= bound1; variable2++)
                {
                    var value = array[variable1, variable2];
                    if (printonlyGreaterThenValue == false || (printonlyGreaterThenValue == true && value > 0))
                    {
                        Console.WriteLine("Value Of " + variable1 + "," + variable2 + " is : " + value);
                    }
                }
            }
        }

        // GeoCode using GOOG, using indicated language (e.g. language="en") for the address texts
        public double[] GeoCode(string language, string Address)
        {
            double[] rslt = null;
            //Test: string address = "חיפה+ישראל";
            string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false&language={1}&key=AIzaSyDEHXuZr3sqg8eL72iPa3cLUMRqszDiI04",
                                                Uri.EscapeDataString(Address), Uri.EscapeDataString(language));
            WebRequest request = WebRequest.Create(requestUri);
            WebResponse response = request.GetResponse();
            XDocument xdoc = XDocument.Load(response.GetResponseStream());
            XElement result = xdoc.Element("GeocodeResponse").Element("result");

            if (result != null)
            {
                XElement locationElement = result.Element("geometry").Element("location");
                string lat = locationElement.Element("lat").Value;
                string lng = locationElement.Element("lng").Value;
                rslt = new double[2] { Convert.ToDouble(lat), Convert.ToDouble(lng) };
            }
            else
            {
                rslt = new double[2] { -1000, -1000 }; // Return a value that marks an error
            }
            return rslt; // retruns structure including Lat and Lng
        }

        public class CallAandR // Use to call AnaR via URKL, and get results via common DB
        {
            public string GetAandR(string aandr)
            {
                WebClient getAandR = new WebClient();
                string response = null;
                {
                    try
                    {
                        // open and read from the supplied URI
                        response = getAandR.DownloadString(aandr);
                    }
                    catch (WebException ex) // If exception of erred response code
                    {
                        if (ex.Response is HttpWebResponse || response == "-1")
                        {
                            // Add you own error handling as required
                            switch (((HttpWebResponse)ex.Response).StatusCode)
                            {
                                case HttpStatusCode.NotFound:
                                case HttpStatusCode.Unauthorized:
                                    response = null;
                                    break;
                                default:
                                    throw ex;
                            }
                        }
                    }
                }
                return response;
            }
        }

        public class CandidateVehicles
        {
            public int PPR_ID { get; set; }
            public int Container_ID { get; set; }
            public int Distance3D { get; set; }
            public int Capacity { get; set; }
            public string ContainerCapacities { get; set; }
            public int CostDiff { get; set; }
        }

        public class stPoint // Used by Segment Tracking, to hold a point and its attributes
        {
            public int PPR_ID { get; set; }
            public string Lat { get; set; }
            public string Lng { get; set; }
            public int? Plan_Index { get; set; }
            public int? State { get; set; }
            public int? Confidence { get; set; }
            public int? Pref_Order { get; set; }
            public double Distance2D { get; set; }
            public int Index { get; set; }
        }

        #region DRAPI
        [WebMethod]
        // The first "ActionID" may also reflect PickandDrop to identify P&D, on top of having a second entry in the call.
        // TW is given in minutes (i.e. Not in Ticks). Absolute time is in "action_date" and "action_datedr"

        public string DRAPI(int routeID, int orgID, string Mission, int taskID, string objectName, int objectBarCode, int? objecttypeID, int? demand, int? value /* covers both P&D */,
          DateTime? startdate, DateTime? enddate, string zone, string travelmode, string commslanguage,
          int? pointID, string pointAdds, double? pointLat, double? pointLng, DateTime? action_date, int? tw_mins,
          string actiontext, decimal? actionDuration, int? personID, int? commsactionID, string comms,
          int? pointIDdr, string pointAddsdr, double? pointLatdr, double? pointLngdr, DateTime? action_datedr, int? tw_minsdr,
          string actiontextdr, decimal? actionDurationdr, int? personIDdr, int? commsactionIDdr, string commsdr)

        {
            string filePath = @"C:\Users\guy\Google Drive\Routes\Projects\Proto\Server\log.txt";
            try
            {
                int ppr_id1 = -1;
                int ppr_id2 = -1;
                int objID = 1; // Void Object
                Boolean pickdrop = false;
                string ppr1_response = "";
                string ppr2_response = "";
                DateTime timenow = DateTime.Now;

                using (var dbContext = new DataModel.Entities())
                {
                    string language = "en"; //_Event.Event_Location;
                    string[] vals = { "Load", "Unload" }; // List of permitted Action categories
                    if (/*(startdate.HasValue && startdate > timenow) ||*/ (enddate.HasValue && enddate < timenow) || (enddate.HasValue && startdate.HasValue && enddate < startdate) ||
                       (action_date.HasValue && action_date < timenow) || (action_datedr.HasValue && action_datedr < timenow) || (action_date.HasValue && action_datedr.HasValue && action_datedr < action_date) ||
                       (tw_mins.HasValue && tw_mins < 0) || (tw_minsdr.HasValue && tw_minsdr < 0))
                    { return "Error: Rejected, Wrong Times"; }

                    double[] vertex1addr = { };
                    double[] vertex2addr = { };
                    var vertices = dbContext.ARConfig.Where(ar => ar.Route_ID == routeID).OrderByDescending(ar => ar.Id) // Get the two addresses that bound the activty area
                        .Select(x => new { x.vertex1, x.vertex2 }).FirstOrDefault();
                    bool verticesexit = (vertices != null && string.IsNullOrWhiteSpace(vertices.vertex1) == false && string.IsNullOrWhiteSpace(vertices.vertex2) == false); // If both addresses exist
                    if (verticesexit)
                    {
                        vertex1addr = GeoCode(language, vertices.vertex1);
                        vertex2addr = GeoCode(language, vertices.vertex2);
                    }

                    bool first_exists =  !string.IsNullOrWhiteSpace(actiontext); // There is a first action
                    bool first_comms = !string.IsNullOrWhiteSpace(comms) && commsactionID.HasValue; // There is comms for the first
                    bool second_exists = !string.IsNullOrWhiteSpace(actiontextdr); // There is a second action
                    bool second_comms = !string.IsNullOrWhiteSpace(commsdr) && commsactionIDdr.HasValue; // There is comms for the second

                    // If exist, use the Lat/Lng received in the request reparameters 
                    // For PPR1 if only address is provided, but NOT Point_ID and NOT Coordinates: Convert this address to Lat/Lng
                    if (first_exists && pointID == null && (pointLat == null || pointLng == null) && string.IsNullOrEmpty(pointAdds) == false)
                    {
                        double[] ppr1cord = GeoCode(language, pointAdds);
                        if (ppr1cord[0] != -1000) // Of Geocoding does not return erred indication
                        {
                            pointLat = ppr1cord[0];
                            pointLng = ppr1cord[1];
                        }
                        else
                        {return "Error: First task address cannot be decoded"; }
                    }
                    // Check if the request PPR1 diverges from the actvity area provided in ARC.  **(2) Note:Does not check for requests with Point_ID
                    if (Convert.ToDouble(pointLat) > Math.Max(Convert.ToDouble(vertex1addr[0]), Convert.ToDouble(vertex2addr[0])) ||
                        Convert.ToDouble(pointLat) < Math.Min(Convert.ToDouble(vertex1addr[0]), Convert.ToDouble(vertex2addr[0])) ||
                        Convert.ToDouble(pointLng) > Math.Max(Convert.ToDouble(vertex1addr[1]), Convert.ToDouble(vertex2addr[1])) ||
                        Convert.ToDouble(pointLng) < Math.Min(Convert.ToDouble(vertex1addr[1]), Convert.ToDouble(vertex2addr[1])))
                        { return "Error: First task location out of bounds"; }

                    // If exist, use the Lat/Lng received in the request reparameters
                    // For PPR2 if only address is provided, but not a Point_ID: Convert this address to Lat/Lng
                    if (second_exists && pointIDdr == null && (pointLatdr == null || pointLngdr == null) && string.IsNullOrWhiteSpace(pointAddsdr) == false)
                    {
                        double[] ppr2cord = GeoCode(language, pointAddsdr);
                        if (ppr2cord[0] != -1000) // Of Geocoding does not return erred indication
                        {
                            pointLatdr = ppr2cord[0];
                            pointLngdr = ppr2cord[1];
                        }
                        else
                        { return "Error: Second task address cannot be decoded"; }
                    }
                    // Check if the request PPR2 diverges from the actvity area provided in ARC.  **(2) Note:Does not check for requests with Point_ID
                    if  (second_exists &&
                        (Convert.ToDouble(pointLatdr) > Math.Max(Convert.ToDouble(vertex1addr[0]), Convert.ToDouble(vertex2addr[0])) ||
                        Convert.ToDouble(pointLatdr) < Math.Min(Convert.ToDouble(vertex1addr[0]), Convert.ToDouble(vertex2addr[0])) ||
                        Convert.ToDouble(pointLngdr) > Math.Max(Convert.ToDouble(vertex1addr[1]), Convert.ToDouble(vertex2addr[1])) ||
                        Convert.ToDouble(pointLngdr) < Math.Min(Convert.ToDouble(vertex1addr[1]), Convert.ToDouble(vertex2addr[1]))))
                    { return "Error: Second task location out of bounds"; }

                    // PPR1 / OPR1&2. When "actiontext" matches an Action_Type_Text in the DB whose Action_Type caetgory in the allowed categories list (vals)
                    var firstaction = dbContext.Actions_Type.Where(at => at.Action_Type_Text.ToLower() == actiontext.ToLower()).Select(at => new { at.Action_Type_ID, at.Action_Type }).FirstOrDefault();
                    if (firstaction != null && vals.Contains(firstaction.Action_Type)) // Check that Action is of Type(string) included in vals
                    {
                        // OBJ
                        DataModel.Object obj = new DataModel.Object(); // Generate an new Object
                        obj.Object_Type_ID = objecttypeID; // May need to match ID already that exists in Object_Type_ID (FK)
                        obj.Obj_Name = !string.IsNullOrEmpty(objectName) ? objectName : (objecttypeID.HasValue ? dbContext.Object_Types.Where(ot => ot.Object_Type_ID == objecttypeID).FirstOrDefault().Object_Type_Name : "Package");
                        obj.Obj_RF_ID = objectBarCode;
                        dbContext.Objects.Add(obj);
                        dbContext.SaveChanges();
                        objID = obj.Object_ID; // Generate Object UID

                        Point_Periods ppr1 = new Point_Periods();
                        ppr1.Hierarchy = 1;
                        ppr1.Route_ID = routeID;
                        ppr1.Point_ID = pointID;
                        ppr1.sLatitude = pointLat.ToString();
                        ppr1.sLongitude = pointLng.ToString();
                        ppr1.PointAdds = pointAdds; //Stores the original address
                        ppr1.Run_Index = null;
                        ppr1.Sub_Route_ID = null;
                        ppr1.btIsMapRoute = false;
                        ppr1.Preferred_Order = 0;
                        ppr1.Time_Span = "600";
                        ppr1.Location_Span = 500;
                        ppr1.Sun = "12:00";
                        ppr1.Mon = "12:00";
                        ppr1.Tue = "12:00";
                        ppr1.Wed = "12:00";
                        ppr1.Thu = "12:00";
                        ppr1.Fri = "12:00";
                        ppr1.Sat = "12:00";
                        ppr1.ActionDate = action_date; // if null Urbana plannner will use the AandR start time
                        ppr1.TW_Mins = tw_mins;
                        ppr1.StartDate = startdate ?? timenow; // Validity period of this task
                        ppr1.EndDate = enddate ?? timenow.AddYears(1);
                        ppr1.State0 = 1; //Registered by Urbana 
                        ppr1.Org_ID = orgID; // Record the initiator of task (in Objects), based on Object ID.
                        dbContext.Point_Periods.Add(ppr1);
                        dbContext.SaveChanges();
                        ppr_id1 = ppr1.Point_Periods_ID;

                        Object_Periods opr1 = new Object_Periods(); //Delivery Action
                        opr1.Hierarchy = 1;
                        opr1.Route_ID = routeID;
                        opr1.Point_ID = pointID ?? 1;
                        opr1.Object_ID = objID;
                        opr1.ObjectType_ID = objecttypeID;
                        opr1.Object_Action_ID = firstaction.Action_Type_ID; // The specfic type under the category
                        opr1.Action_Order = 0;
                        opr1.Duration = actionDuration; // Optional, as will use Action_Type's per-set  duration
                        opr1.Demand = demand ?? 0;
                        opr1.Penalty = value; // If null will later use the default in AandR
                        opr1.PPR_ID = ppr_id1;
                        opr1.Start_Date = timenow;
                        opr1.End_Date = timenow.AddYears(1);
                        opr1.Mon = true;
                        opr1.Tue = true;
                        opr1.Wed = true;
                        opr1.Thu = true;
                        opr1.Fri = true;
                        opr1.Sat = true;
                        opr1.Sun = true;
                        opr1.State = 1; //Recorded
                        dbContext.Object_Periods.Add(opr1);

                        // Generate the second ActionObject if comms parameters exist, in the request
                        Object_Periods opr2 = new Object_Periods(); // Comms Action
                        if (first_comms)
                        {
                            opr2.Hierarchy = 1;
                            opr2.Route_ID = routeID;
                            opr2.Point_ID = pointID ?? 1;
                            opr2.Object_ID = personID ?? 1;
                            opr2.ObjectType_ID = null;
                            opr2.Object_Action_ID = commsactionID ?? dbContext.Actions_Type.Where(at => at.Action_Type == "Default Comms").FirstOrDefault().Action_Type_ID;
                            opr2.Action_Order = 1;
                            opr2.Duration = actionDuration;
                            opr2.Demand = 0;
                            opr2.Penalty = 0;
                            opr2.PPR_ID = ppr_id1;
                            if (String.IsNullOrEmpty(comms)) { opr2.Play_Seq = "Glue_Txt:**;Point_Txt:0;Glue_Txt:,;Action_Txt:0;Glue_Txt:,;Object_Txt:0;Glue_Txt:**"; }
                            else { opr2.Play_Seq = "Glue_Txt:" + comms + ";"; }; // Assign message script or "comms" from DRAPI
                            opr2.Start_Date = timenow;
                            opr2.End_Date = timenow.AddYears(1);
                            opr2.Mon = true;
                            opr2.Tue = true;
                            opr2.Wed = true;
                            opr2.Thu = true;
                            opr2.Fri = true;
                            opr2.Sat = true;
                            opr2.Sun = true;
                            opr2.State = 1; // Recorded
                            dbContext.Object_Periods.Add(opr2);
                        }
                        dbContext.SaveChanges();
                        int opr_id1 = opr1.iObjPeriodID;
                        int opr_id2 = opr2.iObjPeriodID;

                        ppr1_response = "PPR1:" + ppr_id1.ToString() + " OPR1:" + opr_id1.ToString() + " OPR2:" + opr_id2.ToString();
                    }
                    else
                    { return "Error: First task action is missing or wrong"; }

                    // PPR2 / OPR3&4 
                    if (second_exists)
                    {
                        var secondaction = dbContext.Actions_Type.Where(at => at.Action_Type_Text.ToLower() == actiontextdr.ToLower()).Select(at => new { at.Action_Type_ID, at.Action_Type }).FirstOrDefault();
                        if (secondaction != null && vals.Contains(secondaction.Action_Type)) // Check that Action is of Type(string) included in vals
                        {
                            pickdrop = true; // Identify as Pick and Drop request
                            Point_Periods ppr2 = new Point_Periods();
                            ppr2.Hierarchy = 1;
                            ppr2.Route_ID = routeID;
                            ppr2.Point_ID = pointIDdr;
                            ppr2.sLatitude = pointLatdr.ToString();
                            ppr2.sLongitude = pointLngdr.ToString();
                            ppr2.PointAdds = pointAddsdr; //Stores the address text 
                            ppr2.Run_Index = null;
                            ppr2.Sub_Route_ID = null;
                            ppr2.btIsMapRoute = false;
                            ppr2.Preferred_Order = 0;
                            ppr2.Time_Span = "600";
                            ppr2.Location_Span = 500;
                            ppr2.Sun = "12:00";
                            ppr2.Mon = "12:00";
                            ppr2.Tue = "12:00";
                            ppr2.Wed = "12:00";
                            ppr2.Thu = "12:00";
                            ppr2.Fri = "12:00";
                            ppr2.Sat = "12:00";
                            ppr2.ActionDate = action_datedr; // if null will use time 0
                            ppr2.TW_Mins = tw_minsdr;
                            ppr2.StartDate = startdate ?? timenow;
                            ppr2.EndDate = enddate ?? timenow.AddYears(1);
                            ppr2.State0 = 1; //Registered
                            ppr2.PickOrder_Index = ppr_id1; // Indicates PPRID of the related Pickup entry
                            ppr2.Org_ID = orgID; // Record the initiator of task (in Objects), based on Object ID.
                            dbContext.Point_Periods.Add(ppr2);
                            dbContext.SaveChanges();
                            ppr_id2 = ppr2.Point_Periods_ID;

                            Object_Periods opr3 = new Object_Periods();//Delivery Action
                            opr3.Hierarchy = 1;
                            opr3.Route_ID = routeID;
                            opr3.Point_ID = pointID ?? 1;
                            opr3.Object_ID = objID;
                            opr3.ObjectType_ID = objecttypeID;
                            opr3.Object_Action_ID = secondaction.Action_Type_ID;
                            opr3.Action_Order = 0;
                            opr3.Duration = actionDurationdr;
                            opr3.Demand = demand ?? 0;
                            opr3.Penalty = value; // If null will use default in ARC
                            opr3.PPR_ID = ppr_id2;
                            opr3.Play_Seq = "Glue_Txt:" + commsdr + ";";
                            opr3.Start_Date = timenow;
                            opr3.End_Date = timenow.AddYears(1);
                            opr3.Mon = true;
                            opr3.Tue = true;
                            opr3.Wed = true;
                            opr3.Thu = true;
                            opr3.Fri = true;
                            opr3.Sat = true;
                            opr3.Sun = true;
                            opr3.State = 1; //Recorded
                            dbContext.Object_Periods.Add(opr3);

                            Object_Periods opr4 = new Object_Periods(); //Comms Action
                            if (second_comms)
                            {
                                opr4.Hierarchy = 1;
                                opr4.Route_ID = routeID;
                                opr4.Point_ID = pointIDdr ?? 1;
                                opr4.Object_ID = personIDdr ?? 1;
                                opr4.ObjectType_ID = null;
                                opr4.Object_Action_ID = commsactionIDdr ?? dbContext.Actions_Type.Where(at => at.Action_Type == "Default Comms").FirstOrDefault().Action_Type_ID;
                                opr4.Action_Order = 1;
                                opr4.Duration = actionDurationdr;
                                opr4.Demand = 0;
                                opr4.Penalty = 0;
                                opr4.PPR_ID = ppr_id2;
                                if (String.IsNullOrEmpty(commsdr)) { opr4.Play_Seq = "Glue_Txt:**;Point_Txt:0;Glue_Txt:,;Action_Txt:0;Glue_Txt:,;Object_Txt:0;Glue_Txt:**"; }
                                else { opr4.Play_Seq = "Glue_Txt:" + commsdr + ";"; }; // Assign message script or "commsdr" from DRAPI
                                opr4.Start_Date = timenow;
                                opr4.End_Date = timenow.AddYears(1);
                                opr4.Mon = true;
                                opr4.Tue = true;
                                opr4.Wed = true;
                                opr4.Thu = true;
                                opr4.Fri = true;
                                opr4.Sat = true;
                                opr4.Sun = true;
                                opr4.State = 1; //Recorded
                                dbContext.Object_Periods.Add(opr4);
                            }
                            dbContext.SaveChanges();
                            int opr_id3 = opr3.iObjPeriodID;
                            int opr_id4 = opr4.iObjPeriodID;

                            ppr2_response = "PPR2:" + ppr_id2.ToString() + " OPR3:" + opr_id3.ToString() + " OPR4:" + opr_id4.ToString();
                        }
                        // When actiontextdr has value, but it does not match an action type, generate an error.
                        else
                        { return "Error: Second task action is wrong"; }
                    }

                    if (pickdrop == false) { return ppr1_response; }
                    else { return ppr1_response + " " + ppr2_response; }
                }
            }
            catch (Exception ex)
            {
                ErrorLog(filePath, ex.ToString());
                return "Error: Runtime Exception";
            }
        }


        [WebMethod]
        // The first "ActionID" may also reflect PickandDrop to identify P&D, on top of having a second entry in the call.
        // TW is given in minutes (i.e. Not in Ticks). Absolute time is in "action_date" and "action_datedr"
        public string DRAPI_Get(int ppr1id, int? ppr2id)
        {
            using (var dbContext = new DataModel.Entities())
            {
                var info = dbContext.Point_Periods.Where(pp => pp.Point_Periods_ID == ppr1id || pp.Point_Periods_ID == (ppr2id ?? -1))
                         .Join(dbContext.Object_Periods, pp => pp.Point_Periods_ID, op => op.PPR_ID, (pp,op) => new { pp, op}).ToList();

                XElement xmlElements = new XElement("Tasks", info.Select(i => new XElement("Task", i)));
                return null; // xmlElements;
            }
        }


        [WebMethod]
        // Get or set the State (PPR State0) of a certain Task identified by PPR ID, via DRAPI
        // When two ids or set vales are provided use the second for the Drop; If not, find the Drop via PickOrder_Index
        public string DRAPI_State(bool get_set_n, int ppr1id, int? ppr2id, int? set_value1, int? set_value2)
        {
            using (var dbContext = new Entities())
            {
                if (get_set_n) // Get State
                {
                    var ppr1fields = dbContext.Point_Periods.Where(pp => pp.Point_Periods_ID == ppr1id)
                        .Select(pp => new { State0 = pp != null ? pp.State0 : -1, PPR_ID = pp != null ? pp.Point_Periods_ID : -1 }).FirstOrDefault();

                    var ppr2fields = (ppr2id != null) ?
                            dbContext.Point_Periods.Where(pp => pp.Point_Periods_ID == ppr2id).Select(x => new { State0 = (x != null ? x.State0 : -1) }).FirstOrDefault() :
                            dbContext.Point_Periods.Where(pp => pp.PickOrder_Index == ppr1fields.PPR_ID).Select(x => new { State0 = (x != null ? x.State0 : -1) }).FirstOrDefault();

                    return ppr1fields.State0.ToString() + "," + ppr2fields.State0.ToString();
                }

                else // Set State
                {
                    // Get the ppr and if not null set its State
                    var ppr1 = dbContext.Point_Periods.Where(pp => pp.Point_Periods_ID == ppr1id).FirstOrDefault();
                    if (ppr1 != null) { ppr1.State0 = set_value1 ; } else { set_value1 = -1; }

                    // Check if ppr2 and value to set are both provided, get the ppr and set its State 
                    var ppr2 = (ppr2id != null && set_value2 != null) ? dbContext.Point_Periods.Where(pp => pp.Point_Periods_ID == ppr2id).FirstOrDefault() : null;
                    if (ppr2 != null) { ppr2.State0 = set_value2;}  else { set_value2 = -1; }

                    dbContext.SaveChanges();

                    // If either the first or the second/drop PPR was not found return "-1"
                    return set_value1.ToString() + "," + set_value2.ToString() ;
                }
            }
        }
        #endregion
    }

    [Serializable()]
    public class ActionResult
    {
        public int Session_ID { get; set; }
        public int SetID { get; set; }
        public int Object_ID { get; set; }
        public string Action1_OK { get; set; }
        public string Action1_Time { get; set; }
        public string Point1_ID { get; set; }
        public string Action2_OK { get; set; }
        public string Action2_Time { get; set; }
        public string Point2_ID { get; set; }
        public string Action3_OK { get; set; }
        public string Action3_Time { get; set; }
        public string Point3_ID { get; set; }
    }
}