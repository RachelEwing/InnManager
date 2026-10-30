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
    /// Interaction logic for PaymentsControl.xaml
    /// </summary>
    public partial class PaymentsControl : UserControl
    {
        public PaymentsControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates new payment form and reports whether or not the payment was created
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewPaymentClick(object sender, RoutedEventArgs e)
        {
            NewPaymentForm form = new NewPaymentForm() { DataContext = this.DataContext };
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
        public void ViewClick(object sender, RoutedEventArgs e)
        {
            if (PaymentDataGrid.SelectedItem is Payment payment)
            {
                Edit.DataContext = payment;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No payment selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
        public void RefundClick(object sender, EventArgs e)
        {
            if (PaymentDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No payment selected");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to refund {((Payment)(PaymentDataGrid.SelectedItem)).IDNumber}", "Refund Payment?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    (((Payment)(PaymentDataGrid.SelectedItem))).IsRefunded = true;
                }
            }
        }
    }
}
