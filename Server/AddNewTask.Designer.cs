namespace Server
{
    partial class AddNewTask
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
            this.label1 = new System.Windows.Forms.Label();
            this.taskName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.taskDescription = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.daysInterval = new System.Windows.Forms.NumericUpDown();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.codeText = new System.Windows.Forms.RichTextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.advancePath = new System.Windows.Forms.TextBox();
            this.advancedLabel = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pathText = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysInterval)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Task Name";
            // 
            // taskName
            // 
            this.taskName.Location = new System.Drawing.Point(15, 40);
            this.taskName.Name = "taskName";
            this.taskName.Size = new System.Drawing.Size(224, 20);
            this.taskName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Task Description";
            // 
            // taskDescription
            // 
            this.taskDescription.Location = new System.Drawing.Point(12, 119);
            this.taskDescription.Name = "taskDescription";
            this.taskDescription.Size = new System.Drawing.Size(227, 215);
            this.taskDescription.TabIndex = 3;
            this.taskDescription.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.daysInterval);
            this.groupBox1.Controls.Add(this.intervalLabel);
            this.groupBox1.Controls.Add(this.datePicker);
            this.groupBox1.Controls.Add(this.dateLabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Location = new System.Drawing.Point(245, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 310);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trigger";
            // 
            // daysInterval
            // 
            this.daysInterval.Location = new System.Drawing.Point(21, 197);
            this.daysInterval.Name = "daysInterval";
            this.daysInterval.Size = new System.Drawing.Size(139, 20);
            this.daysInterval.TabIndex = 11;
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(50, 175);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(80, 13);
            this.intervalLabel.TabIndex = 10;
            this.intervalLabel.Text = "Minute Interval:";
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(21, 130);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(139, 20);
            this.datePicker.TabIndex = 9;
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(61, 108);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(58, 13);
            this.dateLabel.TabIndex = 8;
            this.dateLabel.Text = "Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trigger Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly",
            "Startup"});
            this.comboBox1.Location = new System.Drawing.Point(21, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(139, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.codeText);
            this.groupBox2.Controls.Add(this.codeLabel);
            this.groupBox2.Controls.Add(this.advancePath);
            this.groupBox2.Controls.Add(this.advancedLabel);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.pathText);
            this.groupBox2.Controls.Add(this.pathLabel);
            this.groupBox2.Location = new System.Drawing.Point(459, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(237, 310);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // codeText
            // 
            this.codeText.Enabled = false;
            this.codeText.Location = new System.Drawing.Point(19, 187);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(212, 117);
            this.codeText.TabIndex = 7;
            this.codeText.Text = "";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(16, 171);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(32, 13);
            this.codeLabel.TabIndex = 6;
            this.codeLabel.Text = "Code";
            // 
            // advancePath
            // 
            this.advancePath.Enabled = false;
            this.advancePath.Location = new System.Drawing.Point(16, 133);
            this.advancePath.Name = "advancePath";
            this.advancePath.Size = new System.Drawing.Size(126, 20);
            this.advancePath.TabIndex = 5;
            // 
            // advancedLabel
            // 
            this.advancedLabel.AutoSize = true;
            this.advancedLabel.Location = new System.Drawing.Point(13, 117);
            this.advancedLabel.Name = "advancedLabel";
            this.advancedLabel.Size = new System.Drawing.Size(35, 13);
            this.advancedLabel.TabIndex = 4;
            this.advancedLabel.Text = "Name";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 97);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.Text = "Custom Batch File";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 23);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Execute Program";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(16, 63);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(126, 20);
            this.pathText.TabIndex = 1;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(13, 47);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(129, 13);
            this.pathLabel.TabIndex = 0;
            this.pathLabel.Text = "Program To Execute Path";
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(245, 348);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(95, 23);
            this.addTaskButton.TabIndex = 6;
            this.addTaskButton.Text = "Add New Task";
            this.addTaskButton.UseVisualStyleBackColor = true;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(358, 348);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 383);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.taskDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taskName);
            this.Controls.Add(this.label1);
            this.Name = "AddNewTask";
            this.Text = "Add New Task";
            this.Load += new System.EventHandler(this.AddNewTask_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daysInterval)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox taskName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox taskDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown daysInterval;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.RichTextBox codeText;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox advancePath;
        private System.Windows.Forms.Label advancedLabel;
        private System.Windows.Forms.Button addTaskButton;
        private System.Windows.Forms.Button button2;
    }
}