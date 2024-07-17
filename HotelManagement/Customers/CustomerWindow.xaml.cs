using BusinessObject;
using HotelManagement.Admins;
using Repositories.BookingDetailR;
using Repositories.BookingReservationR;
using Repositories.CustomerR;
using System.Windows;

namespace HotelManagement.Customers
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        public Customer LoggedInUser { get; set; }
        private readonly ICustomerRepository customerRepository;
        private readonly IBookingDetailRepository bookingDetailRepository;
        public CustomerWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            bookingDetailRepository = new BookingDetailRepository();
            DataContext = this;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DisplayCustomerInfo();
            LoadBookingHistory();
        }
        private void DisplayCustomerInfo()
        {
            if (LoggedInUser != null)
            {
                txtFullName.Text = LoggedInUser.CustomerFullName;
                txtEmail.Text = LoggedInUser.EmailAddress;
                txtPhone.Text = LoggedInUser.Telephone;
                txtBirthday.Text = LoggedInUser.CustomerBirthday.ToString();
                txtPassword.Text = LoggedInUser.Password;
            }
        }
        private async void LoadBookingHistory()
        {
            try
            {
                var bookingHis = await bookingDetailRepository.GetAllBookingDetail();
                dtgBookDetails.ItemsSource = bookingHis;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of booking history");
            }
        }

        private void Update_Profile_Click(object sender, RoutedEventArgs e)
        {
            UpdateProfile updateProfileWindow = new UpdateProfile();
            updateProfileWindow.LoggedInUser = LoggedInUser;
            updateProfileWindow.Closed += (s, args) => DisplayCustomerInfo();
            updateProfileWindow.ShowDialog();
        }
        private void Detail_Click(object sender, RoutedEventArgs e)
        {
            BookingDetail? selectBook = (sender as FrameworkElement)?.DataContext as BookingDetail;

            if (selectBook != null)
            {
                ViewDetailBooking viewDetailBooking = new ViewDetailBooking();
                viewDetailBooking.LoadBooking(selectBook);
                viewDetailBooking.Show();
            }
        }

    }
}
