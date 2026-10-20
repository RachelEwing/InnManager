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
    /// Interaction logic for HousekeepingControl.xaml
    /// </summary>
    public partial class HousekeepingControl : UserControl
    {
        public HousekeepingControl()
        {
            InitializeComponent();
        }
        public void NewTaskClick(object sender, RoutedEventArgs e)
        {
            NewHousekeepingTaskForm form = new NewHousekeepingTaskForm() { DataContext = this.DataContext };
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
    }
}
