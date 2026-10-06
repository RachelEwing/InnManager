using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Payments made
    /// </summary>
    public class Payment : BillingRecord
    {
        /// <summary>
        /// How the bill is being paid
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        /// <summary>
        /// The amount added to the bill (amount is converted to negative to indicate a payment)
        /// </summary>
        public override decimal SignedAmount => -Amount;
    }
}