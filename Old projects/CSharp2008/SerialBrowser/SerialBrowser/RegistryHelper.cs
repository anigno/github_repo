using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Security.Permissions;
using System.Security.AccessControl;

namespace SerialBrowser
{
    public class RegistryHelper
    {
        private const string APPLICATION_DATA_SUB_KEY = "APPLICATION_DATA";

        public static void WriteApplicationData(string applicationName,string varName, string value)
        {
            RegistryKey subKey = Registry.CurrentUser.CreateSubKey(APPLICATION_DATA_SUB_KEY,RegistryKeyPermissionCheck.ReadWriteSubTree);
            RegistryKey appSubKey=subKey.CreateSubKey(applicationName,RegistryKeyPermissionCheck.ReadWriteSubTree);
            appSubKey.SetValue(varName, value, RegistryValueKind.String);
        }

        public static string ReadApplicationData(string applicationName, string varName)
        {
            RegistryKey subKey = Registry.CurrentUser.OpenSubKey(APPLICATION_DATA_SUB_KEY);
            RegistryKey appSubKey = subKey.OpenSubKey(applicationName);
            if (appSubKey == null) return null;
            return (string)appSubKey.GetValue(varName);
        }
    }
}
