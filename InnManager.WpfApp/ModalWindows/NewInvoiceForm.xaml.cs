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
            Invoice invoice = new Invoice();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Invoices.Add(invoice);
            }
            DialogResult = true;
            this.Close();
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
