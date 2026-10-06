using InnManager.Billing;
using InnManager.Enums;

namespace InnManagerTests.Billing
{
    public class ChargeUnitTests
    {
        [Fact]
        public void ChargeDefaultValuesAreSetCorrectly()
        {
            Charge c = new Charge();
            Assert.Equal(0, c.Amount);
            Assert.Equal(DateTime.Today, c.Date);
            Assert.Equal("", c.Description);
            Assert.False(c.IsProcessed);
            Assert.Equal(ChargeCategory.Miscellaneous, c.Category);
            Assert.Equal(0, c.SignedAmount);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(500, 500)]
        public void ChargeSignedAmountIsCalculatedCorrectly(int v, int e)
        {
            Charge c = new Charge();
            c.Amount = v;
            Assert.Equal(e, c.SignedAmount);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(25, 25)]
        [InlineData(50, 50)]
        [InlineData(100, 100)]
        [InlineData(250, 250)]
        [InlineData(600, 600)]
        [InlineData(1250, 1250)]
        [InlineData(5000, 5000)]
        public void ChargeSignedAmountIsEqualtoAmount(int v, int e)
        {
            Charge c = new Charge();
            c.Amount = v;
            Assert.Equal(v, c.SignedAmount);
        }
        [Fact]
        public void ChargeInheritsFromBillingRecord()
        {
            Charge c = new Charge();
            Assert.IsAssignableFrom<BillingRecord>(c);
            Assert.IsAssignableFrom<IBillingRecord>(c);
        }
    }
}