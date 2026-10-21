using InnManager.Employees;
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
    /// Interaction logic for NewEmployeeForm.xaml
    /// </summary>
    public partial class NewEmployeeForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewEmployeeForm()
        {
            InitializeComponent();
            PositionPicker.ItemsSource = Enum.GetValues(typeof(EmployeePosition));
            PositionPicker.SelectedItem = EmployeePosition.FrontDesk;
            HireDatePicker.SelectedDate = DateTime.Today;
            StatusPicker.SelectedItem = StatusPicker.Items[0];
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void AddEmployeeClick(object sender, RoutedEventArgs e) {
            if (Validation()) {
                Employee employee = new Employee() {FirstName = FirstNameText.Text, LastName = LastNameText.Text, Email = EmailText.Text, Position = (EmployeePosition)PositionPicker.SelectedItem, PhoneNumber = PhoneText.Text, HireDate = (DateTime)HireDatePicker.SelectedDate};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Employees.Add(employee);
                }
                DialogResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// Closes form without creating an employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (FirstNameText.Text.Length < 1) {
                valid = false;
                MessageBox.Show("First Name cannot be empty.");
            }
            if (LastNameText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Last Name cannot be empty.");
            }
            if (EmailText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Email cannot be empty.");
            }
            if (PhoneText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Phone cannot be empty.");
            }
            try
            {
                if (HireDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot retroactively add employees.");
                }
            }
            catch {
                valid = false;
                MessageBox.Show("A hiring date must be set.");
            }
            return valid;
        }
    }
}
