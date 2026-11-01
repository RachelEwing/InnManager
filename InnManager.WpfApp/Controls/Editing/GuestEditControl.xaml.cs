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
using InnManager.Enums;
using InnManager.Guests;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for GuestEditControl.xaml
    /// </summary>
    public partial class GuestEditControl : UserControl
    {
        public GuestEditControl()
        {
            InitializeComponent();
            IDTypeEditor.ItemsSource = Enum.GetValues(typeof(IDType));
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public void SaveGuestClick(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                ((Guest)this.DataContext).IDType = (IDType)IDTypeEditor.SelectedItem;
                Close?.Invoke(this, EventArgs.Empty);
            }
        }
        public bool Validation()
        {
            bool valid = true;
            if (FirstNameEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("First Name cannot be empty.");
            }
            if (LastNameEditor.Text.Length < 2)
            {
                valid = false;
                MessageBox.Show("Last Name cannot be that short.");
            }
            if (EmailEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Email cannot be empty.");
            }
            if (PhoneEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Phone Number cannot be empty.");
            }
            if (AddressEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("Address cannot be empty.");
            }
            if (IDNumberEditor.Text.Length < 1)
            {
                valid = false;
                MessageBox.Show("ID Number cannot be empty.");
            }
            return valid;
        }
    }
}
