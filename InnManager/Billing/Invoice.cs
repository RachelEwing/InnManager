using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// A class to represent the invoice
    /// </summary>
    public class Invoice
    {
        public string GuestName { get; set; } = "";
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get; set; } = "";
        /// <summary>
        /// A list of the billing records (payments and charges)
        /// </summary>
        public List<BillingRecord> BillingRecords { get; } = new List<BillingRecord>();
        /// <summary>
        /// Adds up all processed charges
        /// </summary>
        public decimal TotalCharges
        {
            get
            {
                decimal totalCharges = 0;
                foreach (BillingRecord c in BillingRecords)
                {
                    if (c is Charge)
                    {
                        if (c.IsProcessed)
                        {
                            totalCharges += c.Amount;
                        }
                    }
                }
                return totalCharges;
            }
        }
        /// <summary>
        /// Adds up all processed payments
        /// </summary>
        public decimal TotalPayments
        {
            get
            {
                decimal totalCharges = 0;
                foreach (BillingRecord c in BillingRecords)
                {
                    if (c is Payment)
                    {
                        if (c.IsProcessed)
                        {
                            totalCharges += c.SignedAmount;
                        }
                    }
                }
                return totalCharges;
            }
        }
        /// <summary>
        /// Total balance still due
        /// </summary>
        public decimal BalanceDue { get => TotalCharges + TotalPayments; }
        /// <summary>
        /// Status of invoice (paid or unpaid)
        /// </summary>
        public string Status
        {
            get
            {
                if (BalanceDue <= 0) return "Paid";
                else return "Unpaid";
            }
        }
    }
}