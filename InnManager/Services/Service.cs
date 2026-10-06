using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Services
{
    /// <summary>
    /// Class to keep track of hotel services
    /// </summary>
    public class Service
    {
        /// <summary>
        /// name of service property
        /// </summary>
        public string ServiceName { get; set; } = "";
        /// <summary>
        /// description property
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// price property
        /// </summary>
        public decimal Price { get; set; } = 0;
        /// <summary>
        /// availability property
        /// </summary>
        public bool IsAvailable { get; set; } = true;
        /// <summary>
        /// service category property
        /// </summary>
        public ServiceCategory Category { get; set; } = ServiceCategory.Miscellaneous;
    }
}