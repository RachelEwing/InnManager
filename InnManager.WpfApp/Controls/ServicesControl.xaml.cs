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
using InnManager.Services;

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
    }
}
