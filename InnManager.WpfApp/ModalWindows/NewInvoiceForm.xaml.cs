using InnManager.Billing;
using InnManager.Hotels;
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
using InnManager.Guests;
using InnManager.Reservations;

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewInvoiceForm.xaml
    /// </summary>
    public partial class NewInvoiceForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewInvoiceForm()
        {
            InitializeComponent();
            InvoiceDatePicker.SelectedDate = DateTime.Today;
            DueDatePicker.SelectedDate = DateTime.Today;
        }
        /// <summary>
        /// Converts data to a new invoice or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddInvoiceClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Guest guest = (Guest)GuestPicker.SelectedItem;
                Reservation res = (Reservation)ReservationPicker.SelectedItem;
                Invoice invoice = new Invoice() { FirstName = guest.FirstName, LastName = guest.LastName, RoomNumber = res.RoomNumber, InvoiceDate = (DateTime)InvoiceDatePicker.SelectedDate, DueDate = (DateTime)DueDatePicker.SelectedDate};
                invoice.BillingRecords.Add(new Charge() {Amount = res.TotalAmount, IsProcessed = true});
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Invoices.Add(invoice);
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
            try
            {
                if (InvoiceDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot retroactively add invoices.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("An invoice date must be set.");
            }
            try
            {
                if (DueDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot set a due date retroactively.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A due date must be set.");
            }
            if (GuestPicker.SelectedIndex == -1) { valid = false; MessageBox.Show("No guests available yet"); }
            if (ReservationPicker.SelectedIndex == -1) { valid = false; MessageBox.Show("No reservations available yet"); }
            return valid;
        }

    }
}
