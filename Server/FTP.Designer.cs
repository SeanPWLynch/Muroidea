namespace Server
{
	partial class FTP
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.folderControl1 = new FolderControl();
            this.folderControl2 = new FolderControl();
            this.SuspendLayout();
            // 
            // folderControl1
            // 
            this.folderControl1.Location = new System.Drawing.Point(12, 48);
            this.folderControl1.Name = "folderControl1";
            this.folderControl1.Size = new System.Drawing.Size(438, 349);
            this.folderControl1.TabIndex = 0;
            // 
            // folderControl2
            // 
            this.folderControl2.Location = new System.Drawing.Point(459, 48);
            this.folderControl2.Name = "folderControl2";
            this.folderControl2.Size = new System.Drawing.Size(438, 349);
            this.folderControl2.TabIndex = 2;

            // 
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(545, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(280, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 403);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(885, 133);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(41, 21);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(280, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // FTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 548);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.folderControl1);
            this.Controls.Add(this.folderControl2);
            this.Name = "FTP";
            this.Text = "FTP";
            this.Load += new System.EventHandler(this.FTP_Load);
            this.ResumeLayout(false);

		}

		#endregion

        public FolderControl folderControl1;
        private System.Windows.Forms.ComboBox comboBox1;
        public FolderControl folderControl2;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBox2;
	}
}