using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class DatabaseSettings : Form
    {
        Database db;
        public DatabaseSettings(Database db)
        {

            InitializeComponent();

            this.db = db;

            try
            {
                if (this.db.GetUser() == "" || this.db.GetUser() == null)
                {
                    this.txtDBUserName.Text = "NOT SET";
                    this.txtDBPassword.Text = "NOT SET";
                    this.txtDBHost.Text = "NOT SET";
                }
                else
                {
                    this.txtDBUserName.Text = this.db.GetUser();
                    this.txtDBPassword.Text = this.db.GetPass();
                    this.txtDBHost.Text = this.db.GetHost();
                }

            }
            catch (System.Exception ex)
            {
                this.txtDBUserName.Text = "NOT SET";
                this.txtDBPassword.Text = "NOT SET";
                this.txtDBHost.Text = "NOT SET";
            }
        }

        private void btnDBClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnDBInstall_Click(object sender, EventArgs e)
        {
            if (txtDBHost.Text == "" || txtDBHost.Text == null || txtDBUserName.Text == "" || txtDBUserName.Text == null || txtDBPassword.Text == "" || txtDBPassword == null)
            {
                MessageBox.Show("Please Fill In All Fields");
            }
            else
            {
                MessageBox.Show("User Name: " + txtDBUserName.Text + Environment.NewLine + "Password: " + txtDBPassword.Text + Environment.NewLine + "Host: " + txtDBHost.Text);



                db.SetDetails(txtDBUserName.Text.Trim(), txtDBHost.Text.Trim(), txtDBPassword.Text.Trim());

                
                Thread CheckDetailsThread = new Thread(new ThreadStart(delegate
                {
                   bool connection = db.CheckConnection();
                   if (connection == true)
                   {
                       SaveDatabase(db);
                       MessageBox.Show("Connection Successful, Beginning Installation");
                       db.InstallDatabase();
                       MessageBox.Show("Database Installed");
                    }
                   else
                   {
                       MessageBox.Show("Connection failed, please ensure connection details are correct and try again");
                   }
                }));

                CheckDetailsThread.Start();

            }
        }

        private void SaveDatabase(Database db)
        {
         
            Stream fs = File.Create("db.bin");
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fs, db);
            fs.Close();
       
        }

        private void btnDBUninstall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Uninstalling Database");
            db.UninstallDatabase();


        }

        private void btnDBReinstall_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reinstalling Database");
            db.ReInstallDatabase();
        }
    }
}
