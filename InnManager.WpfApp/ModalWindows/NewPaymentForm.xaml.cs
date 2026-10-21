using InnManager.Billing;
using InnManager.Enums;
using InnManager.Hotels;
using InnManager.WpfApp.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewPaymentForm.xaml
    /// </summary>
    public partial class NewPaymentForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewPaymentForm()
        {
            InitializeComponent();
            try
            {
                InvoicePicker.SelectedIndex = 0;
            }
            catch { }
            PaymentMethodPicker.ItemsSource = Enum.GetValues(typeof(PaymentMethod));
            PaymentMethodPicker.SelectedItem = PaymentMethod.Cash;
            PaymentDatePicker.SelectedDate = DateTime.Today;
        }
        /// <summary>
        /// Converts data to a new payment or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddPaymentClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Invoice invoice = (Invoice)InvoicePicker.SelectedItem;
                bool a = !decimal.TryParse(AmountPicker.Text, out decimal amount);
                Payment payment = new Payment() {Invoice = invoice, FirstName = invoice.FirstName, LastName = invoice.LastName, Date = (DateTime)PaymentDatePicker.SelectedDate, PaymentMethod = (PaymentMethod)PaymentMethodPicker.SelectedItem, Amount = amount, IDNumber = ("00" + (((Hotel)this.DataContext).Payments.Count + 1).ToString())};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Payments.Add(payment);
                }
                DialogResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// Cancels and closes form
        /// </summary>
        /// <param name="sender">cancel button</param>
        /// <param name="e">args</param>
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        /// <summary>
        /// Validates form data
        /// </summary>
        /// <returns>Whether or not data is valid</returns>

        public bool Validation() {
            bool valid = true;
            if (!decimal.TryParse(AmountPicker.Text, out decimal capacity))
            {
                MessageBox.Show(
                  "Amount must be a valid whole number.",
                  "Invalid Amount",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (capacity < 1)
            {
                MessageBox.Show(
                  "Amount must be at least 1.",
                  "Invalid Amount",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            try
            {
                if (PaymentDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot set a payment date retroactively.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A payment date must be set.");
            }
            if (InvoicePicker.SelectedIndex == -1) { valid = false; MessageBox.Show("No invoices are available"); }
            return valid;
        }
    }
}
