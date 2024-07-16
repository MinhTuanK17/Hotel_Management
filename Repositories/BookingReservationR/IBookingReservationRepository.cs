using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingReservationR
{
    public interface IBookingReservationRepository
    {
        Task<BookingReservation> GetBookingReservationById(string bookId);
        Task<List<BookingReservation>> GetAllBookingReservation();
        Task AddBookingReservation(BookingReservation book);
        Task UpdateBookingReservation(BookingReservation book);
        Task DeleteBookingReservation(BookingReservation book);
    }
}
