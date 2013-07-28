using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceProcess;
using Communication;
using System.Security.Principal;
namespace ClientService
{
    public class Computer
    {
        private string compID;
        private ClientService client;
        private CPU compCPU;
        private Motherboard compMobo;
        private RAM compRAM;
        private Volumes compVols;
        private DisplayDevices compDisplays;
        private NIC compNICS;
        private List<Process> ProcList;
        private List<Communication.Service> services;

        public Computer(ClientService client)
        {
            this.compID = client.GetCompID();
            this.client = client;
            services = new List<Communication.Service>();
        }

        public void Init() 
        {
            // TODO: Complete member initialization
            Console.WriteLine("Getting CPU Information");
            compCPU = new CPU();

            Console.WriteLine("Getting Motherboard Information");
            compMobo = new Motherboard();

            Console.WriteLine("Getting RAM Information");
            compRAM = new RAM();

            Console.WriteLine("Getting Drive Information");
            compVols = new Volumes();


            Console.WriteLine("Getting Display Adapter Information");
            compDisplays = new DisplayDevices();


            Console.WriteLine("Getting NIC Information");
            compNICS = new NIC();

            Console.WriteLine("Getting Service Information");
            //Getting services information
            UpdateServices();
            Console.WriteLine("Init Complete");
        }

        public ClientService GetClient()
        {
            return this.client;
            
        }

        /// <summary>
        /// Returns the current IP address of the computer.
        /// </summary>
        /// <returns>Returns the IP address in string form.</returns>
        public string GetIPAddress() { return null; }

        /// <summary>
        /// Returns the current RAM usage in percentage form.
        /// </summary>
        /// <returns>Retuns the RAM usage.</returns>
        public int GetRAMUsage() { return 0; }

        /// <summary>
        /// Returns the current CPU usage in percentage form.
        /// </summary>
        /// <returns>Retuns the CPU usage.</returns>
        public int GetCPUUsage() { return 0; }

        /// <summary>
        /// Gets a list of Hardware components in the computer.
        /// Index 0 = CPU
        /// Index 1 = Motherboard
        /// Index 2 = RAM
        /// Index 3 = Volumes
        /// Index 4 = Display Adapters
        /// Index 5 = NICS
        /// </summary>
        /// <returns>Returns a list of hardware objects.</returns>
        public Hardware[] GetHardware() 
        {

            Hardware[] hardwareArray = {compCPU, compMobo, compRAM, compVols, compDisplays, compNICS};

            return hardwareArray;
        }

        /// <summary>
        /// Gets a list of currently running Processes.
        /// </summary>
        /// <returns>Returns a list of Process.</returns>
        public Process[] GetRunningProcesses() 
        { 
            ///For each process found in the WMI create and add them to an array
            ///then return this array


            return null; 
        }

        /// <summary>
        /// Gets a list of currently running Services.
        /// </summary>
        /// <returns>Returns a list of Service.</returns>
        public Service[] GetRunningServices() 
        {
            return null;
        }

       /* /// <summary>
        /// Gets a list of all Processes.
        /// </summary>
        /// <returns>Returns a list of Process.</returns>
        public Process GetAllProcess() 
        {
            foreach (Process proc in compProcess.ProcessList)
            {
                proc.UpdateProcessDetails();
            }
            return this.compProcess; 
        }*/

        public List<Process> ReturnProcesses()
        {
            ProcList = new List<Process>();



            System.Threading.Tasks.Parallel.ForEach(System.Diagnostics.Process.GetProcesses(), proc =>
             {
                 try
                 {
                     System.Diagnostics.PerformanceCounter pcounter = new System.Diagnostics.PerformanceCounter("Process", "% Processor Time", proc.ProcessName, true);
                     pcounter.NextValue();
                     Thread.Sleep(110); // Required For Accurate Reading
                     ProcList.Add(new Process(proc.ProcessName, proc.Id, Convert.ToInt32(pcounter.NextValue()) / Environment.ProcessorCount, proc.Threads.Count, (int)proc.WorkingSet64 / 1024));
                 }
                 catch (Exception e)
                 {

                 }
             });

            return ProcList;
        }

        /// <summary>
        /// Gets a list of all Services.
        /// </summary>
        /// <returns>Returns a list of Service.</returns>
        public Service[] GetAllServices() { return null; }

        /// <summary>
        /// Send a message to the computer for the user to see.
        /// </summary>
        /// <param name="message">The text of the message.</param>
        public void Message(string message) { }

        /// <summary>
        /// Turns the computer off.
        /// </summary>
        public void PowerDown() 
        {
 
        }

        public string GetCompID()
        {
            return this.compID;
        }

        public List<Communication.Service> GetServices()
        {
            return this.services;
        }

        public string StartService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.StartService();
                UpdateServices();
                return code;
            }
        }

        public string StopService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.StopService();
                UpdateServices();
                return code;
            }
        }

        public string RestartService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.RestartService();
                UpdateServices();
                return code;
            }
        }

        public string EnableService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.Enable();
                UpdateServices();
                return code;
            }
        }

        public string DisableService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.Disable();
                UpdateServices();
                return code;
            }
        }



        public Communication.Service GetService(string serviceName)
        {
            foreach (Communication.Service sc in services)
            {
                if (sc.GetServiceName() == serviceName)
                {
                    return sc;
                }
            }
            return null;
        }

        private void UpdateServices()
        {
            ServiceController[] servicesArray = ServiceController.GetServices();
            services.Clear();
            foreach (ServiceController sc in servicesArray)
            {
                Communication.Service temp = new Communication.Service(sc.ServiceName, sc.ServiceType.ToString(), sc.DisplayName, sc.Status.ToString());
                services.Add(temp);
            }

        }

        public string AutoService(string serviceName)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            Communication.Service temp = GetService(serviceName);
            if (temp == null)
            {
                return "Service not found";
            }
            else
            {
                string code = temp.Auto();
                UpdateServices();
                return code;
            }
        }
    }
}
