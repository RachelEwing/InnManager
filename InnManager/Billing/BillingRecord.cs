using System.ComponentModel;

namespace InnManager.Billing
{
    /// <summary>
    /// An abstract class for billingrecord items
    /// </summary>
    public abstract class BillingRecord : IBillingRecord, INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the monetary amount.
        /// </summary>
        private decimal _amount = 0;
        /// <summary>
        /// The amount on the bill (absolute)
        /// </summary>
        public decimal Amount { get=>_amount; set {
                _amount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs (nameof(Amount)));
            } }
        /// <summary>
        /// Stores the current date.
        /// </summary>
        private DateTime _date = DateTime.Today;
        /// <summary>
        /// The date the bill was given
        /// </summary>
        public DateTime Date { get => _date; set
            {
                _date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
            }
        }
        /// <summary>
        /// The backing field for Description
        /// </summary>
        private string _description = "";
        /// <summary>
        /// The description of the bill
        /// </summary>
        public string Description { get => _description; set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        /// <summary>
        /// Backing field for IsProcessed
        /// </summary>
        private bool _isProcessed = false;
        /// <summary>
        /// Whether or not the bill is processed
        /// </summary>
        public bool IsProcessed { get => _isProcessed; set
            {
                _isProcessed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsProcessed)));
            } }
        /// <summary>
        /// The amount on the bill (now positive or negative)
        /// </summary>
        public virtual decimal SignedAmount { get; }
        /// <summary>
        /// Handles changed properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Helper for handling changed properties
        /// </summary>
        /// <param name="propertyName"></param>

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}