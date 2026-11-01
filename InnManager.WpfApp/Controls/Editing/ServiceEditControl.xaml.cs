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
using InnManager.Enums;
using InnManager.Services;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for ServiceEditControl.xaml
    /// </summary>
    public partial class ServiceEditControl : UserControl
    {
        public ServiceEditControl()
        {
            InitializeComponent();
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public void SaveServiceClick(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                ((Service)this.DataContext).Category = (ServiceCategory)ServiceCategoryEditor.SelectedItem;
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (ServiceNameEditor.Text == "") valid = false;
            if (DescriptionEditor.Text == "") valid = false;
            if (!decimal.TryParse(PriceEditor.Text, out decimal capacity))
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
