using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingDetailR
{
    public class BookingDetailRepository : IBookingDetailRepository
    {
        public async Task AddBookingDetail(BookingDetail bookDetail) => await BookingDetailDAO.Instance.AddBookingDetail(bookDetail);

        public async Task DeleteBookingDetail(BookingDetail bookDetail) => await BookingDetailDAO.Instance.DeleteBookingDetail(bookDetail);

        public async Task<List<BookingDetail>> GetAllBookingDetail() => await BookingDetailDAO.Instance.GetAllBookingDetail();

        public async Task<IEnumerable<BookingDetail>> GetBookingDetailByBookId(string bookId) => await BookingDetailDAO.Instance.GetBookingDetailByBookId(bookId);

        public async Task<BookingDetail> GetBookingDetailById(string bookId, string roomId) => await BookingDetailDAO.Instance.GetBookingDetailById(bookId, roomId);
        public async Task UpdateBookingDetail(BookingDetail bookDetail) => await BookingDetailDAO.Instance.UpdateBookingDetail(bookDetail);
    }
}
