using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Services;
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
    /// Interaction logic for ServicesControl.xaml
    /// </summary>
    public partial class ServicesControl : UserControl
    {
        public ServicesControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates new service form and reports whether or not the new service was created
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewServiceClick(object sender, RoutedEventArgs e)
        {
            NewServiceForm form = new NewServiceForm() { DataContext = this.DataContext };
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
            if (ServiceDataGrid.SelectedItem is Service service)
            {
                Edit.DataContext = service;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
                Edit.ServiceCategoryEditor.ItemsSource = Enum.GetValues(typeof(ServiceCategory));
                Edit.ServiceCategoryEditor.SelectedItem = service.Category;
            }
            else
            {
                MessageBox.Show("No service selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
        public void DeleteClick(object sender, EventArgs e)
        {
            if (ServiceDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No service selected");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {((Service)(ServiceDataGrid.SelectedItem)).ServiceName}", "Delete Service?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ((Hotel)this.DataContext).Services.Remove(((Service)(ServiceDataGrid.SelectedItem)));
                }
            }
        }
    }
}
