using InnManager.Billing;

namespace InnManagerTests.Billing
{
    public class BillingSummaryUnitTests
    {
        [Fact]
        public void BillingSummaryDefaultValuesAreSetCorrectly()
        {
            IEnumerable<IBillingRecord> i = new List<IBillingRecord>();
            BillingSummary b = new BillingSummary(i);
            Assert.Equal(0, b.TotalCharges);
            Assert.Equal(0, b.TotalPayments);
            Assert.Equal(0, b.NetBalance);
        }
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 5, 6)]
        [InlineData(10, 20, 30)]
        public void BillingSummaryTotalChargesIsCorrect(int a, int b, int e)
        {
            List<IBillingRecord> i = new List<IBillingRecord>();
            i.Add(new Charge() { Amount = a, IsProcessed = true });
            i.Add(new Charge() { Amount = b, IsProcessed = true });
            BillingSummary bill = new BillingSummary(i);
            Assert.Equal(e, bill.TotalCharges);
        }
        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 5, 6)]
        [InlineData(10, 20, 30)]
        public void BillingSummaryTotalPaymentsIsCorrect(int a, int b, int e)
        {
            List<IBillingRecord> i = new List<IBillingRecord>();
            i.Add(new Payment() { Amount = a, IsProcessed = true });
            i.Add(new Payment() { Amount = b, IsProcessed = true });
            BillingSummary bill = new BillingSummary(i);
            Assert.Equal(-e, bill.TotalPayments);
        }
        [Theory]
        [InlineData(1, 2, 3, 0, 0)]
        [InlineData(3, 4, 5, 1, 1)]
        [InlineData(3, 10, 5, 1, 7)]
        [InlineData(3, 4, 1, 1, 5)]
        public void BillingSummaryNetBalanceIsCorrect(int a, int b, int c, int d, int e)
        {
            List<IBillingRecord> i = new List<IBillingRecord>();
            i.Add(new Charge() { Amount = a, IsProcessed = true });
            i.Add(new Charge() { Amount = b, IsProcessed = true });
            i.Add(new Payment() { Amount = c, IsProcessed = true });
            i.Add(new Payment() { Amount = d, IsProcessed = true });
            BillingSummary bill = new BillingSummary(i);
            Assert.Equal(e, bill.NetBalance);
        }
        [Theory]
        [InlineData(1, 1, 1, 1, 1, -1, 0)]
        [InlineData(0, 0, 12, 13, 0, 0, 0)]
        [InlineData(1, 0, 1, 1, 1, 0, 1)]
        [InlineData(0, 1, 4, 2, 0, -1, -1)]
        [InlineData(1, 1, 0, 0, 1, -1, 0)]
        [InlineData(0, 0, 0, 0, 0, 0, 0)]
        [InlineData(1, 0, 0, 0, 1, 0, 1)]
        [InlineData(0, 1, 0, 0, 0, -1, -1)]
        public void UnprocessedChargesDontChangeResults(int a, int b, int c, int d, int e1, int e2, int e3)
        {
            List<IBillingRecord> i = new List<IBillingRecord>();
            for (int j = 0; j < a; j++)
            {
                i.Add(new Charge() { Amount = 1, IsProcessed = true });
            }
            for (int j = 0; j < b; j++)
            {
                i.Add(new Payment() { Amount = 1, IsProcessed = true });
            }
            for (int j = 0; j < c; j++)
            {
                i.Add(new Charge() { Amount = 1, IsProcessed = false });
            }
            for (int j = 0; j < d; j++)
            {
                i.Add(new Payment() { Amount = 1, IsProcessed = false });
            }
            BillingSummary bill = new BillingSummary(i);
            Assert.Equal(e1, bill.TotalCharges);
            Assert.Equal(e2, bill.TotalPayments);
            Assert.Equal(e3, bill.NetBalance);
        }
    }
}