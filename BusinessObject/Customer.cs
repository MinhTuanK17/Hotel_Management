using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CustomerFullName { get; set; }
        public string? Telephone { get; set; }
        public required string EmailAddress { get; set; }
        public DateOnly? CustomerBirthday { get; set; }
        public string? CustomerStatus { get; set; }
        public required string Password { get; set; }
        public virtual ICollection<BookingReservation>? BookingReservations { get; set; }
    }
}
