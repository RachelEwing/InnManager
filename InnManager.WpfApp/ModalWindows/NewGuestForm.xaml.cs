using InnManager.Enums;
using InnManager.Guests;
using InnManager.Hotels;
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
    /// Interaction logic for NewGuestForm.xaml
    /// </summary>
    public partial class NewGuestForm : Window
    {
        /// <summary>
        /// Initializes and binds comboboxes.  Sets dates to today.
        /// </summary>
        public NewGuestForm()
        {
            InitializeComponent();
            IDTypePicker.ItemsSource = Enum.GetValues(typeof(IDType));
            IDTypePicker.SelectedItem = IDType.Other;
        }
        /// <summary>
        /// Converts data to a new guest or returns error
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">args</param>
        public void AddGuestClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Guest guest = new Guest() {FirstName = FirstNameText.Text, LastName = LastNameText.Text, PhoneNumber = PhoneText.Text, Email = EmailText.Text, Address = AddressText.Text, IDType = (IDType)IDTypePicker.SelectedItem, IDNumber = IDNumberText.Text};
                var data = this.DataContext;
                if (data is Hotel h)
                {
                    h.Guests.Add(guest);
                }
                DialogResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// Cancels and closes form
        /// </summary>
        /// <param name="sender">cancel button</param>
        /// <param name="e">args</param>
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        /// <summary>
        /// Validates form data
        /// </summary>
        /// <returns>Whether or not data is valid</returns>
        public bool Validation()
        {
            bool valid = true;
            if (FirstNameText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("First Name cannot be empty.");
            }
            if (LastNameText.Text.Length < 2)
            {
                valid = false;
                MessageBox.Show("Last Name cannot that short.");
            }
            if (EmailText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Email cannot be empty.");
            }
            if (PhoneText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Phone cannot be empty.");
            }
            if (AddressText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Address cannot be empty.");
            }
            if (IDNumberText.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("ID Number cannot be empty.");
            }
            return valid;
        }
    }
}
