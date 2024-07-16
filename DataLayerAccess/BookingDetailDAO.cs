using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class BookingDetailDAO : SingletonBase<BookingDetailDAO>
    {
        private HotelDbContext? _context;

        public async Task<BookingDetail> GetBookingDetailById(string bookId, string roomId)
        {
            try
            {
                _context = new();
                var book = await _context.BookingDetails.FirstOrDefaultAsync(b => b.BookingReservationID.Equals(bookId) && b.RoomID.Equals(roomId));
                return book!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailByBookId(string bookId)
        {
            try
            {
                _context = new();
                var book = await _context.BookingDetails.Where(b => b.BookingReservationID == bookId).ToListAsync();
                return book!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<List<BookingDetail>> GetAllBookingDetail()
        {
            _context = new();
            return await _context.BookingDetails.AsNoTracking().Include(b => b.RoomInformation).Include(b => b.BookingReservation).Include(b => b.BookingReservation.Customer).ToListAsync();
        }

        public async Task AddBookingDetail(BookingDetail bookDetail)
        {
            _context = new();
            _context.BookingDetails.Add(bookDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingDetail(BookingDetail bookDetail)
        {
            try
            {
                _context = new();
                var findBookDetail = await GetBookingDetailById(bookDetail.BookingReservationID, bookDetail.RoomID);
                if (findBookDetail != null)
                {
                    _context.Entry(findBookDetail).CurrentValues.SetValues(bookDetail);
                }
                else
                {
                    _context.BookingDetails.Update(bookDetail);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteBookingDetail(BookingDetail bookDetail)
        {
            try
            {
                _context = new();
                var findBookDetail = await GetBookingDetailById(bookDetail.BookingReservationID, bookDetail.RoomID);
                if (findBookDetail != null)
                {
                    _context.BookingDetails.Remove(findBookDetail);
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
