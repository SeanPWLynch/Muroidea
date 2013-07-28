// -----------------------------------------------------------------------
// <copyright file="Group.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Communication;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Group
    {
        List<ClientThread> clients;
        private string name;
        private string description;
        private string groupid;

        /// <summary>
        /// Init. the group object
        /// </summary>
        /// <param name="name">The name of the group</param>
        /// <param name="description">The description of the group</param>
        public Group(string id, string name, string description)
        {
            this.clients = new List<ClientThread>();
            this.groupid = id;
            this.name = name;
            this.description = description;
        }

        /// <summary>
        /// Add a client to the group.
        /// </summary>
        /// <param name="c">The client object to add to the group</param>
        public void AddClient(ClientThread c)
        {
            clients.Add(c);
            if (c.GetGroup() != this)
            {
                c.SetGroup(this);
            }
        }

        /// <summary>
        /// Retrieves the list of clients currently in this group
        /// </summary>
        /// <returns>Returns the client list</returns>
        public List<ClientThread> GetClients()
        {
            return clients;
        }

        /// <summary>
        /// Send a group message to the group
        /// </summary>
        /// <param name="message">The message to send the group</param>
        public void SendMessage(string message)
        {
            foreach (ClientThread c in clients)
            {
                Messaging.SendCommand("MessageComputer('"+message+"')", c.GetClientSocket());
            }
        }

        /// <summary>
        /// Returns the name of the group
        /// </summary>
        /// <returns></returns>
        public string GetName()
        {
            return this.name;
        }

        public string GetDesc()
        {
            return this.description;
        }

        public string GetID()
        {
            return this.groupid;
        }
    }

}
