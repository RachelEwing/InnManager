using InnManager.Enums;
using InnManager.Rooms;
using System.ComponentModel;
using System.Net.NetworkInformation;

namespace InnManager.Services
{
    /// <summary>
    /// Class to keep track of hotel services
    /// </summary>
    public class Service : INotifyPropertyChanged
    {
        /// <summary>
        /// Backing field for service name
        /// </summary>
        private string _serviceName = "";
        /// <summary>
        /// name of service property
        /// </summary>
        public string ServiceName { get => _serviceName; set
            {
                _serviceName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ServiceName)));
            }
        }
        /// <summary>
        /// The backing field for description
        /// </summary>
        private string _description = "";
        /// <summary>
        /// description property
        /// </summary>
        public string Description { get => _description; set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        /// <summary>
        /// Backing field for price
        /// </summary>
        private decimal _price = 0;
        /// <summary>
        /// price property
        /// </summary>
        public decimal Price { get => _price; set
            {
                _price = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }
        }
        /// <summary>
        /// Is Available backing field
        /// </summary>
        private bool _isAvailable = true;
        /// <summary>
        /// availability property
        /// </summary>
        public bool IsAvailable { get => _isAvailable; set
            {
                _isAvailable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAvailable)));
            }
        }
        /// <summary>
        /// backing field for Category
        /// </summary>
        private ServiceCategory _category = ServiceCategory.Miscellaneous;
        /// <summary>
        /// service category property
        /// </summary>
        public ServiceCategory Category
        {
            get => _category; set
            {
                _category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
            }
        }
        /// <summary>
        /// Handles changes in properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}