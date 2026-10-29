using InnManager.Employees;
using InnManager.WpfApp.ModalWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using InnManager.Billing;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for InvoicesControl.xaml
    /// </summary>
    public partial class InvoicesControl : UserControl
    {
        public InvoicesControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates new invoice form and reports whether or not the invoice was created
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewInvoiceClick(object sender, RoutedEventArgs e)
        {
            NewInvoiceForm form = new NewInvoiceForm() { DataContext = this.DataContext };
            bool? result = form.ShowDialog();
            if (result == true)
            {
                MessageBox.Show("Received");
            }
            else
            {
                MessageBox.Show("Cancelled");
            }
        }
        public void EditClick(object sender, RoutedEventArgs e)
        {
            if (InvoiceDataGrid.SelectedItem is Invoice invoice)
            {
                Edit.DataContext = invoice;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No invoice selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
    }
}
