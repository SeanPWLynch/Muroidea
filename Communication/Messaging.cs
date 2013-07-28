using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;

namespace Communication
{
    /// <summary>
    /// The messaging class. Might need a better name. This is static class, no need to create objects from it. You can send and receive messages using this class
    /// </summary>
    public class Messaging
    {
        /// <summary>
        /// Recieve a client which is trying to connect to the server. This method will listen for a client on a certain port number.
        /// </summary>
        /// <param name="port">The port number to recieve the client on.</param>
        /// <returns>The client connecting to the server</returns>
        public static TcpClient RecieveClient(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            TcpClient client = tcpListener.AcceptTcpClient();
            tcpListener.Stop();
            return client;
        }
        /// <summary>
        /// Send a message to a machine.
        /// </summary>
        /// <param name="ip">The computers IP address to send the message to</param>
        /// <param name="port">The port number that the computer should recieve the message on</param>
        /// <param name="message">The message to send</param>
        public static void SendMessage(string ip, int port, string message)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(message);

            clientStream.Write(buffer, 0, buffer.Length);
            clientStream.Flush();
            //clientStream.Close(); //maybe remove, wasent in it at first
        }

        public static void SendMessageThreadTest(string ip, int port, string message)
        {
            NetworkStream serverStream = default(NetworkStream);

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(message + '$');
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            //TcpClient client = new TcpClient();

            //IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            //client.Connect(serverEndPoint);

            //NetworkStream clientStream = client.GetStream();

            //ASCIIEncoding encoder = new ASCIIEncoding();
            //byte[] buffer = encoder.GetBytes(message);

            //clientStream.Write(buffer, 0, buffer.Length);
            //clientStream.Flush();
            ////clientStream.Close(); //maybe remove, wasent in it at first
        }

        /// <summary>
        /// Recieve a message from a certain port number on a client machine. Client can mean either server or client, it just means the recieving machine of a message.
        /// </summary>
        /// <param name="port">The port number to recieve the message on.</param>
        /// <returns>The message being sent is returned as a string</returns>
        public static string RecieveMessage(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            TcpClient client = tcpListener.AcceptTcpClient();
            NetworkStream clientStream = client.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
            }
            catch
            {
                //a socket error has occured
                // break;
            }

            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                // break;
            }

            //message has successfully been received
            ASCIIEncoding encoder = new ASCIIEncoding();
            tcpListener.Stop();
            return encoder.GetString(message, 0, bytesRead);
        }


        public static string RecieveMessage(TcpClient client)
        {
            NetworkStream clientStream = client.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            bytesRead = 0;

            try
            {
                //blocks until a client sends a message
                bytesRead = clientStream.Read(message, 0, 4096);
            }
            catch
            {
                //a socket error has occured
                // break;
            }

            if (bytesRead == 0)
            {
                //the client has disconnected from the server
                // break;
            }

            //message has successfully been received
            ASCIIEncoding encoder = new ASCIIEncoding();
            return encoder.GetString(message, 0, bytesRead);
        }



        public static void SendFile(string ip, int port, string file)
        {
            try
            {
                string fileName = null;
                string filePath = null;

                if (file.Contains('\\'))
                {
                    fileName = file.Split('\\')[file.Length - 1];
                    filePath = file.Replace(fileName, "").Trim();

                }
                else
                {
                    fileName = file;
                    filePath = Environment.CurrentDirectory + '\\';
                }

                Console.WriteLine("Starting File Transfer");

                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Parse(ip), port);
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

                byte[] fileData = File.ReadAllBytes(filePath + fileName);
                byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
                byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

                fileNameLen.CopyTo(clientData, 0);
                fileNameByte.CopyTo(clientData, 4);
                fileData.CopyTo(clientData, 4 + fileNameByte.Length);

                clientSock.Connect(ipEnd);
                clientSock.Send(clientData);


                Console.WriteLine("File:{0} has been sent.", fileName);

                clientSock.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("File Sending fail." + ex.Message);
            }
        }

        public static void RecieveFile(int port)
        {
            //string path = @"E:\3rd Year Project - Command Client\Client\bin\Debug\Saving\";
            try
            {
                IPEndPoint ipEnd = new IPEndPoint(IPAddress.Any, port);
                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Bind(ipEnd);
                sock.Listen(100);
                Socket clientSock = sock.Accept();

                byte[] clientData = new byte[1024 * 5000];
                int receivedBytesLen = clientSock.Receive(clientData, clientData.Length, 0);

                Console.WriteLine("Receiving data...");

                int fileNameLen = BitConverter.ToInt32(clientData, 0);
                string fileName = Encoding.UTF8.GetString(clientData, 4, fileNameLen);

                string path;

                do
                {
                    Console.WriteLine("Where would you like to save the file?");
                    path = Console.ReadLine();
                    if (path[path.Length - 1] != '\\')
                    {
                        path += '\\';
                    }

                } while (File.Exists(path + fileName) && !Directory.Exists(path));

                saveFile(ref path, ref  fileName, ref clientSock, ref fileNameLen, ref receivedBytesLen, ref clientData);

                Console.WriteLine("File: {0} received & saved at path: {1}", fileName, path);


                clientSock.Close();
                sock.Close();



            }
            catch (Exception ex)
            {
                Console.WriteLine("File Receiving fail." + ex.Message);


            }
        }

        private static void saveFile(ref string savePath, ref string fileName, ref Socket clientSock, ref int fileNameLen, ref int receivedBytesLen, ref byte[] clientData)
        {
            BinaryWriter bWrite = new BinaryWriter(File.Open(savePath + fileName, FileMode.Append));
            bWrite.Write(clientData, 4 + fileNameLen, receivedBytesLen - 4 - fileNameLen);
            while (receivedBytesLen > 0)
            {
                receivedBytesLen = clientSock.Receive(clientData, clientData.Length, 0);
                if (receivedBytesLen == 0)
                {
                    bWrite.Close();
                    Console.WriteLine("Transfer Complete");
                }
                else
                {
                    bWrite.Write(clientData, 0, receivedBytesLen);

                }
            }
        }

        public static string RecieveCommand(TcpClient clientSocket)
        {
            string dataFromClient = null;
            NetworkStream networkStream = clientSocket.GetStream();
            try
            {
                //clientSocket = serverSocket.AcceptTcpClient();

                int size = clientSocket.ReceiveBufferSize;

                byte[] bytesFrom = new byte[size];
                dataFromClient = null;

                Console.WriteLine(size);
                networkStream.Read(bytesFrom, 0, size);
                dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf(';'));
                Console.WriteLine(dataFromClient);

                //Add trailing blackslashes as they don't seem to send
                //dataFromClient = dataFromClient.Replace("\\","\\\\");

                return dataFromClient;
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            //networkStream.Close();
            return dataFromClient;
            //Console.WriteLine(dataFromClient);


        }

        public static void SendCommand(string command, TcpClient clientSocket)
        {

            NetworkStream serverStream = clientSocket.GetStream();
            //sendBytes = System.Text.Encoding.ASCII.GetBytes(command + ';');
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes(command);
            serverStream.Write(buffer, 0, buffer.Length);
            serverStream.Flush();
            //serverStream.Close();
        }

        public static string CommandReply(TcpClient clientSocket, byte[] bytesFrom)
        {
            int size = clientSocket.ReceiveBufferSize;

            bytesFrom = new byte[size];
            string dataFromClient = null;

            //requestCount = requestCount + 1;
            NetworkStream networkStream = clientSocket.GetStream();
            networkStream.Read(bytesFrom, 0, size);
            dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
            dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
            //Console.WriteLine("From client - " + clNo + " : " + dataFromClient);
            //rCount = Convert.ToString(requestCount);
            return dataFromClient;

        }

        public static void SendFTPDirectory(FTPDirectory obj, TcpClient Socket)
        {
            NetworkStream stream = Socket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, obj);
            byte[] buffer = ms.ToArray();
            System.Threading.Thread.Sleep(500);
            Socket.Client.SendTo(buffer, Socket.Client.RemoteEndPoint);
            // stream.Write(buffer, 0, buffer.Length);
            //stream.Flush();

            Console.WriteLine("BUFFER FOR SENT OBJECT WAS :: " + buffer);
        }

        public static FTPDirectory RecieveFTPDirectory(TcpClient Socket)
        {
            FTPDirectory dataFromClient = null;
            NetworkStream networkStream = Socket.GetStream();
           // clientSocket = serverSocket.AcceptTcpClient();
           // int size = Socket.ReceiveBufferSize;

            byte[] bytesFrom = new byte[1024 * 1024 * 50];
            int len = Socket.Client.Receive(bytesFrom);
            dataFromClient = null;

            BinaryFormatter formattor = new BinaryFormatter();

            MemoryStream ms = new MemoryStream(bytesFrom);
            dataFromClient = (FTPDirectory)formattor.Deserialize(ms);
            return dataFromClient;

            //networkStream.Close();
            //Console.WriteLine(dataFromClient);

        }

        public static void SendBroadcast(string addIP)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);
            IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse(addIP), 9050);



            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            string localIP = null;
            foreach (IPAddress IP in addr)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = IP.ToString();
                }
            }

            byte[] data = Encoding.ASCII.GetBytes(localIP); //addr.Length - 1

            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            sock.SendTo(data, iep1);
            sock.SendTo(data, iep2);

            sock.Close();
        }

        public static string RetrieveBroadcastIP()
        {
             bool returned = false;
            string broadcast = null;
            do
            {
                try
                {
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);
                    sock.Bind(iep);
                    EndPoint ep = (EndPoint)iep;


                    byte[] data = new byte[1024];

                    int recv = sock.ReceiveFrom(data, ref ep);

                    string stringData = Encoding.ASCII.GetString(data, 0, recv);


                    data = new byte[1024];

                    recv = sock.ReceiveFrom(data, ref ep);

                    stringData = Encoding.ASCII.GetString(data, 0, recv);
                    broadcast = stringData;

                    sock.Close();

                    returned = true;
                }
                catch (Exception e) { }
            }
            while (!returned);
            return broadcast;
        }

        public static void SendMulticast(string addIP)
        {
            //send on ip 224.5.5.5
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            IPAddress ip = IPAddress.Parse(addIP);

            sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip));

            sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 2);

            IPEndPoint ipep = new IPEndPoint(ip, 4567);
            sock.Connect(ipep);

            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);

            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            string localIP = null;
            foreach (IPAddress IP in addr)
            {
                if (IP.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = IP.ToString();
                }
            }

            byte[] data = Encoding.ASCII.GetBytes(localIP); //addr.Length - 1
            string s = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);

            sock.Send(data, data.Length, SocketFlags.None);

            sock.Close();
        }

        public static string RetrieveMulitcastIP()
        {
            bool returned = false;
            string multicast = null;
            do
            {
                try
                {
                    Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 4567);
                    sock.Bind(ipep);
                    IPAddress ip = IPAddress.Parse("224.5.6.7");

                    sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(ip, IPAddress.Any));

                    byte[] b = new byte[1024];
                    sock.Receive(b);
                    string str = System.Text.Encoding.ASCII.GetString(b, 0, b.Length);
                    //Console.WriteLine(str.Trim());
                    str = str.Replace('\0', ' '); //IP address trails \0\0\0 sometimes


                    //sock.Disconnect(true);
                    sock.Close();

                    multicast = str.Trim(); //Returns the data, which will be the servers IP address
                    returned = true;
                }
                catch (Exception e)
                {
                    //Console.WriteLine(e.Message);
                }
            } while (!returned);
            return multicast;
        }

        public static void SendMessage(string message, TcpClient Socket)
        {
            NetworkStream stream = Socket.GetStream();
            byte[] buffer;
            buffer = System.Text.Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        public static void FTPFile(string pathOfFile, TcpClient tcpClient)
        {
            byte[] fileData = File.ReadAllBytes(pathOfFile);

            tcpClient.Client.Send(fileData);

            Console.WriteLine("SENT");

            string x = RecieveCommand(tcpClient); //take in leftover bytes
        }

        public static void RemoteAcceptFTP(TcpClient socket, string pathToGo, int fileLength)
        {
            byte[] clientData = new byte[fileLength];
            int receivedBytesLen = socket.Client.Receive(clientData, clientData.Length, 0);

            Console.WriteLine("Receiving data...");
            string d = "\\";
            string[] dirs = pathToGo.Split(d.ToCharArray());

            for (int i = 0; i < dirs.Length - 1; i++)
            {
                if (i != 0)
                {
                    dirs[i] = dirs[i - 1] + dirs[i];
                }
                dirs[i] += "\\";
                if(!Directory.Exists(dirs[i]))
                {
                    Directory.CreateDirectory(dirs[i] + "\\");
                }
            }

            BinaryWriter bWrite = new BinaryWriter(File.Open(pathToGo, FileMode.Append));
            bWrite.Write(clientData, 0,clientData.Length);
            /*while (receivedBytesLen >= 0)
            {
                receivedBytesLen = socket.Client.Receive(clientData, clientData.Length, 0);
                if (receivedBytesLen == 0)
                {
                    bWrite.Close();
                    Console.WriteLine("Transfer Complete");
                }
                else
                {
                    bWrite.Write(clientData, 0, receivedBytesLen);

                }
            }*/
            bWrite.Close();
            Console.WriteLine("Downloaded");
            
        }

        public static void RemoteSendFTP(TcpClient tcpClient, string pathOfFile)
        {
            byte[] fileData = File.ReadAllBytes(pathOfFile);

            tcpClient.Client.Send(fileData);

            Console.WriteLine("SENT");


        }

        public static void LocalAcceptFTP(TcpClient tcpClient, string pathToGo, int fileLength)
        {
            byte[] clientData = new byte[fileLength];
            int receivedBytesLen = tcpClient.Client.Receive(clientData, clientData.Length, 0);

            Console.WriteLine("Receiving data...");

            BinaryWriter bWrite = new BinaryWriter(File.Open(pathToGo, FileMode.Append));
            bWrite.Write(clientData, 0, clientData.Length);
            /*while (receivedBytesLen >= 0)
            {
                receivedBytesLen = socket.Client.Receive(clientData, clientData.Length, 0);
                if (receivedBytesLen == 0)
                {
                    bWrite.Close();
                    Console.WriteLine("Transfer Complete");
                }
                else
                {
                    bWrite.Write(clientData, 0, receivedBytesLen);

                }
            }*/
            bWrite.Close();
            Console.WriteLine("Downloaded");
            string x = RecieveCommand(tcpClient); //take in leftover bytes

        }

        public static void SendComputerDetails(string[] details, TcpClient Socket)
        {


            Container dataContainer = new Container(details);
            NetworkStream stream = Socket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();



            bf.Serialize(ms, dataContainer);
            byte[] buffer = ms.ToArray();            
            System.Threading.Thread.Sleep(500);
            Socket.Client.SendTo(buffer, Socket.Client.RemoteEndPoint);
            // stream.Write(buffer, 0, buffer.Length);
            //stream.Flush();

            Console.WriteLine("BUFFER FOR SENT OBJECT WAS :: " + buffer);
        }

        public static void SendProcessDetails(List<Process> ProcList, TcpClient Socket)
        {


            Container dataContainer = new Container(ProcList);
            NetworkStream stream = Socket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();



            bf.Serialize(ms, dataContainer);
            byte[] buffer = ms.ToArray();
            System.Threading.Thread.Sleep(500);
            Socket.Client.SendTo(buffer, Socket.Client.RemoteEndPoint);
            // stream.Write(buffer, 0, buffer.Length);
            //stream.Flush();

            Console.WriteLine("BUFFER FOR SENT OBJECT WAS :: " + buffer);
        }

        public static string[] RecieveComputerDetails(TcpClient Socket)
        {
            Container dataFromClient = null;
            NetworkStream networkStream = Socket.GetStream();
            // clientSocket = serverSocket.AcceptTcpClient();
            // int size = Socket.ReceiveBufferSize;

            byte[] bytesFrom = new byte[Socket.ReceiveBufferSize];
            int len = Socket.Client.Receive(bytesFrom);
            dataFromClient = null;

            BinaryFormatter formattor = new BinaryFormatter();

            MemoryStream ms = new MemoryStream(bytesFrom);
            ms.Position = 0;
            dataFromClient = (Container)formattor.Deserialize(ms);
            return dataFromClient.data;

            //networkStream.Close();
            //Console.WriteLine(dataFromClient);
        }

        public static List<Process> RecieveProcessDetails(TcpClient Socket)
        {
            Container dataFromClient = null;
            NetworkStream networkStream = Socket.GetStream();
            // clientSocket = serverSocket.AcceptTcpClient();
            // int size = Socket.ReceiveBufferSize;

            byte[] bytesFrom = new byte[Socket.ReceiveBufferSize];
            int len = Socket.Client.Receive(bytesFrom);
            dataFromClient = null;

            BinaryFormatter formattor = new BinaryFormatter();

            MemoryStream ms = new MemoryStream(bytesFrom);
            dataFromClient = (Container)formattor.Deserialize(ms);

            return dataFromClient.ProcList;

            //networkStream.Close();
            //Console.WriteLine(dataFromClient);
        }




        //Iteration 3 messaging updates

        /// <summary>
        /// New Iteration 3 send command, to become standard.
        /// </summary>
        /// <param name="command">The command to be sent</param>
        /// <param name="clientSocket">The client to send the command to</param>
        /// <returns></returns>
        public static string SendNewCommand(string command, TcpClient clientSocket)
        {
            //Frame message
            //Send it
            //Return the response
            //Should be threaded?

            //Get size of message in bytes
            //Send size to client
            //Then send full message
            //Begin accepting response

            NetworkStream stream = clientSocket.GetStream();
            if (stream.CanWrite)
            {

                byte[] myWriteBuffer = Encoding.ASCII.GetBytes(command);
                stream.BeginWrite(myWriteBuffer, 0, myWriteBuffer.Length,
                                                             new AsyncCallback(SendCallback),
                                                             stream);
                //allDone.WaitOne();
            }
            else
            {
                Console.WriteLine("Sorry.  You cannot write to this NetworkStream.");
            }

            return NewRecieve(clientSocket);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                Socket client = (Socket)ar.AsyncState;

                int bytesSent = client.EndSend(ar);

                Console.WriteLine("Sent {0} bytes to server.", bytesSent);
                // Signal that all bytes have been sent.

               // sendDone.Set();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /// <summary>
        /// New Iteration 3 recieve code. To be implemented as standard
        /// </summary>
        /// <param name="socket">The client</param>
        /// <returns></returns>
        public static string NewRecieve(TcpClient socket)
        {
            // Examples for CanRead, Read, and DataAvailable. 

            // Check to see if this NetworkStream is readable. 
            StringBuilder myCompleteMessage = new StringBuilder();
            NetworkStream myNetworkStream = socket.GetStream();
            if (myNetworkStream.CanRead)
            {
                byte[] myReadBuffer = new byte[1024];
               // StringBuilder myCompleteMessage = new StringBuilder();
                int numberOfBytesRead = 0;

                // Incoming message may be larger than the buffer size. 
                do
                {
                    try
                    {

                        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                        myCompleteMessage.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Server has exited. Goodbye");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                    }
                }
                while (myNetworkStream.DataAvailable);

                // Print out the received message to the console.
                Console.WriteLine("You received the following message : " +
                                             myCompleteMessage);
            }
            else
            {
                Console.WriteLine("Sorry.  You cannot read from this NetworkStream.");
            }

            return myCompleteMessage.ToString();
        }


        //Iteration 3 send ftp. 
        /// <summary>
        /// This method is called by the Client sending the file to another client.
        /// </summary>
        /// <param name="source">The source filepath of the file to send</param>
        /// <param name="ip">The IP address of the client</param>
        public static void ClientFTPToClient(string source, string ip)
        {
            //Send file to client who connects on port 9876
            bool inUse = true;
            TcpListener serverSocket = null;
            do
            {
                try
                {
                    serverSocket = new TcpListener(IPAddress.Parse(ip), 9876); //me
                    serverSocket.Start();
                    inUse = false;
                }
                catch (Exception e)
                {
                }

            } while (inUse);

            TcpClient tempClientSocket = new TcpClient(); //client to send file to
            bool connected = false;
            do
            {
                if (serverSocket.Pending())
                {
                    tempClientSocket = serverSocket.AcceptTcpClient(); //Client connected
                    connected = true;
                }
            } while (!connected);

            //now we can send this file to this lad
            byte[] fileData = File.ReadAllBytes(source);

            tempClientSocket.Client.Send(fileData);
            tempClientSocket.Client.Close();
            tempClientSocket.Close();
            
            serverSocket.Stop();
        }

        /// <summary>
        /// This method is called by the Client downloading the file being sent from another client.
        /// </summary>
        /// <param name="ip">The IP address of the client you want to get the file from</param>
        /// <param name="pathToGo">Where to store the incoming file</param>
        /// <param name="fileLength">The length of the file</param>
        public static void AcceptClientFTPToClient(string ip, string pathToGo, int fileLength)
        {

            TcpClient socket = new System.Net.Sockets.TcpClient();
            bool connected = false;
            do
            {
                try
                {
                    socket.Connect(ip, 9876); //Connect to client
                    connected = true;
                }
                catch (Exception e)
                {
                }
            } while (!connected);
            
            Console.WriteLine("Connected to client");

            byte[] clientData = new byte[fileLength];
            int receivedBytesLen = socket.Client.Receive(clientData, clientData.Length, 0);

            Console.WriteLine("Receiving data...");
            string d = "\\";
            string[] dirs = pathToGo.Split(d.ToCharArray());

            for (int i = 0; i < dirs.Length - 1; i++)
            {
                if (i != 0)
                {
                    dirs[i] = dirs[i - 1] + dirs[i];
                }
                dirs[i] += "\\";
                if (!Directory.Exists(dirs[i]))
                {
                    Directory.CreateDirectory(dirs[i] + "\\");
                }
            }

            BinaryWriter bWrite = new BinaryWriter(File.Open(pathToGo, FileMode.Append));
            bWrite.Write(clientData, 0, clientData.Length);
         

            bWrite.Close();
            socket.Client.Close();
            socket.Close();
            //
            Console.WriteLine("Recieved File");
          //  return "Received";
        }

        public static List<Service> RecieveServiceDetails(TcpClient Socket)
        {
            Container dataFromClient = null;
            NetworkStream networkStream = Socket.GetStream();
            // clientSocket = serverSocket.AcceptTcpClient();
            // int size = Socket.ReceiveBufferSize;

            byte[] bytesFrom = new byte[500000];
            int len = Socket.Client.Receive(bytesFrom);
            //len = Socket.Client.Receive(bytesFrom);
            dataFromClient = null;

            BinaryFormatter formattor = new BinaryFormatter();

            MemoryStream ms = new MemoryStream(bytesFrom);
            ms.Seek(0, SeekOrigin.Begin);

            dataFromClient = (Container)formattor.Deserialize(ms);


            return dataFromClient.ServiceList;
        }

        public static void SendServiceDetails(List<Service> ServiceList, TcpClient Socket)
        {


            Container dataContainer = new Container(ServiceList);
            NetworkStream stream = Socket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();



            bf.Serialize(ms, dataContainer);
            byte[] buffer = ms.ToArray();
            System.Threading.Thread.Sleep(500);
            Socket.Client.SendTo(buffer, Socket.Client.RemoteEndPoint);
            // stream.Write(buffer, 0, buffer.Length);
            //stream.Flush();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("BUFFER FOR SENT OBJECT WAS :: " + buffer);
        }

        public static List<ScheduledTask> RecieveTaskDetails(TcpClient Socket)
        {
            Container dataFromClient = null;
            NetworkStream networkStream = Socket.GetStream();
            // clientSocket = serverSocket.AcceptTcpClient();
            // int size = Socket.ReceiveBufferSize;

            byte[] bytesFrom = new byte[500000];
            int len = Socket.Client.Receive(bytesFrom);
            //len = Socket.Client.Receive(bytesFrom);
            dataFromClient = null;

            BinaryFormatter formattor = new BinaryFormatter();

            MemoryStream ms = new MemoryStream(bytesFrom);
            ms.Seek(0, SeekOrigin.Begin);

            dataFromClient = (Container)formattor.Deserialize(ms);


            return dataFromClient.TaskList;
        }

        public static void SendTaskDetails(List<ScheduledTask> TaskList, TcpClient Socket)
        {


            Container dataContainer = new Container(TaskList);
            NetworkStream stream = Socket.GetStream();
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();



            bf.Serialize(ms, dataContainer);
            byte[] buffer = ms.ToArray();
            System.Threading.Thread.Sleep(500);
            Socket.Client.SendTo(buffer, Socket.Client.RemoteEndPoint);
            // stream.Write(buffer, 0, buffer.Length);
            //stream.Flush();
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("BUFFER FOR SENT OBJECT WAS :: " + buffer);
        }
    }
}
