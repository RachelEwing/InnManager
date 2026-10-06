using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// An abstract class for billingrecord items
    /// </summary>
    public abstract class BillingRecord : IBillingRecord
    {
        /// <summary>
        /// The amount on the bill (absolute)
        /// </summary>
        public decimal Amount { get; set; } = 0;
        /// <summary>
        /// The date the bill was given
        /// </summary>
        public DateTime Date { get; set; } = (DateTime.Today);
        /// <summary>
        /// The description of the bill
        /// </summary>
        public string Description { get; set; } = "";
        /// <summary>
        /// Whether or not the bill is processed
        /// </summary>
        public bool IsProcessed { get; set; } = false;
        /// <summary>
        /// The amount on the bill (now positive or negative)
        /// </summary>
        public virtual decimal SignedAmount { get; }
    }
}