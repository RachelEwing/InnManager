using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// An interface for bills
    /// </summary>
    public interface IBillingRecord
    {
        /// <summary>
        /// The amount on the bill (absolute)
        /// </summary>
        public decimal Amount { get; }
        /// <summary>
        /// The date of the bill
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// Whether or not the bill is processed
        /// </summary>
        public bool IsProcessed { get; }
        /// <summary>
        /// Amount on the bill (positive or negative)
        /// </summary>
        public decimal SignedAmount { get; }
    }
}