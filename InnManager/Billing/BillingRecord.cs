using System.ComponentModel;

namespace InnManager.Billing
{
    /// <summary>
    /// An abstract class for billingrecord items
    /// </summary>
    public abstract class BillingRecord : IBillingRecord, INotifyPropertyChanged
    {
        /// <summary>
        /// The amount on the bill (absolute)
        /// </summary>
        public decimal Amount { get; set {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignedAmount)));
            } } = 0;
        /// <summary>
        /// The date the bill was given
        /// </summary>
        public DateTime Date { get; set {

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date))); 
            } } = (DateTime.Today);
        /// <summary>
        /// The description of the bill
        /// </summary>
        public string Description { get; set {
          
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description))); 
            } } = "";
        /// <summary>
        /// Whether or not the bill is processed
        /// </summary>
        public bool IsProcessed { get; set {
             
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsProcessed))); 
            } } = false;
        /// <summary>
        /// The amount on the bill (now positive or negative)
        /// </summary>
        public virtual decimal SignedAmount { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}