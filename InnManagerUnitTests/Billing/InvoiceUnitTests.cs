using InnManager.Billing;

namespace InnManagerTests.Billing
{
    public class InvoiceUnitTests
    {
        /// <summary>
        /// Ensures Invoice default values are set correctly
        /// </summary>
        [Fact]
        public void InvoiceDefaultValuesAreSetCorrectly()
        {
            Invoice i = new Invoice();
            Assert.Equal("", i.GuestName);
            Assert.Equal("", i.RoomNumber);
            Assert.Equal(0, i.BillingRecords.Count);
            Assert.Equal(0, i.TotalCharges);
            Assert.Equal(0, i.TotalPayments);
            Assert.Equal(0, i.BalanceDue);
            Assert.Equal("Paid", i.Status);
        }
        /// <summary>
        /// Ensures the invoice total charges are calculated correctly
        /// </summary>
        /// <param name="a">Charge 1</param>
        /// <param name="b">Charge 2</param>
        /// <param name="c">Charge 3</param>
        /// <param name="e">Expected Value of TotalCharges</param>
        [Theory]
        [InlineData(1, 1, 3, 5)]
        [InlineData(3, 4, 5, 12)]
        public void InvoiceTotalChargesAreSetCorrectly(int a, int b, int c, int e)
        {
            Invoice i = new Invoice();
            i.BillingRecords.Add(new Charge() { Amount = a, IsProcessed = true });
            i.BillingRecords.Add(new Charge() { Amount = b, IsProcessed = true });
            i.BillingRecords.Add(new Charge() { Amount = c, IsProcessed = true });
            Assert.Equal(e, i.TotalCharges);
        }
        /// <summary>
        /// Ensures Invoice total payments are set correctly
        /// </summary>
        /// <param name="a">Payment 1</param>
        /// <param name="b">Payment 2</param>
        /// <param name="c">Payment 3</param>
        /// <param name="e">Expected Value</param>
        [Theory]
        [InlineData(1, 1, 3, -5)]
        [InlineData(3, 4, 5, -12)]
        public void InvoiceTotalPaymentsAreSetCorrectly(int a, int b, int c, int e)
        {
            Invoice i = new Invoice();
            i.BillingRecords.Add(new Payment() { Amount = a, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = b, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = c, IsProcessed = true });
            Assert.Equal(e, i.TotalPayments);
        }
        /// <summary>
        /// Ensures Invoice Balance Due is Set Correctly
        /// </summary>
        /// <param name="a">First Charge</param>
        /// <param name="b">Second Charge</param>
        /// <param name="c">First Payment</param>
        /// <param name="d">Second Payment</param>
        /// <param name="e">Expected Value</param>
        [Theory]
        [InlineData(1, 2, 3, 0, 0)]
        [InlineData(3, 4, 5, 1, 1)]
        [InlineData(3, 10, 5, 1, 7)]
        [InlineData(3, 4, 1, 1, 5)]
        public void InvoiceBalanceDueIsSetCorrectly(int a, int b, int c, int d, int e)
        {
            Invoice i = new Invoice();
            i.BillingRecords.Add(new Charge() { Amount = a, IsProcessed = true });
            i.BillingRecords.Add(new Charge() { Amount = b, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = c, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = d, IsProcessed = true });
            Assert.Equal(e, i.BalanceDue);
        }
        /// <summary>
        /// Ensures Invoice Status Is set correctly
        /// </summary>
        /// <param name="a">charge 1</param>
        /// <param name="b">charge 2</param>
        /// <param name="c">payment1</param>
        /// <param name="d">payment2</param>
        /// <param name="e">expected value</param>
        [Theory]
        [InlineData(1, 2, 3, 0, "Paid")]
        [InlineData(3, 4, 5, 1, "Unpaid")]
        [InlineData(3, 10, 5, 1, "Unpaid")]
        [InlineData(3, 4, 4, 3, "Paid")]
        public void InvoiceStatusIsSetCorrectly(int a, int b, int c, int d, string e)
        {
            Invoice i = new Invoice();
            i.BillingRecords.Add(new Charge() { Amount = a, IsProcessed = true });
            i.BillingRecords.Add(new Charge() { Amount = b, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = c, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = d, IsProcessed = true });
            Assert.Equal(e, i.Status);
        }
        /// <summary>
        /// Ensures Invoice status and balancedue are set correctly
        /// </summary>
        /// <param name="a">Charge</param>
        /// <param name="b">Payment</param>
        /// <param name="c">Expected Status</param>
        /// <param name="e">Expected Balance</param>
        [Theory]
        [InlineData(500, 0, 500, "Unpaid")]
        [InlineData(500, 100, 400, "Unpaid")]
        [InlineData(500, 250, 250, "Unpaid")]
        [InlineData(500, 499, 1, "Unpaid")]
        [InlineData(500, 500, 0, "Paid")]
        [InlineData(500, 550, -50, "Paid")]
        [InlineData(1000, 250, 750, "Unpaid")]
        [InlineData(1000, 1200, -200, "Paid")]
        public void InvoiceStatusIsSetCorrectlyWithExpected(int a, int b, int c, string e)
        {
            Invoice i = new Invoice();
            i.BillingRecords.Add(new Charge() { Amount = a, IsProcessed = true });
            i.BillingRecords.Add(new Payment() { Amount = b, IsProcessed = true });
            Assert.Equal(e, i.Status);
            Assert.Equal(c, i.BalanceDue);
        }
    }
}