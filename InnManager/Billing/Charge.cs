using InnManager.Enums;
using System.ComponentModel;

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
        public ChargeCategory Category { get; set {
              
                OnPropertyChanged((nameof(Category))); 
            } } = ChargeCategory.Miscellaneous;
        /// <summary>
        /// The signed amount (positive) added to the bill
        /// </summary>
        public override decimal SignedAmount => Amount;
    }
}