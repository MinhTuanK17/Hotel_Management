using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoomInfoR
{
    public interface IRoomInformationRepository
    {
        Task<RoomInformation> GetRoomInformationById(string roomId);
        Task<List<RoomInformation>> GetAllRoomInformation();
        Task AddRoomInformation(RoomInformation room);
        Task UpdateRoomInformation(RoomInformation room);
        Task DeleteRoomInformation(RoomInformation room);
        Task<List<RoomInformation>> GetAvailableRooms();

    }
}
