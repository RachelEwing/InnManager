using InnManager.Billing;
using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Rooms;
using InnManager.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Hotels
{
    public class Hotel
    {
        //name of hotel
        public string Name { get; init; }
        //type of hotel
        public HotelType Type { get; init; }
        //list of rooms in the hotel
        public List<Room> Rooms { get; } = new List<Room>();
        //list of guests
        public List<Guest> Guests { get; } = new List<Guest>();
        //list of reservations
        public List<Reservation> Reservations { get; } = new List<Reservation>();
        //list of services
        public List<Service> Services { get; } = new List<Service>();
        //list of invoices
        public List<Invoice> Invoices { get; } = new List<Invoice>();
        //list of payments
        public List<Payment> Payments { get; } = new List<Payment>();
        //list of employees
        public List<Employee> Employees { get; } = new List<Employee>();
        //list of housekeeping tasks
        public List<HousekeepingTask> HouseKeepingTasks { get; } = new List<HousekeepingTask>();
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