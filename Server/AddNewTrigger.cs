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
    public partial class AddNewTrigger : Form
    {
        ScheduledTask task;
        ClientThread client;
        ServerMain dialog;
        public AddNewTrigger(ref ScheduledTask task, ClientThread client, ServerMain dialog)
        {
            InitializeComponent();
            this.task = task;
            this.client = client;
            this.dialog = dialog;
        }

        private void AddNewTrigger_Load(object sender, EventArgs e)
        {
            txtTaskName.Text = task.GetTaskName();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Startup"))
            {
                datePicker.Hide();
                dateLabel.Hide();
                daysInterval.Hide();
                intervalLabel.Hide();
            }
            else if (comboBox1.Text.Equals("Weekly") || comboBox1.Text.Equals("Monthly"))
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Startup")
            {
                Messaging.SendNewCommand("return AddStartupTrigger('"+task.GetTaskName()+"');", client.GetClientSocket());
            }
            else if (comboBox1.Text == "Weekly")
            {
                Messaging.SendNewCommand("return AddWeeklyTrigger('" + task.GetTaskName() + "','"+datePicker.Value.ToString()+"');", client.GetClientSocket());
            }else if(comboBox1.Text == "Monthly")
            {
                Messaging.SendNewCommand("return AddMonthlyTrigger('" + task.GetTaskName() + "','" + datePicker.Value.ToString() + "');", client.GetClientSocket());
            }
            else
            {
                Messaging.SendNewCommand("return AddDailyTrigger('" + task.GetTaskName() + "','" + datePicker.Value.ToString() + "', " + (int)daysInterval.Value + " );", client.GetClientSocket());
            }

            dialog.UpdateTasks();
            dialog.UpdateTaskTriggerDataGrid();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
