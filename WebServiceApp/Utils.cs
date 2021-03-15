using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceApp
{
    public enum KeyValue
    {
        DR,
        TR,
        CR,
        AScoreI,
        BScoreI,
        CScoreI,
        AScoreLoc,
        BScoreLoc,
        CScoreLoc,
        AScoreTime,
        BScoreTime,
        CScoreTime,
        NA
    }

    public class Utils
    {
        public static int getInteger(object value)
        {
            int retVal;
            if (int.TryParse(NullToString(value), out retVal))
            {
                return retVal;
            }
            else
            {
                return 0;
            }
        }
        public static string NullToString(Object obj)
        {
            return obj == null ? "" : obj.ToString();
        }

        public static string GetConfigValue(KeyValue Key)
        {
            if (System.Configuration.ConfigurationManager.AppSettings.AllKeys.Contains(Key.ToString()))
                return System.Configuration.ConfigurationManager.AppSettings[Key.ToString()];
            else
            {
                switch (Key)
                {
                    //case KeyValue.DR:
                    //    return "0";
                    //    break;
                    //case KeyValue.TR:
                    //    return "0";
                    //    break;
                    //case KeyValue.CR:
                    //    return "0";
                    //    break;
                    //case KeyValue.AScoreI:
                    //    return "0";
                    //    break;
                    //case KeyValue.BScoreI:
                    //    return "0";
                    //    break;
                    //case KeyValue.CScoreI:
                    //    return "0";
                    //    break;
                    //case KeyValue.AScoreLoc:
                    //    return "0";
                    //    break;
                    //case KeyValue.BScoreLoc:
                    //    return "0";
                    //    break;
                    //case KeyValue.CScoreLoc:
                    //    return "0";
                    //    break;
                    //case KeyValue.AScoreTime:
                    //    return "0";
                    //    break;
                    //case KeyValue.BScoreTime:
                    //    return "0";
                    //    break;
                    //case KeyValue.CScoreTime:
                    //    return "0";
                    //    break;
                    default:
                        return "";
                        break;
                }
            }
        }
    }
}