using System;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace AnignoraFinanceAnalyzer5.MainManagement
{
    public class AfaCommon
    {
        public static string GetLoggedUser()
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string loggedUsername = windowsIdentity != null ? windowsIdentity.Name : "NoName";
            return loggedUsername;
        }
        public static string GetNetworkDataString()
        {
            StringBuilder sb = new StringBuilder();
            string machineName = Environment.MachineName;
            string hostName = Dns.GetHostName();
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string loggedUsername = windowsIdentity != null ? windowsIdentity.Name : "NoName";
            sb.AppendFormat(" [{0}] ", loggedUsername);
            sb.AppendFormat(" [{0},{1}]\n ", machineName, hostName);
            IPHostEntry host = Dns.GetHostEntry(hostName);
            foreach (IPAddress ip in host.AddressList)
            {
                sb.AppendFormat(" [{0}-{1}]\n ", ip.AddressFamily, ip);
            }
            return sb.ToString();
        }
    }
}