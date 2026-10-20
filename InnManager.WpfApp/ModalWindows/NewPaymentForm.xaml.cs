using InnManager.Billing;
using InnManager.Enums;
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
    /// Interaction logic for NewPaymentForm.xaml
    /// </summary>
    public partial class NewPaymentForm : Window
    {
        public NewPaymentForm()
        {
            InitializeComponent();
            PaymentMethodPicker.ItemsSource = Enum.GetValues(typeof(PaymentMethod));
            PaymentMethodPicker.SelectedItem = PaymentMethod.Cash;
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddPaymentClick(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Payments.Add(payment);
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
