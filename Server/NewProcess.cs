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
    public partial class NewProcess : Form
    {
        /// <summary>
        /// Client
        /// </summary>
        ClientThread client;

        /// <summary>
        /// Required To Update Parent form
        /// </summary>
        ServerMain s; 

        /// <summary>
        /// Form Constructor
        /// </summary>
        /// <param name="ProcList">Current Known Processes, Built from parent form data grid</param>
        /// <param name="client">Client for commands to be sent too</param>
        /// <param name="parent">parent form</param>
        public NewProcess(ClientThread client, ServerMain parent, Database db)
        {
            s = parent;
            List<string> ProcList = db.GetProcesses(client.GetCompID());
            ProcList.Sort();
            InitializeComponent();
            this.client = client;
            string clientName = client.GetComputerName().Split('\0')[0];
            lstBoxProcesses.Items.Clear();
            toolLblConnectedClient.Text += clientName;

            foreach(string procname in ProcList)
            {
                lstBoxProcesses.Items.Add(procname + ".exe");
            }

        }

        /// <summary>
        /// Clears Selection/Text
        /// </summary>
        private void btnProcClear_Click(object sender, EventArgs e)
        {

            lstBoxProcesses.SelectedIndex = -1;
            txtBoxProcessName.Text = "";
        }

        /// <summary>
        /// Sends Command to start process
        /// </summary>
        private void btnProcStart_Click(object sender, EventArgs e)
        {
            bool Response;

            if (lstBoxProcesses.SelectedIndex == -1 && txtBoxProcessName.Text.Trim() == "")
            {
                MessageBox.Show("Please Select A Process Or Enter A Process Name");
            }
            else if (lstBoxProcesses.SelectedIndex == -1)
            {
                Messaging.SendCommand(@"return StartProcess(""" + txtBoxProcessName.Text.Trim() + @""");", client.GetClientSocket());
                Response = bool.Parse(Messaging.RecieveCommand(client.GetClientSocket()));
                CheckResponse(Response);
            }
            else
            {
                Messaging.SendCommand(@"return StartProcess(""" + lstBoxProcesses.SelectedItem.ToString() + @""");", client.GetClientSocket());
                Response = bool.Parse(Messaging.RecieveCommand(client.GetClientSocket()));
                CheckResponse(Response);
            }

        }

        private void lstBoxProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxProcessName.Text = "";
        }

        private void txtBoxProcessName_Click(object sender, EventArgs e)
        {
            lstBoxProcesses.SelectedIndex = -1;
        }

        /// <summary>
        /// Checks response to see if process started or not
        /// </summary>
        /// <param name="Response"></param>
        private void CheckResponse(bool Response)
        {
            if (Response)
            {
                MessageBox.Show("Process Started Successfully");
            }
            else
            {
                MessageBox.Show("Process Did Not Start");
            }
        }

        /// <summary>
        /// hides form
        /// Updates Datagrid
        /// Closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            s._UpdateProcDataGrid();
            this.Dispose();
        }



    }
}
