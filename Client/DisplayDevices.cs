using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Client
{
    class DisplayDevices : Hardware
    {

        public DisplayDevices[] myDevices;
        private int deviceNum = 0;
        private long deviceMem = 0;


        public DisplayDevices()
        {
            int counter = 0;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

            ManagementObjectCollection searchList = searcher.Get();

            this.myDevices = new DisplayDevices[searcher.Get().Count];

            try
            {

                foreach (ManagementObject mo in searchList)
                {
                    myDevices[counter] = new DisplayDevices(counter);
                    try
                    {
                        myDevices[counter].SetManufacturer(mo["AdapterCompatibility"].ToString().Trim());
                    }
                    catch (Exception e)
                    {
                        myDevices[counter].SetManufacturer("none");
                    }
                    try
                    {
                        myDevices[counter].SetModel(mo["name"].ToString().Trim());
                    }
                    catch (Exception e)
                    {
                        myDevices[counter].SetModel("none");
                    }
                    try
                    {
                        myDevices[counter].SetID(mo["deviceid"].ToString().Trim());
                    }
                    catch
                    {
                        myDevices[counter].SetID("none");
                    }
                    try
                    {
                        myDevices[counter].deviceMem = long.Parse(mo["adapterram"].ToString().Trim()) / 1048576;
                    }
                    catch
                    {
                        myDevices[counter].deviceMem = 0;
                    }
                    
                    counter++;

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DisplayDevices(int deviceNum)
        {
            this.deviceNum = deviceNum++;
        }

        public long GetDeviceMem()
        {
            return this.deviceMem;
        }
    }
}