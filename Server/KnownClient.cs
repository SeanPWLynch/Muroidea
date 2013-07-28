using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{

    class KnownClient
    {
            private string compid;
            private string os;
            private string compname;
            private string groupid;
            private string sysid;
            private string mac;
            private static string uptime = "OFFLINE";

        public KnownClient(string compid, string os, string compname, string groupid, string sysid, string mac)
        {
            this.compid = compid;
            this.os = os;
            this.compname = compname;
            this.groupid = groupid;
            this.sysid = sysid;
            this.mac = mac;
        }

        public string GetCompID()
        {
            return this.compid;
        }

        public string GetComputerName()
        {
            return this.compname;
        }

        public string GetClientIP()
        {
            return "N/A";
        }

        public string GetPort()
        {
            return "N/A";
        }

        public string GetGroupName()
        {
            return "OFFLINE";
        }

        public string GetUptime()
        {
            return uptime;
        }

    }
}
