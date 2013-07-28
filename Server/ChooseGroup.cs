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
    public partial class ChooseGroup : Form
    {
        string groupid;
        Database db;
        List<Group> groups;
        ClientThread client;
        private Communication.FTPDirectory fTPDirectory;
        private object p;
        ServerMain ad;
        public ChooseGroup(ref List<Group> groups,  object client,  ServerMain ad, Database db)
        {
            InitializeComponent();
            this.db = db;
            this.groups = groups;
            this.client = (ClientThread)client;
            this.ad = ad;
        }

       

        private void ChooseGroup_Load(object sender, EventArgs e)
        {
            foreach(Group g in groups)
            {
                listBox1.Items.Add(g.GetName());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1 || listBox1.SelectedIndex == null)
            {
                MessageBox.Show("You Must Select A Group First");
            }
            else
            {
            this.client.SetGroup(groups[listBox1.SelectedIndex]);
            ad.Refresh();
            ad.objectListView1.RebuildColumns();
            ad.objectListView1.Refresh();
            db.AddToGroup(client.GetCompID().Trim(), groupid);
            this.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Group g in groups)
            {
                try
                {
                    if (g.GetName().Trim() == listBox1.SelectedItem.ToString().Trim())
                    {
                        txtGroupDesc.Text = g.GetDesc();
                        groupid = g.GetID();
                    }
                }
                catch (System.Exception ex)
                {
                	
                }

            }
        }
    }
}
