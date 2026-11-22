using System;
using System.Collections.Generic;
using System.Text;
using InnManager.Rooms;
using InnManager.Reservations;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Employees;

namespace InnManager.Hotels
{
    public class HotelSampleData
    {
        private static readonly Hotel _hotel = BuildSampleHotel();

        /// <summary>
        /// Gets the sample hotel.
        /// </summary>
        public Hotel SampleHotel => _hotel;

        // Add properties for Rooms, Reservations,
        // Guests, and HousekeepingTasks.

        /// <summary>
        /// Creates a hotel containing sample information.
        /// </summary>
        private static Hotel BuildSampleHotel()
        {
            var hotel = new Hotel();

            // Set the hotel information.
            hotel.TaxRate = 6.5;
            hotel.Name = "Imaginary Resort";

            Room room1 = new Room() { RoomNumber = "101", RoomType = Enums.RoomType.Standard, Rate = 185, Status = Enums.RoomStatus.Available, Floor = 1, Capacity = 3, IsClean = true, HasBalcony = false };
            Room room2 = new Room() { RoomNumber = "102", RoomType = Enums.RoomType.Accessible, Rate = 235, Status = Enums.RoomStatus.Occupied, Floor = 1, Capacity = 2, IsClean = true, HasBalcony = false };
            Room room3 = new Room() { RoomNumber = "103", RoomType = Enums.RoomType.Family, Rate = 285, Status = Enums.RoomStatus.Available, Floor = 1, Capacity = 4, IsClean = true, HasBalcony = true };
            Room room4 = new Room() { RoomNumber = "104", RoomType = Enums.RoomType.Standard, Rate = 185, Status = Enums.RoomStatus.Reserved, Floor = 1, Capacity = 3, IsClean = true, HasBalcony = false };
            Room room5 = new Room() { RoomNumber = "105", RoomType = Enums.RoomType.Standard, Rate = 185, Status = Enums.RoomStatus.Available, Floor = 1, Capacity = 3, IsClean = false, HasBalcony = false };
            Room room6 = new Room() { RoomNumber = "106", RoomType = Enums.RoomType.Standard, Rate = 185, Status = Enums.RoomStatus.Maintenance, Floor = 1, Capacity = 3, IsClean = true, HasBalcony = false };
            hotel.Rooms.Add(room1);
            hotel.Rooms.Add(room2);
            hotel.Rooms.Add(room3);
            hotel.Rooms.Add(room4);
            hotel.Rooms.Add(room5);
            hotel.Rooms.Add(room6);
            Guest guest1 = new Guest() { FirstName = "Tate", LastName = "Jenkins", Address = "544 N Dover Ave", Email = "tjenkins223@fmail.com", PhoneNumber = "123-456-7890", IDType = Enums.IDType.DriverLicense, IDNumber = "12345", IsCheckedIn = true };
            Guest guest2 = new Guest() { FirstName = "Mary", LastName = "Jane", Address = "398 S Denison Ave", Email = "mjane@fmail.com", PhoneNumber = "777-888-9999", IDType = Enums.IDType.Passport, IDNumber = "12344", IsCheckedIn = false };
            Guest guest3 = new Guest() { FirstName = "Gary", LastName = "Johnson", Address = "544 N Dover Ave", Email = "garyjohnson@fmail.com", PhoneNumber = "884-244-1333", IDType = Enums.IDType.DriverLicense, IDNumber = "12147", IsCheckedIn = true };
            Guest guest4 = new Guest() { FirstName = "Barry", LastName = "Peters", Address = "544 N Dover Ave", Email = "bpeters4@fmail.com", PhoneNumber = "993-534-2432", IDType = Enums.IDType.DriverLicense, IDNumber = "12245", IsCheckedIn = true };
            hotel.Guests.Add(guest1);
            hotel.Guests.Add(guest2);
            hotel.Guests.Add(guest3);
            hotel.Guests.Add(guest4);
            Reservation reservation1 = new Reservation() { Guest = guest1, Room = room1, CheckInDate = DateTime.Today, CheckOutDate = new DateTime(2026, DateTime.Today.Month, (DateTime.Today.Day + 3), 0, 0, 0), NumberOfGuests = 2, IsConfirmed = true };
            Reservation reservation2 = new Reservation() { Guest = guest3, Room = room3, CheckInDate = DateTime.Today, CheckOutDate = new DateTime(2026, DateTime.Today.Month, (DateTime.Today.Day + 3), 0, 0, 0), NumberOfGuests = 2, IsConfirmed = true };
            Reservation reservation3 = new Reservation() { Guest = guest4, Room = room5, CheckInDate = DateTime.Today, CheckOutDate = new DateTime(2026, DateTime.Today.Month, (DateTime.Today.Day + 3), 0, 0, 0), NumberOfGuests = 2, IsConfirmed = true };
            Reservation reservation4 = new Reservation() { Guest = guest1, Room = room1, CheckInDate = new DateTime(2026, (DateTime.Today.Month - 1), (DateTime.Today.Day), 0, 0, 0), CheckOutDate = new DateTime(2026, (DateTime.Today.Month - 1), (DateTime.Today.Day + 3), 0, 0, 0), NumberOfGuests = 2, IsCheckedOut = true, IsConfirmed = true};
            Reservation reservation5 = new Reservation() { Guest = guest1, Room = room1, CheckInDate = new DateTime(2027, 2, 5, 0, 0, 0), CheckOutDate = new DateTime(2027, 2, 7, 0, 0, 0), NumberOfGuests = 2 };
            hotel.Reservations.Add(reservation1);
            hotel.Reservations.Add(reservation2);
            hotel.Reservations.Add(reservation3);
            hotel.Reservations.Add(reservation4);
            hotel.Reservations.Add(reservation5);
            Employee employee = new Employee() { FirstName = "Virginia", LastName = "Green", HireDate = new DateTime(2023, 1, 17, 0, 0, 0), IsActive = true };
            HousekeepingTask task1 = new HousekeepingTask() { Room = room5, Description = "Routine Cleaning", Employee = employee, ScheduledDate = DateTime.Today, IsCompleted = false };
            HousekeepingTask task2 = new HousekeepingTask() { Room = room4, Description = "Routine Cleaning", Employee = employee, ScheduledDate = DateTime.Today, IsCompleted = true };
            HousekeepingTask task3 = new HousekeepingTask() { Room = room3, Description = "Routine Cleaning", Employee = employee, ScheduledDate = DateTime.Today, IsCompleted = true };
            HousekeepingTask task4 = new HousekeepingTask() { Room = room1, Description = "Routine Cleaning", Employee = employee, ScheduledDate = DateTime.Today, IsCompleted = true };

            hotel.HouseKeepingTasks.Add(task1);
            hotel.HouseKeepingTasks.Add(task2);
            hotel.HouseKeepingTasks.Add(task3);
            hotel.HouseKeepingTasks.Add(task4);

            return hotel;
        }
    } 
}

