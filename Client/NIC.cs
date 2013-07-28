using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Client
{
    class NIC : Hardware
    {
        private long KBytesIn = 0; //Current MBytes Per Second In
        private long KBytesOut = 0; //Current MBytes Per Second Out
        private long KBytesTotal = 0; //Current MBytes Per Second Total
        public NIC[] NICS;


        public NIC()
        {
            
            int counter = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");

            this.NICS = new NIC[searcher.Get().Count];

            ManagementObjectCollection searchList = searcher.Get();

            foreach (ManagementObject mo in searchList)
            {
                this.NICS[counter] = new NIC(mo["Name"].ToString().Trim());
                try
                {
                    this.NICS[counter].SetManufacturer(mo["Name"].ToString().Split(' ')[0]);
                }
                catch(Exception ex)
                {
                    this.NICS[counter].SetManufacturer(mo["Name"].ToString().Trim());
                }
                try
                {
                    this.NICS[counter].SetID(mo["Name"].ToString().Split(' ')[1]);
                }
                catch (Exception ex)
                {
                    this.NICS[counter].SetID(mo["Name"].ToString().Trim());
                }
                this.NICS[counter].KBytesIn = long.Parse(mo["BytesReceivedPersec"].ToString().Trim()) / 1024 ;
                this.NICS[counter].KBytesOut = long.Parse(mo["BytesSentPersec"].ToString().Trim()) / 1024 ;
                this.NICS[counter].KBytesTotal = long.Parse(mo["BytesTotalPersec"].ToString().Trim()) / 1024 ;
                counter++;
            }
            //this.SetBandwidth();
        }

        public NIC(string name)
        {
            this.SetModel(name);
        }

        public void SetBandwidth()
        {
            int counter = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_Tcpip_NetworkInterface");

            ManagementObjectCollection searchList = searcher.Get();

            foreach (ManagementObject mo in searchList)
            {
                try
                {
                    this.NICS[counter].KBytesIn = long.Parse(mo["BytesReceivedPersec"].ToString().Trim()) / 1024 ;
                }
                catch (Exception ex)
                {
                    this.NICS[counter].KBytesIn = 0;
                }
                try
                {

                    this.NICS[counter].KBytesOut = long.Parse(mo["BytesSentPersec"].ToString().Trim()) / 1024 ;
                }
                catch (Exception ex)
                {
                    this.NICS[counter].KBytesOut = 0;
                }
                try
                {

                    this.NICS[counter].KBytesTotal = long.Parse(mo["BytesTotalPersec"].ToString().Trim()) / 1024 ;
                }
                catch (Exception ex)
                {
                    this.NICS[counter].KBytesTotal = 0;
                }
                counter++;
            }
        }

        public string GetNICUsage()
        {
            string usage = "";
            try
            {
                int limit = 0;
                if (NICS.Length >= 5)
                {
                    limit = 5;
                }
                else
                {
                    limit = NICS.Length;
                }
                for (int i = 0; i < limit; i++)
                {
                    usage += NICS[i].GetModel() + Environment.NewLine;
                    this.SetBandwidth();
                    usage += "Current Speed In: " + NICS[i].KBytesIn + " KB/s" + Environment.NewLine;
                    usage += "Current Speed Out: " + NICS[i].KBytesOut + " KB/s" + Environment.NewLine;
                    usage += "Current Total Speed: " + NICS[i].KBytesTotal + " KB/s" + Environment.NewLine + '$';
                }
            }
            catch (Exception e)
            {
                usage = "NIC error";
            }
            return usage;
        }
    }
}
