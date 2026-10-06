namespace InnManagerTests.Reservations
{
    public class ReservationUnitTests
    {
        /// <summary>
        /// Ensures reservation default values are set correctly
        /// </summary>
        [Fact]
        public void ReservationDefaultValuesAreSetCorrectly()
        {
            Reservation r = new Reservation();
            Assert.Equal("", r.GuestName);
            Assert.Equal("", r.RoomNumber);
            Assert.Equal(DateTime.Today, r.CheckInDate);
            Assert.Equal(DateTime.Today, r.CheckOutDate);
            Assert.False(r.IsCheckedOut);
            Assert.False(r.IsConfirmed);
            Assert.False(r.IsCheckedOutOverdue);
            Assert.False(r.IsActive);
            Assert.Equal("Pending", r.Status);
        }
        /// <summary>
        /// Ensures checked out overdue is set correctly
        /// </summary>
        [Fact]
        public void IsCheckedOutOverdueIsSetCorrectly()
        {
            Reservation r = new Reservation();
            r.IsCheckedOut = false;
            r.CheckOutDate = DateTime.Today.AddDays(-1);
            Assert.True(r.IsCheckedOutOverdue);
        }
        /// <summary>
        /// Ensures IsActive is set correctly
        /// </summary>
        /// <param name="a">IsCheckedOut</param>
        /// <param name="b">IsConfirmed</param>
        /// <param name="e">Expected Value of IsActive</param>
        [Theory]
        [InlineData(true, true, false)]
        [InlineData(true, false, false)]
        [InlineData(false, true, true)]
        [InlineData(false, false, false)]
        public void IsActiveIsSetCorrectly(bool a, bool b, bool e)
        {
            Reservation r = new Reservation();
            r.IsCheckedOut = a;
            r.IsConfirmed = b;
            Assert.Equal(e, r.IsActive);
        }
        /// <summary>
        /// Ensures status is set correctly for reservation
        /// </summary>
        /// <param name="a">IsConfirmed</param>
        /// <param name="b">IsCheckedOut = false and CheckoutDate = yesterday</param>
        /// <param name="c">IsCheckedOut</param>
        /// <param name="e">Expected status</param>
        [Theory]
        [InlineData(true, true, false, "Overdue")]
        [InlineData(true, false, true, "Checked Out")]
        [InlineData(true, false, false, "Confirmed")]
        [InlineData(false, false, false, "Pending")]
        public void StatusIsSetCorrectly(bool a, bool b, bool c, string e)
        {
            Reservation r = new Reservation();
            r.IsConfirmed = a;
            if (b)
            {
                r.IsCheckedOut = false;
                r.CheckOutDate = DateTime.Today.AddDays(-1);
            }
            r.IsCheckedOut = c;
            Assert.Equal(e, r.Status);
        }
        /// <summary>
        /// Ensures Reservation Derived Properties function as intended
        /// </summary>
        /// <param name="o">Offset of checkout date (-1 = yesterday, 0 = today, 1 = tomorrow)</param>
        /// <param name="a">IsCheckedOut</param>
        /// <param name="b">IsConfirmed</param>
        /// <param name="e1">Expected IsCheckedOutOverdue</param>
        /// <param name="e2">Expected IsActive</param>
        /// <param name="s">Expected Status</param>
        [Theory]
        [InlineData(1, false, false, false, false, "Pending")]
        [InlineData(1, false, true, false, true, "Confirmed")]
        [InlineData(-1, false, false, true, false, "Overdue")]
        [InlineData(-1, false, true, true, true, "Overdue")]
        [InlineData(0, false, false, false, false, "Pending")]
        [InlineData(0, false, true, false, true, "Confirmed")]
        [InlineData(-1, true, true, false, false, "Checked Out")]
        [InlineData(1, true, true, false, false, "Checked Out")]
        public void ReservationDerivedPropertiesFunctionCorrectly(int o, bool a, bool b, bool e1, bool e2, string s)
        {
            Reservation r = new Reservation() { CheckOutDate = DateTime.Today.AddDays(o), IsCheckedOut = a, IsConfirmed = b };
            Assert.Equal(e1, r.IsCheckedOutOverdue);
            Assert.Equal(e2, r.IsActive);
            Assert.Equal(s, r.Status);


        }
    }
}