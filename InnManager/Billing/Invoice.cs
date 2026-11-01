using System.ComponentModel;
using System.Text;
using System.Collections.ObjectModel;

namespace InnManager.Billing
{
    /// <summary>
    /// A class to represent the invoice
    /// </summary>
    public class Invoice : INotifyPropertyChanged
    {
        public Invoice() {
            _idGenerator++;
        }
        /// <summary>
        /// Generates ID
        /// </summary>
        private static int _idGenerator = 1;
        /// <summary>
        /// The field for IDNumber
        /// </summary>
        private string _iDNumber = ("INV-" + _idGenerator.ToString("D4"));
        /// <summary>
        /// The Unique ID Number for this guest
        /// </summary>
        public string IDNumber { get => _iDNumber; }
        /// <summary>
        /// The backing field for first name
        /// </summary>
        private string _firstName = "";
        /// <summary>
        /// The first name of the guest
        /// </summary>
        public string FirstName { get => _firstName; set
            {
                _firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestName)));
            }
        }
        /// <summary>
        /// Backing field for guest's last name
        /// </summary>
        private string _lastName = "";
        /// <summary>
        /// The last name of the guest
        /// </summary>
        public string LastName { get => _lastName; set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InvoiceID)));
            }
        }
        /// <summary>
        /// The name of the guest
        /// </summary>
        public string GuestName { get => FirstName + " " + LastName; }
        private string _roomNumber = "";
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get => _roomNumber; set
            {
                _roomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InvoiceID)));
            }
        }
        /// <summary>
        /// A list of the billing records (payments and charges)
        /// </summary>
        public ObservableCollection<BillingRecord> BillingRecords { get; set; } = new ObservableCollection<BillingRecord>();
        /// <summary>
        /// The unique number of the invoice
        /// </summary>
        public string InvoiceID { get
            {
                return _iDNumber;
            }
        }
        /// <summary>
        /// Backing field for invoice date
        /// </summary>
        private DateTime _invoiceDate = DateTime.Today;
        /// <summary>
        /// The date of the invoice
        /// </summary>
        public DateTime InvoiceDate { get => _invoiceDate; set
            {
                _invoiceDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InvoiceDate)));
            }
        }
        /// <summary>
        /// The backing field for the due date
        /// </summary>
        private DateTime _dueDate = DateTime.Today;
        /// <summary>
        /// The due date of the invoice
        /// </summary>
        public DateTime DueDate { get => _dueDate; set
            {
                _dueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DueDate)));
            }
        }
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
        public decimal TotalPaymentsPos { get => -TotalPayments; }
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

        /// <summary>
        /// Handles changed properties
        /// </summary>
    }
}