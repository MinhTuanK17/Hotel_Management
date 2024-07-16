using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class BookingReservation
    {
        [Key]
        public required string BookingReservationID { get; set; }
        public required DateTime BookingDate { get; set; }
        public required decimal TotalPrice { get; set; }
        public required string BookingStatus { get; set; }
        public int? CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual ICollection<BookingDetail> BookingDetail { get; set; }

    }
}
