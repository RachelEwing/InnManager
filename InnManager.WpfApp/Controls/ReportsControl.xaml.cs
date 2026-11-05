using InnManager.Hotels;
using InnManager.WpfApp.Controls.Reports;
using InnManager.WpfApp.ViewModels;
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
    /// Interaction logic for ReportsControl.xaml
    /// </summary>
    public partial class ReportsControl : UserControl
    {
        public ReportsControl(Hotel h)
        {
            InitializeComponent();
            this.DataContext = new HotelReportViewModel(h);
        }
        public void OccupancyClick(object sender, RoutedEventArgs e) {
            Occupancy.Visibility = Visibility.Visible;
            Revenue.Visibility = Visibility.Hidden;
            Guest.Visibility = Visibility.Hidden;
            Housekeeping.Visibility = Visibility.Hidden;
            Reservation.Visibility = Visibility.Hidden;
            Employee.Visibility = Visibility.Hidden;
        }
        public void RevenueClick(object sender, RoutedEventArgs e)
        {
            Occupancy.Visibility = Visibility.Hidden;
            Revenue.Visibility = Visibility.Visible;
            Guest.Visibility = Visibility.Hidden;
            Housekeeping.Visibility = Visibility.Hidden;
            Reservation.Visibility = Visibility.Hidden;
            Employee.Visibility = Visibility.Hidden;
        }
        public void GuestClick(object sender, RoutedEventArgs e)
        {
            Occupancy.Visibility = Visibility.Hidden;
            Revenue.Visibility = Visibility.Hidden;
            Guest.Visibility = Visibility.Visible;
            Housekeeping.Visibility = Visibility.Hidden;
            Reservation.Visibility = Visibility.Hidden;
            Employee.Visibility = Visibility.Hidden;
        }
        public void HousekeepingClick(object sender, RoutedEventArgs e)
        {
            Occupancy.Visibility = Visibility.Hidden;
            Revenue.Visibility = Visibility.Hidden;
            Guest.Visibility = Visibility.Hidden;
            Housekeeping.Visibility = Visibility.Visible;
            Reservation.Visibility = Visibility.Hidden;
            Employee.Visibility = Visibility.Hidden;
        }
        public void ReservationClick(object sender, RoutedEventArgs e)
        {
            Occupancy.Visibility = Visibility.Hidden;
            Revenue.Visibility = Visibility.Hidden;
            Guest.Visibility = Visibility.Hidden;
            Housekeeping.Visibility = Visibility.Hidden;
            Reservation.Visibility = Visibility.Visible;
            Employee.Visibility = Visibility.Hidden;
        }
        public void EmployeeClick(object sender, RoutedEventArgs e)
        {
            Occupancy.Visibility = Visibility.Hidden;
            Revenue.Visibility = Visibility.Hidden;
            Guest.Visibility = Visibility.Hidden;
            Housekeeping.Visibility = Visibility.Hidden;
            Reservation.Visibility = Visibility.Hidden;
            Employee.Visibility = Visibility.Visible;
        }
    }
}
