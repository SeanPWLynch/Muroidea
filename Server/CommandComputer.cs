using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;

namespace Server
{
    public partial class CommandComputer : Form
    {
        List<ClientThread> clients;
        private BrightIdeasSoftware.OLVListItem oLVListItem;
        private ListView.SelectedListViewItemCollection selectedListViewItemCollection;
        private System.Collections.IList iList;


        

        private void CommandComputer_Load(object sender, EventArgs e)
        {
            foreach (ClientThread c in clients)
            {
                richTextBox1.Text += ("Now connected to " + c.GetComputerName());
                richTextBox1.Text += '\n';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendCommand();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendCommand();
            }
        }
        private void SendCommand()
        {
            foreach (ClientThread c in clients)
            {
               // Messaging.SendCommand(textBox1.Text, c.GetClientSocket());
               // Messaging.SendNewCommand(textBox1.Text, c.GetClientSocket()); //added in for testing, remove
                //richTextBox1.Text += '\n';
               // richTextBox1.Text += Messaging.RecieveCommand(c.GetClientSocket());

                richTextBox1.Text += '\n';
                richTextBox1.Text += c.SendCommand(textBox1.Text);
            }
            textBox1.Text = "";
        }


        public CommandComputer(System.Collections.IList iList)
        {
            // TODO: Complete member initialization

            this.clients = (List<ClientThread>)iList.Cast<ClientThread>().ToList() ;
            InitializeComponent();
        }
    }
}
