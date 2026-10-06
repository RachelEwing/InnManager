using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Provides a summary of the bills
    /// </summary>
    public class BillingSummary
    {
        /// <summary>
        /// private field for storing billing records
        /// </summary>
        private IEnumerable<IBillingRecord> _records;
        /// <summary>
        /// Adds up all processed charges
        /// </summary>
        public decimal TotalCharges
        {
            get
            {
                decimal totalCharges = 0;
                foreach (BillingRecord c in _records)
                {
                    if (c.IsProcessed && c is Charge)
                    {
                        totalCharges += c.Amount;
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
                foreach (BillingRecord c in _records)
                {
                    if (c.IsProcessed && c is Payment)
                    {
                        totalCharges += c.SignedAmount;
                    }
                }
                return totalCharges;
            }
        }
        public decimal NetBalance { get => TotalCharges + TotalPayments; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="records">the list of records to be turned into _records and used for aggregating data</param>
        public BillingSummary(IEnumerable<IBillingRecord> records)
        {
            _records = records;
        }

    }
}