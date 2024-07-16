using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.BookingDetailR
{
    public interface IBookingDetailRepository
    {
        Task<BookingDetail> GetBookingDetailById(string bookId, string roomId);
        Task<IEnumerable<BookingDetail>> GetBookingDetailByBookId(string bookId);
        Task<List<BookingDetail>> GetAllBookingDetail();
        Task AddBookingDetail(BookingDetail bookDetail);
        Task UpdateBookingDetail(BookingDetail bookDetail);
        Task DeleteBookingDetail(BookingDetail bookDetail);

    }
}
