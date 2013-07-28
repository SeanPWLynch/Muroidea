using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    public class Service
    {
        /// <summary>
        /// Constructor for Service. Create new Service with its name, which will be its location, for instance :
        /// Service faxService = new Service("Fax");
        /// </summary>
        /// <param name="serviceID">ID of the Service</param>
        public Service(string serviceID) { }

        /// <summary>
        /// Start the Service up.
        /// </summary>
        /// <returns>If it is started successfully, then it will return True. If there is an error, or if it is already running then it will return False.</returns>
        public bool StartService() { return true; }

        /// <summary>
        /// Stop the Service.
        /// </summary>
        /// <returns>It will return True if the Service is successfully stopped. If the Service isn't running, or there was an error when stopping it, then it will return False.</returns>
        public bool StopService() { return true; }

        /// <summary>
        /// This will restart the Service
        /// </summary>
        /// <returns>This will return True if the Service is successfully restarted. If the Service isn't running, or if there was an error in restarting it then it will return False.</returns>
        public bool RestartService() { return true; }

        /// <summary>
        /// The name of the Service.
        /// </summary>
        /// <returns>Returns the name of the Service</returns>
        public string GetName() { return null; }

        /// <summary>
        /// A small brief description of the Service, for example using Fax: 'Enables you to send and receive faxes, utilizing fax resources available on this computer or on the network.'
        /// </summary>
        /// <returns>Returns the Service description.</returns>
        public string GetDescription() { return null; }

        /// <summary>
        /// The status of a Service is its state, is it running or not.
        /// </summary>
        /// <returns>This will return the Services current Status, such as Running or Stopped </returns>
        public string GetStatus() { return null; }

        /// <summary>
        /// The startup type refers to when the Service is started. Is it started automatically when the computer boots up, or will it only start manually.
        /// </summary>
        /// <returns>This returns the startup type, such as 'Manual' or 'Automatic'</returns>
        public string GetStartupType() { return null; }

        /// <summary>
        /// Some Services are depended on by other Services. If that Servcice is stopped, then the other Services may be automatically stopped also.
        /// </summary>
        /// <returns>This returns a list of dependant Services, or null if none exist.</returns>
        public Service[] GetDependantServices() { return null; }

        /// <summary>
        /// Set the startup type of the Service.
        /// </summary>
        /// <param name="type">The type you wish the Service to have, such as 'Manual' or 'Automatic'</param>
        public void SetStartupType(string type) { }
    }
}
