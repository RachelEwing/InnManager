using InnManager.Services;
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
    /// Interaction logic for NewServiceForm.xaml
    /// </summary>
    public partial class NewServiceForm : Window
    {
        public NewServiceForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Converts data to a new employee or returns error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddServiceClick(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            var data = this.DataContext;
            if (data is Hotel h)
            {
                h.Services.Add(service);
            }
            DialogResult = true;
            this.Close();
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
    }
}
