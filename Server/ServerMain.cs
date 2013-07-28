using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Communication;

namespace Server
{
    public partial class ServerMain : Form
    {
        private static List<ClientThread> clients;
        private static List<KnownClient> offlineClients;
        ClientThread selectedClient;
        public static Database db;// = new Database();
        public static List<Group> groups;
        List<string> ProcNames;
        List<ScheduledTask> TaskList;
        DataTable ProcessDataTable;
        DataTable ServiceDataTable;
        DataTable TaskDataTable;
        DataTable TaskActionDataTable;
        DataTable TaskTriggerDataTable;


        public ServerMain()
        {
            InitializeComponent();
            db = new Database();
            groups = new List<Group>();
            groups = db.GetGroups();
            offlineClients = new List<KnownClient>();
            ProcessDataTable = new DataTable("Processes");

            ProcessDataTable.Columns.Add("Process ID", typeof(int));
            ProcessDataTable.Columns.Add("Process Name", typeof(string));
            ProcessDataTable.Columns.Add("CPU %", typeof(int));
            ProcessDataTable.Columns.Add("Memory KB", typeof(int));
            ProcessDataTable.Columns.Add("Thread Count", typeof(int));

            ServiceDataTable = new DataTable("Services");
            ServiceDataTable.Columns.Add("Service Name", typeof(string));
            ServiceDataTable.Columns.Add("Service Type", typeof(string));
            ServiceDataTable.Columns.Add("Display Name", typeof(string));
            ServiceDataTable.Columns.Add("Current Status", typeof(string));
            ServiceDataTable.Columns.Add("Startup Type", typeof(string));

            TaskDataTable = new DataTable("Tasks");
            TaskDataTable.Columns.Add("Task Name", typeof(string));
            TaskDataTable.Columns.Add("Task Description", typeof(string));

            TaskTriggerDataTable = new DataTable("TasksTriggers");
            TaskTriggerDataTable.Columns.Add("Trigger", typeof(string));
            TaskTriggerDataTable.Columns.Add("Trigger Details", typeof(string));
            TaskTriggerDataTable.Columns.Add("Trigger Status", typeof(string));

            TaskActionDataTable = new DataTable("TasksActions");
            TaskActionDataTable.Columns.Add("Action", typeof(string));
            TaskActionDataTable.Columns.Add("File To Run", typeof(string));

            foreach (DataGridViewColumn column in  dataGridTask.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in dataGridTaskTrigger.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in dataGridTaskAction.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        }
        public static List<string[]> compDetails;
        Thread constAddClient;
        private void AddingComputers_Load(object sender, EventArgs e)
        {
            try
            {
                setStats();
                compDetails = db.GetKnownClients();
                foreach (string[] details in compDetails)
                {
                    KnownClient c = new KnownClient(details[0], details[1], details[2], details[3], details[4], details[5]);
                    offlineClients.Add(c);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.objectListOffline.SetObjects(offlineClients);

            this.objectListOffline.PrimarySortColumn = null;

            //Form loads, starts sending off multicasts pew pew pew
            this.objectListView1.SetObjects(clients);
           
            constAddClient = new Thread(AddClients);
            constAddClient.Start();

            this.groupName.GroupKeyGetter = delegate(object rowObject)
            {
                ClientThread client = (ClientThread)rowObject;
                return client.GetGroupName();
            };

            this.groupName.GroupKeyToTitleConverter = delegate(object groupKey)
            {
                return ((string)groupKey).ToString();
            };

            this.objectListView1.PrimarySortColumn = this.groupName;




            //Client hits the multicasts, responds with IP address.
            //Server adds this client to its lists of clients
            //Sends command to client, asking for name and whatnot of hardware.

        }

        public bool checkNewClient(ClientThread c)
        {
            
            string id = Messaging.SendNewCommand("return GetCompID()", c.GetClientSocket());

            bool isNew = db.CheckForNewComputer(id);

            return isNew;
        }

        public void AddClients()
        {
            clients = new List<ClientThread>();
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();
            TcpListener heartBeatListener = new TcpListener(IPAddress.Any, 8889);
            heartBeatListener.Start();
            while (true)
            {
                TcpClient tempClientSocket = new TcpClient();
                TcpClient heartBeatSocket = new TcpClient();
                tempClientSocket.ReceiveTimeout = 300;

                //SendMulticast();
                SendBroadcast();

                //Check and see if a computer is trying to connect. 
                //If not, then sleep, and resend multicast in a second
                if (serverSocket.Pending())
                {
                    tempClientSocket = serverSocket.AcceptTcpClient();

                    heartBeatSocket = heartBeatListener.AcceptTcpClient();
                    
                    ClientThread c = new ClientThread(tempClientSocket, heartBeatSocket);
                    Thread checkHeartBeat = new Thread(() => CheckHeartBeat(heartBeatSocket,c));
                    checkHeartBeat.Start();
                    string compid = c.GetCompID().Trim();
                    //Is New
                    if (!checkNewClient(c))
                    {
                        
                        this.objectListView1.AddObject(c);
                        try
                        {
                            AddClientToDatabase(c);
                            db.InitialSetUptimes(c.GetCompID(), c.GetUptimeHours());
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    //It is Known Khaleesi
                    //It is known
                    else
                    {
                        changeOfflineclient(compid);

                    Console.WriteLine("Connected to " + c.GetClientIP() + " :: " + c.GetPort());

                        this.objectListView1.AddObject(c);
                    
                        string group = db.GetClientGroup(compid.Trim());
                    
                        foreach (Group g in groups)
                        {
                            if (g.GetID().Trim() == group)
                            {
                                c.SetGroup(g);
                            }
                        }

                        clients.Add(c);
                        SetStartGroups();

                    }


                }
                else
                {
                    Thread.Sleep(1000); //Sleep for a second, before sending the next multicast.
                }
            }
        }

        void CheckHeartBeat(TcpClient heartbeat, ClientThread c)
        {
            Messaging.SendCommand("return GetCompDB()", c.GetClientSocket());
            string[] compDB = Messaging.RecieveComputerDetails(c.GetClientSocket());
            KnownClient kc = new KnownClient(compDB[0], compDB[2], compDB[1], "N/A", "N/A", compDB[3]);
            bool connected = true;
            do
            {
                try
                {
                    if (heartbeat.Client.Poll(0, SelectMode.SelectRead))
                    {
                        byte[] buff = new byte[1];
                        if (heartbeat.Client.Receive(buff, SocketFlags.Peek) == 0)
                        {
                            MessageBox.Show("Client left :: ");
                            connected = false;
                        }
                    }
                }
                catch (Exception e)
                {
                   // MessageBox.Show("Client left :: ");
                    connected = false;
                    objectListOffline.AddObject(kc);
                    objectListView1.RemoveObject(c);
                }
               // if (heartbeat.GetStream().ReadByte() < 0 ) { MessageBox.Show("Gone"); }
            } while (connected);
        }

        private void SendMulticast()
        {
            string multiAdd = "224.5.6.7"; //The IP address to send the multicast to.
            Messaging.SendMulticast(multiAdd);
        }

        private void SendBroadcast()
        {
            string broadAdd = "192.168.1.255"; //The IP address to send the multicast to.
            Messaging.SendBroadcast(broadAdd);
        }


        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommandComputer cl = new CommandComputer(objectListView1.SelectedObjects);

            cl.ShowDialog();
        }

        private void AddingComputers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }


        static Thread getComputerHardware;
        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListView1.SelectedObjects.Count != -1) //-1 is null for ints.
            {
                contextMenuStrip1.Enabled = true;
                if (getComputerHardware != null)
                {
                    getComputerHardware.Abort();
                }
                List<ClientThread> c = (List<ClientThread>)objectListView1.SelectedObjects.Cast<ClientThread>().ToList();
                getComputerHardware = new Thread(() => GetComputerHardware(c));
                getComputerHardware.Start();
            }
        }

        Thread AddClientToDB;
        private void AddClientToDatabase(ClientThread client)
        {
            Messaging.SendCommand("return GetProcessDetails();", client.GetClientSocket());
            List<Process> compProc = (List<Process>)Messaging.RecieveProcessDetails(client.GetClientSocket());

            List<string> procnames = new List<string>();

            foreach (Process proc in compProc)
        {
                procnames.Add(proc.GetName());
            }

            procnames = procnames.Distinct().ToList();

            db.AddProcesses(client.GetCompID().Trim(), procnames);
            

            Messaging.SendCommand("return GetSystemDB()", client.GetClientSocket());
            string[] sysDB = Messaging.RecieveComputerDetails(client.GetClientSocket());

            db.InsertIntoTable("SYSTEMCOMPONENTS", sysDB);

            Messaging.SendCommand("return GetCompDB()", client.GetClientSocket());
            string[] compDB = Messaging.RecieveComputerDetails(client.GetClientSocket());

            db.InsertIntoTable("COMPUTER", compDB);


        }
        

        private void GetComputerHardware(List<ClientThread> c)
        {
            
            UpdateProgressBar(true);
            SetHardwareText(new string[]{""});
            SetHardwareUsage(new string[] {"", "", "", ""});
            foreach (ClientThread client in c)
            {
                Messaging.SendCommand("return SendHardwareUsage();", client.GetClientSocket());

                string[] HardwareUsage = Messaging.RecieveComputerDetails(client.GetClientSocket());


                Messaging.SendCommand("return SendHardwareDetails();", client.GetClientSocket());
                SetHardwareText(Messaging.RecieveComputerDetails(client.GetClientSocket()));
                SetHardwareUsage(HardwareUsage);

                Messaging.SendCommand("return GetProcessDetails();", client.GetClientSocket());
                List<Process> ProcList = (List<Process>)Messaging.RecieveProcessDetails(client.GetClientSocket());
                

                SetProcessDataGrid(ProcList);

                
                Messaging.SendCommand("return GetServiceDetails();", client.GetClientSocket());
                List<Service> ServiceList = (List<Service>)Messaging.RecieveServiceDetails(client.GetClientSocket());


                SetServiceDataGrid(ServiceList);

                Messaging.SendCommand("return GetTaskDetails();", client.GetClientSocket());
                List<ScheduledTask> TaskList = (List<ScheduledTask>)Messaging.RecieveTaskDetails(client.GetClientSocket());


                SetTaskDataGrid(TaskList);


                selectedClient = client;
            }
            UpdateProgressBar(false);
        }



        delegate void SetHardwareCallback(string[] details);
        private void SetHardwareText(string[] details)
        {
            if (this.hardwareTreeView.InvokeRequired)
            {
                SetHardwareCallback d = new SetHardwareCallback(SetHardwareText);
                this.Invoke(d, new object[] { details });
            }
            else
            {
                if (details[0] == "")
                {

                }
                else
                {

                    string[] hardwareDetails = details;
                    string[] compDetails = hardwareDetails[0].Split('$');
                    string[] cpuDetails = hardwareDetails[1].Split('$');
                    string[] moboDetails = hardwareDetails[2].Split('$');
                    string[] memoryDetails = hardwareDetails[3].Split('£');
                    string[] storageDetails = hardwareDetails[4].Split('£');
                    string[] displayDetails = hardwareDetails[5].Split('£');

                    //Clearing Nodes
                    this.hardwareTreeView.Nodes[0].Nodes[3].Nodes.Clear();
                    this.hardwareTreeView.Nodes[0].Nodes[4].Nodes.Clear();
                    this.hardwareTreeView.Nodes[0].Nodes[5].Nodes.Clear();

                    //Set Computer Information
                    this.hardwareTreeView.Nodes[0].Nodes[0].Nodes[0].Text = compDetails[0];
                    this.hardwareTreeView.Nodes[0].Nodes[0].Nodes[1].Text = compDetails[1];
                    this.hardwareTreeView.Nodes[0].Nodes[0].Nodes[2].Text = compDetails[2];
                    
                    //Set CPU information
                    this.hardwareTreeView.Nodes[0].Nodes[1].Nodes[0].Text = cpuDetails[0];
                    this.hardwareTreeView.Nodes[0].Nodes[1].Nodes[1].Text = cpuDetails[1];
                    this.hardwareTreeView.Nodes[0].Nodes[1].Nodes[2].Text = cpuDetails[2];

                    //Set Mobo Information
                    this.hardwareTreeView.Nodes[0].Nodes[2].Nodes[0].Text = moboDetails[0];
                    this.hardwareTreeView.Nodes[0].Nodes[2].Nodes[1].Text = moboDetails[1];
                    this.hardwareTreeView.Nodes[0].Nodes[2].Nodes[2].Text = moboDetails[2];

                    //Set Memory Information
                    for(int  i = 0; i < memoryDetails.Length-1; i++)
                    {
                        string[] ram = memoryDetails[i].Split('$');
                        this.hardwareTreeView.Nodes[0].Nodes[3].Nodes.Add(ram[0]);
                        this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].SelectedImageIndex = 4;
                        this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].ImageIndex = 4;
                        for (int j = 0; j < ram.Length-1; j++)
                        {
                            this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes.Add(ram[j]);
                            this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes[j].SelectedImageIndex = 4;
                            this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes[j].ImageIndex = 4;
                            this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[i].Nodes[j].StateImageIndex = 4;


                        }
                    }

                    this.hardwareTreeView.Nodes[0].Nodes[3].Nodes.Add(memoryDetails[memoryDetails.Length-1] + " MB");
                    this.hardwareTreeView.Nodes[0].Nodes[3].Nodes[memoryDetails.Length - 1].ImageIndex = 4;

                    //Set Storage Information
                    for (int i = 0; i < storageDetails.Length - 1; i++)
                    {
                        string[] drive = storageDetails[i].Split('$');
                        this.hardwareTreeView.Nodes[0].Nodes[4].Nodes.Add(drive[0]);
                        this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].SelectedImageIndex = 5;
                        this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].ImageIndex = 5;
                        for (int j = 0; j < drive.Length - 1; j++)
                        {
                            this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].Nodes.Add(drive[j]);
                            this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].Nodes[j].SelectedImageIndex = 5;
                            this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].Nodes[j].ImageIndex = 5;
                            this.hardwareTreeView.Nodes[0].Nodes[4].Nodes[i].Nodes[j].StateImageIndex = 5;
                        }
                    }

                    //Set display adapter information
                   for (int i = 0; i < displayDetails.Length - 1; i++)
                    {
                        string[] adapter = displayDetails[i].Split('$');
                        this.hardwareTreeView.Nodes[0].Nodes[5].Nodes.Add(adapter[0]);
                        this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].SelectedImageIndex = 2;
                        this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].ImageIndex = 2;
                        for (int j = 0; j < adapter.Length - 1; j++)
                        {
                            this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].Nodes.Add(adapter[j]);
                            this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].Nodes[j].SelectedImageIndex = 2;
                            this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].Nodes[j].ImageIndex = 2;
                            this.hardwareTreeView.Nodes[0].Nodes[5].Nodes[i].Nodes[j].StateImageIndex = 2;
                        }
                    }

                }

            }
        }

        delegate void SetProcessDataGridCallback(List<Process> ProcList);
        private void SetProcessDataGrid(List<Process> ProcList)
        {
            if (this.dataGridProcess.InvokeRequired)
            {
                SetProcessDataGridCallback d = new SetProcessDataGridCallback(SetProcessDataGrid);
                this.Invoke(d, new object[] { ProcList });
            }
            else
            {
                ProcNames = new List<string>();
                ProcessDataTable.Rows.Clear();
                foreach (Process proc in ProcList)
                {
                    if(proc != null)
                    {
                        ProcessDataTable.Rows.Add((int)proc.GetPID(), (string)proc.GetName(), (int)proc.CPU, (int)proc.Memory, (int)proc.ThreadCount);
                        ProcNames.Add((string)proc.GetName());
                    }
                }

                dataGridProcess.DataSource = ProcessDataTable;
                dataGridProcess.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void UpdateProcessDataGridCallback();
        private void UpdateProcessDataGrid()
        {
            
            if (this.dataGridProcess.InvokeRequired)
            {
                SetProcessDataGridCallback d = new SetProcessDataGridCallback(SetProcessDataGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Messaging.SendCommand("return GetProcessDetails();", selectedClient.GetClientSocket());
                List<Process> ProcList = (List<Process>)Messaging.RecieveProcessDetails(selectedClient.GetClientSocket());

                ProcNames = new List<string>();
                ProcessDataTable.Rows.Clear();
                foreach (Process proc in ProcList)
                {
                    if (proc != null)
                    {
                        ProcessDataTable.Rows.Add((int)proc.GetPID(), (string)proc.GetName(), (int)proc.CPU, (int)proc.Memory, (int)proc.ThreadCount);
                        ProcNames.Add((string)proc.GetName());
                    }
                }

                dataGridProcess.DataSource = ProcessDataTable;
                dataGridProcess.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void SetServiceDataGridCallback(List<Service> ServiceList);
        private void SetServiceDataGrid(List<Service> ServiceList)
        {
            if (this.dataGridService.InvokeRequired)
            {
                SetServiceDataGridCallback d = new SetServiceDataGridCallback(SetServiceDataGrid);
                this.Invoke(d, new object[] { ServiceList });
            }
            else
            {
                ServiceDataTable.Rows.Clear();

                foreach (Service serv in ServiceList)
                {
                    try
                    {
                    if (serv != null)
                    {
                        ServiceDataTable.Rows.Add(serv.GetServiceName(), serv.GetServiceType(), serv.GetDisplayName(), serv.GetStatus(), serv.GetStartupType());
                    }
                    }
                    catch (System.Exception ex)
                    {

                    }

                }

                dataGridService.DataSource = ServiceDataTable;
                dataGridService.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void UpdateServiceDataGridCallback();
        private void UpdateServiceDataGrid()
        {

            if (this.dataGridService.InvokeRequired)
            {
                SetServiceDataGridCallback d = new SetServiceDataGridCallback(SetServiceDataGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Messaging.SendCommand("return GetServiceDetails();", selectedClient.GetClientSocket());
                List<Service> ServiceList = (List<Service>)Messaging.RecieveServiceDetails(selectedClient.GetClientSocket());

                ServiceDataTable.Rows.Clear();
                foreach (Service serv in ServiceList)
                {
                    if (serv != null)
                    {
                        ServiceDataTable.Rows.Add(serv.GetServiceName(), serv.GetServiceType(), serv.GetDisplayName(), serv.GetStatus(), serv.GetStartupType());
                    }
                }

                dataGridService.DataSource = ServiceDataTable;
                dataGridService.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void SetTaskDataGridCallback(List<ScheduledTask> TaskList);
        private void SetTaskDataGrid(List<ScheduledTask> TaskList)
        {
            this.TaskList = TaskList;
            if (this.dataGridTask.InvokeRequired)
            {
                SetTaskDataGridCallback d = new SetTaskDataGridCallback(SetTaskDataGrid);
                this.Invoke(d, new object[] { TaskList });
            }
            else
            {
                TaskDataTable.Rows.Clear();

                foreach (ScheduledTask t in TaskList)
                {
                    if (t != null)
                    {
                        TaskDataTable.Rows.Add(t.GetTaskName(), t.GetTaskDescription());
                    }
                }

                dataGridTask.DataSource = TaskDataTable;
                dataGridTask.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void UpdateTaskDataGridCallback();
        public void UpdateTaskDataGrid()
        {

            if (this.dataGridTask.InvokeRequired)
            {
                SetTaskDataGridCallback d = new SetTaskDataGridCallback(SetTaskDataGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                Messaging.SendCommand("return GetTaskDetails();", selectedClient.GetClientSocket());
                TaskList = (List<ScheduledTask>)Messaging.RecieveTaskDetails(selectedClient.GetClientSocket());

                TaskDataTable.Rows.Clear();
                foreach (ScheduledTask t in TaskList)
                {
                    if (t != null)
                    {
                        TaskDataTable.Rows.Add(t.GetTaskName(), t.GetTaskDescription());
                    }
                }

                dataGridTask.DataSource = TaskDataTable;
                dataGridTask.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void SetTaskTriggerDataGridCallback(List<SerialTrigger> TaskTriggerList);
        private void SetTaskTriggerDataGrid(List<SerialTrigger> TaskTriggerList)
        {
            if (this.dataGridTaskTrigger.InvokeRequired)
            {
                SetTaskTriggerDataGridCallback d = new SetTaskTriggerDataGridCallback(SetTaskTriggerDataGrid);
                this.Invoke(d, new object[] { TaskTriggerList });
            }
            else
            {
                TaskTriggerDataTable.Rows.Clear();

                foreach (SerialTrigger t in TaskTriggerList)
                {
                    if (t != null)
                    {
                        TaskTriggerDataTable.Rows.Add(t.GetName(), t.GetDetails(), t.GetStatus());
                    }
                }

                dataGridTaskTrigger.DataSource = TaskTriggerDataTable;
                dataGridTaskTrigger.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void UpdateTaskTriggerDataGridCallback();
        public void UpdateTaskTriggerDataGrid()
        {

            if (this.dataGridTaskTrigger.InvokeRequired)
            {
                SetTaskTriggerDataGridCallback d = new SetTaskTriggerDataGridCallback(SetTaskTriggerDataGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                List<SerialTrigger> TaskTriggerList;

                if (dataGridTask.SelectedRows == null)
                {
                    TaskTriggerList = FindTask(dataGridTask.Rows[0].Cells[0].Value.ToString()).GetSerialTriggers();
                }
                else
                {
                    TaskTriggerList = FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString()).GetSerialTriggers();
                }

                TaskTriggerDataTable.Rows.Clear();
                foreach (SerialTrigger t in TaskTriggerList)
                {
                    if (t != null)
                    {
                        TaskTriggerDataTable.Rows.Add(t.GetName(), t.GetDetails(), t.GetStatus());
                    }
                }

                dataGridTaskTrigger.DataSource = TaskTriggerDataTable;
                dataGridTaskTrigger.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void SetTaskActionDataGridCallback(List<SerialAction> TaskActionList);
        private void SetTaskActionDataGrid(List<SerialAction> TaskActionList)
        {
            if (this.dataGridTaskAction.InvokeRequired)
            {
                SetTaskActionDataGridCallback d = new SetTaskActionDataGridCallback(SetTaskActionDataGrid);
                this.Invoke(d, new object[] { TaskActionList });
            }
            else
            {
                TaskActionDataTable.Rows.Clear();

                foreach (SerialAction t in TaskActionList)
                {
                    if (t != null)
                    {
                        TaskActionDataTable.Rows.Add(t.GetName(), t.GetFileToRun());
                    }
                }

                dataGridTaskAction.DataSource = TaskActionDataTable;
                dataGridTaskAction.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        delegate void UpdateTaskActionDataGridCallback();
        public void UpdateTaskActionDataGrid()
        {

            if (this.dataGridTaskAction.InvokeRequired)
            {
                SetTaskActionDataGridCallback d = new SetTaskActionDataGridCallback(SetTaskActionDataGrid);
                this.Invoke(d, new object[] { });
            }
            else
            {
                List<SerialAction> TaskActionList;

                if (dataGridTask.SelectedRows == null)
                {
                    TaskActionList = FindTask(dataGridTask.Rows[0].Cells[0].Value.ToString()).GetSerialActions();
                }
                else
                {
                    TaskActionList = FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString()).GetSerialActions();
                }

                TaskActionDataTable.Rows.Clear();
                foreach (SerialAction t in TaskActionList)
                {
                    if (t != null)
                    {
                        TaskActionDataTable.Rows.Add(t.GetName(), t.GetFileToRun());
                    }
                }

                dataGridTaskAction.DataSource = TaskActionDataTable;
                dataGridTaskAction.Refresh();
                toolStriplblLastUpdate.Text = "Last Updated At: " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        public ScheduledTask FindTask(string name)
        {
            foreach (ScheduledTask t in TaskList)
            {
                if (t.GetTaskName() == name)
                {
                    return t;
                }
            }
            return null;
        }


        delegate void SetHardwareUsageCallback(string[] usage);
        private void SetHardwareUsage(string[] usage)
        {
            if (this.lblCPUUsage.InvokeRequired)
            {
                SetHardwareUsageCallback d = new SetHardwareUsageCallback(SetHardwareUsage);
                this.Invoke(d, new object[] { usage });
            }
            else
            {
                if (usage[0] == "")
                {
                }
                else
                {
                    //Set CPU Usage Labels
                    string[] cpudetails = usage[0].Split('$'); //0 = Uptime: 1 = Utilisation: 2 = Threads: 3 = Processes
                    this.lblUptimeAns.Text = cpudetails[0];
                    this.lblCPUUsageAns.Text = cpudetails[1];
                    this.lblThreadsAns.Text = cpudetails[2];
                    this.lblProcessesAns.Text = cpudetails[3];

                    //Set RAM Usage Labels
                    string[] ramdetails = usage[1].Split('$');
                    this.lblTotalRAMAns.Text = ramdetails[0];
                    this.lblFreeRAMAns.Text = ramdetails[1];
                    this.lblInUseRAMAns.Text = ramdetails[2];

                    //Set Network Usage
                    string[] nicdetails = usage[3].Split('$');
                    this.txtBoxNetworkUsage.Text = "";
                    foreach (string nic in nicdetails)
                    {
                        this.txtBoxNetworkUsage.Text += nic + Environment.NewLine;
                    }

                    //Set Volume Usage

                    this.txtBoxVolUsage.Text = "";
                    string[] diskperf = usage[2].Split('$');
                    foreach (string disk in diskperf)
                    {
                        this.txtBoxVolUsage.Text += disk + Environment.NewLine;
                    }
                }
            }
            //this.lblCPUUsage.Text = usage[0];

        }


        delegate string GetHardwareCallback();
        private string GetHardwareText()
        {
            if (this.hardwareTreeView.InvokeRequired)
            {
                GetHardwareCallback d = new GetHardwareCallback(GetHardwareText);
                return (string)this.Invoke(d, new object[] { });
            }
            else
            {
                return "";
            }
        }

        delegate void StartGroupsCallback();
        private void SetStartGroups()
        {
            if (this.objectListView1.InvokeRequired)
            {
                StartGroupsCallback d = new StartGroupsCallback(SetStartGroups);
                this.Invoke(d, new object[] { });
            }
            else
            {
                this.objectListView1.RebuildColumns();
                this.objectListView1.Refresh();
            }
        }



        delegate void ProgressBarCallback(bool start);
        private void UpdateProgressBar(bool start)
        {
            if (this.progressBar1.InvokeRequired)
            {
                ProgressBarCallback d = new ProgressBarCallback(UpdateProgressBar);
                this.Invoke(d, new object[] { start });
            }
            else
            {
                if (start)
                {
                    progressBar1.Show();
                    progressBar1.MarqueeAnimationSpeed = 30;
                }
                else
                {
                    progressBar1.Hide();
                    progressBar1.MarqueeAnimationSpeed = 0;
                }
            }
        }

        delegate void offlineClientCallback(string compid);
        private void changeOfflineclient(string compid)
        {
            if (this.objectListOffline.InvokeRequired)
            {
                offlineClientCallback d = new offlineClientCallback(changeOfflineclient);
                this.Invoke(d, new object[] {compid});
            }
            else
            {
                objectListOffline.SelectAll();
                foreach(Object obj in objectListOffline.SelectedObjects)
                {
                   KnownClient kc = (KnownClient)obj;
                        if(compid.Trim() == kc.GetCompID().Trim())
                        {

                            objectListOffline.RemoveObject(kc);
                        }
                }
                
            }
        }

        delegate void setStatsCallback();
        private void setStats()
        {
            if (this.lblCommonProcessorAns.InvokeRequired)
            {
                setStatsCallback d = new setStatsCallback(setStats);
                this.Invoke(d, new object[] { });
            }
            else
            {
                string[] stats = db.GetStats();

                this.lblCommonProcessorAns.Text = stats[0];
                this.lblCommonMoboAns.Text = stats[1];
                this.lblCommonDisplayAns.Text = stats[2];
                this.lblAverageRAMAns.Text = stats[3];
                this.lblAverageStorageAns.Text = stats[4];
                this.lblAvgUptimeAns.Text = stats[5];

            }
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTP ftp = new FTP(clients);
            ftp.ShowDialog();
        }

        private void newGroupToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CreateNewGroup cng = new CreateNewGroup(ref groups, db, this);
            cng.Show();
        }

        private void addToGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseGroup cg = new ChooseGroup(ref groups, objectListView1.SelectedObject,  this, db);
            cg.Show();
        }

        private void addToGroupToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
        }

        private void newGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void startNewProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedClient != null)
            {
              NewProcess np = new NewProcess(selectedClient, this, db);
              np.Show();
            }
            else
            {
                MessageBox.Show("Please Select A client");
            }
        }

        private void restartProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedClient != null)
            {
                if (dataGridProcess.SelectedRows.Count < 1)
                {
                    restartProcessesToolStripMenuItem.Enabled = false;
                }
                else
                {
                    restartProcessesToolStripMenuItem.Enabled = true;
                    string PIDS = "";
                    foreach (DataGridViewRow row in dataGridProcess.SelectedRows)
                    {
                        PIDS += row.Cells[0].Value.ToString().Trim() + '$';
                    }
                    Messaging.SendCommand(@"return RestartProcesses(""" + PIDS + @""");", selectedClient.GetClientSocket());
                    string results = Messaging.RecieveCommand(selectedClient.GetClientSocket()).Trim();
                    string[] ResArr = results.Split('$');
                    ResArr[ResArr.Length - 1] = "$";
                    results = "";
                    foreach (string res in ResArr)
                    {
                        if (res != "$")
                        {
                            string[] r = res.Split(new string[] { "::" }, StringSplitOptions.None);
                            if (r[1] == "True")
                            {
                                results += r[0] + ":: Restart Successfull" + Environment.NewLine;
                            }
                            else
                            {
                                results += r[0] + ":: Restart UnSuccessfull" + Environment.NewLine;
                            }
                        }
                    }
                    MessageBox.Show(results);
                    UpdateProcessDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please Select A client");
            }
        }

        private void endProcessesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedClient != null)
            {
                if (dataGridProcess.SelectedRows.Count < 1)
                {
                    restartProcessesToolStripMenuItem.Enabled = false;
                }
                else
                {
                    restartProcessesToolStripMenuItem.Enabled = true;
                    string PIDS = "";
                    foreach (DataGridViewRow row in dataGridProcess.SelectedRows)
                    {
                        PIDS += row.Cells[0].Value.ToString().Trim() + '$';
                    }
                    Messaging.SendCommand(@"return StopProcesses(""" + PIDS + @""");", selectedClient.GetClientSocket());
                    string results = Messaging.RecieveCommand(selectedClient.GetClientSocket());
                    string[] ResArr = results.Split('$');
                    ResArr[ResArr.Length - 1] = "$";
                    results = "";
                    foreach (string res in ResArr)
                    {
                        if (res != "$")
                        {
                            string[] r = res.Split(new string[] { "::" }, StringSplitOptions.None);
                            if (r[1] == "True")
                            {
                                results += r[0] + ":: Ended Successfully" + Environment.NewLine;
                            }
                            else
                            {
                                results += r[0] + ":: Unable To End" + Environment.NewLine;
                            }
                        }
                    }
                    MessageBox.Show(results);
                    UpdateProcessDataGrid();
                }
            }
            else
            {
                MessageBox.Show("Please Select A client");
            }
        }

        public void _UpdateProcDataGrid()
        {
            UpdateProcessDataGrid();
        }

        public void _UpdateGroupList()
        {
            groups = db.GetGroups();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Object obj in objectListView1.SelectedObjects)
            {
                ClientThread c = (ClientThread)obj;
                Messaging.SendCommand("return GetCompDB()", c.GetClientSocket());
                string[] compDB = Messaging.RecieveComputerDetails(c.GetClientSocket());
                KnownClient kc = new KnownClient(compDB[0], compDB[2], compDB[1], "N/A", "N/A", compDB[3]);
                objectListOffline.AddObject(kc);
                Messaging.SendCommand("PowerControl(5);", c.GetClientSocket());
                clients.Remove((ClientThread)obj);
                objectListView1.RemoveObject(obj);
            }
        }

        private void dataGridService_MouseClick(object sender, MouseEventArgs e)
        {
        }


        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("StartService('"+dataGridService.SelectedRows[0].Cells[0].Value+"');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("StopServices('" + dataGridService.SelectedRows[0].Cells[0].Value + "');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("RestartServices('" + dataGridService.SelectedRows[0].Cells[0].Value + "');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

       

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("EnableServices('" + dataGridService.SelectedRows[0].Cells[0].Value + "');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("DisableServices('" + dataGridService.SelectedRows[0].Cells[0].Value + "');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

        private void autoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("AutoServices('" + dataGridService.SelectedRows[0].Cells[0].Value + "');", selectedClient.GetClientSocket());
            UpdateServiceDataGrid();
        }

        private void dataGridTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridTask_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridTask.SelectedCells.Count>0)
            {
                UpdateTaskTriggerDataGrid();
                UpdateTaskActionDataGrid();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ScheduledTask t = FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString());
           AddNewTrigger ant = new AddNewTrigger(ref t, selectedClient, this);
           ant.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNewTask ant = new AddNewTask(this, (ClientThread)objectListView1.SelectedObjects[0]);
            ant.Show();
        }


        internal string UpdateTasks()
        {
            TaskList.Clear(); 
            Messaging.SendCommand("return GetTaskDetails();",  selectedClient.GetClientSocket());
            TaskList = (List<ScheduledTask>)Messaging.RecieveTaskDetails(selectedClient.GetClientSocket());
            return "Done";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("return DeleteTrigger('" + FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString()).GetTaskName() + "'," + dataGridTaskTrigger.SelectedRows[0].Index + ");", selectedClient.GetClientSocket());
            UpdateTasks();
            UpdateTaskTriggerDataGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScheduledTask task = FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString());
            AddAction aa = new AddAction(ref task , selectedClient, this);
            aa.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("return DeleteTask('" + FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString()) .GetTaskName()+ "');", selectedClient.GetClientSocket());
            UpdateTasks();
            UpdateTaskDataGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Messaging.SendNewCommand("return DeleteAction('" + FindTask(dataGridTask.SelectedRows[0].Cells[0].Value.ToString()).GetTaskName() + "'," + dataGridTaskAction.SelectedRows[0].Index + ");", selectedClient.GetClientSocket());
            UpdateTasks();
            UpdateTaskActionDataGrid();
        }
        private void databaseSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DatabaseSettings dbs = new DatabaseSettings(db);
            dbs.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }
    }
}
