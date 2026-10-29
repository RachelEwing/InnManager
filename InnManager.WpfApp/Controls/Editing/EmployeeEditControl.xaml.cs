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
            PositionEditor.ItemsSource = Enum.GetValues(typeof(EmployeePosition));
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            Close?.Invoke(this, EventArgs.Empty);
        }
        public void SaveEmployeeClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
