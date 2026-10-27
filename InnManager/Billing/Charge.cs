using InnManager.Enums;
using System.ComponentModel;

namespace InnManager.Billing

{
    /// <summary>
    /// A class to represent a charge on the bill
    /// </summary>
    public class Charge : BillingRecord
    {
        private ChargeCategory _category = ChargeCategory.Miscellaneous;
        /// <summary>
        /// The category that is being charged for
        /// </summary>
        public ChargeCategory Category { get => _category; set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        /// <summary>
        /// The signed amount (positive) added to the bill
        /// </summary>
        public override decimal SignedAmount => Amount;
    }
}