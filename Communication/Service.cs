// -----------------------------------------------------------------------
// <copyright file="Service.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Communication
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceProcess;
    using System.Security.Permissions;
    using System.Management;

    [Serializable]
    public class Service
    {
        private string serviceName;
        private string serviceType;
        private string displayName;
        private string status;

        public Service(string serviceName, string serviceType, string displayName, string status)
        {
            this.serviceName = serviceName;
            this.serviceType = serviceType;
            this.displayName = displayName;
            this.status = status;
           // this.serviceController = serviceController;
        }

        public string StartService()
        {
            ServiceController sc = GetController();
            if (sc.Status != ServiceControllerStatus.Running)
            {
                try
                {
                    sc.Start();
                    return "Service started successfully";
                }
                catch (Exception ae)
                {
                    return "Problem starting Service. Is it enabled?";
                }
            }
            else
            {
                return "Service already running";
            }
        }

        public string Enable()
        {
            
            if (this.GetStartupType()!="Manual")
            {
                try
                {
                    string path = "Win32_Service.Name='" + this.serviceName + "'";
                    ManagementPath p = new ManagementPath(path);
                    ManagementObject ManagementObj = new ManagementObject(p);
                    object[] parameters = new object[1];
                    parameters[0] = "Manual";
                    ManagementObj.InvokeMethod("ChangeStartMode", parameters); 
                    return "Service has been enabled to be automatic";
                }
                catch (UnauthorizedAccessException ae)
                {
                    return "Error enabling.";
                }
            }
            else
            {
                return "Service already enabled";
            }
        }

        public string Disable()
        {
            if (this.GetStartupType() != "Disabled")
            {
                try
                {
                    string path = "Win32_Service.Name='" + this.serviceName + "'";
                    ManagementPath p = new ManagementPath(path);
                    ManagementObject ManagementObj = new ManagementObject(p);
                    object[] parameters = new object[1];
                    parameters[0] = "Disabled";
                    ManagementObj.InvokeMethod("ChangeStartMode", parameters);
                    return "Service has been enabled to be manual";
                }
                catch (UnauthorizedAccessException ae)
                {
                    return "Error disabling.";
                }
            }
            else
            {
                return "Service already disabled";
            }
        }

        public string StopService()
        {
            ServiceController sc = GetController();
            if (sc.Status != ServiceControllerStatus.Stopped)
            {
                try
                {
                    sc.Stop();
                    return "Service stopped successfully";
                }
                catch (Exception ae)
                {
                    return "Problem stopping Service. Is it enabled?";
                }
            }
            else
            {
                return "Service already stopped";
            }
            
        }

        public string RestartService()
        {
            ServiceController sc = GetController();
            if (sc.Status != ServiceControllerStatus.Running)
            {
                try
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    sc.Start();
                    return "Service restarted successfully";
                }
                catch (Exception ae)
                {
                    return "Problem restarting Service. Is it enabled?";
                }
            }
            else
            {
                return "Service not running";
            }
        }

        public string GetServiceName()
        {
            return serviceName;
        }

        public string GetServiceType()
        {
            return serviceType;
        }

        public string GetDisplayName()
        {
            return displayName;
        }

        public string GetStatus()
        {
            return status;
        }

        public string GetStartupType()
        {
            try
            {

            //construct the management path
            string path = "Win32_Service.Name='" + this.serviceName + "'";
            ManagementPath p = new ManagementPath(path);
            //construct the management object
            ManagementObject ManagementObj = new ManagementObject(p);
            return ManagementObj["StartMode"].ToString();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "N/A";
            }
        }

        private ServiceController GetController()
        {
            ServiceController serviceController;
            ServiceController[] services = ServiceController.GetServices();
            serviceController = services.FirstOrDefault(s => s.ServiceName == serviceName);
            return serviceController;
        }

        public string Auto()
        {
            if (this.GetStartupType() != "Auto")
            {
                try
                {
                    string path = "Win32_Service.Name='" + this.serviceName + "'";
                    ManagementPath p = new ManagementPath(path);
                    ManagementObject ManagementObj = new ManagementObject(p);
                    object[] parameters = new object[1];
                    parameters[0] = "Auto";
                    ManagementObj.InvokeMethod("ChangeStartMode", parameters);
                    return "Service has been enabled to be automatic";
                }
                catch (UnauthorizedAccessException ae)
                {
                    return "Error making service automatic.";
                }
            }
            else
            {
                return "Service already set as automatic";
            }
        }
    }
}
