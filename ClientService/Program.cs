using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace ClientService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            System.ServiceProcess.ServiceBase[] ServicesToRun;
            // Change the following line to match.
            ServicesToRun = new System.ServiceProcess.ServiceBase[] { new ClientService() };
            System.ServiceProcess.ServiceBase.Run(ServicesToRun);
        }
    }
}
