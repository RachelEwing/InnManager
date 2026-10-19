using InnManager.Hotels;
using InnManager.WpfApp.Controls;
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
using InnManager.Employees;

namespace InnManager.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hotel h = new Hotel();
            h.Employees.Add(new Employee());
            this.DataContext = h;
        }
        /// <summary>
        /// Displays Dashboard Panel when the Dashboard navigation is clicked
        /// </summary>
        /// <param name="sender">The Dashboard navigation button</param>
        /// <param name="e">Event args</param>
        public void DashboardNavClick(object sender, RoutedEventArgs e) {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new DashboardControl());
        }
        /// <summary>
        /// Displays Rooms Panel when the Rooms navigation is clicked
        /// </summary>
        /// <param name="sender">The Rooms navigation button</param>
        /// <param name="e">Event args</param>
        public void RoomsNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new RoomsControl());
        }
        /// <summary>
        /// Displays Reservations Panel when the Reservations navigation is clicked
        /// </summary>
        /// <param name="sender">The Reservations navigation button</param>
        /// <param name="e">Event args</param>
        public void ReservationNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new ReservationsControl());
        }
        /// <summary>
        /// Displays Guests Panel when the Guests navigation is clicked
        /// </summary>
        /// <param name="sender">The Guests navigation button</param>
        /// <param name="e">Event args</param>
        public void GuestsNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new GuestsControl());
        }
        /// <summary>
        /// Displays Services Panel when the Services navigation is clicked
        /// </summary>
        /// <param name="sender">The Services navigation button</param>
        /// <param name="e">Event args</param>
        public void ServicesNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new ServicesControl());
        }
        /// <summary>
        /// Displays Invoices Panel when the Invoices navigation is clicked
        /// </summary>
        /// <param name="sender">The Invoices navigation button</param>
        /// <param name="e">Event args</param>
        public void InvoicesNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new InvoicesControl());
        }
        /// <summary>
        /// Displays Payments Panel when the Payments navigation is clicked
        /// </summary>
        /// <param name="sender">The Payments navigation button</param>
        /// <param name="e">Event args</param>
        public void PaymentsNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new PaymentsControl());
        }
        /// <summary>
        /// Displays Employees Panel when the Employees navigation is clicked
        /// </summary>
        /// <param name="sender">The Employees navigation button</param>
        /// <param name="e">Event args</param>
        public void EmployeesNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new EmployeesControl());
        }
        /// <summary>
        /// Displays Housekeeping Panel when the Housekeeping navigation is clicked
        /// </summary>
        /// <param name="sender">The Housekeeping navigation button</param>
        /// <param name="e">Event args</param>
        public void HousekeepingNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new HousekeepingControl());
        }
        /// <summary>
        /// Displays Reports Panel when the Reports navigation is clicked
        /// </summary>
        /// <param name="sender">The Reports navigation button</param>
        /// <param name="e">Event args</param>
        public void ReportsNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new ReportsControl());
        }
        /// <summary>
        /// Displays Settings Panel when the Settings navigation is clicked
        /// </summary>
        /// <param name="sender">The Settings navigation button</param>
        /// <param name="e">Event args</param>
        public void SettingsNavClick(object sender, RoutedEventArgs e)
        {
            DisplayGrid.Children.Clear();
            DisplayGrid.Children.Add(new SettingsControl());
        }
    }
}