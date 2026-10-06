using System;
using System.Collections.Generic;
using System.Text;

namespace InnManagerTests_Clean_
{
    public class RequiredTests
    {
        /// <summary>
        /// Ensures Room Charges are processed correctly, and inherit from BillingRecords and IBillingRecords
        /// </summary>
        [Fact]
        public void ProcessRoomChargeCorrectly()
        {
            Charge c = new Charge() { Amount = 600, Category = ChargeCategory.Room, IsProcessed = true };
            Assert.Equal(600, c.Amount);
            Assert.Equal(600, c.SignedAmount);
            Assert.Equal(ChargeCategory.Room, c.Category);
            Assert.True(c.IsProcessed);
            Assert.IsAssignableFrom<BillingRecord>(c);
            Assert.IsAssignableFrom<IBillingRecord>(c);
        }
        /// <summary>
        /// Ensures Credit card payments are processed correctly
        /// </summary>
        [Fact]
        public void ProcessedCreditCardPaymentCorrectly()
        {
            Payment p = new Payment() { Amount = 500, PaymentMethod = PaymentMethod.CreditCard, IsProcessed = true };
            Assert.Equal(500, p.Amount);
            Assert.Equal(-500, p.SignedAmount);
            Assert.Equal(PaymentMethod.CreditCard, p.PaymentMethod);
            Assert.True(p.IsProcessed);
            Assert.IsAssignableFrom<BillingRecord>(p);
            Assert.IsAssignableFrom<IBillingRecord>(p);
        }
        /// <summary>
        /// Ensures partially paid invoices are processed correctly
        /// </summary>
        [Fact]
        public void PartiallyPaidInvoiceIsCorrect()
        {
            Charge c1 = new Charge() { Amount = 600, Category = ChargeCategory.Room, IsProcessed = true };
            Charge c2 = new Charge() { Amount = 40, Category = ChargeCategory.Laundry, IsProcessed = true };
            Payment p = new Payment() { Amount = 250, PaymentMethod = PaymentMethod.CreditCard, IsProcessed = true };
            Invoice i = new Invoice();
            i.BillingRecords.Add(c1);
            i.BillingRecords.Add(c2);
            i.BillingRecords.Add(p);
            Assert.Equal(640, i.TotalCharges);
            Assert.Equal(-250, i.TotalPayments);
            Assert.Equal(390, i.BalanceDue);
            Assert.Equal("Unpaid", i.Status);
        }
        /// <summary>
        /// Ensures fully paid invoices are processed correctly
        /// </summary>
        [Fact]
        public void FullyPaidInvoiceIsCorrect()
        {
            Charge c1 = new Charge() { Amount = 600, Category = ChargeCategory.Room, IsProcessed = true };
            Charge c2 = new Charge() { Amount = 40, Category = ChargeCategory.Laundry, IsProcessed = true };
            Payment p = new Payment() { Amount = 640, IsProcessed = true };
            Invoice i = new Invoice();
            i.BillingRecords.Add(c1);
            i.BillingRecords.Add(c2);
            i.BillingRecords.Add(p);
            Assert.Equal(640, i.TotalCharges);
            Assert.Equal(-640, i.TotalPayments);
            Assert.Equal(0, i.BalanceDue);
            Assert.Equal("Paid", i.Status);
        }
        /// <summary>
        /// Ensures Unprocessed Bills are ignored by BillingRecords
        /// </summary>
        [Fact]
        public void IgnoreUnprocessedBilling()
        {
            Charge c1 = new Charge() { Amount = 700, Category = ChargeCategory.Room, IsProcessed = true };
            Charge c2 = new Charge() { Amount = 150, Category = ChargeCategory.Spa, IsProcessed = false };
            Payment p1 = new Payment() { Amount = 200, IsProcessed = true };
            Payment p2 = new Payment() { Amount = 300, IsProcessed = false };
            Invoice i = new Invoice();
            i.BillingRecords.Add(c1);
            i.BillingRecords.Add(c2);
            i.BillingRecords.Add(p1);
            i.BillingRecords.Add(p2);
            Assert.Equal(700, i.TotalCharges);
            Assert.Equal(-200, i.TotalPayments);
            Assert.Equal(500, i.BalanceDue);
            Assert.Equal("Unpaid", i.Status);
        }
        /// <summary>
        /// Ensures A billingsummary with a mix of processed and unprocessed payments and charges functions correctly
        /// </summary>
        [Fact]
        public void BillingSummaryWithMixedRecordsIsCorrect()
        {
            Charge c1 = new Charge() { Amount = 1200, Category = ChargeCategory.Room, IsProcessed = true };
            Charge c2 = new Charge() { Amount = 300, Category = ChargeCategory.Dining, IsProcessed = true };
            Charge c3 = new Charge() { Amount = 100, Category = ChargeCategory.Laundry, IsProcessed = true };
            Charge c4 = new Charge() { Amount = 400, Category = ChargeCategory.Spa, IsProcessed = false };
            Payment p1 = new Payment() { Amount = 800, IsProcessed = true };
            Payment p2 = new Payment() { Amount = 250, IsProcessed = true };
            Payment p3 = new Payment() { Amount = 500, IsProcessed = false };
            Invoice i = new Invoice();
            i.BillingRecords.Add(c1);
            i.BillingRecords.Add(c2);
            i.BillingRecords.Add(c3);
            i.BillingRecords.Add(c4);
            i.BillingRecords.Add(p1);
            i.BillingRecords.Add(p2);
            i.BillingRecords.Add(p3);
            BillingSummary b = new BillingSummary(i.BillingRecords);
            Assert.Equal(1600, b.TotalCharges);
            Assert.Equal(-1050, b.TotalPayments);
            Assert.Equal(550, b.NetBalance);
        }
        /// <summary>
        /// Ensures the hotel processes room counts correctly, and counts available and occupied rooms correctly
        /// </summary>
        [Fact]
        public void HotelRoomStatusCountsIsCorrect()
        {
            Hotel h = new Hotel() { Name = "Grandview Hotel", Type = HotelType.Business };
            h.Rooms.Add(new Room() { RoomNumber = "101", Status = RoomStatus.Available });
            h.Rooms.Add(new Room() { RoomNumber = "102", Status = RoomStatus.Available });
            h.Rooms.Add(new Room() { RoomNumber = "103", Status = RoomStatus.Occupied });
            h.Rooms.Add(new Room() { RoomNumber = "104", Status = RoomStatus.Reserved });
            h.Rooms.Add(new Room() { RoomNumber = "201", Status = RoomStatus.Maintenance });
            h.Rooms.Add(new Room() { RoomNumber = "202", Status = RoomStatus.Occupied });
            h.Rooms.Add(new Room() { RoomNumber = "203", Status = RoomStatus.Maintenance });
            h.Rooms.Add(new Room() { RoomNumber = "204", Status = RoomStatus.Available });
            Assert.Equal(8, h.Rooms.Count);
            Assert.Equal(3, h.AvailableRoomCount);
            Assert.Equal(2, h.OccupiedRoomCount);
        }
        /// <summary>
        /// Ensures HousekeepingStatus processed status correctly
        /// </summary>
        [Fact]
        public void HousekeepingStatusIsCorrect()
        {
            HousekeepingTask h = new HousekeepingTask() { RoomNumber = "204", Description = "Clean and prepare room", IsCompleted = false };
            Assert.Equal("Not Completed", h.Status);
            h.IsCompleted = true;
            Assert.Equal("Complete", h.Status);
        }
    }
}
