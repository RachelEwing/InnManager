using InnManager.Employees;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Housekeeping;
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
    /// Interaction logic for HousekeepingControl.xaml
    /// </summary>
    public partial class HousekeepingControl : UserControl
    {
        public HousekeepingControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates a new task form and reports whether or not the task was added
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewTaskClick(object sender, RoutedEventArgs e)
        {
            NewHousekeepingTaskForm form = new NewHousekeepingTaskForm((Hotel)this.DataContext);
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
            if (HousekeepingDataGrid.SelectedItem is HousekeepingTask task)
            {
                Edit.DataContext = task;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No task selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
        public void DeleteClick(object sender, EventArgs e)
        {
            if (HousekeepingDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No task selected");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {((HousekeepingTask)(HousekeepingDataGrid.SelectedItem)).Description}", "Delete Task?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ((Hotel)this.DataContext).HouseKeepingTasks.Remove(((HousekeepingTask)(HousekeepingDataGrid.SelectedItem)));
                }
            }
        }
    }
}
