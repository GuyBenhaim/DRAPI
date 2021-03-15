using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;
using WebServiceApp.ServiceReference2;


namespace WebServiceApp
{
     public class WebServiceCalls
    {
        public static void CallWebService()
        {

            RoutePlannerServiceImplClient service = new RoutePlannerServiceImplClient();
            preparePlanRequest _pPR = new preparePlanRequest();
            

            RoutePoint[] _rp = new RoutePoint[2];
            PathPoint[]  _pp = new PathPoint[50];
            
            _rp[0] = new RoutePoint();
            _rp[0].hide = false;
            _rp[0].periodid = 999;
            _rp[0].point_Coordinates="120;140";
            _rp[0].point_Name = "first";
            _rp[0].point_Orientation = 90;
            _rp[0].point_Speed = 1;
            _rp[0].pointid = 1;
            _rp[0].preferred_Order = 1;
            _rp[0].req_id = 1;
            _rp[0].time = "111";
            _rp[0].user_Message = "nice day";
            _rp[0].weekday = "SAT";

            _rp[1] = new RoutePoint();
            _rp[1].hide = false;
            _rp[1].periodid = 999;
            _rp[1].point_Coordinates = "120;180";
            _rp[1].point_Name = "first";
            _rp[1].point_Orientation = 90;
            _rp[1].point_Speed = 1;
            _rp[1].pointid = 2;
            _rp[1].preferred_Order = 2;
            _rp[1].req_id = 1;
            _rp[1].time = "111";
            _rp[1].user_Message = "nice day";
            _rp[1].weekday = "SAT";


            // service.preparePlan(_rp); 
            List<PathPoint> list = service.preparePlan(_rp).ToList();
            list.ForEach(i => Console.Write("{0}\t", i));

           
        }
    }

}



//public static void CallWebService(Route_ID)
//{
//    var _url = "http://xxxxxxxxx/Service1.asmx";
//    var _action = "http://xxxxxxxx/Service1.asmx?op=HelloWorld";

//    XmlDocument soapEnvelopeXml = CreateSoapEnvelope();
//    HttpWebRequest webRequest = CreateWebRequest(_url, _action);
//    InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

//    // begin async call to web request.
//    IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);

//    // suspend this thread until call is complete. You might want to
//    // do something usefull here like update your UI.
//    asyncResult.AsyncWaitHandle.WaitOne();

//    // get the response from the completed web request.
//    string soapResult;
//    using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
//    {
//        using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
//        {
//            soapResult = rd.ReadToEnd();
//        }
//        Console.Write(soapResult);        
//    }
//}

//private static HttpWebRequest CreateWebRequest(string url, string action)
//{
//    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
//    webRequest.Headers.Add("SOAPAction", action);
//    webRequest.ContentType = "text/xml;charset=\"utf-8\"";
//    webRequest.Accept = "text/xml";
//    webRequest.Method = "POST";
//    return webRequest;
//}

//private static XmlDocument CreateSoapEnvelope()
//{
//    XmlDocument soapEnvelop = new XmlDocument();
//    soapEnvelop.LoadXml(@"<SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/1999/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/1999/XMLSchema""><SOAP-ENV:Body><HelloWorld xmlns=""http://tempuri.org/"" SOAP-ENV:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/""><int1 xsi:type=""xsd:integer"">12</int1><int2 xsi:type=""xsd:integer"">32</int2></HelloWorld></SOAP-ENV:Body></SOAP-ENV:Envelope>");
//    return soapEnvelop;
//}

//private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
//{
//    using (Stream stream = webRequest.GetRequestStream())
//    {
//        soapEnvelopeXml.Save(stream);
//    }
//}

