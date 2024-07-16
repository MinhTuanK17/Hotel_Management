using BusinessObject;
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
    /// Interaction logic for AddNewRoomType.xaml
    /// </summary>
    public partial class AddNewRoomType : Window
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        public AddNewRoomType()
        {
            InitializeComponent();
            roomTypeRepository = new RoomTypeRepository();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomType roomType = new RoomType
                {
                    RoomTypeName = txtRoomTypeName.Text,
                    TypeNote = txtNote.Text,
                    TypeDescription = txtDescription.Text,
                };

                await roomTypeRepository.AddRoomType(roomType);
                MessageBox.Show("Add Room Type Successfully!", "Note");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Can not add room type");
            }
        }
    }
}
