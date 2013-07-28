using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ClientService
{
    class CPU : Hardware
    {
        private int numPhysicalCores = 0;
        private int numLogicalCores = 0;
        private string cpuUsage = "none";
        private string UpTime = "none"; 
        private int processes = 0;
        private int threads = 0;

        public CPU()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            ManagementObjectCollection searchList = searcher.Get();

            foreach (ManagementObject mo in searchList)
            {
                this.SetModel(mo["name"].ToString().Trim());
                this.SetManufacturer(mo["Manufacturer"].ToString().Trim());
                this.SetID(mo["ProcessorId"].ToString().Trim());

                //Remember to create an XP version
                this.numPhysicalCores = int.Parse(mo["NumberOfCores"].ToString());
                this.numLogicalCores = int.Parse(mo["NumberOfLogicalProcessors"].ToString());

            }

            searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_System");
            
            searchList = searcher.Get();

            try
            {

                foreach (ManagementObject mo in searchList)
                {
                    this.UpTime = mo["SystemUpTime"].ToString().Trim();
                    this.processes = int.Parse(mo["Processes"].ToString().Trim());
                    this.threads = int.Parse(mo["Threads"].ToString().Trim());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " something broke");
            }

            this.SetCPUUsage();

        }



        public void SetCPUUsage()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_PerfFormattedData_Counters_ProcessorInformation WHERE Name = '_Total'");

                ManagementObjectCollection searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    this.cpuUsage = ((long)100 - long.Parse(mo["PercentIdleTime"].ToString())).ToString().Trim() + '%';
                }
            }
            catch (ManagementException e)
            {
                Console.WriteLine("Error " + e.Message);
            }
        }

        public string GetCPUUsage()
        {
            try
            {
                this.SetCPUUsage();
                return this.cpuUsage;
            }
            catch (Exception e)
            {
                return "CPU error";
            }
        }

        public int GetNumPhysicalCores()
        {
            try
            {
                return this.numPhysicalCores;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int GetNumLogicalCores()
        {
            try
            {
                return this.numLogicalCores;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        /// <summary>
        /// Returns all details needed for showing CPU Usage
        /// Each detail seperated by $
        /// 1: Uptime
        /// 2: Utilisation
        /// 3: Threads
        /// 4: Processes
        /// </summary>
        /// <returns></returns>
        public string GetAllDetails()
        {

            string details = "";
            try
            {
                this.UpdateDetails();

                TimeSpan t = TimeSpan.FromSeconds(double.Parse(this.UpTime));

                string uptime = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                    t.Hours,
                    t.Minutes,
                    t.Seconds,
                    t.Milliseconds);

                details += uptime + '$' + this.GetCPUUsage() + '$' + this.threads.ToString() + '$' + this.processes.ToString();
            }
            catch (Exception e)
            {
                details = "None";
            }

            return details;
        }

        public void UpdateDetails()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_System");

            ManagementObjectCollection searchList = searcher.Get();

            foreach (ManagementObject mo in searchList)
            {
                this.UpTime = mo["SystemUpTime"].ToString().Trim();
                this.processes = int.Parse(mo["Processes"].ToString().Trim());
                this.threads = int.Parse(mo["Threads"].ToString().Trim());
            }

            this.SetCPUUsage();
        }
    }
}
