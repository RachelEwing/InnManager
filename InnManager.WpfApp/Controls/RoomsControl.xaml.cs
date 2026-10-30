using InnManager.Employees;
using InnManager.Enums;
using InnManager.Guests;
using InnManager.Hotels;
using InnManager.Rooms;
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
                Edit.RoomTypeEditor.ItemsSource = Enum.GetValues(typeof(RoomType));
                Edit.RoomTypeEditor.SelectedItem = room.RoomType;
                Edit.RoomStatusEditor.ItemsSource = Enum.GetValues(typeof(RoomStatus));
                Edit.RoomStatusEditor.SelectedItem = room.Status;
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
        public void DeleteClick(object sender, EventArgs e)
        {
            if (RoomDataGrid.SelectedItem == null)
            {
                MessageBox.Show("No room selected");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {((Room)(RoomDataGrid.SelectedItem)).RoomID}", "Delete Room?", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ((Hotel)this.DataContext).Rooms.Remove(((Room)(RoomDataGrid.SelectedItem)));
                }
            }
        }
    }
}
