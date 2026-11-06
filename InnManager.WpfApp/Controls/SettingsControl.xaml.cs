using InnManager.Enums;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InnManager.WpfApp.Controls
{
    /// <summary>
    /// Interaction logic for SettingsControl.xaml
    /// </summary>
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            InitializeComponent();
        }
        public void InfoClick(object sender, RoutedEventArgs e) {
            Info.Visibility = Visibility.Visible;
            RB.Visibility = Visibility.Hidden;
            Account.Visibility = Visibility.Hidden;
        }
        public void RBClick(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            RB.Visibility = Visibility.Visible;
            Account.Visibility = Visibility.Hidden;
            RB.CheckInPicker.SelectedItem = ((Hotel)this.DataContext).CheckInTime;
            RB.CheckOutPicker.SelectedItem = ((Hotel)this.DataContext).CheckOutTime;
        }
        public void AccountClick(object sender, RoutedEventArgs e)
        {
            Info.Visibility = Visibility.Hidden;
            RB.Visibility = Visibility.Hidden;
            Account.Visibility = Visibility.Visible;
        }
    }
}
