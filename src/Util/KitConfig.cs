using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;

namespace Com.Migocorp.BJRD.Event.CheckIn.Util
{
    public class KitConfig
    {
        public static string GetKeyStr(string name, string defaultValue)
        {
            return ConfigurationManager.AppSettings[name] == null ? defaultValue : ConfigurationManager.AppSettings[name];
        }

        public static bool GetKeyBool(string name, bool defaultValue)
        {
            return Convert.ToBoolean(GetKeyStr(name, "false"));
        }

        public static int GetKeyInt(string name, int defaultValue)
        {
            return KitStr.parseInt(name, defaultValue);
        }

    }
}