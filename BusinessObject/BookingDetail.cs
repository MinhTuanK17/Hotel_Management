using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    [PrimaryKey(nameof(BookingReservationID), nameof(RoomID))]
    public class BookingDetail
    {
        public string BookingReservationID { get; set; }
        public string RoomID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal ActualPrice { get; set; }
        public virtual BookingReservation BookingReservation { get; set; }
        public virtual RoomInformation RoomInformation { get; set; }
    }
}
