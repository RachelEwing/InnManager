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
        public NewServiceForm()
        {
            InitializeComponent();
            CategoryPicker.ItemsSource = Enum.GetValues(typeof(ServiceCategory));
            CategoryPicker.SelectedItem = ServiceCategory.Miscellaneous;
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddServiceClick(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Services.Add(service);
            }
            DialogResult = true;
            this.Close();
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        public bool Validation() {
            bool valid = true;
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
