using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ClientService
{

    class RAM : Hardware
    {
        private long totalRAM = 0;
        public RAM[] installedRAM;
        private int numModules = 0;
        private int moduleNumber = 0;
        private string speed = "none";
        private long moduleSize = 0;
        private long freeRAM = 0;

        public RAM()
        {
            int counter = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");

            ManagementObjectCollection searchList = searcher.Get();

            
            this.numModules = searcher.Get().Count;
            this.installedRAM = new RAM[numModules];

            foreach (ManagementObject mo in searchList)
            {
                installedRAM[counter] = new RAM(counter);
                try
                {
                    installedRAM[counter].SetManufacturer(mo["manufacturer"].ToString().Trim());
                }
                catch (Exception e)
                {
                    installedRAM[counter].SetManufacturer("none");
                }

                try
                {
                    installedRAM[counter].SetModel(mo["partnumber"].ToString().Trim());
                }
                catch (Exception e)
                {
                    installedRAM[counter].SetModel("none");
                }

                try
                {
                    installedRAM[counter].SetID(mo["serialnumber"].ToString().Trim());
                }
                catch (Exception e)
                {
                    installedRAM[counter].SetID("none");
                }

                try
                {
                    installedRAM[counter].speed = mo["speed"].ToString().Trim() + "MHz";
                }
                catch (Exception e)
                {
                    installedRAM[counter].speed = "none";
                }

                try
                {
                    installedRAM[counter].moduleSize = long.Parse(mo["capacity"].ToString().Trim()) / 1048576;
                }
                catch (Exception e)
                {
                    installedRAM[counter].moduleSize = 0;
                }
                counter++;
            }
        }

        public RAM(int moduleNumber)
        {
            this.moduleNumber = moduleNumber;
        }

        public long GetTotalRAM()
        {
            this.totalRAM = 0;
            try
            {
                for (int i = 0; i < 2; i++)
                {
                    this.totalRAM += this.installedRAM[i].moduleSize;
                }
            }
            catch (Exception e)
            {

            }
            return totalRAM;
        }

        public int GetNumModules()
        {
            return this.numModules;
        }

        public int GetModuleNumber()
        {
            return this.moduleNumber;
        }

        public string GetModuleSpeed()
        {
            return this.speed;
        }

        public long GetModuleSize()
        {
            return this.moduleSize;
        }

        public void SetFreeRAM()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

                ManagementObjectCollection searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    this.freeRAM = long.Parse(mo["FreePhysicalMemory"].ToString().Trim()) / 1024;
                }
            }
            catch (Exception e)
            {

            }
        }

        public long GetFreeRAM()
        {
            this.SetFreeRAM();
            return this.freeRAM;
        }

        /// <summary>
        /// Returns string containing all RA details seperated by '$'
        /// 0: Total RAM
        /// 1: Free RAM
        /// 2: RAM In Use
        /// </summary>
        /// <returns></returns>
        public string GetRAMDetails()
        {
            string details = "";
            try
            {
                details += this.GetTotalRAM() + "MB$" + this.GetFreeRAM() + "MB$" + (this.GetTotalRAM() - this.GetFreeRAM()) + "MB";
            }
            catch (Exception e)
            {
                details = "RAM error";
            }

            return details;
        }

    }
}

