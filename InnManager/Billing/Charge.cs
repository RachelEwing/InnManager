using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing

{
    /// <summary>
    /// A class to represent a charge on the bill
    /// </summary>
    public class Charge : BillingRecord
    {
        /// <summary>
        /// The category that is being charged for
        /// </summary>
        public ChargeCategory Category { get; set; } = ChargeCategory.Miscellaneous;
        /// <summary>
        /// The signed amount (positive) added to the bill
        /// </summary>
        public override decimal SignedAmount => Amount;
    }
}