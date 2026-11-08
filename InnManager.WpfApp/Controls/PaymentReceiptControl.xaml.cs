using InnManager.WpfApp.ViewModels;
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
using InnManager.Hotels;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for PaymentReceiptControl.xaml
    /// </summary>
    public partial class PaymentReceiptControl : UserControl
    {
        public PaymentReceiptControl(Hotel h, Payment p)
        {
            InitializeComponent();
            this.DataContext = new ReceiptViewModel(h, p);
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e) {
            Close?.Invoke(sender, EventArgs.Empty);
            this.Visibility = Visibility.Hidden;
        }
        public void SaveReceipt(object sender, RoutedEventArgs e) {
            ((ReceiptViewModel)this.DataContext).Generate();
            Close?.Invoke(sender, EventArgs.Empty);
            this.Visibility = Visibility.Hidden;
        }
    }
}
