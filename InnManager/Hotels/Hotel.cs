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
        public int CheckInTime { get; set; } = 9;
        /// <summary>
        /// The default time for checking out
        /// </summary>
        public int CheckOutTime { get; set; } = 17;
        /// <summary>
        /// The account associated with the hotel
        /// </summary>
        public Account Account { get; set; } = new Account();
        /// <summary>
        /// The tax rate that applies to this hotel
        /// </summary>
        public double TaxRate { get; set; } = 6.5;
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
        public ObservableCollection<Reservation> RecentReservations { get {
                if (Reservations.Count > 5)
                {
                    int index = Reservations.Count;
                    return new ObservableCollection<Reservation> { Reservations[index-1], Reservations[index-2], Reservations[index-3], Reservations[index-4], Reservations[index-5] };
                }
                else {
                    ObservableCollection<Reservation> res = new ObservableCollection<Reservation>();
                    for (int i = (Reservations.Count-1); i > 0; i--) {
                        res.Add(Reservations[i]);
                    }
                    return res;
                }
            } }
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