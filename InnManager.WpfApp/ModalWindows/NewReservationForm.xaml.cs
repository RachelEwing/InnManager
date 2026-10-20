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
            if (this.DataContext is Hotel)
            {
                MessageBox.Show("Is a hotel?");
            }
            if (this.DataContext == null)
            {
                MessageBox.Show("Null?");
            }

        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddReservationClick(object sender, RoutedEventArgs e)
        {
            Reservation reservation = new Reservation();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Reservations.Add(reservation);
            }
            DialogResult = true;
            this.Close();
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
            return valid;
        }
    }
}
