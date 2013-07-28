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
    public partial class AddAction : Form
    {
        ScheduledTask task;
        ClientThread client;
        ServerMain dialog;
        public AddAction(ref ScheduledTask task, ClientThread client, ServerMain dialog)
        {
            InitializeComponent();
            this.task = task;
            this.client = client;
            this.dialog = dialog;
        }

        private void AddAction_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            advancedLabel.Enabled = false;
            advancePath.Enabled = false;
            codeText.Enabled = false;
            codeLabel.Enabled = false;

            pathLabel.Enabled = true;
            pathText.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            advancedLabel.Enabled = true;
            advancePath.Enabled = true;
            codeText.Enabled = true;
            codeLabel.Enabled = true;


            pathLabel.Enabled = false;
            pathText.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Messaging.SendNewCommand("return AddAction('" + task.GetTaskName() + "','" + pathText.Text + "');", client.GetClientSocket());
            }
            else
            {
                Messaging.SendNewCommand("return AddActionAdvanced('" + task.GetTaskName() + "','" + advancePath.Text+ "', '"+codeText.Text+"');", client.GetClientSocket());
            }


            dialog.UpdateTasks();
            dialog.UpdateTaskActionDataGrid();

            this.Close();
        }
    }
}
