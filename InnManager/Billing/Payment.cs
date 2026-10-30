using InnManager.Enums;
using System.ComponentModel;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// Payments made
    /// </summary>
    public class Payment : BillingRecord
    {
        public string Status { get {

                if (IsRefunded)
                {
                    return "Refunded";
                }
                else {
                    return Invoice.Status;
                }
            } }
        private bool _isRefunded = false;
        public bool IsRefunded { get => _isRefunded; set {
                _isRefunded = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// Which invoice the payment is connected to
        /// </summary>
        public Invoice Invoice { get; set; } = new Invoice();
        /// <summary>
        /// How the bill is being paid
        /// </summary>
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
        /// <summary>
        /// The amount added to the bill (amount is converted to negative to indicate a payment)
        /// </summary>
        public override decimal SignedAmount => -Amount;
        /// <summary>
        /// Last Name of the Guest
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// First Name of the Guest
        /// </summary>
        public string FirstName { get; set; } = "";
        public string GuestName { get => FirstName + " " + LastName; }
        /// <summary>
        /// The ID Number of the guest
        /// </summary>
        public string IDNumber { get; set; } = "";
        /// <summary>
        /// The unique reference for the payment
        /// </summary>
        public string PaymentReference
        {
            get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("PAY-");
                    sb.Append(LastName[0]);
                    sb.Append(LastName[1]);
                    sb.Append("-");
                    sb.Append(IDNumber.Substring(IDNumber.Length - 3));
                    sb.Append("-");
                    if (PaymentMethod == PaymentMethod.Cash) {
                        sb.Append("C");
                    }
                    else if (PaymentMethod == PaymentMethod.BankTransfer)
                    {
                        sb.Append("BT");
                    }
                    else if (PaymentMethod == PaymentMethod.CreditCard)
                    {
                        sb.Append("CC");
                    }
                    else if (PaymentMethod == PaymentMethod.DebitCard)
                    {
                        sb.Append("DC");
                    }
                    else
                    {
                        sb.Append("DW");
                    }
                    return sb.ToString();
                }
                catch
                {
                    return "Unavailable";
                }
            }
        }
    }
}