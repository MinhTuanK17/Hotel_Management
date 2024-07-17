using BusinessObject;
using Repositories.BookingDetailR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelManagement.Customers
{
    /// <summary>
    /// Interaction logic for ViewDetailBooking.xaml
    /// </summary>
    public partial class ViewDetailBooking : Window
    {
        private readonly IBookingDetailRepository bookingDetailRepository;
        public ViewDetailBooking()
        {
            InitializeComponent();
            bookingDetailRepository = new BookingDetailRepository();
        }
        public void LoadBooking (BookingDetail bookingDetail)
        {
            txtBookingId.Text = bookingDetail.BookingReservationID;
            txtBookingDate.Text = bookingDetail.BookingReservation.BookingDate.ToString();
            txtStartDate.Text = bookingDetail.StartDate.ToString();
            txtEndDate.Text = bookingDetail.EndDate.ToString();
            txtRoomID.Text = bookingDetail.RoomID;
            txtRoomNumber.Text = bookingDetail.RoomInformation.RoomNumber.ToString();
            txtStatus.Text = bookingDetail.BookingReservation.BookingStatus;
            txtPrice.Text = bookingDetail.ActualPrice.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
