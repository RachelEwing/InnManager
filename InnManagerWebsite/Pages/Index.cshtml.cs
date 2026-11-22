using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InnManager.Hotels;
using InnManager.Enums;
using InnManager.Housekeeping;
using InnManager.Rooms;
using System.Collections.ObjectModel;
using InnManager.Reservations;
using InnManager.Guests;

namespace InnManagerWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private static HotelSampleData _hotelData { get; set; } = new HotelSampleData();
        public static Hotel hotel = (Hotel)_hotelData.SampleHotel;
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Guest> Guests { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<HousekeepingTask> Housekeeping { get; set; }
        public void OnGet(){
            Rooms = (IEnumerable<Room>)hotel.Rooms;
            Guests = (IEnumerable<Guest>)hotel.Guests;
            Reservations = (IEnumerable<Reservation>)hotel.Reservations;
            Housekeeping = (IEnumerable<HousekeepingTask>)hotel.HouseKeepingTasks;
        }
    }
}
