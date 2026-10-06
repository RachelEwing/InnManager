global using InnManager;
global using InnManager.Enums;
global using InnManager.Rooms;
global using InnManager.Hotels;
global using InnManager.Billing;
global using InnManager.Employees;
global using InnManager.Guests;
global using InnManager.Housekeeping;
global using InnManager.Reservations;
global using InnManager.Services;
namespace InnManagerTests.Hotels
{
    public class HotelUnitTests
    {
        /// <summary>
        /// Ensures Hotel defaults are set correctly
        /// </summary>
        [Fact]
        public void HotelDefaultValuesAreSetCorrectly()
        {
            Hotel h = new Hotel() { Name = "Grandview Hotel", Type = HotelType.Business };
            Assert.Equal(0, h.Rooms.Count);
            Assert.Equal(0, h.Guests.Count);
            Assert.Equal(0, h.Reservations.Count);
            Assert.Equal(0, h.Services.Count);
            Assert.Equal(0, h.Invoices.Count);
            Assert.Equal(0, h.Payments.Count);
            Assert.Equal(0, h.Employees.Count);
            Assert.Equal(0, h.HouseKeepingTasks.Count);
            Assert.Equal(0, h.AvailableRoomCount);
            Assert.Equal(0, h.OccupiedRoomCount);
        }
        /// <summary>
        /// Ensures Hotel Available room count is set correctly
        /// </summary>
        /// <param name="e">expected value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(14)]
        [InlineData(35)]
        public void HotelAvailableRoomCountFunctionsCorrectly(int e)
        {
            Hotel h = new Hotel();
            for (int i = 0; i < e; i++)
            {
                h.Rooms.Add(new Room() { Status = RoomStatus.Available });
            }
            h.Rooms.Add(new Room() { Status = RoomStatus.Occupied });
            Assert.Equal(e, h.AvailableRoomCount);
        }
        /// <summary>
        /// Ensures OccupiedRoomCount is set correctly
        /// </summary>
        /// <param name="e">Expected value</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(14)]
        [InlineData(35)]
        public void HotelOccupiedRoomCountFunctionsCorrectly(int e)
        {
            Hotel h = new Hotel();
            for (int i = 0; i < e; i++)
            {
                h.Rooms.Add(new Room() { Status = RoomStatus.Occupied });
            }
            h.Rooms.Add(new Room() { Status = RoomStatus.Available });
            Assert.Equal(e, h.OccupiedRoomCount);
        }
        /// <summary>
        /// Ensures hotelroomcount works with various statuses
        /// </summary>
        /// <param name="r1">RoomStatus of first room</param>
        /// <param name="r2">RoomStatus of second room</param>
        /// <param name="r3">RoomStatus of third room</param>
        /// <param name="r4">RoomStatus of fourth room</param>
        /// <param name="r5">RoomStatus of fifth room</param>
        /// <param name="a">Expected available</param>
        /// <param name="o">Expected occupied</param>
        [Theory]
        [InlineData(RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, RoomStatus.Available, 5, 0)]
        [InlineData(RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, RoomStatus.Occupied, 0, 5)]
        [InlineData(RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Available, 3, 2)]
        [InlineData(RoomStatus.Reserved, RoomStatus.Maintenance, RoomStatus.Reserved, RoomStatus.Maintenance, RoomStatus.Reserved, 0, 0)]
        [InlineData(RoomStatus.Available, RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Maintenance, RoomStatus.Available, 2, 1)]
        [InlineData(RoomStatus.Occupied, RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Maintenance, RoomStatus.Available, 1, 2)]
        [InlineData(RoomStatus.Maintenance, RoomStatus.Available, RoomStatus.Maintenance, RoomStatus.Available, RoomStatus.Occupied, 2, 1)]
        [InlineData(RoomStatus.Reserved, RoomStatus.Occupied, RoomStatus.Available, RoomStatus.Occupied, RoomStatus.Reserved, 1, 2)]
        public void HotelRoomCountFunctionsCorrectly(RoomStatus r1, RoomStatus r2, RoomStatus r3, RoomStatus r4, RoomStatus r5, int a, int o)
        {
            Hotel h = new Hotel();
            h.Rooms.Add(new Room() { Status = r1 });
            h.Rooms.Add(new Room() { Status = r2 });
            h.Rooms.Add(new Room() { Status = r3 });
            h.Rooms.Add(new Room() { Status = r4 });
            h.Rooms.Add(new Room() { Status = r5 });
            Assert.Equal(a, h.AvailableRoomCount);
            Assert.Equal(o, h.OccupiedRoomCount);
        }
    }
}