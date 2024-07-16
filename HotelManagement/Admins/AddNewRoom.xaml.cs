using BusinessObject;
using Repositories.CustomerR;
using Repositories.RoomInfoR;
using Repositories.RoomTypeR;
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

namespace HotelManagement.Admins
{
    /// <summary>
    /// Interaction logic for AddNewRoom.xaml
    /// </summary>
    public partial class AddNewRoom : Window
    {
        private readonly IRoomInformationRepository roomInformationRepository;
        private readonly IRoomTypeRepository roomTypeRepository;

        public AddNewRoom()
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = new RoomInformation
                {
                    RoomID = txtRoomID.Text,
                    RoomNumber = int.Parse(txtRoomNumber.Text),
                    RoomDetailDescription = txtDescription.Text,
                    RoomMaxCapacity = int.Parse(txtCapacity.Text),
                    RoomPricePerDay = Decimal.Parse(txtPricePerDay.Text),
                    RoomStatus = "Active",
                    RoomTypeID = (int)cbRoomType.SelectedValue,
                };

                await roomInformationRepository.AddRoomInformation(room);
                MessageBox.Show("Add Room Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add room");
            }
        }
    }
}
