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
using InnManager.Rooms;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for RoomEditControl.xaml
    /// </summary>
    public partial class RoomEditControl : UserControl
    {
        public RoomEditControl()
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
        public void SaveRoomClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                ((Room)this.DataContext).RoomType = (RoomType)RoomTypeEditor.SelectedItem;
                ((Room)this.DataContext).Status = (RoomStatus)RoomStatusEditor.SelectedItem;
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (RoomNumberEditor.Text == "") valid = false;
            if (!decimal.TryParse(RateEditor.Text, out decimal rate))
            {
                MessageBox.Show(
                  "Rate must be a valid whole number.",
                  "Invalid Rate",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (rate < 1)
            {
                MessageBox.Show(
                  "Rate must be at least 1.",
                  "Invalid Rate",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            if (!int.TryParse(FloorEditor.Text, out int floor))
            {
                MessageBox.Show(
                  "Floor must be a valid whole number.",
                  "Invalid Floor",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (floor < 1)
            {
                MessageBox.Show(
                  "Floor must be at least 1.",
                  "Invalid Floor Number",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            if (!int.TryParse(CapacityEditor.Text, out int capacity))
            {
                MessageBox.Show(
                  "Capacity must be a valid whole number.",
                  "Invalid Capacity",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (capacity < 1)
            {
                MessageBox.Show(
                  "Capacity must be at least 1.",
                  "Invalid Capacity",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            return valid;
        }
    }
}
