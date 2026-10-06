using InnManager.Billing;
using InnManager.Enums;

namespace InnManagerTests.Billing
{
    public class PaymentUnitTests
    {
        [Fact]
        public void PaymentDefaultValuesAreSetCorrectly()
        {
            Payment p = new Payment();
            Assert.Equal(0, p.Amount);
            Assert.Equal(DateTime.Today, p.Date);
            Assert.Equal("", p.Description);
            Assert.False(p.IsProcessed);
            Assert.Equal(PaymentMethod.Cash, p.PaymentMethod);
            Assert.Equal(0, p.SignedAmount);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, -1)]
        [InlineData(500, -500)]
        public void PaymentSignedAmountIsCalculatedCorrectly(int v, int e)
        {
            Payment p = new Payment();
            p.Amount = v;
            Assert.Equal(e, p.SignedAmount);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(25, -25)]
        [InlineData(50, -50)]
        [InlineData(100, -100)]
        [InlineData(250, -250)]
        [InlineData(600, -600)]
        [InlineData(1250, -1250)]
        [InlineData(5000, -5000)]
        public void PaymentSignedAmountIsEqualtoAmount(int v, int e)
        {
            Payment c = new Payment();
            c.Amount = v;
            Assert.Equal(e, c.SignedAmount);
        }
        [Fact]
        public void PaymentInheritsFromBillingRecord()
        {
            Payment c = new Payment();
            Assert.IsAssignableFrom<BillingRecord>(c);
            Assert.IsAssignableFrom<IBillingRecord>(c);
        }
    }
}