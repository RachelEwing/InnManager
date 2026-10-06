using System;
using System.Collections.Generic;
using System.Text;

namespace InnManager.Enums
{
    /// <summary>
    /// An enumeration of products and services at the hotel that are added to the guest's invoice
    /// </summary>
    public enum ChargeCategory
    {
        Room,
        Dining,
        RoomService,
        Laundry,
        Transportation,
        Spa,
        Recreation,
        Business,
        Parking,
        Miscellaneous
    }
}