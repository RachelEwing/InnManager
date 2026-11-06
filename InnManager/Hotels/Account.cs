using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InnManager.Hotels
{
    public class Account : INotifyPropertyChanged
    {
        private string _displayName = "Not Set";
        /// <summary>
        /// The name of the account
        /// </summary>
        public string DisplayName { get=>_displayName; set {
                _displayName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DisplayName)));
            } }
        /// <summary>
        /// The account's attached email
        /// </summary>
        public string Email { get; set; } = "Not Set";
        /// <summary>
        /// The account's attached phone number
        /// </summary>
        public string PhoneNumber { get; set; } = "Not Set";
        /// <summary>
        /// The position of the account user
        /// </summary>
        public string Position { get; set; } = "Not Set";
        /// <summary>
        /// The department of the account user
        /// </summary>
        public string Department { get; set; } = "Not Set";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
