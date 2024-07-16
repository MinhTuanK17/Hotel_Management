using BusinessObject;
using Repositories.BookingDetailR;
using Repositories.CustomerR;
using Repositories.RoomInfoR;
using Repositories.RoomTypeR;
using System.Windows;
using System.Windows.Input;

namespace HotelManagement.Admins
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IRoomInformationRepository roomInformationRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IBookingDetailRepository bookingDetailRepository;
        public AdminWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            roomInformationRepository = new RoomInformationRepository();
            roomTypeRepository = new RoomTypeRepository();
            bookingDetailRepository = new BookingDetailRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomers();
            LoadRoomList();
            LoadRoomTypeList();
            LoadBookingList();
        }

        public async void LoadCustomers()
        {
            try
            {
                var customerList = await customerRepository.GetAllCustomer();
                dtgCustomers.ItemsSource = customerList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of customers");
            }
        }
        public async void LoadRoomList()
        {
            try
            {
                var roomList = await roomInformationRepository.GetAllRoomInformation();
                dtgRooms.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of rooms");
            }
        }

        public async void LoadRoomTypeList()
        {
            try
            {
                var roomTypeList = await roomTypeRepository.GetAllRoomType();
                dtgRoomTypes.ItemsSource = roomTypeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of roomtypes");
            }
        }

        public async void LoadBookingList()
        {
            try
            {
                var bookingList = await bookingDetailRepository.GetAllBookingDetail();
                dtgBookings.ItemsSource = bookingList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of bookings");
            }
        }
        // Management Customer
        private void Add_Click_Customer(object sender, MouseButtonEventArgs e)
        {
            AddNewCustomer addNewCustomer = new AddNewCustomer();
            addNewCustomer.Closed += (s, args) => LoadCustomers();
            addNewCustomer.Show();
        }
        private void Edit_Click_Customer(object sender, RoutedEventArgs e)
        {
            Customer selectedCustomer = (sender as FrameworkElement)?.DataContext as Customer;

            if (selectedCustomer != null)
            {
                EditCustomer editCustomer = new EditCustomer();
                editCustomer.LoadCustomerData(selectedCustomer);
                editCustomer.Closed += (s, args) => LoadCustomers();
                editCustomer.Show();
            }
        }
        private async void Delete_Click_Customer(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer selectedCustomer = (Customer)dtgCustomers.SelectedItem;
                Customer customer = await customerRepository.GetCustomerById(selectedCustomer.CustomerID);
                if (customer != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this customer?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await customerRepository.DeleteCustomer(customer);
                        MessageBox.Show("Customer deleted successfully.");
                        LoadCustomers();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a customer to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete customer: " + ex.Message, "Delete Error");
            }
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            LoginWindow login = new LoginWindow();
            login.Show();
        }
        // Management Room
        private void Add_Click_Room(object sender, MouseButtonEventArgs e)
        {
            AddNewRoom addNewRoom = new AddNewRoom();
            addNewRoom.Closed += (s, args) => LoadRoomList();
            addNewRoom.Show();
        }
        private async void Delete_Click_Room(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation selectedRoom = (RoomInformation)dtgRooms.SelectedItem;
                RoomInformation room = await roomInformationRepository.GetRoomInformationById(selectedRoom.RoomID);
                if (room != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this room?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await roomInformationRepository.DeleteRoomInformation(room);
                        MessageBox.Show("Room deleted successfully.");
                        LoadRoomList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete customer: " + ex.Message, "Delete Error");
            }
        }
        private void Edit_Click_Room(object sender, RoutedEventArgs e)
        {
            RoomInformation selectedRoom = (sender as FrameworkElement)?.DataContext as RoomInformation;

            if (selectedRoom != null)
            {
                EditRoomInformation editRoom = new EditRoomInformation();
                editRoom.LoadRoomInformationData(selectedRoom);
                editRoom.Closed += (s, args) => LoadRoomList();
                editRoom.Show();
            }
        }

        // Management Room Type
        private void Add_Click_RoomType(object sender, MouseButtonEventArgs e)
        {
            AddNewRoomType addNewRoomType = new AddNewRoomType();
            addNewRoomType.Closed += (s, args) => LoadRoomTypeList();
            addNewRoomType.Show();
        }

        private void Edit_Click_RoomType(object sender, RoutedEventArgs e)
        {
            RoomType selectedRoomType = (sender as FrameworkElement)?.DataContext as RoomType;

            if (selectedRoomType != null)
            {
                EditRoomType editRoomType = new EditRoomType();
                editRoomType.LoadRoomTypeData(selectedRoomType);
                editRoomType.Closed += (s, args) => LoadRoomTypeList();
                editRoomType.Show();
            }
        }
        private async void Delete_Click_RoomType(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomType selectedRoomType = (RoomType)dtgRoomTypes.SelectedItem;
                RoomType roomType = await roomTypeRepository.GetRoomTypeById(selectedRoomType.RoomTypeID);
                if (roomType != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this room type?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await roomTypeRepository.DeleteRoomType(roomType);
                        MessageBox.Show("RoomType deleted successfully.");
                        LoadRoomTypeList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a room type to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete roomtype: " + ex.Message, "Delete Error");
            }
        }

        //Management Booking
        private async void Delete_Click_Booking(object sender, RoutedEventArgs e)
        {
            try
            {
                BookingDetail selectedBook = (BookingDetail)dtgBookings.SelectedItem;
                BookingDetail booking = await bookingDetailRepository.GetBookingDetailById(selectedBook.BookingReservationID, selectedBook.RoomID);
                if (booking != null)
                {
                    MessageBoxResult result = MessageBox.Show($"Do you want to delete this booking?",
                                                        "Confirm Deleting",
                                                        MessageBoxButton.YesNo,
                                                        MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        await bookingDetailRepository.DeleteBookingDetail(booking);
                        MessageBox.Show("Booking deleted successfully.");
                        LoadRoomTypeList();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a booking to delete.", "Delete Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot delete booking: " + ex.Message, "Delete Error");
            }
        }

    }
}
