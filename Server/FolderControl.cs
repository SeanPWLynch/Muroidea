using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Communication;
using BrightIdeasSoftware;
using System.IO;

namespace Server
{
    public partial class FolderControl : UserControl
    {
        ClientThread client;
        RichTextBox log;
        bool IsRemote; //Is this a remote directory or local?

        public FolderControl()
        {
            InitializeComponent();
            NewFolderControl();
        }
        public void NewFolderControl()
        {
            //InitializeComponent();
            //InitializeComponent();
            treeListView1.IsSimpleDragSource = true;
            treeListView1.IsSimpleDropSink = true;

            SimpleDropSink sink1 = (SimpleDropSink)treeListView1.DropSink;
            sink1.AcceptExternal = true;
            sink1.CanDropBetween = true;
            sink1.CanDropOnBackground = true;
            sink1.ModelDropped += new EventHandler<ModelDropEventArgs>(HandleModelDropped);

        }
        /// <summary>
        /// This will init a local directory.
        /// </summary>
        /// <param name="path"></param>
        public void InitLocal(string path,ClientThread client, ref RichTextBox richTextBox1)
        {
            this.client = client;
            this.log = richTextBox1;
            IsRemote = false;
            FTPDirectory dir = new FTPDirectory(path, false, null);
            dir.GetDirs();
            dir.GetChildrenDirs();

            // Configure the first tree 
            treeListView1.CanExpandGetter = delegate(object x)
            {
                return ((FTPDirectory)x).Children != null;
            };
            treeListView1.ChildrenGetter = delegate(object x) { return ((FTPDirectory)x).GetChildren(); };

            treeListView1.Roots = dir.Children;

            treeListView1.IsSimpleDragSource = true;
            treeListView1.IsSimpleDropSink = true;


        }

        /// <summary>
        /// This will init a remote file directory
        /// </summary>
        /// <param name="path">The path to init</param>
        /// <param name="client">The client in which we are taking the file directory from</param>
        /// <param name="richTextBox1">The textbox in which we want to print the log to</param>
        public void InitRemote(string path, ClientThread client, ref RichTextBox richTextBox1)
        {
            this.log = richTextBox1;
            IsRemote = true;
            this.client = client;
            Messaging.SendCommand("return InitFTPDirectory('" + path + "');", client.GetClientSocket());
            FTPDirectory dir = (FTPDirectory)Messaging.RecieveFTPDirectory(client.GetClientSocket());

            treeListView1.CanExpandGetter = delegate(object x)
            {
                return ((FTPDirectory)x).IsFile == false;
            };
            treeListView1.ChildrenGetter = delegate(object x) { return GetRemoteChildren(x, client); };

            treeListView1.Roots = dir.Children;

            

            

        }

        /// <summary>
        /// Return the children directories of a remote directory, if any.
        /// </summary>
        /// <param name="node">The node is a GUID number, which points to the directory location on the remove machine.</param>
        /// <param name="client"></param>
        /// <returns></returns>
        private List<FTPDirectory> GetRemoteChildren(object node, ClientThread client)
        {
            this.client = client;
            Messaging.SendCommand("return GetFTPDirectory('" + ((FTPDirectory)node).GetID() + "');", client.GetClientSocket());
            FTPDirectory dir = (FTPDirectory)Messaging.RecieveFTPDirectory(client.GetClientSocket());
            return dir.Children;
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Depreciated. To be removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleModelCanDrop(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            e.InfoMessage = "DRAGGING";
            e.Handled = true; 
            e.Effect = DragDropEffects.None;
            if (e.SourceModels.Contains(e.TargetModel))
            {
                e.InfoMessage = "Cannot drop on self";
            }
            else
            {
                var sourceModels = e.SourceModels.Cast<FTPDirectory>();
                FTPDirectory target = e.TargetModel as FTPDirectory;
                e.InfoMessage = "FTP this directory/file";
                e.Effect = DragDropEffects.Move;
            }
        }
       
        /// <summary>
        /// Depreciated. To be removed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleModelDropped(object sender, BrightIdeasSoftware.ModelDropEventArgs e)
        {
            //e.SourceModels => Files to send.
            //e.TargetModel => Directory to send it to.
            //Take file location of target
            //FTP local file to that location
            //Method should be:
            //FTPFile(pathOfFile, pathToGo, Socket);
            //If remote folder control and file was dropped, then tell remote to
            //get ready for ftp, local sends.
            //If local folder control and file was dropped, then enter recieve mode
            //and tell remote to ftp it.

           /* string pathOfFile = null;
            string pathToGo = null;
            foreach(FTPDirectory ftp in (List<FTPDirectory>)e.SourceModels.Cast<FTPDirectory>().ToList())
            {
                pathOfFile = ftp.Path;
                pathToGo = ((FTPDirectory)e.TargetModel).Path +"\\"+ ftp.Name;
                if (IsRemote)
                {
                    Messaging.SendCommand("RemoteAcceptFTP("+client.GetPort()+",'"+pathToGo+"');", client.GetClientSocket());
                    //Messaging.RemoteAcceptFTP(client.GetClientSocket(), pathToGo);
                    Messaging.FTPFile(pathOfFile, client.GetClientSocket());
                }
                else
                {
                    Messaging.RemoteSendFTP(client.GetClientSocket(), pathOfFile);
                    Messaging.LocalAcceptFTP(client.GetClientSocket());
                }
                
            }*/
        }

        private void treeListView1_CanDrop(object sender, OlvDropEventArgs e)
        {
            BrightIdeasSoftware.OLVDataObject data = e.DataObject as BrightIdeasSoftware.OLVDataObject;

            FTPDirectory da = (FTPDirectory)data.ModelObjects[0];

            e.Effect = DragDropEffects.Move;
            //MessageBox.Show(da.Name);
        }

        private void treeListView1_Dropped(object sender, OlvDropEventArgs e)
        {
            FTP par = (FTP)this.ParentForm;
            FolderControl oppositeFolderControl;
            if(this == par.folderControl1)
            {
                oppositeFolderControl = par.folderControl2;
            }else{
                oppositeFolderControl = par.folderControl1;
            }


            BrightIdeasSoftware.OLVDataObject data = e.DataObject as BrightIdeasSoftware.OLVDataObject;
            FTPDirectory location = (FTPDirectory) e.DropTargetItem.RowObject;
            string pathOfFile = null;
            string pathToGo = null;
            foreach (FTPDirectory ftp in (List<FTPDirectory>)data.ModelObjects.Cast<FTPDirectory>().ToList())
            {
                pathOfFile = ftp.Path;
                pathToGo = (location).Path + "\\" + ftp.Name;
               // MessageBox.Show(pathToGo);
                if (IsRemote && !oppositeFolderControl.IsRemote) //Local Server to Remote Client
                {
                    log.Text+=("\nStart transfer of " + ftp.Name+". From LOCAL to "+client.GetComputerName()+".");
                    pathToGo = pathToGo.Replace("\\", "\\\\");

                    if (Directory.Exists(pathOfFile))//if folder
                    {
                        //gotta check in this dir for other dirs
                        SendFolder(ftp, client, pathToGo, par);
                    }
                    else
                    {

                        Messaging.SendCommand("RemoteAcceptFTP(" + client.GetPort() + ",'" + pathToGo + "', " + new FileInfo(pathOfFile).Length + ");", client.GetClientSocket());
                        //Messaging.RemoteAcceptFTP(client.GetClientSocket(), pathToGo);
                        Messaging.FTPFile(pathOfFile, client.GetClientSocket());
                        log.Text += ("\nFile successfully sent.\n");
                        par.Refresh();
                    }
                }
                else if (IsRemote && oppositeFolderControl.IsRemote) //Client to client
                {
                    if (ftp.IsFile)
                    {
                        log.Text += ("\nStart transfer of " + ftp.Name + ". From CLIENT to " + client.GetComputerName() + ".");
                        pathToGo = pathToGo.Replace("\\", "\\\\");
                        oppositeFolderControl.client.SendFileToOtherClient(pathOfFile, ftp.kbSize, pathToGo, client);
                    }
                    else
                    {
                        SendFolderToClient(ftp, pathOfFile, pathToGo, client, oppositeFolderControl);
                        log.Text += ftp.Name + " sent";
                    }
                }
                else //Client to Server
                {
                    log.Text += ("\nStart transfer of " + ftp.Name + ". From " + client.GetComputerName() + " to LOCAL.");
                    //pathToGo = pathToGo.Replace("\\", "\\\\");
                    pathOfFile = pathOfFile.Replace("\\", "\\\\");
                    Messaging.SendCommand("RemoteSendFTP(" + client.GetPort() + ", '" + pathOfFile + "');", client.GetClientSocket());
                    //Messaging.RemoteSendFTP(client.GetClientSocket(), pathOfFile);
                    Messaging.LocalAcceptFTP(client.GetClientSocket(), pathToGo, ftp.kbSize);
                    log.Text += ("\nFile successfully sent.\n");
                    par.Refresh();
                }

            }
        }

        /// <summary>
        /// Send a whole folder to a remote client
        /// </summary>
        /// <param name="ftp">The directory to send</param>
        /// <param name="pathOfFile">The location of the directory</param>
        /// <param name="pathToGo">Where to store it in the remote machine</param>
        /// <param name="client">The current client</param>
        /// <param name="oppositeFolderControl">The folder control that dropped it</param>
        private void SendFolderToClient(FTPDirectory ftp, string pathOfFile, string pathToGo, ClientThread client, FolderControl oppositeFolderControl)
        {
            if (ftp.IsFile)
            {
                pathToGo = pathToGo.Replace("\\", "\\\\");
                oppositeFolderControl.client.SendFileToOtherClient(pathOfFile, ftp.kbSize, pathToGo, client);
            }
            else
            {
                ftp.GetChildren();
                foreach (FTPDirectory f in ftp.Children)
                {
                    SendFolderToClient(f, f.Path, pathToGo + "\\" + f.Name, client, oppositeFolderControl);
                }
            }
        }

        private void SendFolder(FTPDirectory ftp, ClientThread client, string pathToGo, FTP par)
        {
            if (Directory.Exists(ftp.Path))
            {
                ftp.GetChildren();
                foreach (FTPDirectory f in ftp.Children)
                {
                    SendFolder(f, client, pathToGo + "\\\\" + f.Name, par);
                }
            }
            else
            {

                Messaging.SendCommand("RemoteAcceptFTP(" + client.GetPort() + ",'" + pathToGo + "', " + new FileInfo(ftp.Path).Length + ");", client.GetClientSocket());
                //Messaging.RemoteAcceptFTP(client.GetClientSocket(), pathToGo);
                Messaging.FTPFile(ftp.Path, client.GetClientSocket());
                log.Text += ("\nFile successfully sent.\n");
                par.Refresh();
            }

        }

       
    }
}
