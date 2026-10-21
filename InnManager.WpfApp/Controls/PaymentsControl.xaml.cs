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
    }
}
