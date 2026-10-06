namespace InnManagerTests.Housekeeping
{
    public class HousekeepingTaskUnitTests
    {
        /// <summary>
        /// Ensures HousekeepingTask defaults are correct
        /// </summary>
        [Fact]
        public void HousekeepingDefaultValuesAreSetCorrectly()
        {
            HousekeepingTask h = new HousekeepingTask();
            Assert.Equal("", h.RoomNumber);
            Assert.Equal("", h.Description);
            Assert.Equal(DateTime.Today, h.ScheduledDate);
            Assert.False(h.IsCompleted);
            Assert.Equal("Not Completed", h.Status);
        }
        /// <summary>
        /// Ensures Housekeeping statuses alter correctly
        /// </summary>
        /// <param name="b">iscompleted bool</param>
        /// <param name="e">expected status</param>
        [Theory]
        [InlineData(true, "Complete")]
        [InlineData(false, "Not Completed")]
        public void HousekeepingStatusFunctionsCorrectly(bool b, string e)
        {
            HousekeepingTask h = new HousekeepingTask();
            h.IsCompleted = b;
            Assert.Equal(e, h.Status);
        }
    }
}