namespace Server
{
    partial class ServerMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("ID: ");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Operating System: ");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Computer Name: ");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Computer Details", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Name: ", 1, 1);
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Physical Cores: ", 1, 1);
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Logical Cores:", 1, 1);
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("CPU", 1, 1, new System.Windows.Forms.TreeNode[] {
            treeNode21,
            treeNode22,
            treeNode23});
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Manufacturer:", 3, 3);
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Model:", 3, 3);
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("System Model: ", 3, 3);
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Motherboard", 3, 3, new System.Windows.Forms.TreeNode[] {
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Memory", 4, 4);
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Storage", 5, 5);
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("Display Adapters", 2, 2);
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("System", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode24,
            treeNode28,
            treeNode29,
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMain));
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.compID = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.compName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.ip = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.port = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.groupName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.getUptime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGroupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabInfoContainer = new System.Windows.Forms.TabControl();
            this.tabHardwarePage = new System.Windows.Forms.TabPage();
            this.tabControlHardware = new System.Windows.Forms.TabControl();
            this.tabPageHardwareDetails = new System.Windows.Forms.TabPage();
            this.hardwareTreeView = new System.Windows.Forms.TreeView();
            this.hardwareDetailsImages = new System.Windows.Forms.ImageList(this.components);
            this.tabPageHardwareUsage = new System.Windows.Forms.TabPage();
            this.tblLayoutHardwareUsage = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxRAMUsage = new System.Windows.Forms.GroupBox();
            this.lblInUseRAMAns = new System.Windows.Forms.Label();
            this.lblInUseRAM = new System.Windows.Forms.Label();
            this.lblFreeRAMAns = new System.Windows.Forms.Label();
            this.lblTotalRAMAns = new System.Windows.Forms.Label();
            this.lblFreeRAM = new System.Windows.Forms.Label();
            this.lblTotalRAM = new System.Windows.Forms.Label();
            this.grpNetworkUsage = new System.Windows.Forms.GroupBox();
            this.txtBoxNetworkUsage = new System.Windows.Forms.RichTextBox();
            this.grpBoxVolUsage = new System.Windows.Forms.GroupBox();
            this.txtBoxVolUsage = new System.Windows.Forms.RichTextBox();
            this.grpBoxCPUUsage = new System.Windows.Forms.GroupBox();
            this.lblThreadsAns = new System.Windows.Forms.Label();
            this.lblProcessesAns = new System.Windows.Forms.Label();
            this.lblCPUUsageAns = new System.Windows.Forms.Label();
            this.lblUptimeAns = new System.Windows.Forms.Label();
            this.lblNumthreads = new System.Windows.Forms.Label();
            this.lblNumProcesses = new System.Windows.Forms.Label();
            this.lblCPUUsage = new System.Windows.Forms.Label();
            this.lblUptime = new System.Windows.Forms.Label();
            this.tabProcessPage = new System.Windows.Forms.TabPage();
            this.dataGridProcess = new System.Windows.Forms.DataGridView();
            this.contextMenuProcess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.endProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartProcessesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabServicePage = new System.Windows.Forms.TabPage();
            this.dataGridService = new System.Windows.Forms.DataGridView();
            this.serviceContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSchedule = new System.Windows.Forms.TabPage();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridTaskTrigger = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridTaskAction = new System.Windows.Forms.DataGridView();
            this.dataGridTask = new System.Windows.Forms.DataGridView();
            this.tabpageStatistics = new System.Windows.Forms.TabPage();
            this.tblLayoutStats = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutStatLabels = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCommonProcessor = new System.Windows.Forms.Label();
            this.lblMostCommonMobo = new System.Windows.Forms.Label();
            this.lblMostCommonDisplay = new System.Windows.Forms.Label();
            this.lblAverageRAM = new System.Windows.Forms.Label();
            this.lblAverageStorage = new System.Windows.Forms.Label();
            this.lblAvgUptime = new System.Windows.Forms.Label();
            this.flowLayoutStatText = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCommonProcessorAns = new System.Windows.Forms.Label();
            this.lblCommonMoboAns = new System.Windows.Forms.Label();
            this.lblCommonDisplayAns = new System.Windows.Forms.Label();
            this.lblAverageRAMAns = new System.Windows.Forms.Label();
            this.lblAverageStorageAns = new System.Windows.Forms.Label();
            this.lblAvgUptimeAns = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.statusStripBot = new System.Windows.Forms.StatusStrip();
            this.toolStriplblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            this.serverMainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tabControlCliens = new System.Windows.Forms.TabControl();
            this.onlineClients = new System.Windows.Forms.TabPage();
            this.offlinClients = new System.Windows.Forms.TabPage();
            this.objectListOffline = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn6 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabInfoContainer.SuspendLayout();
            this.tabHardwarePage.SuspendLayout();
            this.tabControlHardware.SuspendLayout();
            this.tabPageHardwareDetails.SuspendLayout();
            this.tabPageHardwareUsage.SuspendLayout();
            this.tblLayoutHardwareUsage.SuspendLayout();
            this.grpBoxRAMUsage.SuspendLayout();
            this.grpNetworkUsage.SuspendLayout();
            this.grpBoxVolUsage.SuspendLayout();
            this.grpBoxCPUUsage.SuspendLayout();
            this.tabProcessPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcess)).BeginInit();
            this.contextMenuProcess.SuspendLayout();
            this.tabServicePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridService)).BeginInit();
            this.serviceContextStrip.SuspendLayout();
            this.tabPageSchedule.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTaskTrigger)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTaskAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).BeginInit();
            this.tabpageStatistics.SuspendLayout();
            this.tblLayoutStats.SuspendLayout();
            this.flowLayoutStatLabels.SuspendLayout();
            this.flowLayoutStatText.SuspendLayout();
            this.statusStripBot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.serverMainSplitContainer)).BeginInit();
            this.serverMainSplitContainer.Panel1.SuspendLayout();
            this.serverMainSplitContainer.Panel2.SuspendLayout();
            this.serverMainSplitContainer.SuspendLayout();
            this.tabControlCliens.SuspendLayout();
            this.onlineClients.SuspendLayout();
            this.offlinClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListOffline)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.AllColumns.Add(this.compID);
            this.objectListView1.AllColumns.Add(this.compName);
            this.objectListView1.AllColumns.Add(this.ip);
            this.objectListView1.AllColumns.Add(this.port);
            this.objectListView1.AllColumns.Add(this.groupName);
            this.objectListView1.AllColumns.Add(this.getUptime);
            this.objectListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.compID,
            this.compName,
            this.ip,
            this.port,
            this.groupName,
            this.getUptime});
            this.objectListView1.ContextMenuStrip = this.contextMenuStrip1;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.FullRowSelect = true;
            this.objectListView1.IsSearchOnSortColumn = false;
            this.objectListView1.Location = new System.Drawing.Point(3, 3);
            this.objectListView1.MenuLabelGroupBy = "Group by \'groupName\'";
            this.objectListView1.MenuLabelLockGroupingOn = "Lock grouping on \'groupName\'";
            this.objectListView1.MenuLabelSortAscending = "Sort ascending by \'groupName\'";
            this.objectListView1.MenuLabelSortDescending = "Sort descending by \'groupName\'";
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(633, 456);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            this.objectListView1.SelectedIndexChanged += new System.EventHandler(this.objectListView1_SelectedIndexChanged);
            // 
            // compID
            // 
            this.compID.AspectName = "GetCompID";
            this.compID.Text = "Computer ID";
            this.compID.Width = 73;
            // 
            // compName
            // 
            this.compName.AspectName = "GetComputerName";
            this.compName.Groupable = false;
            this.compName.Text = "Computer Name";
            this.compName.Width = 92;
            // 
            // ip
            // 
            this.ip.AspectName = "GetClientIP";
            this.ip.Groupable = false;
            this.ip.Text = "IP Address";
            this.ip.Width = 110;
            // 
            // port
            // 
            this.port.AspectName = "GetPort";
            this.port.Groupable = false;
            this.port.Text = "Port Number";
            this.port.Width = 107;
            // 
            // groupName
            // 
            this.groupName.AspectName = "GetGroupName";
            this.groupName.Text = "Group";
            this.groupName.Width = 79;
            // 
            // getUptime
            // 
            this.getUptime.AspectName = "GetUptime";
            this.getUptime.Text = "Uptime D:H:M:S";
            this.getUptime.Width = 100;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendMessageToolStripMenuItem,
            this.groupToolStripMenuItem,
            this.fTPToolStripMenuItem,
            this.shutdownToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 92);
            // 
            // sendMessageToolStripMenuItem
            // 
            this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
            this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sendMessageToolStripMenuItem.Text = "Send Command";
            this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
            // 
            // groupToolStripMenuItem
            // 
            this.groupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToGroupToolStripMenuItem,
            this.commandGroupToolStripMenuItem,
            this.removeFromGroupToolStripMenuItem,
            this.newGroupToolStripMenuItem1});
            this.groupToolStripMenuItem.Name = "groupToolStripMenuItem";
            this.groupToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.groupToolStripMenuItem.Text = "Group";
            // 
            // addToGroupToolStripMenuItem
            // 
            this.addToGroupToolStripMenuItem.Name = "addToGroupToolStripMenuItem";
            this.addToGroupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.addToGroupToolStripMenuItem.Text = "Add To Group";
            this.addToGroupToolStripMenuItem.Click += new System.EventHandler(this.addToGroupToolStripMenuItem_Click);
            this.addToGroupToolStripMenuItem.MouseHover += new System.EventHandler(this.addToGroupToolStripMenuItem_MouseHover);
            // 
            // commandGroupToolStripMenuItem
            // 
            this.commandGroupToolStripMenuItem.Name = "commandGroupToolStripMenuItem";
            this.commandGroupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.commandGroupToolStripMenuItem.Text = "Command Group";
            // 
            // removeFromGroupToolStripMenuItem
            // 
            this.removeFromGroupToolStripMenuItem.Name = "removeFromGroupToolStripMenuItem";
            this.removeFromGroupToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.removeFromGroupToolStripMenuItem.Text = "Remove From Group";
            // 
            // newGroupToolStripMenuItem1
            // 
            this.newGroupToolStripMenuItem1.Name = "newGroupToolStripMenuItem1";
            this.newGroupToolStripMenuItem1.Size = new System.Drawing.Size(184, 22);
            this.newGroupToolStripMenuItem1.Text = "New Group";
            this.newGroupToolStripMenuItem1.Click += new System.EventHandler(this.newGroupToolStripMenuItem1_Click);
            // 
            // fTPToolStripMenuItem
            // 
            this.fTPToolStripMenuItem.Name = "fTPToolStripMenuItem";
            this.fTPToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fTPToolStripMenuItem.Text = "FTP";
            this.fTPToolStripMenuItem.Click += new System.EventHandler(this.fTPToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // tabInfoContainer
            // 
            this.tabInfoContainer.Controls.Add(this.tabHardwarePage);
            this.tabInfoContainer.Controls.Add(this.tabProcessPage);
            this.tabInfoContainer.Controls.Add(this.tabServicePage);
            this.tabInfoContainer.Controls.Add(this.tabPageSchedule);
            this.tabInfoContainer.Controls.Add(this.tabpageStatistics);
            this.tabInfoContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfoContainer.Location = new System.Drawing.Point(0, 0);
            this.tabInfoContainer.Name = "tabInfoContainer";
            this.tabInfoContainer.SelectedIndex = 0;
            this.tabInfoContainer.Size = new System.Drawing.Size(624, 488);
            this.tabInfoContainer.TabIndex = 2;
            // 
            // tabHardwarePage
            // 
            this.tabHardwarePage.Controls.Add(this.tabControlHardware);
            this.tabHardwarePage.Location = new System.Drawing.Point(4, 22);
            this.tabHardwarePage.Name = "tabHardwarePage";
            this.tabHardwarePage.Padding = new System.Windows.Forms.Padding(3);
            this.tabHardwarePage.Size = new System.Drawing.Size(616, 462);
            this.tabHardwarePage.TabIndex = 0;
            this.tabHardwarePage.Text = "Hardware";
            this.tabHardwarePage.UseVisualStyleBackColor = true;
            // 
            // tabControlHardware
            // 
            this.tabControlHardware.Controls.Add(this.tabPageHardwareDetails);
            this.tabControlHardware.Controls.Add(this.tabPageHardwareUsage);
            this.tabControlHardware.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHardware.Location = new System.Drawing.Point(3, 3);
            this.tabControlHardware.Name = "tabControlHardware";
            this.tabControlHardware.SelectedIndex = 0;
            this.tabControlHardware.Size = new System.Drawing.Size(610, 456);
            this.tabControlHardware.TabIndex = 2;
            // 
            // tabPageHardwareDetails
            // 
            this.tabPageHardwareDetails.Controls.Add(this.hardwareTreeView);
            this.tabPageHardwareDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageHardwareDetails.Name = "tabPageHardwareDetails";
            this.tabPageHardwareDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHardwareDetails.Size = new System.Drawing.Size(602, 430);
            this.tabPageHardwareDetails.TabIndex = 0;
            this.tabPageHardwareDetails.Text = "Details";
            this.tabPageHardwareDetails.UseVisualStyleBackColor = true;
            // 
            // hardwareTreeView
            // 
            this.hardwareTreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.hardwareTreeView.ImageIndex = 0;
            this.hardwareTreeView.ImageList = this.hardwareDetailsImages;
            this.hardwareTreeView.Location = new System.Drawing.Point(3, 3);
            this.hardwareTreeView.Name = "hardwareTreeView";
            treeNode17.Name = "ComputerID";
            treeNode17.Text = "ID: ";
            treeNode18.Name = "OperatingSystem";
            treeNode18.Text = "Operating System: ";
            treeNode19.Name = "ComputerName";
            treeNode19.Text = "Computer Name: ";
            treeNode20.Name = "ComputerDetails";
            treeNode20.Text = "Computer Details";
            treeNode21.ImageIndex = 1;
            treeNode21.Name = "CPUName";
            treeNode21.SelectedImageIndex = 1;
            treeNode21.Text = "Name: ";
            treeNode22.ImageIndex = 1;
            treeNode22.Name = "PhysicalCores";
            treeNode22.SelectedImageIndex = 1;
            treeNode22.Text = "Physical Cores: ";
            treeNode23.ImageIndex = 1;
            treeNode23.Name = "LogicalCores";
            treeNode23.SelectedImageIndex = 1;
            treeNode23.Text = "Logical Cores:";
            treeNode24.ImageIndex = 1;
            treeNode24.Name = "CPU";
            treeNode24.SelectedImageIndex = 1;
            treeNode24.Text = "CPU";
            treeNode25.ImageIndex = 3;
            treeNode25.Name = "MoboManufacturer";
            treeNode25.SelectedImageIndex = 3;
            treeNode25.Text = "Manufacturer:";
            treeNode26.ImageIndex = 3;
            treeNode26.Name = "MoboModel: ";
            treeNode26.SelectedImageIndex = 3;
            treeNode26.Text = "Model:";
            treeNode27.ImageIndex = 3;
            treeNode27.Name = "MoboSystemModel";
            treeNode27.SelectedImageIndex = 3;
            treeNode27.Text = "System Model: ";
            treeNode28.ImageIndex = 3;
            treeNode28.Name = "Motherboard";
            treeNode28.SelectedImageIndex = 3;
            treeNode28.Text = "Motherboard";
            treeNode29.ImageIndex = 4;
            treeNode29.Name = "Memory";
            treeNode29.SelectedImageIndex = 4;
            treeNode29.Text = "Memory";
            treeNode30.ImageIndex = 5;
            treeNode30.Name = "Storage";
            treeNode30.SelectedImageIndex = 5;
            treeNode30.Text = "Storage";
            treeNode31.ImageIndex = 2;
            treeNode31.Name = "Display";
            treeNode31.SelectedImageIndex = 2;
            treeNode31.Text = "Display Adapters";
            treeNode32.ImageIndex = 0;
            treeNode32.Name = "System";
            treeNode32.Text = "System";
            this.hardwareTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode32});
            this.hardwareTreeView.SelectedImageIndex = 0;
            this.hardwareTreeView.Size = new System.Drawing.Size(345, 424);
            this.hardwareTreeView.TabIndex = 0;
            // 
            // hardwareDetailsImages
            // 
            this.hardwareDetailsImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("hardwareDetailsImages.ImageStream")));
            this.hardwareDetailsImages.TransparentColor = System.Drawing.Color.Transparent;
            this.hardwareDetailsImages.Images.SetKeyName(0, "computer.png");
            this.hardwareDetailsImages.Images.SetKeyName(1, "cpu.png");
            this.hardwareDetailsImages.Images.SetKeyName(2, "display.png");
            this.hardwareDetailsImages.Images.SetKeyName(3, "Motherboard.png");
            this.hardwareDetailsImages.Images.SetKeyName(4, "ram.png");
            this.hardwareDetailsImages.Images.SetKeyName(5, "storage.png");
            // 
            // tabPageHardwareUsage
            // 
            this.tabPageHardwareUsage.Controls.Add(this.tblLayoutHardwareUsage);
            this.tabPageHardwareUsage.Location = new System.Drawing.Point(4, 22);
            this.tabPageHardwareUsage.Name = "tabPageHardwareUsage";
            this.tabPageHardwareUsage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHardwareUsage.Size = new System.Drawing.Size(602, 430);
            this.tabPageHardwareUsage.TabIndex = 1;
            this.tabPageHardwareUsage.Text = "Usage";
            this.tabPageHardwareUsage.UseVisualStyleBackColor = true;
            // 
            // tblLayoutHardwareUsage
            // 
            this.tblLayoutHardwareUsage.ColumnCount = 5;
            this.tblLayoutHardwareUsage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutHardwareUsage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutHardwareUsage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutHardwareUsage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutHardwareUsage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblLayoutHardwareUsage.Controls.Add(this.grpBoxRAMUsage, 2, 0);
            this.tblLayoutHardwareUsage.Controls.Add(this.grpNetworkUsage, 0, 1);
            this.tblLayoutHardwareUsage.Controls.Add(this.grpBoxVolUsage, 2, 1);
            this.tblLayoutHardwareUsage.Controls.Add(this.grpBoxCPUUsage, 0, 0);
            this.tblLayoutHardwareUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutHardwareUsage.Location = new System.Drawing.Point(3, 3);
            this.tblLayoutHardwareUsage.Name = "tblLayoutHardwareUsage";
            this.tblLayoutHardwareUsage.RowCount = 3;
            this.tblLayoutHardwareUsage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tblLayoutHardwareUsage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblLayoutHardwareUsage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tblLayoutHardwareUsage.Size = new System.Drawing.Size(596, 424);
            this.tblLayoutHardwareUsage.TabIndex = 0;
            // 
            // grpBoxRAMUsage
            // 
            this.tblLayoutHardwareUsage.SetColumnSpan(this.grpBoxRAMUsage, 2);
            this.grpBoxRAMUsage.Controls.Add(this.lblInUseRAMAns);
            this.grpBoxRAMUsage.Controls.Add(this.lblInUseRAM);
            this.grpBoxRAMUsage.Controls.Add(this.lblFreeRAMAns);
            this.grpBoxRAMUsage.Controls.Add(this.lblTotalRAMAns);
            this.grpBoxRAMUsage.Controls.Add(this.lblFreeRAM);
            this.grpBoxRAMUsage.Controls.Add(this.lblTotalRAM);
            this.grpBoxRAMUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxRAMUsage.Location = new System.Drawing.Point(241, 3);
            this.grpBoxRAMUsage.Name = "grpBoxRAMUsage";
            this.grpBoxRAMUsage.Size = new System.Drawing.Size(232, 121);
            this.grpBoxRAMUsage.TabIndex = 2;
            this.grpBoxRAMUsage.TabStop = false;
            this.grpBoxRAMUsage.Text = "RAM";
            // 
            // lblInUseRAMAns
            // 
            this.lblInUseRAMAns.AutoSize = true;
            this.lblInUseRAMAns.Location = new System.Drawing.Point(76, 42);
            this.lblInUseRAMAns.Name = "lblInUseRAMAns";
            this.lblInUseRAMAns.Size = new System.Drawing.Size(13, 13);
            this.lblInUseRAMAns.TabIndex = 5;
            this.lblInUseRAMAns.Text = "0";
            // 
            // lblInUseRAM
            // 
            this.lblInUseRAM.AutoSize = true;
            this.lblInUseRAM.Location = new System.Drawing.Point(6, 42);
            this.lblInUseRAM.Name = "lblInUseRAM";
            this.lblInUseRAM.Size = new System.Drawing.Size(44, 13);
            this.lblInUseRAM.TabIndex = 4;
            this.lblInUseRAM.Text = "In Use: ";
            // 
            // lblFreeRAMAns
            // 
            this.lblFreeRAMAns.AutoSize = true;
            this.lblFreeRAMAns.Location = new System.Drawing.Point(76, 68);
            this.lblFreeRAMAns.Name = "lblFreeRAMAns";
            this.lblFreeRAMAns.Size = new System.Drawing.Size(13, 13);
            this.lblFreeRAMAns.TabIndex = 3;
            this.lblFreeRAMAns.Text = "0";
            // 
            // lblTotalRAMAns
            // 
            this.lblTotalRAMAns.AutoSize = true;
            this.lblTotalRAMAns.Location = new System.Drawing.Point(76, 16);
            this.lblTotalRAMAns.Name = "lblTotalRAMAns";
            this.lblTotalRAMAns.Size = new System.Drawing.Size(13, 13);
            this.lblTotalRAMAns.TabIndex = 2;
            this.lblTotalRAMAns.Text = "0";
            // 
            // lblFreeRAM
            // 
            this.lblFreeRAM.AutoSize = true;
            this.lblFreeRAM.Location = new System.Drawing.Point(6, 68);
            this.lblFreeRAM.Name = "lblFreeRAM";
            this.lblFreeRAM.Size = new System.Drawing.Size(61, 13);
            this.lblFreeRAM.TabIndex = 1;
            this.lblFreeRAM.Text = "Free RAM: ";
            // 
            // lblTotalRAM
            // 
            this.lblTotalRAM.AutoSize = true;
            this.lblTotalRAM.Location = new System.Drawing.Point(6, 16);
            this.lblTotalRAM.Name = "lblTotalRAM";
            this.lblTotalRAM.Size = new System.Drawing.Size(64, 13);
            this.lblTotalRAM.TabIndex = 0;
            this.lblTotalRAM.Text = "Total RAM: ";
            // 
            // grpNetworkUsage
            // 
            this.tblLayoutHardwareUsage.SetColumnSpan(this.grpNetworkUsage, 2);
            this.grpNetworkUsage.Controls.Add(this.txtBoxNetworkUsage);
            this.grpNetworkUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpNetworkUsage.Location = new System.Drawing.Point(3, 130);
            this.grpNetworkUsage.Name = "grpNetworkUsage";
            this.tblLayoutHardwareUsage.SetRowSpan(this.grpNetworkUsage, 2);
            this.grpNetworkUsage.Size = new System.Drawing.Size(232, 291);
            this.grpNetworkUsage.TabIndex = 1;
            this.grpNetworkUsage.TabStop = false;
            this.grpNetworkUsage.Text = "Network";
            // 
            // txtBoxNetworkUsage
            // 
            this.txtBoxNetworkUsage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxNetworkUsage.Location = new System.Drawing.Point(1, 20);
            this.txtBoxNetworkUsage.Name = "txtBoxNetworkUsage";
            this.txtBoxNetworkUsage.Size = new System.Drawing.Size(199, 271);
            this.txtBoxNetworkUsage.TabIndex = 0;
            this.txtBoxNetworkUsage.Text = "";
            // 
            // grpBoxVolUsage
            // 
            this.tblLayoutHardwareUsage.SetColumnSpan(this.grpBoxVolUsage, 3);
            this.grpBoxVolUsage.Controls.Add(this.txtBoxVolUsage);
            this.grpBoxVolUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxVolUsage.Location = new System.Drawing.Point(241, 130);
            this.grpBoxVolUsage.Name = "grpBoxVolUsage";
            this.tblLayoutHardwareUsage.SetRowSpan(this.grpBoxVolUsage, 2);
            this.grpBoxVolUsage.Size = new System.Drawing.Size(352, 291);
            this.grpBoxVolUsage.TabIndex = 3;
            this.grpBoxVolUsage.TabStop = false;
            this.grpBoxVolUsage.Text = "Hard Drives";
            // 
            // txtBoxVolUsage
            // 
            this.txtBoxVolUsage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBoxVolUsage.Location = new System.Drawing.Point(7, 20);
            this.txtBoxVolUsage.Name = "txtBoxVolUsage";
            this.txtBoxVolUsage.Size = new System.Drawing.Size(305, 271);
            this.txtBoxVolUsage.TabIndex = 0;
            this.txtBoxVolUsage.Text = "";
            // 
            // grpBoxCPUUsage
            // 
            this.tblLayoutHardwareUsage.SetColumnSpan(this.grpBoxCPUUsage, 2);
            this.grpBoxCPUUsage.Controls.Add(this.lblThreadsAns);
            this.grpBoxCPUUsage.Controls.Add(this.lblProcessesAns);
            this.grpBoxCPUUsage.Controls.Add(this.lblCPUUsageAns);
            this.grpBoxCPUUsage.Controls.Add(this.lblUptimeAns);
            this.grpBoxCPUUsage.Controls.Add(this.lblNumthreads);
            this.grpBoxCPUUsage.Controls.Add(this.lblNumProcesses);
            this.grpBoxCPUUsage.Controls.Add(this.lblCPUUsage);
            this.grpBoxCPUUsage.Controls.Add(this.lblUptime);
            this.grpBoxCPUUsage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxCPUUsage.Location = new System.Drawing.Point(3, 3);
            this.grpBoxCPUUsage.Name = "grpBoxCPUUsage";
            this.grpBoxCPUUsage.Size = new System.Drawing.Size(232, 121);
            this.grpBoxCPUUsage.TabIndex = 0;
            this.grpBoxCPUUsage.TabStop = false;
            this.grpBoxCPUUsage.Text = "CPU";
            // 
            // lblThreadsAns
            // 
            this.lblThreadsAns.AutoSize = true;
            this.lblThreadsAns.Location = new System.Drawing.Point(96, 87);
            this.lblThreadsAns.Name = "lblThreadsAns";
            this.lblThreadsAns.Size = new System.Drawing.Size(13, 13);
            this.lblThreadsAns.TabIndex = 7;
            this.lblThreadsAns.Text = "0";
            // 
            // lblProcessesAns
            // 
            this.lblProcessesAns.AutoSize = true;
            this.lblProcessesAns.Location = new System.Drawing.Point(96, 63);
            this.lblProcessesAns.Name = "lblProcessesAns";
            this.lblProcessesAns.Size = new System.Drawing.Size(13, 13);
            this.lblProcessesAns.TabIndex = 6;
            this.lblProcessesAns.Text = "0";
            // 
            // lblCPUUsageAns
            // 
            this.lblCPUUsageAns.AutoSize = true;
            this.lblCPUUsageAns.Location = new System.Drawing.Point(96, 40);
            this.lblCPUUsageAns.Name = "lblCPUUsageAns";
            this.lblCPUUsageAns.Size = new System.Drawing.Size(13, 13);
            this.lblCPUUsageAns.TabIndex = 5;
            this.lblCPUUsageAns.Text = "0";
            // 
            // lblUptimeAns
            // 
            this.lblUptimeAns.AutoSize = true;
            this.lblUptimeAns.Location = new System.Drawing.Point(96, 16);
            this.lblUptimeAns.Name = "lblUptimeAns";
            this.lblUptimeAns.Size = new System.Drawing.Size(13, 13);
            this.lblUptimeAns.TabIndex = 4;
            this.lblUptimeAns.Text = "0";
            // 
            // lblNumthreads
            // 
            this.lblNumthreads.AutoSize = true;
            this.lblNumthreads.Location = new System.Drawing.Point(6, 87);
            this.lblNumthreads.Name = "lblNumthreads";
            this.lblNumthreads.Size = new System.Drawing.Size(46, 13);
            this.lblNumthreads.TabIndex = 3;
            this.lblNumthreads.Text = "Threads";
            // 
            // lblNumProcesses
            // 
            this.lblNumProcesses.AutoSize = true;
            this.lblNumProcesses.Location = new System.Drawing.Point(6, 63);
            this.lblNumProcesses.Name = "lblNumProcesses";
            this.lblNumProcesses.Size = new System.Drawing.Size(62, 13);
            this.lblNumProcesses.TabIndex = 2;
            this.lblNumProcesses.Text = "Processes: ";
            // 
            // lblCPUUsage
            // 
            this.lblCPUUsage.AutoSize = true;
            this.lblCPUUsage.Location = new System.Drawing.Point(6, 40);
            this.lblCPUUsage.Name = "lblCPUUsage";
            this.lblCPUUsage.Size = new System.Drawing.Size(58, 13);
            this.lblCPUUsage.TabIndex = 1;
            this.lblCPUUsage.Text = "Utilisation: ";
            // 
            // lblUptime
            // 
            this.lblUptime.AutoSize = true;
            this.lblUptime.Location = new System.Drawing.Point(6, 16);
            this.lblUptime.Name = "lblUptime";
            this.lblUptime.Size = new System.Drawing.Size(83, 13);
            this.lblUptime.TabIndex = 0;
            this.lblUptime.Text = "System Uptime: ";
            // 
            // tabProcessPage
            // 
            this.tabProcessPage.Controls.Add(this.dataGridProcess);
            this.tabProcessPage.Location = new System.Drawing.Point(4, 22);
            this.tabProcessPage.Name = "tabProcessPage";
            this.tabProcessPage.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessPage.Size = new System.Drawing.Size(616, 462);
            this.tabProcessPage.TabIndex = 1;
            this.tabProcessPage.Text = "Processes";
            this.tabProcessPage.UseVisualStyleBackColor = true;
            // 
            // dataGridProcess
            // 
            this.dataGridProcess.AllowUserToAddRows = false;
            this.dataGridProcess.AllowUserToDeleteRows = false;
            this.dataGridProcess.AllowUserToOrderColumns = true;
            this.dataGridProcess.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridProcess.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProcess.ContextMenuStrip = this.contextMenuProcess;
            this.dataGridProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridProcess.Location = new System.Drawing.Point(3, 3);
            this.dataGridProcess.Name = "dataGridProcess";
            this.dataGridProcess.ReadOnly = true;
            this.dataGridProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProcess.ShowCellErrors = false;
            this.dataGridProcess.ShowCellToolTips = false;
            this.dataGridProcess.ShowEditingIcon = false;
            this.dataGridProcess.ShowRowErrors = false;
            this.dataGridProcess.Size = new System.Drawing.Size(610, 456);
            this.dataGridProcess.TabIndex = 0;
            // 
            // contextMenuProcess
            // 
            this.contextMenuProcess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.endProcessesToolStripMenuItem,
            this.restartProcessesToolStripMenuItem,
            this.startNewProcessToolStripMenuItem});
            this.contextMenuProcess.Name = "contextMenuProcess";
            this.contextMenuProcess.Size = new System.Drawing.Size(173, 70);
            // 
            // endProcessesToolStripMenuItem
            // 
            this.endProcessesToolStripMenuItem.Name = "endProcessesToolStripMenuItem";
            this.endProcessesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.endProcessesToolStripMenuItem.Text = "End Process(es)";
            this.endProcessesToolStripMenuItem.Click += new System.EventHandler(this.endProcessesToolStripMenuItem_Click);
            // 
            // restartProcessesToolStripMenuItem
            // 
            this.restartProcessesToolStripMenuItem.Name = "restartProcessesToolStripMenuItem";
            this.restartProcessesToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.restartProcessesToolStripMenuItem.Text = "Restart Process(es)";
            this.restartProcessesToolStripMenuItem.Click += new System.EventHandler(this.restartProcessesToolStripMenuItem_Click);
            // 
            // startNewProcessToolStripMenuItem
            // 
            this.startNewProcessToolStripMenuItem.Name = "startNewProcessToolStripMenuItem";
            this.startNewProcessToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.startNewProcessToolStripMenuItem.Text = "Start New Process";
            this.startNewProcessToolStripMenuItem.Click += new System.EventHandler(this.startNewProcessToolStripMenuItem_Click);
            // 
            // tabServicePage
            // 
            this.tabServicePage.Controls.Add(this.dataGridService);
            this.tabServicePage.Location = new System.Drawing.Point(4, 22);
            this.tabServicePage.Name = "tabServicePage";
            this.tabServicePage.Size = new System.Drawing.Size(616, 462);
            this.tabServicePage.TabIndex = 2;
            this.tabServicePage.Text = "Services";
            this.tabServicePage.UseVisualStyleBackColor = true;
            // 
            // dataGridService
            // 
            this.dataGridService.AllowUserToAddRows = false;
            this.dataGridService.AllowUserToDeleteRows = false;
            this.dataGridService.AllowUserToOrderColumns = true;
            this.dataGridService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridService.ContextMenuStrip = this.serviceContextStrip;
            this.dataGridService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridService.Location = new System.Drawing.Point(0, 0);
            this.dataGridService.MultiSelect = false;
            this.dataGridService.Name = "dataGridService";
            this.dataGridService.ReadOnly = true;
            this.dataGridService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridService.Size = new System.Drawing.Size(616, 462);
            this.dataGridService.TabIndex = 0;
            this.dataGridService.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridService_MouseClick);
            // 
            // serviceContextStrip
            // 
            this.serviceContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.startupTypeToolStripMenuItem});
            this.serviceContextStrip.Name = "serviceContextStrip";
            this.serviceContextStrip.Size = new System.Drawing.Size(142, 92);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // startupTypeToolStripMenuItem
            // 
            this.startupTypeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.autoToolStripMenuItem,
            this.disableToolStripMenuItem1});
            this.startupTypeToolStripMenuItem.Name = "startupTypeToolStripMenuItem";
            this.startupTypeToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.startupTypeToolStripMenuItem.Text = "Startup Type";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // autoToolStripMenuItem
            // 
            this.autoToolStripMenuItem.Name = "autoToolStripMenuItem";
            this.autoToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.autoToolStripMenuItem.Text = "Auto";
            this.autoToolStripMenuItem.Click += new System.EventHandler(this.autoToolStripMenuItem_Click);
            // 
            // disableToolStripMenuItem1
            // 
            this.disableToolStripMenuItem1.Name = "disableToolStripMenuItem1";
            this.disableToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.disableToolStripMenuItem1.Text = "Disable";
            this.disableToolStripMenuItem1.Click += new System.EventHandler(this.disableToolStripMenuItem1_Click);
            // 
            // tabPageSchedule
            // 
            this.tabPageSchedule.Controls.Add(this.button9);
            this.tabPageSchedule.Controls.Add(this.button8);
            this.tabPageSchedule.Controls.Add(this.tabControl1);
            this.tabPageSchedule.Controls.Add(this.dataGridTask);
            this.tabPageSchedule.Location = new System.Drawing.Point(4, 22);
            this.tabPageSchedule.Name = "tabPageSchedule";
            this.tabPageSchedule.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSchedule.Size = new System.Drawing.Size(616, 462);
            this.tabPageSchedule.TabIndex = 3;
            this.tabPageSchedule.Text = "Scheduled Tasks";
            this.tabPageSchedule.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(115, 435);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(99, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "Delete Task";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(10, 435);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(99, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "Add New Task";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 198);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(607, 236);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dataGridTaskTrigger);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(599, 210);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Triggers";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(389, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Add New Trigger";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(494, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Delete Trigger";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridTaskTrigger
            // 
            this.dataGridTaskTrigger.AllowUserToAddRows = false;
            this.dataGridTaskTrigger.AllowUserToDeleteRows = false;
            this.dataGridTaskTrigger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTaskTrigger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTaskTrigger.Location = new System.Drawing.Point(3, 3);
            this.dataGridTaskTrigger.MultiSelect = false;
            this.dataGridTaskTrigger.Name = "dataGridTaskTrigger";
            this.dataGridTaskTrigger.ReadOnly = true;
            this.dataGridTaskTrigger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTaskTrigger.Size = new System.Drawing.Size(596, 170);
            this.dataGridTaskTrigger.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button3);
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.dataGridTaskAction);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(599, 210);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Actions";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(390, 182);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Add New Action";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(495, 182);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(99, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Delete Action";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridTaskAction
            // 
            this.dataGridTaskAction.AllowUserToAddRows = false;
            this.dataGridTaskAction.AllowUserToDeleteRows = false;
            this.dataGridTaskAction.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTaskAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTaskAction.Location = new System.Drawing.Point(3, 3);
            this.dataGridTaskAction.MultiSelect = false;
            this.dataGridTaskAction.Name = "dataGridTaskAction";
            this.dataGridTaskAction.ReadOnly = true;
            this.dataGridTaskAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTaskAction.Size = new System.Drawing.Size(596, 170);
            this.dataGridTaskAction.TabIndex = 5;
            // 
            // dataGridTask
            // 
            this.dataGridTask.AllowUserToAddRows = false;
            this.dataGridTask.AllowUserToDeleteRows = false;
            this.dataGridTask.AllowUserToResizeColumns = false;
            this.dataGridTask.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTask.Location = new System.Drawing.Point(0, 0);
            this.dataGridTask.MultiSelect = false;
            this.dataGridTask.Name = "dataGridTask";
            this.dataGridTask.ReadOnly = true;
            this.dataGridTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridTask.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTask.Size = new System.Drawing.Size(617, 192);
            this.dataGridTask.TabIndex = 1;
            this.dataGridTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTask_CellContentClick);
            this.dataGridTask.SelectionChanged += new System.EventHandler(this.dataGridTask_SelectionChanged);
            // 
            // tabpageStatistics
            // 
            this.tabpageStatistics.Controls.Add(this.tblLayoutStats);
            this.tabpageStatistics.Location = new System.Drawing.Point(4, 22);
            this.tabpageStatistics.Name = "tabpageStatistics";
            this.tabpageStatistics.Size = new System.Drawing.Size(616, 462);
            this.tabpageStatistics.TabIndex = 4;
            this.tabpageStatistics.Text = "Network Statistics";
            this.tabpageStatistics.UseVisualStyleBackColor = true;
            // 
            // tblLayoutStats
            // 
            this.tblLayoutStats.ColumnCount = 2;
            this.tblLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblLayoutStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblLayoutStats.Controls.Add(this.flowLayoutStatLabels, 0, 0);
            this.tblLayoutStats.Controls.Add(this.flowLayoutStatText, 1, 0);
            this.tblLayoutStats.Dock = System.Windows.Forms.DockStyle.Left;
            this.tblLayoutStats.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutStats.Name = "tblLayoutStats";
            this.tblLayoutStats.RowCount = 1;
            this.tblLayoutStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutStats.Size = new System.Drawing.Size(474, 462);
            this.tblLayoutStats.TabIndex = 0;
            // 
            // flowLayoutStatLabels
            // 
            this.flowLayoutStatLabels.Controls.Add(this.lblCommonProcessor);
            this.flowLayoutStatLabels.Controls.Add(this.lblMostCommonMobo);
            this.flowLayoutStatLabels.Controls.Add(this.lblMostCommonDisplay);
            this.flowLayoutStatLabels.Controls.Add(this.lblAverageRAM);
            this.flowLayoutStatLabels.Controls.Add(this.lblAverageStorage);
            this.flowLayoutStatLabels.Controls.Add(this.lblAvgUptime);
            this.flowLayoutStatLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutStatLabels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutStatLabels.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutStatLabels.Name = "flowLayoutStatLabels";
            this.flowLayoutStatLabels.Size = new System.Drawing.Size(183, 456);
            this.flowLayoutStatLabels.TabIndex = 0;
            // 
            // lblCommonProcessor
            // 
            this.lblCommonProcessor.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblCommonProcessor.AutoSize = true;
            this.lblCommonProcessor.Location = new System.Drawing.Point(27, 5);
            this.lblCommonProcessor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCommonProcessor.Name = "lblCommonProcessor";
            this.lblCommonProcessor.Size = new System.Drawing.Size(130, 13);
            this.lblCommonProcessor.TabIndex = 0;
            this.lblCommonProcessor.Text = "Most Common Processor: ";
            // 
            // lblMostCommonMobo
            // 
            this.lblMostCommonMobo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMostCommonMobo.AutoSize = true;
            this.lblMostCommonMobo.Location = new System.Drawing.Point(20, 28);
            this.lblMostCommonMobo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMostCommonMobo.Name = "lblMostCommonMobo";
            this.lblMostCommonMobo.Size = new System.Drawing.Size(137, 13);
            this.lblMostCommonMobo.TabIndex = 1;
            this.lblMostCommonMobo.Text = "Most Common Motherboard";
            // 
            // lblMostCommonDisplay
            // 
            this.lblMostCommonDisplay.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblMostCommonDisplay.AutoSize = true;
            this.lblMostCommonDisplay.Location = new System.Drawing.Point(6, 51);
            this.lblMostCommonDisplay.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblMostCommonDisplay.Name = "lblMostCommonDisplay";
            this.lblMostCommonDisplay.Size = new System.Drawing.Size(151, 13);
            this.lblMostCommonDisplay.TabIndex = 2;
            this.lblMostCommonDisplay.Text = "Most Common Display Adapter";
            // 
            // lblAverageRAM
            // 
            this.lblAverageRAM.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAverageRAM.AutoSize = true;
            this.lblAverageRAM.Location = new System.Drawing.Point(82, 74);
            this.lblAverageRAM.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAverageRAM.Name = "lblAverageRAM";
            this.lblAverageRAM.Size = new System.Drawing.Size(75, 13);
            this.lblAverageRAM.TabIndex = 3;
            this.lblAverageRAM.Text = "Average Ram:";
            // 
            // lblAverageStorage
            // 
            this.lblAverageStorage.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAverageStorage.AutoSize = true;
            this.lblAverageStorage.Location = new System.Drawing.Point(64, 97);
            this.lblAverageStorage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAverageStorage.Name = "lblAverageStorage";
            this.lblAverageStorage.Size = new System.Drawing.Size(93, 13);
            this.lblAverageStorage.TabIndex = 4;
            this.lblAverageStorage.Text = "Average Storage: ";
            // 
            // lblAvgUptime
            // 
            this.lblAvgUptime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblAvgUptime.AutoSize = true;
            this.lblAvgUptime.Location = new System.Drawing.Point(3, 120);
            this.lblAvgUptime.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAvgUptime.Name = "lblAvgUptime";
            this.lblAvgUptime.Size = new System.Drawing.Size(154, 13);
            this.lblAvgUptime.TabIndex = 5;
            this.lblAvgUptime.Text = "Average Uptime Last 30 Days: ";
            // 
            // flowLayoutStatText
            // 
            this.flowLayoutStatText.Controls.Add(this.lblCommonProcessorAns);
            this.flowLayoutStatText.Controls.Add(this.lblCommonMoboAns);
            this.flowLayoutStatText.Controls.Add(this.lblCommonDisplayAns);
            this.flowLayoutStatText.Controls.Add(this.lblAverageRAMAns);
            this.flowLayoutStatText.Controls.Add(this.lblAverageStorageAns);
            this.flowLayoutStatText.Controls.Add(this.lblAvgUptimeAns);
            this.flowLayoutStatText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutStatText.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutStatText.Location = new System.Drawing.Point(192, 3);
            this.flowLayoutStatText.Name = "flowLayoutStatText";
            this.flowLayoutStatText.Size = new System.Drawing.Size(279, 456);
            this.flowLayoutStatText.TabIndex = 1;
            // 
            // lblCommonProcessorAns
            // 
            this.lblCommonProcessorAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCommonProcessorAns.AutoSize = true;
            this.lblCommonProcessorAns.Location = new System.Drawing.Point(3, 5);
            this.lblCommonProcessorAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCommonProcessorAns.Name = "lblCommonProcessorAns";
            this.lblCommonProcessorAns.Size = new System.Drawing.Size(43, 13);
            this.lblCommonProcessorAns.TabIndex = 0;
            this.lblCommonProcessorAns.Text = "Not Set";
            // 
            // lblCommonMoboAns
            // 
            this.lblCommonMoboAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCommonMoboAns.AutoSize = true;
            this.lblCommonMoboAns.Location = new System.Drawing.Point(3, 28);
            this.lblCommonMoboAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCommonMoboAns.Name = "lblCommonMoboAns";
            this.lblCommonMoboAns.Size = new System.Drawing.Size(43, 13);
            this.lblCommonMoboAns.TabIndex = 1;
            this.lblCommonMoboAns.Text = "Not Set";
            // 
            // lblCommonDisplayAns
            // 
            this.lblCommonDisplayAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCommonDisplayAns.AutoSize = true;
            this.lblCommonDisplayAns.Location = new System.Drawing.Point(3, 51);
            this.lblCommonDisplayAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblCommonDisplayAns.Name = "lblCommonDisplayAns";
            this.lblCommonDisplayAns.Size = new System.Drawing.Size(43, 13);
            this.lblCommonDisplayAns.TabIndex = 2;
            this.lblCommonDisplayAns.Text = "Not Set";
            // 
            // lblAverageRAMAns
            // 
            this.lblAverageRAMAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAverageRAMAns.AutoSize = true;
            this.lblAverageRAMAns.Location = new System.Drawing.Point(3, 74);
            this.lblAverageRAMAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAverageRAMAns.Name = "lblAverageRAMAns";
            this.lblAverageRAMAns.Size = new System.Drawing.Size(43, 13);
            this.lblAverageRAMAns.TabIndex = 3;
            this.lblAverageRAMAns.Text = "Not Set";
            // 
            // lblAverageStorageAns
            // 
            this.lblAverageStorageAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAverageStorageAns.AutoSize = true;
            this.lblAverageStorageAns.Location = new System.Drawing.Point(3, 97);
            this.lblAverageStorageAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAverageStorageAns.Name = "lblAverageStorageAns";
            this.lblAverageStorageAns.Size = new System.Drawing.Size(43, 13);
            this.lblAverageStorageAns.TabIndex = 4;
            this.lblAverageStorageAns.Text = "Not Set";
            // 
            // lblAvgUptimeAns
            // 
            this.lblAvgUptimeAns.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAvgUptimeAns.AutoSize = true;
            this.lblAvgUptimeAns.Location = new System.Drawing.Point(3, 120);
            this.lblAvgUptimeAns.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.lblAvgUptimeAns.Name = "lblAvgUptimeAns";
            this.lblAvgUptimeAns.Size = new System.Drawing.Size(43, 13);
            this.lblAvgUptimeAns.TabIndex = 5;
            this.lblAvgUptimeAns.Text = "Not Set";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(658, 516);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(624, 22);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // statusStripBot
            // 
            this.statusStripBot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStriplblLastUpdate});
            this.statusStripBot.Location = new System.Drawing.Point(0, 516);
            this.statusStripBot.Name = "statusStripBot";
            this.statusStripBot.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStripBot.Size = new System.Drawing.Size(1284, 22);
            this.statusStripBot.SizingGrip = false;
            this.statusStripBot.TabIndex = 4;
            // 
            // toolStriplblLastUpdate
            // 
            this.toolStriplblLastUpdate.Name = "toolStriplblLastUpdate";
            this.toolStriplblLastUpdate.Size = new System.Drawing.Size(10, 17);
            this.toolStriplblLastUpdate.Text = " ";
            // 
            // serverMainSplitContainer
            // 
            this.serverMainSplitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.serverMainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serverMainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.serverMainSplitContainer.Margin = new System.Windows.Forms.Padding(5);
            this.serverMainSplitContainer.Name = "serverMainSplitContainer";
            // 
            // serverMainSplitContainer.Panel1
            // 
            this.serverMainSplitContainer.Panel1.Controls.Add(this.tabControlCliens);
            // 
            // serverMainSplitContainer.Panel2
            // 
            this.serverMainSplitContainer.Panel2.Controls.Add(this.tabInfoContainer);
            this.serverMainSplitContainer.Size = new System.Drawing.Size(1284, 492);
            this.serverMainSplitContainer.SplitterDistance = 651;
            this.serverMainSplitContainer.SplitterWidth = 5;
            this.serverMainSplitContainer.TabIndex = 5;
            // 
            // tabControlCliens
            // 
            this.tabControlCliens.Controls.Add(this.onlineClients);
            this.tabControlCliens.Controls.Add(this.offlinClients);
            this.tabControlCliens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCliens.Location = new System.Drawing.Point(0, 0);
            this.tabControlCliens.Name = "tabControlCliens";
            this.tabControlCliens.SelectedIndex = 0;
            this.tabControlCliens.Size = new System.Drawing.Size(647, 488);
            this.tabControlCliens.TabIndex = 1;
            // 
            // onlineClients
            // 
            this.onlineClients.Controls.Add(this.objectListView1);
            this.onlineClients.Location = new System.Drawing.Point(4, 22);
            this.onlineClients.Name = "onlineClients";
            this.onlineClients.Padding = new System.Windows.Forms.Padding(3);
            this.onlineClients.Size = new System.Drawing.Size(639, 462);
            this.onlineClients.TabIndex = 0;
            this.onlineClients.Text = "Online Clients";
            this.onlineClients.UseVisualStyleBackColor = true;
            // 
            // offlinClients
            // 
            this.offlinClients.Controls.Add(this.objectListOffline);
            this.offlinClients.Location = new System.Drawing.Point(4, 22);
            this.offlinClients.Name = "offlinClients";
            this.offlinClients.Padding = new System.Windows.Forms.Padding(3);
            this.offlinClients.Size = new System.Drawing.Size(639, 462);
            this.offlinClients.TabIndex = 1;
            this.offlinClients.Text = "Offline Clients";
            this.offlinClients.UseVisualStyleBackColor = true;
            // 
            // objectListOffline
            // 
            this.objectListOffline.AllColumns.Add(this.olvColumn1);
            this.objectListOffline.AllColumns.Add(this.olvColumn2);
            this.objectListOffline.AllColumns.Add(this.olvColumn3);
            this.objectListOffline.AllColumns.Add(this.olvColumn4);
            this.objectListOffline.AllColumns.Add(this.olvColumn5);
            this.objectListOffline.AllColumns.Add(this.olvColumn6);
            this.objectListOffline.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4,
            this.olvColumn5,
            this.olvColumn6});
            this.objectListOffline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListOffline.IsSearchOnSortColumn = false;
            this.objectListOffline.Location = new System.Drawing.Point(3, 3);
            this.objectListOffline.MenuLabelGroupBy = "Group by \'groupName\'";
            this.objectListOffline.MenuLabelLockGroupingOn = "Lock grouping on \'groupName\'";
            this.objectListOffline.MenuLabelSortAscending = "Sort ascending by \'groupName\'";
            this.objectListOffline.MenuLabelSortDescending = "Sort descending by \'groupName\'";
            this.objectListOffline.Name = "objectListOffline";
            this.objectListOffline.Size = new System.Drawing.Size(633, 456);
            this.objectListOffline.TabIndex = 1;
            this.objectListOffline.UseCompatibleStateImageBehavior = false;
            this.objectListOffline.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "GetCompID";
            this.olvColumn1.Groupable = false;
            this.olvColumn1.Text = "Computer ID";
            this.olvColumn1.Width = 73;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "GetComputerName";
            this.olvColumn2.Groupable = false;
            this.olvColumn2.Text = "Computer Name";
            this.olvColumn2.Width = 92;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "GetClientIP";
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Text = "IP Address";
            this.olvColumn3.Width = 110;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "GetPort";
            this.olvColumn4.Groupable = false;
            this.olvColumn4.Text = "Port Number";
            this.olvColumn4.Width = 107;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "GetGroupName";
            this.olvColumn5.Text = "Group";
            this.olvColumn5.Width = 79;
            // 
            // olvColumn6
            // 
            this.olvColumn6.AspectName = "GetUptime";
            this.olvColumn6.Groupable = false;
            this.olvColumn6.Text = "Uptime D:H:M:S";
            this.olvColumn6.Width = 100;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip.TabIndex = 6;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // databaseSettingsToolStripMenuItem
            // 
            this.databaseSettingsToolStripMenuItem.Name = "databaseSettingsToolStripMenuItem";
            this.databaseSettingsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.databaseSettingsToolStripMenuItem.Text = "Database Settings";
            this.databaseSettingsToolStripMenuItem.Click += new System.EventHandler(this.databaseSettingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // deleteTriggerToolStripMenuItem
            // 
            this.deleteTriggerToolStripMenuItem.Name = "deleteTriggerToolStripMenuItem";
            this.deleteTriggerToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // modifyTriggerToolStripMenuItem
            // 
            this.modifyTriggerToolStripMenuItem.Name = "modifyTriggerToolStripMenuItem";
            this.modifyTriggerToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.modifyTriggerToolStripMenuItem.Text = "Modify Trigger";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ServerMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 538);
            this.Controls.Add(this.serverMainSplitContainer);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.statusStripBot);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ServerMain";
            this.Text = "Muroidea";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddingComputers_FormClosing);
            this.Load += new System.EventHandler(this.AddingComputers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabInfoContainer.ResumeLayout(false);
            this.tabHardwarePage.ResumeLayout(false);
            this.tabControlHardware.ResumeLayout(false);
            this.tabPageHardwareDetails.ResumeLayout(false);
            this.tabPageHardwareUsage.ResumeLayout(false);
            this.tblLayoutHardwareUsage.ResumeLayout(false);
            this.grpBoxRAMUsage.ResumeLayout(false);
            this.grpBoxRAMUsage.PerformLayout();
            this.grpNetworkUsage.ResumeLayout(false);
            this.grpBoxVolUsage.ResumeLayout(false);
            this.grpBoxCPUUsage.ResumeLayout(false);
            this.grpBoxCPUUsage.PerformLayout();
            this.tabProcessPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProcess)).EndInit();
            this.contextMenuProcess.ResumeLayout(false);
            this.tabServicePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridService)).EndInit();
            this.serviceContextStrip.ResumeLayout(false);
            this.tabPageSchedule.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTaskTrigger)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTaskAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTask)).EndInit();
            this.tabpageStatistics.ResumeLayout(false);
            this.tblLayoutStats.ResumeLayout(false);
            this.flowLayoutStatLabels.ResumeLayout(false);
            this.flowLayoutStatLabels.PerformLayout();
            this.flowLayoutStatText.ResumeLayout(false);
            this.flowLayoutStatText.PerformLayout();
            this.statusStripBot.ResumeLayout(false);
            this.statusStripBot.PerformLayout();
            this.serverMainSplitContainer.Panel1.ResumeLayout(false);
            this.serverMainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.serverMainSplitContainer)).EndInit();
            this.serverMainSplitContainer.ResumeLayout(false);
            this.tabControlCliens.ResumeLayout(false);
            this.onlineClients.ResumeLayout(false);
            this.offlinClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListOffline)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        //Set Process Data Set Information


        private BrightIdeasSoftware.OLVColumn compName;
        private BrightIdeasSoftware.OLVColumn ip;
        private BrightIdeasSoftware.OLVColumn port;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromGroupToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn groupName;
        private System.Windows.Forms.ToolStripMenuItem fTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGroupToolStripMenuItem1;
        public BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.TabControl tabInfoContainer;
        private System.Windows.Forms.TabPage tabHardwarePage;
        private System.Windows.Forms.TabPage tabProcessPage;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage tabServicePage;
        private System.Windows.Forms.TableLayoutPanel tblLayoutHardwareUsage;
        private System.Windows.Forms.TabControl tabControlHardware;
        private System.Windows.Forms.TabPage tabPageHardwareDetails;
        private System.Windows.Forms.TabPage tabPageHardwareUsage;
        private System.Windows.Forms.GroupBox grpBoxCPUUsage;
        private System.Windows.Forms.GroupBox grpNetworkUsage;
        private System.Windows.Forms.Label lblNumthreads;
        private System.Windows.Forms.Label lblNumProcesses;
        private System.Windows.Forms.Label lblCPUUsage;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.Label lblThreadsAns;
        private System.Windows.Forms.Label lblProcessesAns;
        private System.Windows.Forms.Label lblCPUUsageAns;
        private System.Windows.Forms.Label lblUptimeAns;
        private System.Windows.Forms.GroupBox grpBoxRAMUsage;
        private System.Windows.Forms.Label lblFreeRAMAns;
        private System.Windows.Forms.Label lblTotalRAMAns;
        private System.Windows.Forms.Label lblFreeRAM;
        private System.Windows.Forms.Label lblTotalRAM;
        private System.Windows.Forms.Label lblInUseRAMAns;
        private System.Windows.Forms.Label lblInUseRAM;
        private System.Windows.Forms.RichTextBox txtBoxNetworkUsage;
        private System.Windows.Forms.GroupBox grpBoxVolUsage;
        private System.Windows.Forms.RichTextBox txtBoxVolUsage;
        private System.Windows.Forms.DataGridView dataGridProcess;
        private System.Windows.Forms.StatusStrip statusStripBot;
        private System.Windows.Forms.ToolStripStatusLabel toolStriplblLastUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuProcess;
        private System.Windows.Forms.ToolStripMenuItem endProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartProcessesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridService;
        private System.Windows.Forms.ContextMenuStrip serviceContextStrip;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableToolStripMenuItem1;
        private System.Windows.Forms.SplitContainer serverMainSplitContainer;
        private System.Windows.Forms.TreeView hardwareTreeView;
        private System.Windows.Forms.ImageList hardwareDetailsImages;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseSettingsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn getUptime;
        private BrightIdeasSoftware.OLVColumn compID;
        private System.Windows.Forms.TabControl tabControlCliens;
        private System.Windows.Forms.TabPage onlineClients;
        private System.Windows.Forms.TabPage offlinClients;
        public BrightIdeasSoftware.ObjectListView objectListOffline;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private BrightIdeasSoftware.OLVColumn olvColumn6;

        private System.Windows.Forms.TabPage tabPageSchedule;
        private System.Windows.Forms.DataGridView dataGridTask;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridTaskTrigger;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridTaskAction;
        private System.Windows.Forms.ContextMenuStrip triggerContextStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteTriggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyTriggerToolStripMenuItem;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TabPage tabpageStatistics;
        private System.Windows.Forms.TableLayoutPanel tblLayoutStats;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutStatLabels;
        private System.Windows.Forms.Label lblCommonProcessor;
        private System.Windows.Forms.Label lblMostCommonMobo;
        private System.Windows.Forms.Label lblMostCommonDisplay;
        private System.Windows.Forms.Label lblAverageRAM;
        private System.Windows.Forms.Label lblAverageStorage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutStatText;
        private System.Windows.Forms.Label lblCommonProcessorAns;
        private System.Windows.Forms.Label lblCommonMoboAns;
        private System.Windows.Forms.Label lblCommonDisplayAns;
        private System.Windows.Forms.Label lblAverageRAMAns;
        private System.Windows.Forms.Label lblAverageStorageAns;
        private System.Windows.Forms.Label lblAvgUptime;
        private System.Windows.Forms.Label lblAvgUptimeAns;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}