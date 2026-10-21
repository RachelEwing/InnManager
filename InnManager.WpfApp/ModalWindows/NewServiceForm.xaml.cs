using InnManager.Enums;
using InnManager.Hotels;
using InnManager.Services;
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
    /// Interaction logic for NewServiceForm.xaml
    /// </summary>
    public partial class NewServiceForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewServiceForm()
        {
            InitializeComponent();
            CategoryPicker.ItemsSource = Enum.GetValues(typeof(ServiceCategory));
            CategoryPicker.SelectedItem = ServiceCategory.Miscellaneous;
        }
        /// <summary>
        /// Converts data to a new service or returns error
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void AddServiceClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                bool a = !decimal.TryParse(PricePicker.Text, out decimal price);
                Service service = new Service() {ServiceName = ServiceNameText.Text, Category = (ServiceCategory)CategoryPicker.SelectedItem, Price = price, IsAvailable = (IsAvailablePicker.IsChecked == true), Description = DescriptionText.Text};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Services.Add(service);
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
        /// Validates data
        /// </summary>
        /// <returns>Whether or not data is valid</returns>
        public bool Validation() {
            bool valid = true;
            if (ServiceNameText.Text == "") valid = false;
            if (DescriptionText.Text == "") valid = false;
            if (!decimal.TryParse(PricePicker.Text, out decimal capacity))
            {
                MessageBox.Show(
                  "Price must be a valid whole number.",
                  "Invalid Price",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (capacity < 1)
            {
                MessageBox.Show(
                  "Price must be at least 1.",
                  "Invalid Price",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            return valid;
        }
    }
}
