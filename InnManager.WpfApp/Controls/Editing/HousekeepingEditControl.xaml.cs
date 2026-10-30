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
using InnManager.Housekeeping;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for HousekeepingEditControl.xaml
    /// </summary>
    public partial class HousekeepingEditControl : UserControl
    {
        public HousekeepingEditControl()
        {
            InitializeComponent();
        }

        public DependencyProperty HotelProperty = DependencyProperty.Register(nameof(Hotel), typeof(Hotel), typeof(HousekeepingEditControl));

        public Hotel HotelData {
            get => (Hotel)GetValue(HotelProperty);
            set => SetValue(HotelProperty, value);
        }

        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            Close?.Invoke(this, EventArgs.Empty);
        }
        public void SaveTaskClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
