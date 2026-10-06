using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Guests
{
    /// <summary>
    /// A class to keep track of the hotel's guests
    /// </summary>
    public class Guest
    {
        public string FirstName { get; set; } = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// email property
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// phone number property
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// Checked in property
        /// </summary>
        public bool IsCheckedIn { get; set; } = false;
    }
}