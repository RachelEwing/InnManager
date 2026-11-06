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
using InnManager.Hotels;

namespace InnManager.WpfApp.Controls.Settings
{
    /// <summary>
    /// Interaction logic for AccountControl.xaml
    /// </summary>
    public partial class AccountControl : UserControl
    {
        public AccountControl()
        {
            InitializeComponent();
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            Hotel h = (Hotel)this.DataContext;
            DisplayNameText.Text = h.Account.DisplayName;
            EmailText.Text = h.Account.Email;
            PhoneNumberText.Text = h.Account.PhoneNumber;
            PositionText.Text = h.Account.Position;
            DepartmentText.Text = h.Account.Department;
        }
        public void SaveClick(object sender, RoutedEventArgs e) {
            Hotel h = (Hotel)this.DataContext;
            h.Account.DisplayName = DisplayNameText.Text;
            h.Account.Email = EmailText.Text;
            h.Account.PhoneNumber = PhoneNumberText.Text;
            h.Account.Position = PositionText.Text;
            h.Account.Department = DepartmentText.Text;
        }
    }
}
