namespace InnManagerTests.Services
{
    public class ServiceUnitTests
    {
        /// <summary>
        /// Ensures Service default values are set correctly
        /// </summary>
        [Fact]
        public void ServiceDefaultValuesAreSetCorrectly()
        {
            Service s = new Service();
            Assert.Equal("", s.ServiceName);
            Assert.Equal("", s.Description);
            Assert.Equal(0, s.Price);
            Assert.True(s.IsAvailable);
            Assert.Equal(ServiceCategory.Miscellaneous, s.Category);
        }
    }
}