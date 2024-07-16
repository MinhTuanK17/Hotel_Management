using BusinessObject;
using Repositories.CustomerR;
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
    /// Interaction logic for EditRoomType.xaml
    /// </summary>
    public partial class EditRoomType : Window
    {
        private readonly IRoomTypeRepository roomTypeRepository;

        public EditRoomType()
        {
            InitializeComponent();
            roomTypeRepository = new RoomTypeRepository();
        }
        public void LoadRoomTypeData(RoomType roomType)
        {
            txtRoomTypeID.Text = roomType.RoomTypeID.ToString();
            txtDescription.Text = roomType.TypeDescription;
            txtNote.Text = roomType.TypeNote;
            txtRoomTypeName.Text = roomType.RoomTypeName;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int roomTypeId = int.Parse(txtRoomTypeID.Text);
                RoomType roomType = await roomTypeRepository.GetRoomTypeById(roomTypeId);
                if (roomType != null)
                {
                    roomType.RoomTypeID = int.Parse(txtRoomTypeID.Text);
                    roomType.RoomTypeName = txtRoomTypeName.Text;
                    roomType.TypeDescription = txtDescription.Text;
                    roomType.TypeNote = txtNote.Text;
                 
                    await roomTypeRepository.UpdateRoomType(roomType);
                    MessageBox.Show("Update RoomType Successfully!", "Note");
                    this.Close();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Valid input is incorrect", "Cannot update roomtypes");
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
