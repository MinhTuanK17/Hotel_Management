using BusinessObject;
using Repositories.CustomerR;
using Repositories.RoomInfoR;
using Repositories.RoomTypeR;
using System.Windows;

namespace HotelManagement.Admins
{
    /// <summary>
    /// Interaction logic for EditRoomInformation.xaml
    /// </summary>
    public partial class EditRoomInformation : Window
    {
        private readonly IRoomInformationRepository roomInformationRepository;
        private readonly IRoomTypeRepository roomTypeRepository;
        public EditRoomInformation()
        {
            InitializeComponent(); 
            roomInformationRepository = new RoomInformationRepository();
            roomTypeRepository = new RoomTypeRepository();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomType();
        }
        public async void LoadRoomType()
        {
            try
            {
                var roomTypes = await roomTypeRepository.GetAllRoomType();
                cbRoomType.ItemsSource = roomTypes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of Room Types");
            }
        }
        public void LoadRoomInformationData(RoomInformation room)
        {
            txtRoomID.Text = room.RoomID.ToString();
            txtRoomNumber.Text = room.RoomNumber.ToString();
            txtDescription.Text = room.RoomDetailDescription;
            txtCapacity.Text = room.RoomMaxCapacity.ToString();
            txtPricePerDay.Text = room.RoomPricePerDay.ToString();
            txtRoomStatus.Text = room.RoomStatus;
            cbRoomType.SelectedValue = room.RoomTypeID;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string roomId = txtRoomID.Text;
                RoomInformation room = await roomInformationRepository.GetRoomInformationById(roomId);
                if (room != null)
                {
                    room.RoomNumber = int.Parse(txtRoomNumber.Text);
                    room.RoomDetailDescription = txtDescription.Text;
                    room.RoomMaxCapacity = int.Parse(txtCapacity.Text);
                    room.RoomPricePerDay = decimal.Parse(txtPricePerDay.Text);
                    room.RoomStatus = txtRoomStatus.Text;
                    room.RoomTypeID = (int)cbRoomType.SelectedValue;

                    await roomInformationRepository.UpdateRoomInformation(room);
                    MessageBox.Show("Update Room Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update room");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
