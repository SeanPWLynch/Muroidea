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
    public partial class FTP : Form
    {
        List<ClientThread> clients;
        public FTP()
        {
            this.folderControl1 = new FolderControl();
            this.folderControl2 = new FolderControl();
            InitializeComponent();
        }
        public FTP(List<ClientThread> clients)
        {

            InitializeComponent();
            this.clients = clients;
            foreach (ClientThread c in clients)
            {
                comboBox1.Items.Add(c.GetComputerName());
                comboBox2.Items.Add(c.GetComputerName());
            }

            comboBox2.Items.Add("LOCAL");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = clients.Count;

            
            richTextBox1.Text = "::";
            folderControl1.InitLocal("C:\\",clients[comboBox1.SelectedIndex], ref richTextBox1);

            folderControl2.InitRemote("C:\\\\", clients[comboBox1.SelectedIndex], ref richTextBox1); //update to get combobox selection
        }

        private void FTP_Load(object sender, EventArgs e)
        {
          //  InitializeComponent();
        }
        public  RichTextBox GetRTB()
        {
            return richTextBox1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            folderControl2.InitRemote("C:\\\\", clients[comboBox1.SelectedIndex], ref richTextBox1); //update to get combobox selection
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != clients.Count)
            {
                //Remote
                folderControl1.InitRemote("C:\\\\", clients[comboBox2.SelectedIndex], ref richTextBox1); //update to get combobox selection
            }
            else
            {
                folderControl1.InitLocal("C:\\\\", clients[comboBox1.SelectedIndex], ref richTextBox1); //update to get combobox selection
            
            }
        }
    }
}
