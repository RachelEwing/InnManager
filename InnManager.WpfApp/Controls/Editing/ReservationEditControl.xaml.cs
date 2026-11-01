using InnManager.Guests;
using InnManager.Rooms;
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
using InnManager.Reservations;
using InnManager.Rooms;
using InnManager.Guests;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for ReservationEditControl.xaml
    /// </summary>
    public partial class ReservationEditControl : UserControl
    {
        public ReservationEditControl()
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
        public void SaveReservationClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                ((Reservation)this.DataContext).Room = (Room)RoomEditor.SelectedItem;
                ((Reservation)this.DataContext).Guest = (Guest)GuestNameEditor.SelectedItem;
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (!int.TryParse(NumberOfGuestsEditor.Text, out int capacity))
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
            if (RoomEditor.SelectedItem is Room r)
            {
                if (r.Capacity < capacity) { valid = false; MessageBox.Show("The selected room cannot hold that many people."); }
            }
            else
            {
                valid = false;
            }
            try
            {
                if (CheckOutEditor?.SelectedDate < CheckInEditor?.SelectedDate)
                {
                    valid = false;
                    MessageBox.Show("You must check in before you can check out.");
                }
            }
            catch
            {
                valid = false;
                MessageBox.Show("A check out date must be set.");
            }
            return valid;
        }
    }
}
