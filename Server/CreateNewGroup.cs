using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class CreateNewGroup : Form
    {
        List<Group> groups;
        Database db;
        ServerMain p;

        public CreateNewGroup(ref List<Group> groups, Database db, ServerMain s)
        {
            InitializeComponent();
            this.groups = groups;
            this.db = db;
            this.p = s;
        }

        private void CreateNewGroup_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //groups.Add(new Group(textBox1.Text, " "));
            string[] groupdetails = new string[] {this.textBox1.Text.ToString(), this.txtGroupDesc.Text.ToString()};
            db.InsertIntoTable("COMPUTERGROUP", groupdetails);
            p._UpdateGroupList();
            this.Close();
        }
    }
}
