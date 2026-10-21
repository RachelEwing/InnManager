using InnManager.Employees;
using InnManager.Enums;
using InnManager.Hotels;
using InnManager.Housekeeping;
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
using InnManager.Rooms;

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewHousekeepingTaskForm.xaml
    /// </summary>
    public partial class NewHousekeepingTaskForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewHousekeepingTaskForm(Hotel h)
        {
            InitializeComponent();
            this.DataContext = h;
            StatusPicker.SelectedIndex = 0;
            ScheduledDatePicker.SelectedDate = DateTime.Today;
        }
        /// <summary>
        /// Converts data to a new task or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddTaskClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                HousekeepingTask task = new HousekeepingTask() { RoomNumber = ((Room)RoomPicker.SelectedItem).RoomNumber, Description = DescriptionText.Text, AssignedStaff = ((Employee)AssignedStaffPicker.SelectedItem).EmployeeID , ScheduledDate = (DateTime)ScheduledDatePicker.SelectedDate, IsCompleted = (StatusPicker.SelectedItem == "Complete")};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.HouseKeepingTasks.Add(task);
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
        /// Validates form data
        /// </summary>
        /// <returns>whether or not data is valid</returns>
        public bool Validation() {
            bool valid = true;
            if (DescriptionText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Description cannot be empty.");
            }
            try
            {
                if (ScheduledDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot retroactively schedule tasks.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A scheduled date must be set.");
            }
            if (AssignedStaffPicker.SelectedIndex == -1) { valid = false; MessageBox.Show("No staff available yet"); }
            if (RoomPicker.SelectedIndex == -1) { valid = false; MessageBox.Show("No rooms available yet"); }
            return valid;
        }
    }
}
