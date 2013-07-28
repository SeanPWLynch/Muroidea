using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Communication
{
    [Serializable]
    public class Container
    {
        /// <summary>
        /// String Array
        /// </summary>
        public string[] data;

        /// <summary>
        /// Process List
        /// </summary>
        public List<Process> ProcList;

        public List<Service> ServiceList;

        public List<ScheduledTask> TaskList;

        /// <summary>
        /// Type of container
        /// </summary>
        public string ContainerType;

        /// <summary>
        /// Container for sending string arrays
        /// </summary>
        /// <param name="data">Array Of String To be Sent</param>
        public Container(string[] data)
        {
            this.data = data;
            this.ContainerType = "StringCon";
        }

        /// <summary>
        /// Container for sending process lists
        /// </summary>
        /// <param name="ProcList">Process List To Be Sent</param>
        public Container(List<Process> ProcList)
        {
            this.ProcList = ProcList;
            this.ContainerType = "ProcCon";
        }

        public Container(List<Service> ServiceList)
        {
            this.ServiceList = ServiceList;
            this.ContainerType = "ServiceCon";
        }

        public Container(List<ScheduledTask> TaskList)
        {
            this.TaskList = TaskList;
            this.ContainerType = "ScheduleTaskCon";
        }

    }
}
