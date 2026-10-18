using System.ComponentModel;

namespace InnManager.Housekeeping
{
    /// <summary>
    /// A class for keeping track of housekeeping tasks
    /// </summary>
    public class HousekeepingTask : INotifyPropertyChanged
    {
        public string RoomNumber { get; set
            {
                RoomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        } = "";
        /// <summary>
        /// description of task property
        /// </summary>
        public string Description { get; set
            {
                Description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        } = "";
        /// <summary>
        /// scheduled date for task property
        /// </summary>
        public DateTime ScheduledDate { get; set
            {
                ScheduledDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScheduledDate)));
            }
        } = DateTime.Today;
        /// <summary>
        /// is completed boolean property
        /// </summary>
        public bool IsCompleted { get; set
            {
                IsCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        } = false;
        public string AssignedStaff { get; set
            {
                AssignedStaff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AssignedStaff)));
            }
        } = "";
        /// <summary>
        /// status property
        /// </summary>
        public string Status
        {
            get
            {
                if (IsCompleted)
                {
                    return "Complete";
                }
                else
                {
                    return "Not Completed";
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}