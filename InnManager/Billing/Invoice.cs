using System.ComponentModel;
using System.Text;

namespace InnManager.Billing
{
    /// <summary>
    /// A class to represent the invoice
    /// </summary>
    public class Invoice : INotifyPropertyChanged
    {
        public string IDNumber { private get; set; } = "";
        /// <summary>
        /// The first name of the guest
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// The last name of the guest
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// The name of the guest
        /// </summary>
        public string GuestName { get => FirstName + " " + LastName; }
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get; set;} = "";
        /// <summary>
        /// A list of the billing records (payments and charges)
        /// </summary>
        public List<BillingRecord> BillingRecords { get; } = new List<BillingRecord>();
        /// <summary>
        /// The unique number of the invoice
        /// </summary>
        public string InvoiceID { get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("RES-");
                    sb.Append(LastName[0]);
                    sb.Append(LastName[1]);
                    sb.Append("-");
                    sb.Append(IDNumber.Substring(IDNumber.Length - 3));
                    sb.Append("-");
                    sb.Append(RoomNumber);
                    return sb.ToString();
                }
                catch
                {
                    return "Unavailable";
                }
            }
        }
        /// <summary>
        /// The date of the invoice
        /// </summary>
        public DateTime InvoiceDate { get; set; } = DateTime.Today;
        /// <summary>
        /// The due date of the invoice
        /// </summary>
        public DateTime DueDate { get; set; } = DateTime.Today;
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}