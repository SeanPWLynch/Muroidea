namespace Server
{
    partial class DatabaseSettings
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDBHost = new System.Windows.Forms.Label();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.txtDBUserName = new System.Windows.Forms.TextBox();
            this.txtDBHost = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDBClose = new System.Windows.Forms.Button();
            this.btnDBUninstall = new System.Windows.Forms.Button();
            this.btnDBReinstall = new System.Windows.Forms.Button();
            this.btnDBInstall = new System.Windows.Forms.Button();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.lblDBHost, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblDBPassword, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDBUser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDBUserName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDBHost, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDBPassword, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(314, 242);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblDBHost
            // 
            this.lblDBHost.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDBHost.AutoSize = true;
            this.lblDBHost.Location = new System.Drawing.Point(3, 143);
            this.lblDBHost.Name = "lblDBHost";
            this.lblDBHost.Size = new System.Drawing.Size(119, 13);
            this.lblDBHost.TabIndex = 2;
            this.lblDBHost.Text = "Database Host Addess:";
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDBPassword.AutoSize = true;
            this.lblDBPassword.Location = new System.Drawing.Point(17, 83);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(105, 13);
            this.lblDBPassword.TabIndex = 1;
            this.lblDBPassword.Text = "Database Password:";
            // 
            // lblDBUser
            // 
            this.lblDBUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Location = new System.Drawing.Point(15, 23);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(107, 13);
            this.lblDBUser.TabIndex = 0;
            this.lblDBUser.Text = "Database Username:";
            // 
            // txtDBUserName
            // 
            this.txtDBUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBUserName.Location = new System.Drawing.Point(128, 20);
            this.txtDBUserName.Name = "txtDBUserName";
            this.txtDBUserName.Size = new System.Drawing.Size(183, 20);
            this.txtDBUserName.TabIndex = 3;
            // 
            // txtDBHost
            // 
            this.txtDBHost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBHost.Location = new System.Drawing.Point(128, 140);
            this.txtDBHost.Name = "txtDBHost";
            this.txtDBHost.Size = new System.Drawing.Size(183, 20);
            this.txtDBHost.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.btnDBClose, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDBUninstall, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDBReinstall, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDBInstall, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 183);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(308, 56);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // btnDBClose
            // 
            this.btnDBClose.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDBClose.Location = new System.Drawing.Point(3, 16);
            this.btnDBClose.Name = "btnDBClose";
            this.btnDBClose.Size = new System.Drawing.Size(71, 23);
            this.btnDBClose.TabIndex = 0;
            this.btnDBClose.Text = "Close";
            this.btnDBClose.UseVisualStyleBackColor = true;
            this.btnDBClose.Click += new System.EventHandler(this.btnDBClose_Click);
            // 
            // btnDBUninstall
            // 
            this.btnDBUninstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDBUninstall.Location = new System.Drawing.Point(80, 16);
            this.btnDBUninstall.Name = "btnDBUninstall";
            this.btnDBUninstall.Size = new System.Drawing.Size(71, 23);
            this.btnDBUninstall.TabIndex = 1;
            this.btnDBUninstall.Text = "Uninstall";
            this.btnDBUninstall.UseVisualStyleBackColor = true;
            this.btnDBUninstall.Click += new System.EventHandler(this.btnDBUninstall_Click);
            // 
            // btnDBReinstall
            // 
            this.btnDBReinstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDBReinstall.Location = new System.Drawing.Point(157, 16);
            this.btnDBReinstall.Name = "btnDBReinstall";
            this.btnDBReinstall.Size = new System.Drawing.Size(71, 23);
            this.btnDBReinstall.TabIndex = 2;
            this.btnDBReinstall.Text = "Reinstall";
            this.btnDBReinstall.UseVisualStyleBackColor = true;
            this.btnDBReinstall.Click += new System.EventHandler(this.btnDBReinstall_Click);
            // 
            // btnDBInstall
            // 
            this.btnDBInstall.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnDBInstall.Location = new System.Drawing.Point(234, 16);
            this.btnDBInstall.Name = "btnDBInstall";
            this.btnDBInstall.Size = new System.Drawing.Size(71, 23);
            this.btnDBInstall.TabIndex = 3;
            this.btnDBInstall.Text = "Install";
            this.btnDBInstall.UseVisualStyleBackColor = true;
            this.btnDBInstall.Click += new System.EventHandler(this.btnDBInstall_Click);
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBPassword.Location = new System.Drawing.Point(128, 80);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(183, 20);
            this.txtDBPassword.TabIndex = 7;
            // 
            // DatabaseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 242);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DatabaseSettings";
            this.Text = "DatabaseSettings";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblDBHost;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.TextBox txtDBUserName;
        private System.Windows.Forms.TextBox txtDBHost;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnDBClose;
        private System.Windows.Forms.Button btnDBUninstall;
        private System.Windows.Forms.Button btnDBReinstall;
        private System.Windows.Forms.Button btnDBInstall;
        private System.Windows.Forms.TextBox txtDBPassword;
    }
}