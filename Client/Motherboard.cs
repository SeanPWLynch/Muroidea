using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Client
{
    class Motherboard : Hardware
    {
        private string SystemModel = "none";

        public Motherboard()
        {
            
            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");

                ManagementObjectCollection searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    this.SetManufacturer(mo["manufacturer"].ToString().Trim());
                    this.SetModel(mo["product"].ToString().Trim());
                    this.SetID(mo["SerialNumber"].ToString().Trim().Replace(",", null).Trim());
                }

                searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");

                searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    this.SystemModel = mo["model"].ToString().Trim();
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string GetSystemModel()
        {
            return this.SystemModel;
        }

    }
}