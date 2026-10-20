using InnManager.Employees;
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
        public NewReservationForm()
        {
            InitializeComponent();
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
    }
}
