using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Client
{
    public class Hardware
    {

        public Hardware()
        {
            model = "empty";
            manufacturer = "empty";
            id = "empty";
        }

        private string model;
        private string manufacturer;
        private string id;

        /// <summary>
        /// Gets the name of piece of Hardware.
        /// </summary>
        /// <returns>Returns the name of the Hardware.</returns>
        public string GetModel() 
        { 
            return this.model; 
        }

        /// <summary>
        /// Gets the Hardware type, such as 'Disk Drive' or 'Display Device'
        /// </summary>
        /// <returns>Returns the Hardware type.</returns>
        public string GetDeviceType() { return null; }

        /// <summary>
        /// Returns the manufacturer of the Hardware, if there is one.
        /// </summary>
        /// <returns>Returns the manufacturer.</returns>
        public string GetManufacturer() 
        { 
            return this.manufacturer; 
        }

        /// <summary>
        /// The location can mean connected through USB port, or serial connection.
        /// </summary>
        /// <returns>Returns where the Hardware is located.</returns>
        public string GetLocation() { return null; }

        /// <summary>
        /// Returns the description of the Hardware
        /// </summary>
        /// <returns>Returns the description.</returns>
        public string GetDescription() { return null; }

        /// <summary>
        /// The ID of the Hardware.
        /// </summary>
        /// <returns>An integer value of the Hardwares ID.</returns>
        public string GetID() 
        {
            return this.id; 
        }

        public void SetModel(string model)
        {
            this.model = model;
        }

        public void SetManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
        }

        public void SetID(string id)
        {
            this.id = id;
        }
    }
}
