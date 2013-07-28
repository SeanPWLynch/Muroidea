namespace Server
{
    partial class FolderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeListView1 = new BrightIdeasSoftware.TreeListView();
            this.nameCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.sizeCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dateCol = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeListView1
            // 
            this.treeListView1.AllColumns.Add(this.nameCol);
            this.treeListView1.AllColumns.Add(this.sizeCol);
            this.treeListView1.AllColumns.Add(this.dateCol);
            this.treeListView1.AllowDrop = true;
            this.treeListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.sizeCol,
            this.dateCol});
            this.treeListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeListView1.Location = new System.Drawing.Point(0, 0);
            this.treeListView1.Name = "treeListView1";
            this.treeListView1.OwnerDraw = true;
            this.treeListView1.ShowGroups = false;
            this.treeListView1.Size = new System.Drawing.Size(494, 397);
            this.treeListView1.TabIndex = 0;
            this.treeListView1.UseCompatibleStateImageBehavior = false;
            this.treeListView1.View = System.Windows.Forms.View.Details;
            this.treeListView1.VirtualMode = true;
            this.treeListView1.CanDrop += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.treeListView1_CanDrop);
            this.treeListView1.Dropped += new System.EventHandler<BrightIdeasSoftware.OlvDropEventArgs>(this.treeListView1_Dropped);
            this.treeListView1.SelectedIndexChanged += new System.EventHandler(this.treeListView1_SelectedIndexChanged);
            // 
            // nameCol
            // 
            this.nameCol.AspectName = "Name";
            this.nameCol.Text = "Name";
            this.nameCol.Width = 312;
            // 
            // sizeCol
            // 
            this.sizeCol.AspectName = "Size";
            this.sizeCol.Text = "Size";
            // 
            // dateCol
            // 
            this.dateCol.AspectName = "Date";
            this.dateCol.Text = "Date";
            // 
            // FolderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeListView1);
            this.Name = "FolderControl";
            this.Size = new System.Drawing.Size(494, 397);
            ((System.ComponentModel.ISupportInitialize)(this.treeListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.OLVColumn nameCol;
        private BrightIdeasSoftware.OLVColumn sizeCol;
        private BrightIdeasSoftware.OLVColumn dateCol;
        public BrightIdeasSoftware.TreeListView treeListView1;

    }
}
