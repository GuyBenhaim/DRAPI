//------------------------------------------------------------------------------
//    Manually Generated
//------------------------------------------------------------------------------

namespace WebServiceApp.DataModel
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    public partial class Object_Vector
    {
         internal static void UpdateActionOK(int NA)
        {
            DatabaseGateway da = new DatabaseGateway();
            da.ExecuteNonQuery("proc_Object_Vector_UpdateActionOk", NA);
        }

        public static List<ActionResult> GetActionForSessionAndObject(int? session_ID, int? object_ID)
        {
            List<ActionResult> lstActionResults = new List<ActionResult>();
            DatabaseGateway da = new DatabaseGateway();
            DataTable dt = da.QueryForDataTable("proc_GetActions", session_ID, object_ID);
            if (dt.Rows.Count > 0)
            {
                ActionResult objActionResult;
                foreach (DataRow row in dt.Rows)
                {
                    if (row != null)
                    {
                        objActionResult = new ActionResult();
                        if (row.Table.Columns.Contains("Object_ID"))
                            objActionResult.Object_ID = (int)row["Object_ID"];

                        if (row.Table.Columns.Contains("Session_ID") && row["Session_ID"] != DBNull.Value)
                            objActionResult.Session_ID = Convert.ToInt32(row["Session_ID"]);
                        else
                            objActionResult.Session_ID = -1;

                        if (row.Table.Columns.Contains("Action1_OK") && row["Action1_OK"] != DBNull.Value)
                            objActionResult.Action1_OK = Convert.ToString(row["Action1_OK"]);
                        else
                            objActionResult.Action1_OK = string.Empty;
                        if (row.Table.Columns.Contains("Action2_OK") && row["Action2_OK"] != DBNull.Value)
                            objActionResult.Action2_OK = Convert.ToString(row["Action2_OK"]);
                        else
                            objActionResult.Action2_OK = string.Empty;
                        if (row.Table.Columns.Contains("Action3_OK") && row["Action3_OK"] != DBNull.Value)
                            objActionResult.Action3_OK = Convert.ToString(row["Action3_OK"]);
                        else
                            objActionResult.Action3_OK = string.Empty;

                        if (row.Table.Columns.Contains("Action1_Time") && row["Action1_Time"] != DBNull.Value)
                            objActionResult.Action1_Time = Convert.ToString(row["Action1_Time"]);
                        else
                            objActionResult.Action1_Time = string.Empty;

                        if (row.Table.Columns.Contains("Action2_Time") && row["Action2_Time"] != DBNull.Value)
                            objActionResult.Action2_Time = Convert.ToString(row["Action2_Time"]);
                        else
                            objActionResult.Action2_Time = string.Empty;

                        if (row.Table.Columns.Contains("Action3_Time") && row["Action3_Time"] != DBNull.Value)
                            objActionResult.Action3_Time = Convert.ToString(row["Action3_Time"]);
                        else
                            objActionResult.Action3_Time = string.Empty;


                        if (row.Table.Columns.Contains("Point1_ID") && row["Point1_ID"] != DBNull.Value)
                            objActionResult.Point1_ID = Convert.ToString(row["Point1_ID"]);
                        else
                            objActionResult.Point1_ID = string.Empty;

                        if (row.Table.Columns.Contains("Point2_ID") && row["Point2_ID"] != DBNull.Value)
                            objActionResult.Point2_ID = Convert.ToString(row["Point2_ID"]);
                        else
                            objActionResult.Point2_ID = string.Empty;

                        if (row.Table.Columns.Contains("Point3_ID") && row["Point3_ID"] != DBNull.Value)
                            objActionResult.Point3_ID = Convert.ToString(row["Point3_ID"]);
                        else
                            objActionResult.Point3_ID = string.Empty;

                        lstActionResults.Add(objActionResult);
                    }
                }
                return lstActionResults;
            }
            else
                return lstActionResults;
        }
    }
}