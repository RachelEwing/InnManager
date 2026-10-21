using InnManager.Employees;
using InnManager.Enums;
using InnManager.Hotels;
using InnManager.Reservations;
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
using InnManager.Guests;
using InnManager.Rooms;

namespace InnManager.WpfApp.ModalWindows
{
    /// <summary>
    /// Interaction logic for NewReservationForm.xaml
    /// </summary>
    public partial class NewReservationForm : Window
    {
        public NewReservationForm(Hotel hotel)
        {
            DataContext = hotel;
            InitializeComponent();
            CheckInDatePicker.SelectedDate = DateTime.Today;
            CheckOutDatePicker.SelectedDate = DateTime.Today;
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddReservationClick(object sender, RoutedEventArgs e)
        {

            if (Validation()) {
                Guest guest = (Guest)GuestPicker.SelectedItem;
                Room room = (Room)RoomPicker.SelectedItem;
                bool a = !int.TryParse(NumberOfGuestsText.Text, out int capacity);
                Reservation reservation = new Reservation() { FirstName = guest.FirstName, LastName = guest.LastName, RoomNumber = room.RoomNumber, CheckInDate = (DateTime)CheckInDatePicker.SelectedDate, CheckOutDate = (DateTime)CheckOutDatePicker.SelectedDate, Status = StatusPicker.SelectedItem.ToString(), NumberOfGuests = capacity, IDNumber = guest.IDNumber};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Reservations.Add(reservation);
                }
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
            if (!int.TryParse(NumberOfGuestsText.Text, out int capacity))
            {
                MessageBox.Show(
                  "Number of Guests must be a valid whole number.",
                  "Invalid number of guests",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }

            if (capacity < 1)
            {
                MessageBox.Show(
                  "Number of guests must be at least 1.",
                  "Invalid number of guests",
                  MessageBoxButton.OK,
                  MessageBoxImage.Warning);

                valid = false;
            }
            if (RoomPicker.SelectedItem is Room r)
            {
                if (r.Capacity < capacity) { valid = false; MessageBox.Show("The selected room cannot hold that many people."); }
            }
            else {
                valid = false;
            }
            try
            {
                if (CheckInDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot retroactively check in.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A check in date must be set.");
            }
            try
            {
                if (CheckOutDatePicker?.SelectedDate < DateTime.Today)
                {
                    valid = false;
                    MessageBox.Show("You cannot retroactively set a check out date.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A check out date must be set.");
            }
            if ((GuestPicker.SelectedItem as Guest) == null) valid = false;
            if ((RoomPicker.SelectedItem as Room) == null) valid = false;
            return valid;
        }
    }
}
