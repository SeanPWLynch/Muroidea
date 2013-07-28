using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;
using System.Threading;

namespace Server
{
    public partial class AddNewTask : Form
    {
        ServerMain dialog;
        ClientThread client;
        public AddNewTask(ServerMain dialog, ClientThread client)
        {
            InitializeComponent();
            this.dialog = dialog;
            this.client = client;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Startup")
            {
                datePicker.Hide();
                dateLabel.Hide();
                daysInterval.Hide();
                intervalLabel.Hide();
            }
            else if (comboBox1.Text == "Weekly" || comboBox1.Text == "Monthly")
            {
                datePicker.Show();
                dateLabel.Show();
                daysInterval.Hide();
                intervalLabel.Hide();
            }
            else
            {
                datePicker.Show();
                dateLabel.Show();
                daysInterval.Show();
                intervalLabel.Show();
            }
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

        private void AddNewTask_Load(object sender, EventArgs e)
        {

        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked)
            {
                //  Messaging.SendNewCommand("return AddAction('"+taskName.Text+"','"+pathText.Text+"');", client.GetClientSocket());
                Messaging.SendNewCommand("return AddTask('" + taskName.Text + "','" + taskDescription.Text + "','" + pathText.Text + "');", client.GetClientSocket());
            }
            else
            {
                Messaging.SendNewCommand("return AddAdvanceTask('" + taskName.Text + "','" + taskDescription.Text + "','" + advancePath.Text + "','"+codeText.Text.Replace('\n','^')+"');", client.GetClientSocket());
            }
            Thread.Sleep(200);
            dialog.UpdateTasks();

            ScheduledTask task = dialog.FindTask(taskName.Text);

            if (comboBox1.Text == "Startup")
            {
                Messaging.SendNewCommand("return AddStartupTrigger('" + task.GetTaskName() + "');", client.GetClientSocket());
            }
            else if (comboBox1.Text == "Weekly")
            {
                Messaging.SendNewCommand("return AddWeeklyTrigger('" + task.GetTaskName() + "','" + datePicker.Value.ToString() + "');", client.GetClientSocket());
            }
            else if (comboBox1.Text == "Monthly")
            {
                Messaging.SendNewCommand("return AddMonthlyTrigger('" + task.GetTaskName() + "','" + datePicker.Value.ToString() + "');", client.GetClientSocket());
            }
            else
            {
                Messaging.SendNewCommand("return AddDailyTrigger('" + task.GetTaskName() + "','" + datePicker.Value.ToString() + "', " + (int)daysInterval.Value + " );", client.GetClientSocket());
            }

           

            dialog.UpdateTaskDataGrid();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
