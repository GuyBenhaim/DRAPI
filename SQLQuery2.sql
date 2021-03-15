update Session set Segment_K = null where Route_ID=654

select Container_ID,Plan_Index, sLatitude+','+sLongitude AS CCOR from Point_Periods where Route_ID=654 AND Container_ID=78 Order By Plan_Index

Select * from Session where Session_ID=1207

Update Session set Route_Location='0,0' where Session_ID=1207
