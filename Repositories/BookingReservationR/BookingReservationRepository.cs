using BusinessObject;
using DataLayerAccess;

namespace Repositories.BookingReservationR
{
    public class BookingReservationRepository : IBookingReservationRepository
    {
        public async Task AddBookingReservation(BookingReservation book) => await BookingReservationDAO.Instance.AddBookingReservation(book);

        public async Task DeleteBookingReservation(BookingReservation book) => await BookingReservationDAO.Instance.DeleteBookingReservation(book);
        public async Task<List<BookingReservation>> GetAllBookingReservation() => await BookingReservationDAO.Instance.GetAllBookingReservation();

        public async Task<BookingReservation> GetBookingReservationById(string bookId) => await BookingReservationDAO.Instance.GetBookingReservationById(bookId);

        public async Task UpdateBookingReservation(BookingReservation book) => await BookingReservationDAO.Instance.UpdateBookingReservation(book);
    }
}
