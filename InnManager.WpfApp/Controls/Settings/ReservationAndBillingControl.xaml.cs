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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InnManager.WpfApp.Controls.Settings
{
    /// <summary>
    /// Interaction logic for ReservationAndBillingControl.xaml
    /// </summary>
    public partial class ReservationAndBillingControl : UserControl
    {
        public List<string> hours = new List<string> { "1:00am", "2:00am", "3:00am", "4:00am", "5:00am", "6:00am", "7:00am", "8:00am", "9:00am", "10:00am", "11:00am", "12:00pm", "1:00pm", "2:00pm", "3:00pm", "4:00pm", "5:00pm", "6:00pm", "7:00pm", "8:00pm", "9:00pm", "10:00pm", "11:00pm", "12:00am" };
        public ReservationAndBillingControl()
        {
            InitializeComponent();
            CheckInPicker.ItemsSource = hours;
            CheckOutPicker.ItemsSource = hours;
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            Hotel h = (Hotel)this.DataContext;
            TaxRateText.Text = h.TaxRate.ToString();
            CheckInPicker.SelectedItem = h.CheckInTime;
            CheckOutPicker.SelectedItem = h.CheckOutTime;
        }
        public void SaveClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Hotel h = (Hotel)this.DataContext;
                bool a = !double.TryParse(TaxRateText.Text, out double tax);
                h.TaxRate = tax;
                h.CheckInTime = CheckInPicker.SelectedItem.ToString();
                h.CheckOutTime = CheckOutPicker.SelectedItem.ToString();
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (!double.TryParse(TaxRateText.Text, out double tax))
            {
                MessageBox.Show(
                  "Tax Rate must be a valid number.",
                  "Invalid Tax Rate",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (tax < 0)
            {
                MessageBox.Show(
                  "Tax Cannot be negative",
                  "Invalid Tax Rate",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            if (tax > 100) //This part's just for fun.  :)
            {
                MessageBox.Show(
                  "You can't be serious.",
                  "Invalid Tax Rate",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            return valid;
        }
    }
}
