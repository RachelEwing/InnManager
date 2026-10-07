namespace InnManagerTests.Guests
{
    public class GuestUnitTests
    {
        /// <summary>
        /// Ensures guest defaults are set correctly
        /// </summary>
        [Fact]
        public void GuestDefaultValuesAreSetCorrectly()
        {
            Guest g = new Guest();
            Assert.Equal("", g.FirstName);
            Assert.Equal("", g.LastName);
            Assert.Equal("", g.Email);
            Assert.Equal("", g.PhoneNumber);
            Assert.Equal("", g.GuestID);
            Assert.Equal("", g.IDNumber);
            Assert.Equal(IDType.Other, g.IDType);
            Assert.Equal("", g.Address);
            Assert.False(g.IsCheckedIn);
        }
    }
}