using InnManager.Billing;
using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Housekeeping;
using InnManager.Reservations;
using InnManager.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;

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
        public void GenerateOccupancy()
        {
            string filepath = ($"report_occupancy_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Occupancy Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>OCCUPANCY REPORT</h1>");
            sb.Append($"<p>Total Rooms: {TotalRooms}</p>");
            sb.Append($"<p>Available Rooms: {AvailableRooms}</p>");
            sb.Append($"<p>Occupied Rooms: {OccupiedRooms}</p>");
            sb.Append($"<p>Occupancy Rate: {OccupancyRate}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
        #region Revenue Report Data
        public decimal TotalRoomCharges { get => _hotel.Invoices.Sum(invoice => invoice.TotalRoomCost); }
        public decimal TotalServiceCharges { get => _hotel.Invoices.Sum(invoice => invoice.TotalServices); }
        public decimal TotalTax { get => _hotel.Invoices.Sum(invoice => invoice.TotalTax); }
        public decimal TotalInvoiceAmount { get => TotalRoomCharges + TotalServiceCharges + TotalTax; }
        public decimal TotalPaidAmount { get => _hotel.Invoices.Sum(invoice => invoice.TotalPaymentsPos); }
        public decimal OutstandingBalance { get => TotalInvoiceAmount - TotalPaidAmount; }
        public void GenerateRevenue()
        {
            string filepath = ($"report_revenue_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Revenue Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>REVENUE REPORT</h1>");
            sb.Append($"<p>Total Room Charges: {TotalRoomCharges}</p>");
            sb.Append($"<p>Total Service Charges: {TotalServiceCharges}</p>");
            sb.Append($"<p>Total Tax: {TotalTax}</p>");
            sb.Append($"<p>Total Invoice Amount: {TotalInvoiceAmount}</p>");
            sb.Append($"<p>Total Paid Amount: {TotalPaidAmount}</p>");
            sb.Append($"<p>Outstanding Balance: {OutstandingBalance}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
        #region Guest Report Data
        public int TotalGuests { get => _hotel.Guests.Count; }
        public int CheckedInGuests { get => _hotel.Guests.Count(guest => guest.IsCheckedIn); }
        public int NotCheckedInGuests { get => TotalGuests - CheckedInGuests; }
        public void GenerateGuest()
        {
            string filepath = ($"report_guests_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Guest Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>GUEST REPORT</h1>");
            sb.Append($"<p>Total Guests: {TotalGuests}</p>");
            sb.Append($"<p>Checked In Guests: {CheckedInGuests}</p>");
            sb.Append($"<p>Not Checked In Guests: {NotCheckedInGuests}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
        #region Housekeeping Report Data
        public int TotalTasks { get => _hotel.HouseKeepingTasks.Count; }
        public int CompletedTasks { get => _hotel.HouseKeepingTasks.Count(task => task.IsCompleted); }
        public int UncompletedTasks { get => TotalTasks - CompletedTasks; }
        public void GenerateHousekeeping()
        {
            string filepath = ($"report_housekeeping_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Housekeeping Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>HOUSEKEEPING REPORT</h1>");
            sb.Append($"<p>Total Tasks: {TotalTasks}</p>");
            sb.Append($"<p>Completed Tasks: {CompletedTasks}</p>");
            sb.Append($"<p>Uncompleted Tasks: {UncompletedTasks}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
        #region Reservation Report Data
        public int TotalReservations { get => _hotel.Reservations.Count(); }
        public int CheckedOutReservations { get => _hotel.Reservations.Count(res => res.Status == "Checked Out"); }
        public int OverdueReservations { get => _hotel.Reservations.Count(res => res.Status == "Overdue"); }

        public int ConfirmedReservations { get => _hotel.Reservations.Count(res => res.Status == "Confirmed"); }

        public int PendingReservations { get => _hotel.Reservations.Count(res => res.Status == "Pending"); }

        public int CancelledReservations { get => _hotel.Reservations.Count(res => res.Status == "Cancelled"); }
        public void GenerateReservations()
        {
            string filepath = ($"report_reservations_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Reservations Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>RESERVATIONS REPORT</h1>");
            sb.Append($"<p>Total Reservations: {TotalReservations}</p>");
            sb.Append($"<p>Checked Out Reservations: {CheckedOutReservations}</p>");
            sb.Append($"<p>Overdue Reservations: {OverdueReservations}</p>");
            sb.Append($"<p>Confirmed Reservations: {ConfirmedReservations}</p>");
            sb.Append($"<p>Pending Reservations: {PendingReservations}</p>");
            sb.Append($"<p>Cancelled Reservations: {CancelledReservations}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
        #region Employee Report Data
        public int TotalEmployees { get => _hotel.Employees.Count(); }
        public int ActiveEmployees { get => _hotel.Employees.Count(e=>e.IsActive); }
        public int InactiveEmployees { get => TotalEmployees - ActiveEmployees; }
        public void GenerateEmployee()
        {
            string filepath = ($"report_employee_{DateTime.Today:yyyy-MM-dd_HH-mm-ss}.html");
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<meta charset='UTF-8'>");
            sb.Append($"<title>{_hotel.Name} Employee Report</title>");
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append($"<h1>{_hotel.Name}</h1>");
            sb.Append($"<h1>EMPLOYEE REPORT</h1>");
            sb.Append($"<p>Total Employees: {TotalEmployees}</p>");
            sb.Append($"<p>Active Employees: {ActiveEmployees}</p>");
            sb.Append($"<p>Inactive Employees: {InactiveEmployees}</p>");
            sb.Append("</body>");
            sb.Append("</html>");
            string content = sb.ToString();
            try
            {
                File.WriteAllText(filepath, content);
                MessageBox.Show("Report generated");
            }
            catch
            {
                MessageBox.Show("There was an error in generating your report.");
            }
        }
        #endregion
    }
}
