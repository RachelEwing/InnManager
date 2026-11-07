using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InnManager.Hotels;
using InnManager.Rooms;
using InnManager.Billing;
using InnManager.Guests;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Employees;

namespace InnManager.WpfApp.ViewModels
{
    public class HotelReportViewModel
    {
        public HotelReportViewModel(Hotel h) {
            _hotel = h;
        }
        private Hotel _hotel;
        #region Occupancy Report Data
        public int TotalRooms { get => _hotel.Rooms.Count; }
        public int AvailableRooms { get => _hotel.AvailableRoomCount; }
        public int OccupiedRooms { get => _hotel.OccupiedRoomCount; }
        public string OccupancyRate { get {
                if (TotalRooms == 0) return "0%";
                return (100 * ((double)OccupiedRooms / (double)TotalRooms)).ToString() + "%"; 
            } }
        #endregion
        #region Revenue Report Data
        public decimal TotalRoomCharges { get => _hotel.Invoices.Sum(invoice => invoice.TotalRoomCost); }
        public decimal TotalServiceCharges { get => _hotel.Invoices.Sum(invoice => invoice.TotalServices); }
        public decimal TotalTax { get => _hotel.Invoices.Sum(invoice => invoice.TotalTax); }
        public decimal TotalInvoiceAmount { get => TotalRoomCharges + TotalServiceCharges + TotalTax; }
        public decimal TotalPaidAmount { get => _hotel.Invoices.Sum(invoice => invoice.TotalPaymentsPos); }
        public decimal OutstandingBalance { get => TotalInvoiceAmount - TotalPaidAmount; }
        #endregion
        #region Guest Report Data
        public int TotalGuests { get => _hotel.Guests.Count; }
        public int CheckedInGuests { get => _hotel.Guests.Count(guest => guest.IsCheckedIn); }
        public int NotCheckedInGuests { get => TotalGuests - CheckedInGuests; }
        #endregion
        #region Housekeeping Report Data
        public int TotalTasks { get => _hotel.HouseKeepingTasks.Count; }
        public int CompletedTasks { get => _hotel.HouseKeepingTasks.Count(task => task.IsCompleted); }
        public int UncompletedTasks { get => TotalTasks - CompletedTasks; }
        #endregion
        #region Reservation Report Data
        public int TotalReservations { get => _hotel.Reservations.Count(); }
        public int CheckedOutReservations { get => _hotel.Reservations.Count(res => res.Status == "Checked Out"); }
        public int OverdueReservations { get => _hotel.Reservations.Count(res => res.Status == "Overdue"); }

        public int ConfirmedReservations { get => _hotel.Reservations.Count(res => res.Status == "Confirmed"); }

        public int PendingReservations { get => _hotel.Reservations.Count(res => res.Status == "Pending"); }

        public int CancelledReservations { get => _hotel.Reservations.Count(res => res.Status == "Cancelled"); }

        #endregion
        #region Employee Report Data
        public int TotalEmployees { get => _hotel.Employees.Count(); }
        public int ActiveEmployees { get => _hotel.Employees.Count(e=>e.IsActive); }
        public int InactiveEmployees { get => TotalEmployees - ActiveEmployees; }
        #endregion
    }
}
