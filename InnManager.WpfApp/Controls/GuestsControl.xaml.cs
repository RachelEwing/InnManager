using InnManager.Employees;
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
using InnManager.Guests;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for GuestsControl.xaml
    /// </summary>
    public partial class GuestsControl : UserControl
    {
        public GuestsControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates a new guest form and reports if a new gust was added
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewGuestClick(object sender, RoutedEventArgs e)
        {
            NewGuestForm form = new NewGuestForm() { DataContext = this.DataContext };
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
            if (GuestDataGrid.SelectedItem is Guest guest)
            {
                Edit.DataContext = guest;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No guest selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
    }
}
