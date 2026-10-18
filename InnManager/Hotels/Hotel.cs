using InnManager.Billing;
using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Rooms;
using InnManager.Services;
using System.Collections.ObjectModel;

namespace InnManager.Hotels
{
    public class Hotel
    {
        //name of hotel
        public string Name { get; init; }
        //type of hotel
        public HotelType Type { get; init; }
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