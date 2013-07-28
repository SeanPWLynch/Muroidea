// -----------------------------------------------------------------------
// <copyright file="ClientThread.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Net;
    using System.IO;
    using Communication;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ClientThread
    {
        /// <summary>
        /// The group in which the client is part of
        /// </summary>
        Group group = null;

        private TcpClient socket;
        private TcpClient heartBeat;
        private string compName;
        private string compIP;
        string uptime;
        string compID;
     

        /// <summary>
        /// Returns the group in which this client is part of
        /// </summary>
        /// <returns></returns>
        public Group GetGroup()
        {
            return group;
        }

        public string GetGroupName()
        {
            if (group == null)
            {
                return "No Group";
            }
            else { return this.group.GetName();}
            
        }

        /// <summary>
        /// Sets the Group which the client will be part of
        /// </summary>
        /// <param name="group">The group to make the client part of</param>
        public void SetGroup(Group group)
        {
            this.group = group;
            if (!this.group.GetClients().Contains(this))
            {
                this.group.AddClient(this);
            }
        }

        /// <summary>
        /// Init. the client
        /// </summary>
        /// <param name="socket">The socket pointing to the clients computer</param>
        public ClientThread(TcpClient socket, TcpClient heartbeat)
        {
            this.socket = socket;
            this.heartBeat = heartbeat;
        }


        /// <summary>
        /// Returns the clients IP address.
        /// </summary>
        /// <returns>The IP address of the computer</returns>
        public string GetClientIP()
        {
            if (this.compIP == null)
            {
                compIP = socket.Client.RemoteEndPoint.ToString();
                return socket.Client.RemoteEndPoint.ToString().Split(':')[0];
            }
            else
            {
                return compIP.Split(':')[0];
            }
        }

        /// <summary>
        /// Returns the port number of the clients socket.
        /// </summary>
        /// <returns></returns>
        public int GetPort()
        {
            if (this.compIP == null)
            {
                compIP = socket.Client.RemoteEndPoint.ToString();
                return int.Parse(socket.Client.RemoteEndPoint.ToString().Split(':')[1]);
            }
            else
            {
                return int.Parse(compIP.Split(':')[1]);
            }
        }

        /// <summary>
        /// Returns the client socket pointing to the clients computer
        /// </summary>
        /// <returns></returns>
        public TcpClient GetClientSocket()
        {
            return socket;
        }

        public void SendFile(byte[] ClientData)
        {
            try
            {
                Console.WriteLine("Starting File Transfer");

                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(this.GetClientIP()), this.GetPort() + 1);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSock.Connect(ipEnd);
                clientSock.Send(ClientData);

                Console.WriteLine("File has been sent.");

                clientSock.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("File Sending fail." + ex.Message);
            }
        }

        public string GetComputerName()
        {
            if (this.compName == null)
            {
                compName = Messaging.SendNewCommand("return GetComputerName();", this.GetClientSocket());
                return Messaging.SendNewCommand("return GetComputerName();", this.GetClientSocket());
            }
            else
            {
                return this.compName;
            }
        }



        //The following three methods need to be written out
        //to follow my new plan of creating a new socket for each command.
        //Please god say it works.
        public string SendCommand(string command) 
        {
            return Messaging.SendNewCommand(command, GetClientSocket());
        }

        public string SendFileToOtherClient(string source , int fileLength, string destination, ClientThread toClient ) 
        {
            //Send FTP file
            //Tell client to look for the file
            // Messaging.SendNewCommand("RemoteSendFTP('"+toClient.GetClientIP()+"',"+toClient.GetPort()+",'" + source + "');", this.GetClientSocket());
            //return toClient.RecieveFileFromOtherClient(destination, fileLength, this.GetClientIP(), this.GetPort()); 

            //Ok, this will be the new server. The server will send the file.
            //Server will tell the client to connect to it, and wait for the file to send

            Messaging.SendNewCommand("RemoteAcceptFTPFromClient('" + this.GetClientIP() + "', '" + destination + "'," + fileLength + ");", toClient.GetClientSocket());
            //this line tells the toClient that to connect to the ip address, the file will be this big and store it here
            Messaging.SendNewCommand("SendFTPToClient('"+source.Replace("\\", "\\\\")+"','"+this.GetClientIP()+"');", this.GetClientSocket());
            //Messaging.ClientFTPToClient(source, this.GetClientIP());
            return "Sent";
        }

        public string RecieveFileFromOtherClient(string destination, int fileLength, string ipAdd, int port)
        {
            Messaging.SendNewCommand("RemoteAcceptFTP(" + port + ",'" + destination + "', " + fileLength + ");", this.GetClientSocket());
            return "SENT FTP";
        }

        public string GetUptime()
        {
            if (this.uptime == null)
            {
                uptime = Messaging.SendNewCommand("return GetUptime()", GetClientSocket());
                return uptime;
            }
            else
            {
                return uptime;
            }
        }

        public string GetUptimeHours()
        {
                return Messaging.SendNewCommand("return GetUptimeHours()", GetClientSocket());
                
        }

        public string GetCompID()
        {
            if (this.compID == null)
            {
                compID = Messaging.SendNewCommand("return GetCompID()", GetClientSocket());
                return compID;
            }
            else
            {
                return compID;
            }
        }
    }
}
