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
            if (Validation()) {
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
        public bool Validation()
        {
            bool valid = true;
            if (HotelNameText.Text == "")
            {
                MessageBox.Show("Hotel Name Cannot be Empty");
                valid = false;
            }
            if (AddressText.Text == "")
            {
                MessageBox.Show("Address Cannot be Empty");
                valid = false;
            }
            if (CityText.Text == "")
            {
                MessageBox.Show("City Cannot be Empty");
                valid = false;
            }
            if (StateProvinceText.Text == "")
            {
                MessageBox.Show("State/Province Cannot be Empty");
                valid = false;
            }
            if (PostalCodeText.Text == "")
            {
                MessageBox.Show("Postal Code Cannot be Empty");
                valid = false;
            }
            if (EmailText.Text == "")
            {
                MessageBox.Show("Email Cannot be Empty");
                valid = false;
            }
            if (PhoneNumberText.Text == "")
            {
                MessageBox.Show("Phone Number Cannot be Empty");
                valid = false;
            }
            if (WebsiteText.Text == "")
            {
                MessageBox.Show("Website Cannot be Empty");
                valid = false;
            }
            if (DescriptionText.Text == "")
            {
                MessageBox.Show("Description Cannot be Empty");
                valid = false;
            }
            return valid;
        }
    }
}
