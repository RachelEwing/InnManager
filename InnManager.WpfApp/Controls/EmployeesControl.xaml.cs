using InnManager.Employees;
using InnManager.Hotels;
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
using InnManager.WpfApp.Controls.Editing;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for EmployeesControl.xaml
    /// </summary>
    public partial class EmployeesControl : UserControl
    {
        public EmployeesControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates a new employee form and reports whether the new employee was added or not
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewEmployeeClick(object sender, RoutedEventArgs e)
        {
            NewEmployeeForm form = new NewEmployeeForm() {DataContext = this.DataContext};
            bool? result = form.ShowDialog();
            if (result == true)
            {
                MessageBox.Show("Received");
            }
            else {
                MessageBox.Show("Cancelled");
            }
        }
        public void EditClick(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is Employee employee)
            {
                Edit.DataContext = employee;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else {
                MessageBox.Show("No employee selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e) {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
    }
}
