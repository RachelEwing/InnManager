using InnManager.Billing;
using InnManager.Enums;

namespace InnManagerTests.Billing
{
    public class ChargeUnitTests
    {
        /// <summary>
        /// Ensures Charge Default values are set correctly
        /// </summary>
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
        /// <summary>
        /// Ensures Charge Signed amount is calculated correctly
        /// </summary>
        /// <param name="v">Amount</param>
        /// <param name="e">Expected Signed Amount</param>
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
        /// <summary>
        /// Ensures the charge signed amount is equal to the amount
        /// </summary>
        /// <param name="v">The amount</param>
        /// <param name="e">The expected amount</param>
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
        /// <summary>
        /// Ensures Charge Inhereits from BillingRecord and IBillingRecord
        /// </summary>
        [Fact]
        public void ChargeInheritsFromBillingRecord()
        {
            Charge c = new Charge();
            Assert.IsAssignableFrom<BillingRecord>(c);
            Assert.IsAssignableFrom<IBillingRecord>(c);
        }
    }
}