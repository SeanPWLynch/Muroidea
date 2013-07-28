using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;

namespace Communication
{
    [Serializable]
    public class Process
    {
        /// <summary>
        /// This Class was required to send process information between clients and server as the
        /// System.Diagnostics.Process class is not serializable
        /// </summary>

        private int ProcessID; //Process ID
        private string ProcessName; //Process Name
        public int CPU; //CPU usage of process
        public int ThreadCount; //Number of threads
        public int ParentID; //ID of process which created current process if available otherwise -1
        public long UpTime; //Time in seconds process had been running
        public int Memory; //RAm Usage in KB
        public Process[] ProcessList; //Array of all processes

        /// <summary>
        /// Constructor for process, information taken from System.Diagnostics.Process
        /// </summary>
        public Process(string ProcessName, int ProcessID, int CPU, int ThreadCount, int Memory)
        {
            this.ProcessID = ProcessID;
            this.ProcessName = ProcessName;
            this.CPU = CPU;
            this.ThreadCount = ThreadCount;
            this.Memory = Memory;
        }

        /// <summary>
        /// Start the Process up.
        /// </summary>
        /// <returns>If it is started successfully, then it will return True. If there is an error, or if it is already running then it will return False.</returns>
        public static bool StartProcess(string procname)
        {
            try
            {
                System.Diagnostics.Process proc = System.Diagnostics.Process.Start(procname);
                if (proc.ProcessName != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// This will restart the Pocess
        /// </summary>
        /// <returns>This will return True if the Process is successfully restarted. If the Process isn't running, or if there was an error in restarting it then it will return False.</returns>
        public static bool RestartProcess(int PID)
        {
            string ProcessName = "";
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\CIMV2", "Win32_Process.Handle='"+PID+"'", null);
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_Process WHERE ProcessId =" + PID  + @"");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    ProcessName = queryObj["Name"].ToString().Trim();
                }

                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("Terminate");

                // Add the input parameters.

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = classInstance.InvokeMethod("Terminate", inParams, null);

                // List outParams
                Console.WriteLine("Out parameters:");
                Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
                if (int.Parse(outParams["ReturnValue"].ToString().Trim()) != 0)
                {
                    return false;
                }
                else
                {
                    return StartProcess(ProcessName);   
                }
            }
            catch (ManagementException err)
            {
                Console.WriteLine("An error occurred while trying to execute the WMI method: " + err.Message);
                return false;
            }
        }

        /// <summary>
        /// Stop the Process.
        /// </summary>
        /// <returns>It will return True if the Process is successfully stopped. If the Process isn't running, or there was an error when stopping it, then it will return False.</returns>
        public static bool StopProcess(int PID) 
        {
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\CIMV2", "Win32_Process.Handle='" + PID + "'", null);
               
                // Obtain in-parameters for the method
                ManagementBaseObject inParams = classInstance.GetMethodParameters("Terminate");

                // Add the input parameters.

                // Execute the method and obtain the return values.
                ManagementBaseObject outParams = classInstance.InvokeMethod("Terminate", inParams, null);

                // List outParams
                Console.WriteLine("Out parameters:");
                Console.WriteLine("ReturnValue: " + outParams["ReturnValue"]);
                if (int.Parse(outParams["ReturnValue"].ToString().Trim()) != 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (ManagementException err)
            {
                Console.WriteLine("An error occurred while trying to execute the WMI method: " + err.Message);
                return false;
            }
        }

        /// <summary>
        /// The name of the Process.
        /// </summary>
        /// <returns>Returns the name of the Process</returns>
        public string GetName()
        {
            return this.ProcessName;
        }

        /// <summary>
        /// Returns the Process ID.
        /// </summary>
        /// <returns>The Process ID</returns>
        public int GetPID()
        {
            return this.ProcessID;
        }

        /// <summary>
        /// Returns the status of the Process, such as 'Running'.
        /// </summary>
        /// <returns>Returns the status of the Process.</returns>
        public string GetStatus() { return null; }

        /// <summary>
        /// Returns the CPU usage being used by the Process.
        /// </summary>
        /// <returns>Returns CPU usage in percentage form.</returns>
        public int GetCPU()
        {
            return this.CPU;
        }

        /// <summary>
        /// Returns the RAM usage being used by the Process.
        /// </summary>
        /// <returns>Returns RAM usage in percentage form.</returns>
        public int GetMemory()
        {
            return this.Memory;
        }


        /// <summary>
        /// Returns Process Uptime
        /// </summary>
        /// <returns>Returns Process Uptime In Seconds</returns>
        public long GetUptime()
        {
            return this.UpTime;
        }

        public int GetThreadCount()
        {
            return this.ThreadCount;
        }

    }
}
