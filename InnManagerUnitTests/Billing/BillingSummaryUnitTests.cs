using InnManager.Billing;

namespace InnManagerTests.Billing
{
    public class BillingSummaryUnitTests
    {
        /// <summary>
        /// Tests BillingSummary default values
        /// </summary>
        [Fact]
        public void BillingSummaryDefaultValuesAreSetCorrectly()
        {
            IEnumerable<IBillingRecord> i = new List<IBillingRecord>();
            BillingSummary b = new BillingSummary(i);
            Assert.Equal(0, b.TotalCharges);
            Assert.Equal(0, b.TotalPayments);
            Assert.Equal(0, b.NetBalance);
        }
        /// <summary>
        /// Tests BillingSummary's TotalCharges calculation
        /// </summary>
        /// <param name="a">First Charge</param>
        /// <param name="b">Second Charge</param>
        /// <param name="e">Expected value</param>
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
        /// <summary>
        /// Ensures BillingSummary calculates TotalPayments correctly
        /// </summary>
        /// <param name="a">First Payment</param>
        /// <param name="b">Second Payment</param>
        /// <param name="e">Expected Value</param>
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
        /// <summary>
        /// Ensures BillingSummary Net Balance is calculated correctly
        /// </summary>
        /// <param name="a">first charge</param>
        /// <param name="b">second charge</param>
        /// <param name="c">first payment</param>
        /// <param name="d">second payment</param>
        /// <param name="e">expected result</param>
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
        /// <summary>
        /// Ensures Unprocessed Charges Don't Change the results
        /// </summary>
        /// <param name="a">Number of Processed Charges</param>
        /// <param name="b">Number of Processed Payments</param>
        /// <param name="c">Number of Unprocessed Charges</param>
        /// <param name="d">Number of Unprocessed Payments</param>
        /// <param name="e1">Expected Total Charges</param>
        /// <param name="e2">Expected Total Payments</param>
        /// <param name="e3">Expected Net Balance</param>
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