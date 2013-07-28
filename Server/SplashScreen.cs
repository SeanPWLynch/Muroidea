using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Server
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            this.Show();
            Thread.Sleep(300);
            ServerMain.db = new Database();
            ServerMain.groups = new List<Group>();
            ServerMain.groups = ServerMain.db.GetGroups();
            ServerMain.compDetails = ServerMain.db.GetKnownClients();
            ServerMain sm = new ServerMain();
            Thread.Sleep(1000);
            sm.ShowDialog();
            this.Close();
        }
    }
}
