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
using InnManager.Employees;
using InnManager.Hotels;

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewEmployeeForm.xaml
    /// </summary>
    public partial class NewEmployeeForm : Window
    {
        public NewEmployeeForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddEmployeeClick(object sender, RoutedEventArgs e) {
            Employee employee = new Employee();
            var data = this.DataContext;
            if (data is Hotel h) {
                h.Employees.Add(employee);
            }
            DialogResult = true;
            this.Close();
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
    }
}
