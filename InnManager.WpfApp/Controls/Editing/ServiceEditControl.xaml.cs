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
using InnManager.Services;

namespace InnManager.WpfApp.Controls.Editing
{
    /// <summary>
    /// Interaction logic for ServiceEditControl.xaml
    /// </summary>
    public partial class ServiceEditControl : UserControl
    {
        public ServiceEditControl()
        {
            InitializeComponent();
        }
        public event EventHandler Close;
        public void BackClick(object sender, RoutedEventArgs e)
        {
            Close?.Invoke(this, EventArgs.Empty);
        }
        public void SaveServiceClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
