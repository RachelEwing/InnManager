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

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewInvoiceForm.xaml
    /// </summary>
    public partial class NewInvoiceForm : Window
    {
        public NewInvoiceForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddInvoiceClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Invoice invoice = new Invoice();
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Invoices.Add(invoice);
                }
                DialogResult = true;
                this.Close();
            }
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
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
            return valid;
        }

    }
}
