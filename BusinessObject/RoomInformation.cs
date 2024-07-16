using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class RoomInformation
    {
        [Key]
        public required string RoomID { get; set; }
        public required int RoomNumber { get; set; }
        public string? RoomDetailDescription { get; set; }
        public required int RoomMaxCapacity { get; set; }
        public required decimal RoomPricePerDay { get; set; }
        public required string RoomStatus { get; set; }
        public int? RoomTypeID { get; set; }
        public virtual RoomType? RoomType { get; set; }

        public virtual ICollection<BookingDetail> BookingDetail { get; set; }

    }
}