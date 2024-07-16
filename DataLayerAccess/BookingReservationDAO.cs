using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class BookingReservationDAO : SingletonBase<BookingReservationDAO>
    {
        private HotelDbContext? _context;

        public async Task<BookingReservation> GetBookingReservationById(string bookId)
        {
            try
            {
                _context = new();
                var book = await _context.BookingReservations.FirstOrDefaultAsync(b => b.BookingReservationID.Equals(bookId));
                return book!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<BookingReservation>> GetAllBookingReservation()
        {
            _context = new();
            return await _context.BookingReservations.AsNoTracking().Include(b => b.Customer).ToListAsync();
        }

        public async Task AddBookingReservation(BookingReservation book)
        {
            _context = new();
            _context.BookingReservations.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingReservation(BookingReservation book)
        {
            try
            {
                _context = new();
                var findBook = await GetBookingReservationById(book.BookingReservationID);
                if (findBook != null)
                {
                    _context.Entry(findBook).CurrentValues.SetValues(book);
                }
                else
                {
                    _context.BookingReservations.Update(book);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteBookingReservation(BookingReservation book)
        {
            try
            {
                _context = new();
                var findBook = await GetBookingReservationById(book.BookingReservationID);
                if (findBook != null)
                {
                    _context.BookingReservations.Remove(findBook);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
