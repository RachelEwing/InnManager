using InnManager.Billing;
using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Rooms;
using InnManager.Services;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace InnManager.Hotels
{
    public class Hotel
    {
        /// <summary>
        /// The default time for checking in
        /// </summary>
        public string CheckInTime = "9:00am";
        /// <summary>
        /// The default time for checking out
        /// </summary>
        public string CheckOutTime = "5:00pm";
        /// <summary>
        /// The account associated with the hotel
        /// </summary>
        public Account Account { get; set; } = new Account();
        /// <summary>
        /// The tax rate that applies to this hotel
        /// </summary>
        public decimal TaxRate;
        //name of hotel
        public string Name { get; set; }
        //type of hotel
        public HotelType Type { get; set; } = HotelType.Standard;
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string StateProvince { get; set; } = "";
        public string PostalCode { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string Website { get; set; } = "";
        public string Description { get; set; } = "";
        //list of rooms in the hotel
        public ObservableCollection<Room> Rooms { get; } = new ObservableCollection<Room>();
        //list of guests
        public ObservableCollection<Guest> Guests { get; } = new ObservableCollection<Guest>();
        //list of reservations
        public ObservableCollection<Reservation> Reservations { get; } = new ObservableCollection<Reservation>();
        //list of services
        public ObservableCollection<Service> Services { get; } = new ObservableCollection<Service>();
        //list of invoices
        public ObservableCollection<Invoice> Invoices { get; } = new ObservableCollection<Invoice>();
        //list of payments
        public ObservableCollection<Payment> Payments { get; } = new ObservableCollection<Payment>();
        //list of employees
        public ObservableCollection<Employee> Employees { get; } = new ObservableCollection<Employee>();
        //list of housekeeping tasks
        public ObservableCollection<HousekeepingTask> HouseKeepingTasks { get; } = new ObservableCollection<HousekeepingTask>();
        //number of rooms available
        public int AvailableRoomCount
        {
            get
            {
                int i = 0;
                foreach (Room r in Rooms)
                {
                    if (r.Status == RoomStatus.Available) i++;
                }
                return i;
            }
        }
        //number of rooms occupied
        public int OccupiedRoomCount
        {
            get
            {
                int i = 0;
                foreach (Room r in Rooms)
                {
                    if (r.Status == RoomStatus.Occupied) i++;
                }
                return i;
            }
        }
    }
}