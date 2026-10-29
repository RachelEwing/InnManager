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
using InnManager.Rooms;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for RoomsControl.xaml
    /// </summary>
    public partial class RoomsControl : UserControl
    {
        public RoomsControl()
        {
            InitializeComponent();
            Edit.Close += OnBackClick;
        }
        /// <summary>
        /// Creates a new room form and reports whether or not the new room was created
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void NewRoomClick(object sender, RoutedEventArgs e)
        {
            NewRoomForm form = new NewRoomForm() { DataContext = this.DataContext };
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
            if (RoomDataGrid.SelectedItem is Room room)
            {
                Edit.DataContext = room;
                Main.Visibility = Visibility.Hidden;
                Edit.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("No room selected.");
            }
        }
        public void OnBackClick(object sender, EventArgs e)
        {
            Main.Visibility = Visibility.Visible;
            Edit.Visibility = Visibility.Hidden;
        }
    }
}
