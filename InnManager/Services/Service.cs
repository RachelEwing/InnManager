using InnManager.Enums;
using InnManager.Rooms;
using System.ComponentModel;

namespace InnManager.Services
{
    /// <summary>
    /// Class to keep track of hotel services
    /// </summary>
    public class Service : INotifyPropertyChanged
    {
        /// <summary>
        /// name of service property
        /// </summary>
        public string ServiceName { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ServiceName)));
            }
        } = "";
        /// <summary>
        /// description property
        /// </summary>
        public string Description { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        } = "";
        /// <summary>
        /// price property
        /// </summary>
        public decimal Price { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
            }
        } = 0;
        /// <summary>
        /// availability property
        /// </summary>
        public bool IsAvailable { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAvailable)));
            }
        } = true;
        /// <summary>
        /// service category property
        /// </summary>
        public ServiceCategory Category { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Category)));
            }
        } = ServiceCategory.Miscellaneous;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}