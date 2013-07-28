// -----------------------------------------------------------------------
// <copyright file="Client.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LuaInterface;
    using Communication;
    using System.Net.Sockets;
    using System.Threading;
    using System.Net;
    using Microsoft.Win32;
    using System.Management;
    using System.Net.NetworkInformation;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Client
    {
        Lua lua;
        Computer computer;
        CPU compCPU;
        Motherboard compMobo;
        RAM compRAM;
        //RAM compRam;
        Volumes compVols;
        Hardware[] compHardware;
        DisplayDevices compDisplay;
        NIC compNIC;



        System.Net.Sockets.TcpClient clientSocket;
        System.Net.Sockets.TcpClient heartBeat;

        /// <summary>
        /// The start of the client program
        /// </summary>
        public Client()
        {
            Console.WriteLine("Start");
            computer = new Computer(this);
            InitComputer();
            

            InitLUA();
            Console.WriteLine("Looking out for Server...");
            string ServerIP = null;
            do
            {
               // ServerIP = Messaging.RetrieveMulitcastIP();
                ServerIP = Messaging.RetrieveBroadcastIP();
            } while (ServerIP == null || ServerIP == " ");
            Console.WriteLine("SERVERIP :: " + ServerIP);
            Console.WriteLine("Found the server!");
           
            CommandMode(ServerIP);
        }

        void SendHeartBeat()
        {
            do
            {
                //Messaging.SendCommand("Checking in", heartBeat);
                //Thread.Sleep(1000);
            } while (true);
        }

        /// <summary>
        /// Enter command mode, which allows the server to send LUA commands to the client.
        /// </summary>
        /// <param name="ServerIP">The IP address of the server.</param>
        private void CommandMode(string ServerIP)
        {
            clientSocket = new System.Net.Sockets.TcpClient();
            //this.socket = clientSocket;
            NetworkStream serverStream = default(NetworkStream);
            bool connected = false;
            do
            {
                try
                {
                    Console.WriteLine("SERVER IS " + ServerIP);
                    serverStream = default(NetworkStream);
                    clientSocket = new System.Net.Sockets.TcpClient();
                    clientSocket.Connect(ServerIP, 8888); //Error socket handling go here.
                    heartBeat = new System.Net.Sockets.TcpClient();
                    heartBeat.Connect(ServerIP, 8889);
                    Thread sendHeartBeat = new Thread(SendHeartBeat);
                    //sendHeartBeat.Start();
                    connected = true;
                }
                catch (Exception se)
                {
                    //Retry
                    // Console.WriteLine(se.ToString());
                    Thread.Sleep(10000);
                }
            } while (!connected);
            
           // serverStream = clientSocket.GetStream();
            Console.WriteLine("Connected to server successfully");

            Console.WriteLine();
            object[] t = null;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Waiting on command from the server....");
                try
                {
                   // string command = Messaging.RecieveCommand(clientSocket);
                    string command = Messaging.NewRecieve(clientSocket);
                    if (command == null) { throw new AccessViolationException(); } //Server closed.
                    t = lua.DoString(command);
                    
                    if (t == null)
                    {
                        Messaging.SendMessage("Executed", clientSocket);
                    }
                    else if (t[0].ToString() == "Communication.FTPDirectory")
                    {
                        Messaging.SendFTPDirectory((FTPDirectory)t[0], clientSocket);
                    }
                    else if (t[0].ToString() == "Communication.Container")
                    {
                        if (((Container)t[0]).ContainerType == "StringCon")
                        {
                        Messaging.SendComputerDetails(((Container)t[0]).data, clientSocket);
                    }
                        else if (((Container)t[0]).ContainerType == "ProcCon")
                        {
                            Messaging.SendProcessDetails(((Container)t[0]).ProcList, clientSocket);
                        }
                        else if (((Container)t[0]).ContainerType == "ServiceCon")
                        {
                            Messaging.SendServiceDetails(((Container)t[0]).ServiceList, clientSocket);
                        }
                        else if (((Container)t[0]).ContainerType == "ScheduleTaskCon")
                        {
                            Messaging.SendTaskDetails(((Container)t[0]).TaskList, clientSocket);
                    }
                    }
                    else
                    {
                        Messaging.SendMessage(t[0].ToString(), clientSocket);
                    }
                }
                catch (System.AccessViolationException ae3)
                {
                    Console.WriteLine("Server has exited. Goodbye!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
                catch (LuaException le)
                {
                    Messaging.SendMessage("LUA Command not found", clientSocket);
                }
            } while (true);
        }


        /// <summary>
        /// This method takes care of all of the LUA init. It assigns all of the functions that will be used.
        /// </summary>
        private void InitLUA()
        {
            lua = new Lua();

            lua.RegisterFunction("Hello", this, this.GetType().GetMethod("SayHello"));
            lua.RegisterFunction("AddTwoNumbers", this, this.GetType().GetMethod("AddTwoNumbers"));
            lua.RegisterFunction("GetIP", this, this.GetType().GetMethod("GetIP"));
            lua.RegisterFunction("Quit", this, this.GetType().GetMethod("Quit"));
            lua.RegisterFunction("RetrieveFile", this, this.GetType().GetMethod("RetrieveFile"));
            lua.RegisterFunction("MessageComputer", this, this.GetType().GetMethod("MessageComputer"));
            lua.RegisterFunction("GetComputerName", this, this.GetType().GetMethod("GetComputerName"));
            lua.RegisterFunction("GetCompID", this, this.GetType().GetMethod("GetCompID"));
            lua.RegisterFunction("GetCPUDetails", this, this.GetType().GetMethod("GetCPUDetails"));
            lua.RegisterFunction("GetMoboDetails", this, this.GetType().GetMethod("GetMoboDetails"));
            lua.RegisterFunction("GetRAMDetails", this, this.GetType().GetMethod("GetRAMDetails"));
            lua.RegisterFunction("GetStorageDetails", this, this.GetType().GetMethod("GetStorageDetails"));
            lua.RegisterFunction("GetVideoDetails", this, this.GetType().GetMethod("GetVideoDetails"));
            lua.RegisterFunction("GetAllInfo", this, this.GetType().GetMethod("GetAllInfo"));
            lua.RegisterFunction("GetMACAddress", this, this.GetType().GetMethod("GetMACAddress"));
            lua.RegisterFunction("InitFTPDirectory", this, this.GetType().GetMethod("InitFTPDirectory"));
            lua.RegisterFunction("GetFTPDirectory", this, this.GetType().GetMethod("GetFTPDirectory"));


            lua.RegisterFunction("GetComputerDetails", this, this.GetType().GetMethod("GetComputerDetails")); //GetComputerDetails
            lua.RegisterFunction("GetHardwareDetails", this, this.GetType().GetMethod("GetHardwareDetails")); //GetHardwareDetails
            lua.RegisterFunction("SendHardwareDetails", this, this.GetType().GetMethod("SendHardwareDetails")); //GetHardwareDetails
            lua.RegisterFunction("SendComputerDetails", this, this.GetType().GetMethod("SendComputerDetails")); //GetHardwareDetails
            lua.RegisterFunction("SendHardwareUsage", this, this.GetType().GetMethod("SendHardwareUsage")); //GetHardwareDetails

            
            lua.RegisterFunction("RemoteAcceptFTP", this, this.GetType().GetMethod("RemoteAcceptFTP"));
            lua.RegisterFunction("RemoteSendFTP", this, this.GetType().GetMethod("RemoteSendFTP"));


            //Process Commands
            lua.RegisterFunction("GetProcessDetails", this, this.GetType().GetMethod("GetProcessDetails"));
            lua.RegisterFunction("StartProcess", this, this.GetType().GetMethod("StartProcess"));
            lua.RegisterFunction("RestartProcesses", this, this.GetType().GetMethod("RestartProcesses"));
            lua.RegisterFunction("StopProcesses", this, this.GetType().GetMethod("StopProcesses"));

            //Service Commands
            lua.RegisterFunction("GetServiceDetails", this, this.GetType().GetMethod("GetServiceDetails"));
            lua.RegisterFunction("StartService", this, this.GetType().GetMethod("StartService"));
            lua.RegisterFunction("RestartServices", this, this.GetType().GetMethod("RestartServices"));
            lua.RegisterFunction("StopServices", this, this.GetType().GetMethod("StopServices"));
            lua.RegisterFunction("EnableServices", this, this.GetType().GetMethod("EnableServices"));
            lua.RegisterFunction("DisableServices", this, this.GetType().GetMethod("DisableServices"));
            lua.RegisterFunction("AutoServices", this, this.GetType().GetMethod("AutoServices"));

            //Scheduled Task Commands
            lua.RegisterFunction("AddTask", this, this.GetType().GetMethod("AddTask"));
            lua.RegisterFunction("AddAdvanceTask", this, this.GetType().GetMethod("AddAdvanceTask"));
            lua.RegisterFunction("GetTaskDetails", this, this.GetType().GetMethod("GetTaskDetails"));
            lua.RegisterFunction("AddDailyTrigger", this, this.GetType().GetMethod("AddDailyTrigger"));
            lua.RegisterFunction("AddWeeklyTrigger", this, this.GetType().GetMethod("AddWeeklyTrigger"));
            lua.RegisterFunction("AddMonthlyTrigger", this, this.GetType().GetMethod("AddMonthlyTrigger"));
            lua.RegisterFunction("AddStartupTrigger", this, this.GetType().GetMethod("AddStartupTrigger"));
            lua.RegisterFunction("AddAction", this, this.GetType().GetMethod("AddAction"));
            lua.RegisterFunction("AddActionAdvanced", this, this.GetType().GetMethod("AddActionAdvanced"));
            lua.RegisterFunction("DeleteTrigger", this, this.GetType().GetMethod("DeleteTrigger"));
            lua.RegisterFunction("DeleteAction", this, this.GetType().GetMethod("DeleteAction"));
            lua.RegisterFunction("DeleteTask", this, this.GetType().GetMethod("DeleteTask"));

            //System Operations
            lua.RegisterFunction("PowerControl", this, this.GetType().GetMethod("PowerControl"));
            lua.RegisterFunction("GetUptime", this, this.GetType().GetMethod("GetUptime"));
            lua.RegisterFunction("GetUptimeHours", this, this.GetType().GetMethod("GetUptimeHours"));

            


            //GetTemps()

            //Database Stuff
            lua.RegisterFunction("GetCompDB", this, this.GetType().GetMethod("GetCompDB"));
            lua.RegisterFunction("GetSystemDB", this, this.GetType().GetMethod("GetSystemDB"));

            


            lua.RegisterFunction("RemoteAcceptFTPFromClient", this, this.GetType().GetMethod("RemoteAcceptFTPFromClient"));
            //SendFTPToClient
            lua.RegisterFunction("SendFTPToClient", this, this.GetType().GetMethod("SendFTPToClient"));
            
        }

        public string RetrieveFile(int port)
        {
            Messaging.RecieveFile(port);
            return "File retrieved";
        }

        /// <summary>
        /// Quit the program
        /// </summary>
        public string Quit()
        {
            Console.WriteLine("Program quitting......");
            Thread.Sleep(2000);
            Environment.Exit(0);
            return "Client Quitting";
        }

        /// <summary>
        /// Says hello to the user. To use this command type in "SayHello('Whatever');"
        /// </summary>
        /// <param name="name">Your name</param>
        public string SayHello(string name)
        {
            Console.WriteLine("Why hello there " + name);
            return "Why hello there " + name;
        }

        /// <summary>
        /// This method returns a message that was sent from the server.
        /// </summary>
        /// <param name="msg">The message to print to the client.</param>
        public void MessageComputer(string msg)
        {
            Console.WriteLine("Message recieved from server :: ");
            Console.WriteLine(msg);
        }


        /// <summary>
        /// Adds two numbers together and returns the result
        /// </summary>
        /// <param name="a">Var one</param>
        /// <param name="b">Var two</param>
        /// <returns>The result</returns>
        public string AddTwoNumbers(int a, int b)
        {
            Console.WriteLine("Server asked me to add " + a + " and " + b + " together");
            return "The two numbers added together are " + (a + b);
        }

        /// <summary>
        /// This code returns the IP address of the computer its running on
        /// </summary>
        /// <returns>The IP address</returns>
        public string GetIP()
        {
            Console.WriteLine("Server asked for my IP address");
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            string localIP = null;
            foreach (IPAddress IP in addr)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = IP.ToString();
                }
            }
            return "The client has checked their IP address. It is " + localIP;
        }

        /// <summary>
        /// This method starts a process up, such as 'calc.exe'
        /// </summary>
        /// <param name="process">The name / location of the process. For example, [StartProcess("calc.exe");]</param>
        /// <returns>Returns if the process was started successfully or not.</returns>
        public bool StartProcess(string process)
        {
            try
            {
                return Process.StartProcess(process);
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string RestartProcesses(string ToRestart)
        {
            string Results = "";

            string[] PIDArr = ToRestart.Split('$');

            foreach (string pid in PIDArr)
            {
                if (pid != "")
                {
                    Results += pid + "::" + Process.RestartProcess(int.Parse(pid)) + '$';

                }
            }

            return Results;
        }

        public string StopProcesses(string ToKill)
        {
            string Results = "";

            string[] PIDArr = ToKill.Split('$');

            foreach (string pid in PIDArr)
            {
                if (pid != "")
                {
                    Results += pid + "::" + Process.StopProcess(int.Parse(pid)) + "$";
                }
            }

            return Results;
        }



        /// <summary>
        /// Gets the computer name for machine
        /// </summary>
        /// <returns>Computer Name</returns>
        public string GetComputerName()
        {
            return Environment.MachineName.ToString();
        }

        /// <summary>
        /// Creates UID using the product ID, CPUID and Motherboard ID
        /// </summary>
        /// <returns>Computer ID</returns>
        public string GetCompID()
        {
            RegistryKey localMachine = null;
            if (Environment.Is64BitOperatingSystem)
            {
                localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry64);
            }
            else
            {
                localMachine = RegistryKey.OpenBaseKey(Microsoft.Win32.RegistryHive.LocalMachine, RegistryView.Registry32);
            }
            RegistryKey windowsNTKey = localMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion");
            string compID = windowsNTKey.GetValue("ProductId").ToString();

            string cpuid = "";
            string moboserial = "";
            string macAddress = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select ProcessorID From Win32_processor");
                ManagementObjectCollection searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    cpuid = mo["ProcessorID"].ToString();
                }



                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                searchList = searcher.Get();

                foreach (ManagementObject mo in searchList)
                {
                    moboserial = (string)mo["SerialNumber"];
                }

                searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
                IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
                macAddress = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();

            }
            catch (Exception)
            {
            }


            compID += cpuid;
            compID += moboserial;
            compID += macAddress;

            Console.WriteLine(compID.Length);
            compID = compID.Replace("-", null).Replace(":", null).Replace(".", null);
            return compID;

        }

        /// <summary>
        /// Returns CPU information
        /// </summary>
        /// <returns></returns>
        public string GetCPUDetails()
        {
            string cpuDetails = "";
            cpuDetails += "CPU Details: " + Environment.NewLine + "$";
            cpuDetails += "Processor Name: " + compCPU.GetModel() + Environment.NewLine + "$";
            cpuDetails += "Number Of Physical Cores: " + compCPU.GetNumPhysicalCores() + Environment.NewLine + "$";
            cpuDetails += "Number Of Logical Cores: " + compCPU.GetNumLogicalCores() + Environment.NewLine + "$";
            cpuDetails += "Current CPU Usage: " + compCPU.GetCPUUsage() + Environment.NewLine + "$";
            cpuDetails += Environment.NewLine;

            return cpuDetails;
        }

        /// <summary>
        /// Returns Motherboard details in a string
        /// </summary>
        /// <returns>String Containing Mobo Details</returns>
        public string GetMoboDetails()
        {
            string moboDetails = "";

            moboDetails += "Motherboard Details: " + Environment.NewLine;
            moboDetails += "Manufacturer: " + compMobo.GetManufacturer() + Environment.NewLine;
            moboDetails += "Model: " + compMobo.GetModel() + Environment.NewLine;
            moboDetails += "System Model: " + compMobo.GetSystemModel() + Environment.NewLine;
            moboDetails += Environment.NewLine;

            return moboDetails;
        }

        /// <summary>
        /// Returns string containing ram details
        /// </summary>
        /// <returns>String containing RAM details</returns>
        public string GetRAMDetails()
        {
            string RAMDetails = "";

            for (int i = 0; i < compRAM.installedRAM.Length; i++)
            {
                RAMDetails += "Module " + compRAM.installedRAM[i].GetModuleNumber() + ": " + Environment.NewLine;
                RAMDetails += "Manufacturer: " + compRAM.installedRAM[i].GetManufacturer() + Environment.NewLine;
                RAMDetails += "Model: " + compRAM.installedRAM[i].GetModel() + Environment.NewLine;
                RAMDetails += "Module Size: " + compRAM.installedRAM[i].GetModuleSize() + Environment.NewLine;
                RAMDetails += "Module Speed: " + compRAM.installedRAM[i].GetModuleSpeed() + Environment.NewLine;
            }
            RAMDetails += "Total Installed Memory: " + compRAM.GetTotalRAM() + Environment.NewLine;
            RAMDetails += Environment.NewLine;

            return RAMDetails;
        }

        /// <summary>
        /// Returns string containing storage details
        /// </summary>
        /// <returns>String containing storage details</returns>
        public string GetStorageDetails()
        {
            string storage = "";

            storage += "Drive Details: " + Environment.NewLine;
            for (int i = 0; i < compVols.drives.Length; i++)
            {
                storage += "Drive Letter: " + compVols.drives[i].GetDriveLetter() + Environment.NewLine;
                storage += "Boot Volume: " + compVols.drives[i].GetOSDrive() + Environment.NewLine;
                storage += "File System: " + compVols.drives[i].GetFileSystem() + Environment.NewLine;
                storage += "Drive Capacity: " + compVols.drives[i].GetDriveCapacity() + "GB" + Environment.NewLine;
                storage += "Free Space: " + compVols.drives[i].GetFreeSpace() + "GB" + Environment.NewLine;
                storage += Environment.NewLine;
                        }
                            storage += Environment.NewLine;


            return storage;
        }

        /// <summary>
        /// Returns Video Details
        /// </summary>
        /// <returns></returns>
        public string GetVideoDetails()
        {
            string videoDetails = "";
            videoDetails += "Video Adapter Details: " + Environment.NewLine;
            for (int i = 0; i < compDisplay.myDevices.Length; i++)
                {
                videoDetails += "Adapter " + (i + 1) + ": " + Environment.NewLine;
                videoDetails += "Manufacturer: " + compDisplay.myDevices[i].GetManufacturer() + Environment.NewLine;
                videoDetails += "Model: " + compDisplay.myDevices[i].GetModel() + Environment.NewLine;
                videoDetails += "Adapter Memory: " + compDisplay.myDevices[i].GetDeviceMem() + "MB" + Environment.NewLine;
                    videoDetails += Environment.NewLine;
            }

            return videoDetails;
        }


        ///NOTICE FOR SERVICE CHANGE
        ///
        /// <summary>
        /// Returns string containing all computer hardware information
        /// </summary>
        /// <returns>String containing all computer hardware information</returns>
        public string[] GetAllInfo()
        {
            string[] ComputerDetails = new string[6];

            try
            {
                string compDetails = "";
                compDetails += "Computer ID: " + this.GetCompID() + '$';
                compDetails += "Computer Name: " + this.GetComputerName() + '$';
                compDetails += "Operating System: " + Environment.OSVersion + '$';

                ComputerDetails[0] = compDetails;

                string CPUDetails = "";

                CPUDetails += "Processor Name: " + compCPU.GetModel() + '$';
                CPUDetails += "Number Of Physical Cores: " + compCPU.GetNumPhysicalCores() + '$';
                CPUDetails += "Number Of Logical Cores: " + compCPU.GetNumLogicalCores() + '$';

                ComputerDetails[1] = CPUDetails;


                string motherboardDetails = "";

                motherboardDetails += "Manufacturer: " + compMobo.GetManufacturer() + '$';
                motherboardDetails += "Model: " + compMobo.GetModel() + '$';
                motherboardDetails += "System Model: " + compMobo.GetSystemModel() + '$';

                ComputerDetails[2] = motherboardDetails;

                string ramDetails = "";

                for (int i = 0; i < compRAM.installedRAM.Length; i++)
                {
                    ramDetails += "Module " + compRAM.installedRAM[i].GetModuleNumber() + '$';
                    ramDetails += "Manufacturer: " + compRAM.installedRAM[i].GetManufacturer() + '$';
                    ramDetails += "Model: " + compRAM.installedRAM[i].GetModel() + ": $";
                    ramDetails += "Module Size: " + compRAM.installedRAM[i].GetModuleSize() + '$';
                    ramDetails += "Module Speed: " + compRAM.installedRAM[i].GetModuleSpeed() + '$';
                    ramDetails += '£';
                }
                ramDetails += "Total Installed Memory: " + compRAM.GetTotalRAM();

                ComputerDetails[3] = ramDetails;

                string storageDetails = "";

                for (int i = 0; i < compVols.drives.Length; i++)
                {
                    storageDetails += "Drive: " + compVols.drives[i].GetDriveLetter()  + '$';
                    storageDetails += "Boot Volume: " + compVols.drives[i].GetOSDrive() + '$';
                    storageDetails += "File System: " + compVols.drives[i].GetFileSystem() + '$';
                    storageDetails += "Drive Capacity: " + compVols.drives[i].GetDriveCapacity() + "GB" + '$';
                    storageDetails += "Free Space: " + compVols.drives[i].GetFreeSpace() + "GB" + '$';
                    storageDetails += '£';
                }

                ComputerDetails[4] = storageDetails;

                string displayDetails = "";

                for (int i = 0; i < compDisplay.myDevices.Length; i++)
                {
                    displayDetails += "Adapter " + (i + 1) + '$';
                    displayDetails += "Manufacturer: " + compDisplay.myDevices[i].GetManufacturer() + '$';
                    displayDetails += "Model: " + compDisplay.myDevices[i].GetModel() + '$';
                    displayDetails += "Adapter Memory: " + compDisplay.myDevices[i].GetDeviceMem() + "MB" + '$';
                    displayDetails += '£';
                }

                ComputerDetails[5] = displayDetails;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ComputerDetails;
        }

        public string[] DBGetCompInfo()
        {
            string[] ComputerDetails = new string[4];

            try
            {

                ComputerDetails[0] = this.GetCompID();
                ComputerDetails[1] = this.GetComputerName();
                ComputerDetails[2] = "" + Environment.OSVersion;
                ComputerDetails[3] = this.GetMACAddress().Trim();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return ComputerDetails;
        }

        public string[] DBGetSystemInfo()
        {
            string[] SystemDetails = new string[6];

            try
            {


                SystemDetails[0] = this.GetCompID().Trim();
                SystemDetails[1] = this.compCPU.GetManufacturer().Trim();
                SystemDetails[2] = this.compRAM.GetTotalRAM().ToString();
                SystemDetails[3] = this.compMobo.GetManufacturer().Trim();
                SystemDetails[4] = this.compVols.GetTotalFreeSpace().ToString().Trim();
                SystemDetails[5] = this.compDisplay.myDevices[0].GetManufacturer().Trim();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return SystemDetails;
        }

        public FTPDirectory dir;
        public FTPDirectory InitFTPDirectory(string path)
        {
            dir = new FTPDirectory(path, false, null);
            dir.GetDirs();
            dir.GetChildrenDirs();
            return dir;
        }
        public FTPDirectory GetFTPDirectory(string node)
        {
            FTPDirectory directory = dir.FindDirectory(node);
            directory.GetDirs();
            directory.GetChildrenDirs();
            return directory;
        }


        public void InitComputer()
        {
            computer.Init();
            compHardware = computer.GetHardware();
            compCPU = (CPU)compHardware[0];
            compMobo = (Motherboard)compHardware[1];
            compRAM = (RAM)compHardware[2];
            compVols = (Volumes)compHardware[3];
            compDisplay = (DisplayDevices)compHardware[4];
            compNIC = (NIC)compHardware[5];
        }

        public string[] GetComputerDetails()
        {
            //(COMPID, GROUPID, OPID, SYSID, MAC, IPPORT)
            string[] details = { this.computer.GetCompID(), null, null, this.computer.GetCompID(), this.GetMACAddress(), this.GetIP() };
            return details;
        }


        public string[] GetHardwareUsage()
        {
            //CPU, RAM, IO, Network
            string[] usage = { this.compCPU.GetAllDetails(), this.compRAM.GetRAMDetails(), this.compVols.GetVolUsage(), this.compNIC.GetNICUsage() };
            Console.WriteLine("Returning usage");
            return usage;
        }

        public Container GetProcessDetails()
        {
            Container ProcContainer = new Container(this.computer.ReturnProcesses());
            return ProcContainer;
        }

        public Container GetServiceDetails()
        {
            Container ServiceContainer = new Container(this.computer.GetServices());
            return ServiceContainer;
        }

        public Container GetTaskDetails()
        {
            Container TaskContainer = new Container(this.computer.GetScheduledTasks());
            return TaskContainer;
        }

        public string DeleteTask(string taskName)
        {
            return this.computer.DeleteTask(taskName);
        }

        public string DeleteTrigger(string taskName, int triggerIndex)
        {
            return this.computer.DeleteTrigger(taskName, triggerIndex);
        }

        public string DeleteAction(string taskName, int actionIndex)
        {
            return this.computer.DeleteAction(taskName, actionIndex);
        }

        public string AddTask(string taskName, string description,string path)
        {
            return this.computer.AddTask(taskName, description,path);
        }

        public string AddAdvanceTask(string taskName, string description, string codepath, string code)
        {
            return this.computer.AddAdvanceTask(taskName, description, codepath,code);
        }

        public string AddDailyTrigger(string taskName, string dateTime, int everyMinute)
        {
            return this.computer.AddDailyTrigger(taskName, dateTime, everyMinute);
        }

        public string AddWeeklyTrigger(string taskName, string dateTime)
        {
            return this.computer.AddWeeklyTrigger(taskName, dateTime);
        }

        public string AddMonthlyTrigger(string taskName, string dateTime)
        {
            return this.computer.AddMonthlyTrigger(taskName, dateTime);
        }

        public string AddStartupTrigger(string taskName)
        {
            return this.computer.AddStartupTrigger(taskName);
        }

        public string AddAction(string taskName, string path) 
        {
            return this.computer.AddAction(taskName, path); 
        }
        public string AddActionAdvanced(string taskName, string path, string code)
        {
            return this.computer.AddActionAdvanced(taskName, path, code);
        }

        public Container GetCompDB()
        {
            Container CompDetailsContainer = new Container(this.DBGetCompInfo());
            return CompDetailsContainer;
        }

        public Container GetSystemDB()
        {
            Container CompDetailsContainer = new Container(this.DBGetSystemInfo());
            return CompDetailsContainer;
        }


        public string StartService(string serviceName)
        {
            return this.computer.StartService(serviceName);
        }

        public string RestartServices(string serviceName)
        {
            return this.computer.RestartService(serviceName);
        }

        public string StopServices(string serviceName)
        {
            return this.computer.StopService(serviceName);
        }

        public string EnableServices(string serviceName)
        {
            return this.computer.EnableService(serviceName);
        }

        public string DisableServices(string serviceName)
        {
            return this.computer.DisableService(serviceName);
        }

        public string AutoServices(string serviceName)
        {
            return this.computer.AutoService(serviceName);
        }



        /// <summary>
        /// Creates a string[] Container object containing computer
        /// Hardware usage
        /// </summary>
        /// <returns>String[] Data Container with Hardware Usage</returns>
        public Container SendHardwareUsage()
        {
            Console.WriteLine("Getting usage...");
            Container dataContainter = new Container(GetHardwareUsage());
            Console.WriteLine("Returning hardware usage");
            return dataContainter;
        }

        public Container SendHardwareDetails()
        {
            Container dataContainter = new Container(GetHardwareDetails());
            return dataContainter;
        }

        public string[] GetHardwareDetails()
        {
            Console.WriteLine("Returning Details");
            return this.GetAllInfo();
        }

        /// <summary>
        /// Creates a string[] Container object containing computer
        /// Hardware details
        /// </summary>
        /// <returns>String[] Data Container</returns>
        public Container SendComputerDetails()
        {
            Container dataContainer = new Container(GetComputerDetails());
            return dataContainer;
        }


        /// <summary>
        /// Returns MAC address of first active network card
        /// </summary>
        /// <returns></returns>
        public string GetMACAddress()
        {
            string macAddress = "";
            try
            {

                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
                IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
                macAddress = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            return macAddress.Trim();
        }

        public void RemoteSendFTP(string ipAdd, int port, string pathOfFile)
        {
            //Server wants a file, send it to them
            TcpClient toSend = new TcpClient();
            toSend.Connect(ipAdd, port);
            Messaging.RemoteSendFTP(toSend, pathOfFile);


            /*
             * To make this work, remote send will become TCP server, and recieving client thread will
             * be tcp client.
             * Server(this) will try to connect, and so will client
             * When connected, it will send file, close connection
             * Client will accept file and close connection
             */



            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();
            

        }

        public void RemoteAcceptFTP(int port, string pathToGo, int fileLength)
        {
            //Start accepting the FTP connection

            Messaging.RemoteAcceptFTP(clientSocket, pathToGo.ToString(), fileLength);
        }


        /// <summary>
        /// Handles shutdown/logoff/restart of local machine
        /// </summary>
        /// <param name="op">4 = Log Off: 5 = Shutdown: 6 = Reboot: 12 = PowerOff</param>
        public void PowerControl(int op)
        {
            try
            {
                ManagementBaseObject outParameters = null;
                ManagementClass classInstance = new ManagementClass("Win32_OperatingSystem");
                classInstance.Get();
                // enables required security privilege.
                classInstance.Scope.Options.EnablePrivileges = true;
                // get our in parameters
                ManagementBaseObject inParameters = classInstance.GetMethodParameters("Win32Shutdown");
                // pass the flag of 0 = System Shutdown
                inParameters["Flags"] = op.ToString().Trim();
                inParameters["Reserved"] = "0";
                foreach (ManagementObject manObj in classInstance.GetInstances())
                {
                    outParameters = manObj.InvokeMethod("Win32Shutdown", inParameters, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Thread fromClient = null;   
        /// <summary>
        /// Client accepts an FTP connection from another client.
        /// </summary>
        /// <param name="ipAdd">IP address to connect to.</param>
        /// <param name="dest">The file path to store the incoming file</param>
        /// <param name="fileLength">The length of the file</param>
        public void RemoteAcceptFTPFromClient(string ipAdd, string dest, int fileLength)
        {
            if (fromClient != null)
            {
                do
                {
                } while (fromClient.IsAlive); //Wait until the thread is finished downloading the previous file (when downloading a folder)
            }
            fromClient = new Thread(() => Messaging.AcceptClientFTPToClient(ipAdd, dest, fileLength));
            fromClient.Start();

           // Messaging.AcceptClientFTPToClient(ipAdd, dest, fileLength);
        }

        Thread toClient = null;
        /// <summary>
        /// Client connects to another client to send a file or folder.
        /// </summary>
        /// <param name="source">The source filepath of the file to send</param>
        /// <param name="ip">The IP that will act as the server</param>
        public void SendFTPToClient(string source, string ip)
        {
            if (toClient != null)
            {
                do
                {
                } while (toClient.IsAlive);
            }

            toClient = new Thread(()=> Messaging.ClientFTPToClient(source, ip));
            toClient.Start();

        }

        public static string GetUptime()
        {
            ManagementObject mo = new ManagementObject(@"\\.\root\cimv2:Win32_OperatingSystem=@");
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
            TimeSpan temp = DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
            return temp.Days.ToString() + ":" + temp.Hours.ToString() + ":" + temp.Minutes.ToString() + ":" + temp.Seconds.ToString();
        }

        public static string GetUptimeHours()
        {
            ManagementObject mo = new ManagementObject(@"\\.\root\cimv2:Win32_OperatingSystem=@");
            DateTime lastBootUp = ManagementDateTimeConverter.ToDateTime(mo["LastBootUpTime"].ToString());
            TimeSpan temp = DateTime.Now.ToUniversalTime() - lastBootUp.ToUniversalTime();
            return temp.Hours.ToString();
        }

    }
}


