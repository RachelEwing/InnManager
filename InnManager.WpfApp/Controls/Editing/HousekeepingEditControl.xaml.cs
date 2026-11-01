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
using InnManager.Hotels;
using InnManager.Housekeeping;
using InnManager.Rooms;
using InnManager.Employees;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for HousekeepingEditControl.xaml
    /// </summary>
    public partial class HousekeepingEditControl : UserControl
    {
        public HousekeepingEditControl()
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
        public void SaveTaskClick(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                ((HousekeepingTask)this.DataContext).Room = (Room)(RoomNumberEditor.SelectedItem);
                ((HousekeepingTask)this.DataContext).Employee = (Employee)(AssignedStaffEditor.SelectedItem);
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (DescriptionEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Description cannot be empty.");
            }
            return valid;
        }
    }
}
