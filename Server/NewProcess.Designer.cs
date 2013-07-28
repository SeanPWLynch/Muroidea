namespace Server
{
    partial class NewProcess
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
            this.tblLayoutNewProcess = new System.Windows.Forms.TableLayoutPanel();
            this.grpBoxSelectProc = new System.Windows.Forms.GroupBox();
            this.lstBoxProcesses = new System.Windows.Forms.ListBox();
            this.grpBoxEnterProcess = new System.Windows.Forms.GroupBox();
            this.txtBoxProcessName = new System.Windows.Forms.RichTextBox();
            this.tblLayoutProcButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnProcExit = new System.Windows.Forms.Button();
            this.btnProcClear = new System.Windows.Forms.Button();
            this.btnProcStart = new System.Windows.Forms.Button();
            this.statusStripNewProc = new System.Windows.Forms.StatusStrip();
            this.toolLblConnectedClient = new System.Windows.Forms.ToolStripStatusLabel();
            this.tblLayoutNewProcess.SuspendLayout();
            this.grpBoxSelectProc.SuspendLayout();
            this.grpBoxEnterProcess.SuspendLayout();
            this.tblLayoutProcButtons.SuspendLayout();
            this.statusStripNewProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tblLayoutNewProcess
            // 
            this.tblLayoutNewProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayoutNewProcess.ColumnCount = 1;
            this.tblLayoutNewProcess.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutNewProcess.Controls.Add(this.grpBoxSelectProc, 0, 0);
            this.tblLayoutNewProcess.Controls.Add(this.grpBoxEnterProcess, 0, 1);
            this.tblLayoutNewProcess.Controls.Add(this.tblLayoutProcButtons, 0, 2);
            this.tblLayoutNewProcess.Controls.Add(this.statusStripNewProc, 0, 3);
            this.tblLayoutNewProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutNewProcess.Location = new System.Drawing.Point(0, 0);
            this.tblLayoutNewProcess.Name = "tblLayoutNewProcess";
            this.tblLayoutNewProcess.RowCount = 4;
            this.tblLayoutNewProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tblLayoutNewProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tblLayoutNewProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tblLayoutNewProcess.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblLayoutNewProcess.Size = new System.Drawing.Size(282, 462);
            this.tblLayoutNewProcess.TabIndex = 0;
            // 
            // grpBoxSelectProc
            // 
            this.grpBoxSelectProc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpBoxSelectProc.Controls.Add(this.lstBoxProcesses);
            this.grpBoxSelectProc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxSelectProc.Location = new System.Drawing.Point(3, 3);
            this.grpBoxSelectProc.Name = "grpBoxSelectProc";
            this.grpBoxSelectProc.Size = new System.Drawing.Size(276, 325);
            this.grpBoxSelectProc.TabIndex = 0;
            this.grpBoxSelectProc.TabStop = false;
            this.grpBoxSelectProc.Text = "Select Process";
            // 
            // lstBoxProcesses
            // 
            this.lstBoxProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxProcesses.FormattingEnabled = true;
            this.lstBoxProcesses.Location = new System.Drawing.Point(3, 16);
            this.lstBoxProcesses.Name = "lstBoxProcesses";
            this.lstBoxProcesses.Size = new System.Drawing.Size(270, 306);
            this.lstBoxProcesses.TabIndex = 0;
            this.lstBoxProcesses.SelectedIndexChanged += new System.EventHandler(this.lstBoxProcesses_SelectedIndexChanged);
            // 
            // grpBoxEnterProcess
            // 
            this.grpBoxEnterProcess.Controls.Add(this.txtBoxProcessName);
            this.grpBoxEnterProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxEnterProcess.Location = new System.Drawing.Point(3, 334);
            this.grpBoxEnterProcess.Name = "grpBoxEnterProcess";
            this.grpBoxEnterProcess.Size = new System.Drawing.Size(276, 60);
            this.grpBoxEnterProcess.TabIndex = 1;
            this.grpBoxEnterProcess.TabStop = false;
            this.grpBoxEnterProcess.Text = "Enter Process Name";
            // 
            // txtBoxProcessName
            // 
            this.txtBoxProcessName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxProcessName.Location = new System.Drawing.Point(3, 16);
            this.txtBoxProcessName.Name = "txtBoxProcessName";
            this.txtBoxProcessName.Size = new System.Drawing.Size(270, 41);
            this.txtBoxProcessName.TabIndex = 1;
            this.txtBoxProcessName.Text = "";
            this.txtBoxProcessName.Click += new System.EventHandler(this.txtBoxProcessName_Click);
            // 
            // tblLayoutProcButtons
            // 
            this.tblLayoutProcButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tblLayoutProcButtons.ColumnCount = 3;
            this.tblLayoutProcButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLayoutProcButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLayoutProcButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblLayoutProcButtons.Controls.Add(this.btnProcExit, 0, 0);
            this.tblLayoutProcButtons.Controls.Add(this.btnProcClear, 1, 0);
            this.tblLayoutProcButtons.Controls.Add(this.btnProcStart, 2, 0);
            this.tblLayoutProcButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLayoutProcButtons.Location = new System.Drawing.Point(3, 400);
            this.tblLayoutProcButtons.Name = "tblLayoutProcButtons";
            this.tblLayoutProcButtons.RowCount = 1;
            this.tblLayoutProcButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutProcButtons.Size = new System.Drawing.Size(276, 38);
            this.tblLayoutProcButtons.TabIndex = 2;
            // 
            // btnProcExit
            // 
            this.btnProcExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcExit.Location = new System.Drawing.Point(3, 3);
            this.btnProcExit.Name = "btnProcExit";
            this.btnProcExit.Size = new System.Drawing.Size(86, 32);
            this.btnProcExit.TabIndex = 0;
            this.btnProcExit.Text = "Exit";
            this.btnProcExit.UseVisualStyleBackColor = true;
            this.btnProcExit.Click += new System.EventHandler(this.btnProcExit_Click);
            // 
            // btnProcClear
            // 
            this.btnProcClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcClear.Location = new System.Drawing.Point(95, 3);
            this.btnProcClear.Name = "btnProcClear";
            this.btnProcClear.Size = new System.Drawing.Size(86, 32);
            this.btnProcClear.TabIndex = 1;
            this.btnProcClear.Text = "Clear";
            this.btnProcClear.UseVisualStyleBackColor = true;
            this.btnProcClear.Click += new System.EventHandler(this.btnProcClear_Click);
            // 
            // btnProcStart
            // 
            this.btnProcStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnProcStart.Location = new System.Drawing.Point(187, 3);
            this.btnProcStart.Name = "btnProcStart";
            this.btnProcStart.Size = new System.Drawing.Size(86, 32);
            this.btnProcStart.TabIndex = 2;
            this.btnProcStart.Text = "Start Process";
            this.btnProcStart.UseVisualStyleBackColor = true;
            this.btnProcStart.Click += new System.EventHandler(this.btnProcStart_Click);
            // 
            // statusStripNewProc
            // 
            this.statusStripNewProc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolLblConnectedClient});
            this.statusStripNewProc.Location = new System.Drawing.Point(0, 441);
            this.statusStripNewProc.Name = "statusStripNewProc";
            this.statusStripNewProc.Size = new System.Drawing.Size(282, 21);
            this.statusStripNewProc.TabIndex = 3;
            this.statusStripNewProc.Text = "statusStrip1";
            // 
            // toolLblConnectedClient
            // 
            this.toolLblConnectedClient.Name = "toolLblConnectedClient";
            this.toolLblConnectedClient.Size = new System.Drawing.Size(88, 16);
            this.toolLblConnectedClient.Text = "Connected To: ";
            // 
            // NewProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(282, 462);
            this.Controls.Add(this.tblLayoutNewProcess);
            this.Name = "NewProcess";
            this.Text = "New Process";
            this.tblLayoutNewProcess.ResumeLayout(false);
            this.tblLayoutNewProcess.PerformLayout();
            this.grpBoxSelectProc.ResumeLayout(false);
            this.grpBoxEnterProcess.ResumeLayout(false);
            this.tblLayoutProcButtons.ResumeLayout(false);
            this.statusStripNewProc.ResumeLayout(false);
            this.statusStripNewProc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tblLayoutNewProcess;
        private System.Windows.Forms.GroupBox grpBoxSelectProc;
        private System.Windows.Forms.ListBox lstBoxProcesses;
        private System.Windows.Forms.GroupBox grpBoxEnterProcess;
        private System.Windows.Forms.RichTextBox txtBoxProcessName;
        private System.Windows.Forms.TableLayoutPanel tblLayoutProcButtons;
        private System.Windows.Forms.Button btnProcExit;
        private System.Windows.Forms.Button btnProcClear;
        private System.Windows.Forms.Button btnProcStart;
        private System.Windows.Forms.StatusStrip statusStripNewProc;
        private System.Windows.Forms.ToolStripStatusLabel toolLblConnectedClient;
    }
}