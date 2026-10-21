using System.ComponentModel;

namespace InnManager.Housekeeping
{
    /// <summary>
    /// A class for keeping track of housekeeping tasks
    /// </summary>
    public class HousekeepingTask : INotifyPropertyChanged
    {
        /// <summary>
        /// RoomNumber of room the task is associated with
        /// </summary>
        public string RoomNumber { get; set;
        } = "";
        /// <summary>
        /// description of task property
        /// </summary>
        public string Description { get; set;
        } = "";
        /// <summary>
        /// scheduled date for task property
        /// </summary>
        public DateTime ScheduledDate { get; set;
        } = DateTime.Today;
        /// <summary>
        /// is completed boolean property
        /// </summary>
        public bool IsCompleted { get; set;
        } = false;
        public string AssignedStaff { get; set;
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
        /// <summary>
        /// Handles changes in properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}