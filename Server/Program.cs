using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Communication;
using System.IO;
using System.Windows.Forms;


namespace Server
{
    class Program
    {
        /// <summary>
        /// Private list of clientThreads. These will be used to store information about clients connected to the server
        /// </summary>
        private static List<ClientThread> clients;
        private static List<Group> groups;

        [STAThread]
        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ServerMain());
        }

        /// <summary>
        /// Returns the list of clients
        /// </summary>
        /// <returns></returns>
        public List<ClientThread> GetClients() { return clients; }

        /// <summary>
        /// This method will constantly run as a thread. It currently sends a multicast to the network every second, informing
        /// computers on the network that it is there. When a client sees this, it will send a message to the server and the client
        /// will be added to the clients list.
        /// </summary>
        public static void AddClients()
        {
            clients = new List<ClientThread>();
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 8888);
            serverSocket.Start();

            while (true)
            {
                TcpClient tempClientSocket = new TcpClient();
                tempClientSocket.ReceiveTimeout = 300;
                
                SendMulticast();

                //Check and see if a computer is trying to connect. 
                //If not, then sleep, and resend multicast in a second
                if (serverSocket.Pending())
                {
                    tempClientSocket = serverSocket.AcceptTcpClient();
                    ClientThread c = new ClientThread(tempClientSocket,null);
                    clients.Add(c);
                    Console.WriteLine("Connected to " + c.GetClientIP() + " :: "+c.GetPort());
                }
                else {
                    Thread.Sleep(1000); //Sleep for a second, before sending the next multicast.
                }
            }
        }

        /// <summary>
        /// This method is also a thread. It prints out the menu constantly.
        /// </summary>
        public static void PrintMenu() {
            Console.WriteLine("0. Print latest client list");
            Console.WriteLine("1. Send message to all");
            Console.WriteLine("2. Connect to certain computer");
            Console.WriteLine("3. Send file to all computers");
            Console.WriteLine("4. View groups");
            Console.WriteLine("5. Add Group");
            Console.WriteLine("6. Message group");

            int selection = int.Parse(Console.ReadLine().ToString());

            switch (selection)
            {
                case 0:
                    PrintLatestClientList();
                    break;
                case 1:
                    SendMessageToAll();
                    break;
                case 2:
                    DirectConnectionToComputer();
                    break;
                case 3:
                    SendFileToAllComputers();
                    break;
                case 4:
                    ViewGroups();
                    break;
                case 5:
                    AddGroup();
                    break;
                case 6:
                    MessageGroup();
                    break;
                default:
                    break;

            }

            PrintMenu();
        }

        private static void MessageGroup()
        {
            Console.WriteLine("What group would you like to message?");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.WriteLine(i + " :: " + groups[i].GetName());
            }
            int selection = int.Parse(Console.ReadLine());

            Console.WriteLine("And the message?");
            groups[selection].SendMessage(Console.ReadLine());
        }

        private static void AddGroup()
        {
            Console.WriteLine("Name of group :: ");
            //groups.Add(new Group(Console.ReadLine(), "null description"));
        }

        private static void ViewGroups()
        {
            Console.WriteLine("What group would you like to view?");
            for (int i = 0; i < groups.Count; i++)
            {
                Console.Write(i + " :: " + groups[i].GetName());
            }
            int selection = int.Parse(Console.ReadLine());

            foreach (ClientThread c in groups[selection].GetClients())
            {
                Console.WriteLine(c.GetClientIP() + " :: " + c.GetPort());
            }

            Console.WriteLine("Would you like to add a client to this group?");
            if (Console.ReadLine() == "true")
            {
                Console.WriteLine("Which one?");
                for (int i = 0; i < clients.Count(); i++)
                {
                    Console.WriteLine(i + ") " + clients[i].GetClientIP() + " :: " + clients[i].GetPort());
                }
                groups[selection].AddClient(clients[int.Parse(Console.ReadLine())]);
            }
        }

        private static void SendFileToAllComputers()
        {
            string file = null;
            string fileName = null;
            string filePath = null;
            Console.WriteLine("Type in the file location to send ::");
            file = Console.ReadLine();

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

            byte[] fileNameByte = Encoding.ASCII.GetBytes(fileName);

            byte[] fileData = File.ReadAllBytes(filePath + fileName);
            byte[] clientData = new byte[4 + fileNameByte.Length + fileData.Length];
            byte[] fileNameLen = BitConverter.GetBytes(fileNameByte.Length);

            fileNameLen.CopyTo(clientData, 0);
            fileNameByte.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileNameByte.Length);

            foreach (ClientThread c in clients)
            {
                Messaging.SendCommand("RetrieveFile("+(c.GetPort()+1)+");", c.GetClientSocket());
                Thread sendFile = new Thread(() => c.SendFile(clientData));
                sendFile.Start();
            }
        }

        /// <summary>
        /// This method allows the server to directly connect to one client and send it commands. It shows a menu, 
        /// and lets the user choose what computer to communicate with.
        /// </summary>
        private static void DirectConnectionToComputer()
        {
            Console.WriteLine("Choose a computer to connect to directly :: ");
            for(int i = 0 ; i < clients.Count ; i++)
            {
                Console.WriteLine(i + " " + clients[i].GetClientIP() + "::" + clients[i].GetPort());
            }

            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Connected. Type in 'leave' to return back to menu.");
            Console.WriteLine();
            string message = null;

            do
            {
                Console.Write("Command> ");
                message = Console.ReadLine();
                Messaging.SendCommand(message, clients[selection].GetClientSocket());
               Console.WriteLine("Message::"+ Messaging.RecieveMessage(clients[selection].GetClientSocket()));
            } while (message != "leave");
        }

        /// <summary>
        /// This method allows the server to send a message to every client connected to it.
        /// </summary>
        private static void SendMessageToAll()
        {
            string message = null;
            Console.WriteLine("Please type in your message to send to all the clients.");
            message = Console.ReadLine();
            foreach (ClientThread c in clients)
            {
                Messaging.SendCommand("MessageComputer('" + message + "');", c.GetClientSocket()); //Sends a LUA command to
                                                                                                     //the client, which
                                                                                                     //executes it.
                Messaging.RecieveMessage(c.GetClientSocket());//Recieve the reply from the client.
            }
        }

        /// <summary>
        /// This method prints out the entire client list connected to the server.
        /// </summary>
        private static void PrintLatestClientList()
        {
            foreach(ClientThread c in clients)
            {
                Console.WriteLine(c.GetClientIP() + " : " + c.GetPort());
            }
        }

        /// <summary>
        /// This method sends a mulicast to the network.
        /// </summary>
        private static void SendMulticast()
        {
            string multiAdd = "224.5.6.7"; //The IP address to send the multicast to.
            Messaging.SendMulticast(multiAdd);
        }
    }
}
