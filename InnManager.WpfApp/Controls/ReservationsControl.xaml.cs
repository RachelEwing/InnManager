using InnManager.Employees;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Reservations;
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
    /// Interaction logic for ReservationsControl.xaml
    /// </summary>
    public partial class ReservationsControl : UserControl
    {
        public ReservationsControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates new reservation form and reports whether or not the reservation was created
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewReservationClick(object sender, RoutedEventArgs e)
        {
            NewReservationForm form = new NewReservationForm((Hotel)this.DataContext);
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
            if (ReservationDataGrid.SelectedItem is Reservation reservation)
            {
                Edit.DataContext = reservation;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No reservation selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
        public void DeleteClick(object sender, EventArgs e)
        {
            if (ReservationDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No reservation selected");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {((Reservation)(ReservationDataGrid.SelectedItem)).ReservationID}", "Delete Reservation?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ((Hotel)this.DataContext).Reservations.Remove(((Reservation)(ReservationDataGrid.SelectedItem)));
                }
            }
        }
    }
}
