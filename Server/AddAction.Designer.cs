namespace Server
{
    partial class AddAction
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
            this.codeText = new System.Windows.Forms.RichTextBox();
            this.codeLabel = new System.Windows.Forms.Label();
            this.advancePath = new System.Windows.Forms.TextBox();
            this.advancedLabel = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.pathText = new System.Windows.Forms.TextBox();
            this.pathLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // codeText
            // 
            this.codeText.Enabled = false;
            this.codeText.Location = new System.Drawing.Point(28, 201);
            this.codeText.Name = "codeText";
            this.codeText.Size = new System.Drawing.Size(322, 166);
            this.codeText.TabIndex = 15;
            this.codeText.Text = "";
            // 
            // codeLabel
            // 
            this.codeLabel.AutoSize = true;
            this.codeLabel.Location = new System.Drawing.Point(25, 185);
            this.codeLabel.Name = "codeLabel";
            this.codeLabel.Size = new System.Drawing.Size(32, 13);
            this.codeLabel.TabIndex = 14;
            this.codeLabel.Text = "Code";
            // 
            // advancePath
            // 
            this.advancePath.Enabled = false;
            this.advancePath.Location = new System.Drawing.Point(25, 147);
            this.advancePath.Name = "advancePath";
            this.advancePath.Size = new System.Drawing.Size(200, 20);
            this.advancePath.TabIndex = 13;
            // 
            // advancedLabel
            // 
            this.advancedLabel.AutoSize = true;
            this.advancedLabel.Location = new System.Drawing.Point(22, 131);
            this.advancedLabel.Name = "advancedLabel";
            this.advancedLabel.Size = new System.Drawing.Size(35, 13);
            this.advancedLabel.TabIndex = 12;
            this.advancedLabel.Text = "Name";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(25, 111);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(110, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.Text = "Custom Batch File";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(106, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Execute Program";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(25, 77);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(200, 20);
            this.pathText.TabIndex = 9;
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.Location = new System.Drawing.Point(22, 61);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(129, 13);
            this.pathLabel.TabIndex = 8;
            this.pathLabel.Text = "Program To Execute Path";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(76, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Add Action";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 419);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codeText);
            this.Controls.Add(this.codeLabel);
            this.Controls.Add(this.advancePath);
            this.Controls.Add(this.advancedLabel);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.pathText);
            this.Controls.Add(this.pathLabel);
            this.Name = "AddAction";
            this.Text = "Add Action";
            this.Load += new System.EventHandler(this.AddAction_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox codeText;
        private System.Windows.Forms.Label codeLabel;
        private System.Windows.Forms.TextBox advancePath;
        private System.Windows.Forms.Label advancedLabel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}