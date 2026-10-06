using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Reservations
{
    /// <summary>
    /// Class for keeping track of hotel reservations
    /// </summary>
    public class Reservation
    {
        public string GuestName { get; set; } = "";
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get; set; } = "";
        /// <summary>
        /// check in date property
        /// </summary>
        public DateTime CheckInDate { get; set; } = DateTime.Today;
        /// <summary>
        /// check out date property
        /// </summary>
        public DateTime CheckOutDate { get; set; } = DateTime.Today;
        /// <summary>
        /// checked out boolean property
        /// </summary>
        public bool IsCheckedOut { get; set; } = false;
        /// <summary>
        /// checked out overdue boolean property
        /// </summary>
        public bool IsCheckedOutOverdue
        {
            get
            {
                if (IsCheckedOut == false && CheckOutDate < DateTime.Today) return true;
                else return false;
            }
        }
        /// <summary>
        /// confirmation property
        /// </summary>
        public bool IsConfirmed { get; set; } = false;
        /// <summary>
        /// active boolean property
        /// </summary>
        public bool IsActive
        {
            get
            {
                if (IsCheckedOut == false && IsConfirmed) return true;
                else return false;
            }
        }
        /// <summary>
        /// status property
        /// </summary>
        public string Status
        {
            get
            {
                if (IsCheckedOutOverdue)
                {
                    return "Overdue";
                }
                else if (IsConfirmed)
                {
                    if (IsCheckedOut)
                    {
                        return "Checked Out";
                    }
                    else
                    {
                        return "Confirmed";
                    }
                }
                else
                {
                    return "Pending";
                }
            }
        }
    }
}