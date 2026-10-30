using InnManager.Enums;
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

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for EmployeeEditControl.xaml
    /// </summary>
    public partial class EmployeeEditControl : UserControl
    {
        public EmployeeEditControl()
        {
            InitializeComponent();
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            Close?.Invoke(this, EventArgs.Empty);
        }
        public void SaveEmployeeClick(object sender, RoutedEventArgs e)
        {
            if (Validation()) {
            }
        }
        public bool Validation() {
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
            return valid;
        }
    }
}
