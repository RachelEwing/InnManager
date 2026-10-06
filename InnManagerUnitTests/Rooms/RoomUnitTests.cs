namespace InnManagerTests.Rooms
{
    public class RoomUnitTests
    {
        /// <summary>
        /// Ensures Room default values are set correctly
        /// </summary>
        [Fact]
        public void RoomDefaultValuesAreSetCorrectly()
        {
            Room r = new Room();
            Assert.Equal(0, r.Floor);
            Assert.Equal(1, r.Capacity);
            Assert.False(r.HasBalcony);
            Assert.True(r.IsClean);
            Assert.Equal(RoomType.Standard, r.RoomType);
            Assert.Equal(RoomStatus.Available, r.Status);
        }
    }
}