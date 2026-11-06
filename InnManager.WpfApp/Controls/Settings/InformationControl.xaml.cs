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

namespace InnManager.WpfApp.Controls.Settings
{
    /// <summary>
    /// Interaction logic for InformationControl.xaml
    /// </summary>
    public partial class InformationControl : UserControl
    {
        public InformationControl()
        {
            InitializeComponent();
            HotelTypePicker.ItemsSource = Enum.GetValues(typeof(HotelType));
        }
        public void CancelClick(object sender, RoutedEventArgs e)
        {
            Hotel h = (Hotel)this.DataContext;
            HotelNameText.Text = h.Name;
            HotelTypePicker.SelectedItem = h.Type;
            AddressText.Text = h.Address;
            CityText.Text = h.City;
            StateProvinceText.Text = h.StateProvince;
            PostalCodeText.Text = h.PostalCode;
            PhoneNumberText.Text = h.PhoneNumber;
            EmailText.Text = h.EmailAddress;
            WebsiteText.Text = h.Website;
            DescriptionText.Text = h.Description;
        }
        public void SaveClick(object sender, RoutedEventArgs e)
        {
            Hotel h = (Hotel)this.DataContext;
            h.Name = HotelNameText.Text;
            h.Type = (HotelType)HotelTypePicker.SelectedItem;
            h.Address = AddressText.Text;
            h.City = CityText.Text;
            h.StateProvince = StateProvinceText.Text;
            h.PostalCode = PostalCodeText.Text;
            h.PhoneNumber = PhoneNumberText.Text;
            h.EmailAddress = EmailText.Text;
            h.Website = WebsiteText.Text;
            h.Description = DescriptionText.Text;
        }
    }
}
