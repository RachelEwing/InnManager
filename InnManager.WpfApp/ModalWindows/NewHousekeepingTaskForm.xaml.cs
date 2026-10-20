using InnManager.Employees;
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

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewHousekeepingTaskForm.xaml
    /// </summary>
    public partial class NewHousekeepingTaskForm : Window
    {
        public NewHousekeepingTaskForm()
        {
            InitializeComponent();
            StatusPicker.SelectedIndex = 0;
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddTaskClick(object sender, RoutedEventArgs e)
        {
            HousekeepingTask task = new HousekeepingTask();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.HouseKeepingTasks.Add(task);
            }
            DialogResult = true;
            this.Close();
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
