using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace ClientService
{
    class Volumes : Hardware
    {

        public Volumes[] drives;
        private string driveLetter = "none";
        private string osDrive = "none";
        private string fileSystem = "none";
        private long driveCap = 0;
        private long freeSpace = 0;
        private string volUsage = "none";

        public Volumes()
        {
            int counter = 0;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Volume");

                ManagementObjectCollection searchList = searcher.Get();

                this.drives = new Volumes[searcher.Get().Count];

                foreach (ManagementObject mo in searchList)
                {
                    try
                    {
                        try
                        {
                            this.drives[counter] = new Volumes(mo["driveletter"].ToString().Trim() + @"\");
                        }
                        catch (System.Exception ex)
                        {
                           this.drives[counter] = new Volumes("Not Applicable");
                        }

                        try
                        {
                            this.drives[counter].osDrive = mo["bootvolume"].ToString().Trim();
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].osDrive = "Not Applicable";
                        }

                        try
                        {
                            this.drives[counter].fileSystem = mo["filesystem"].ToString().Trim();
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].fileSystem = "Not Applicable";
                        }

                        try
                        {
                            this.drives[counter].driveCap = long.Parse(mo["capacity"].ToString().Trim()) / 1073741824;
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].driveCap = 0;
                        }

                        try
                        {
                            this.drives[counter].freeSpace = long.Parse(mo["freespace"].ToString().Trim()) / 1073741824;
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].freeSpace = 0;
                        }

                        try
                        {
                            this.drives[counter].SetID(mo["DeviceID"].ToString().Trim().Replace(@"\", "").Replace("?", "").Replace("Volume", "").Replace("{", "").Replace("}", "").Replace("-", "").Trim());
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].SetID("Not Applicable");
                        }

                        try
                        {
                            this.drives[counter].SetManufacturer("Not Applicable");
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].SetManufacturer("Not Applicable");
                        }

                        try
                        {
                            this.drives[counter].SetModel("Not Applicable");
                        }
                        catch (System.Exception ex)
                        {
                            this.drives[counter].SetModel("Not Applicable");
                        }
                        counter++;
                    }
                        
                    catch (System.Exception ex)
                    {
                        
                    }

                }

        }

        public Volumes(string driveLetter)
        {
            this.driveLetter = driveLetter;
        }

        public string GetDriveLetter()
        {
            return this.driveLetter;
        }

        public string GetOSDrive()
        {
            return this.osDrive;
        }

        public string GetFileSystem()
        {
            return this.fileSystem;
        }

        public long GetDriveCapacity()
        {
            return this.driveCap;
        }

        public long GetFreeSpace()
        {
            return this.freeSpace;
        }

        public void SetVolUsage()
        {
            string usage = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfDisk_LogicalDisk");
            ManagementObjectCollection searchList = searcher.Get();

            foreach (ManagementObject mo in searchList)
            {
                if (mo["Name"].ToString().Trim() == "_Total")
                {
                    usage += "Total For All Drives: " + Environment.NewLine;
                }
                else
                {
                    usage += "Drive: " + mo["Name"].ToString().Trim() + @"\" + Environment.NewLine; 
                }
                usage += "Read Speed: " + long.Parse(mo["DiskReadBytesPersec"].ToString().Trim()) / 1024 + "KB/s" + Environment.NewLine;
                usage += "Write Speed: " + long.Parse(mo["DiskWriteBytesPersec"].ToString().Trim()) / 1024 + "KB/s" + Environment.NewLine;
                usage += '$';
            }
            this.volUsage = usage;
        }

        public string GetVolUsage()
        {
            try
            {
                this.SetVolUsage();
                return this.volUsage;
            }
            catch (Exception e)
            {
                return "Volume error";
            }
        }

    }
}
