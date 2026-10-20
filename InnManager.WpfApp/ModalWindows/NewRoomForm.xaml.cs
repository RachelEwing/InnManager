using InnManager.Rooms;
using InnManager.Hotels;
using InnManager.Enums;
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
    /// Interaction logic for NewRoomForm.xaml
    /// </summary>
    public partial class NewRoomForm : Window
    {
        public NewRoomForm()
        {
            InitializeComponent();
            StatusPicker.ItemsSource = Enum.GetValues(typeof(RoomStatus));
            StatusPicker.SelectedItem = RoomStatus.Available;
            RoomTypePicker.ItemsSource = Enum.GetValues(typeof(RoomType));
            RoomTypePicker.SelectedItem = RoomType.Standard;
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddRoomClick(object sender, RoutedEventArgs e)
        {
            Room room = new Room();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Rooms.Add(room);
            }
            if (Validation()) {
                DialogResult = true;
                this.Close();
            }
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        public bool Validation() {
            bool valid = true;
            if (RoomNumberText.Text == "") valid = false;
            if (!decimal.TryParse(RateText.Text, out decimal rate))
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
            if (!int.TryParse(FloorPicker.Text, out int floor))
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
            if (!int.TryParse(CapacityPicker.Text, out int capacity))
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
