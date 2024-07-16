using BusinessObject;
using DataLayerAccess;

namespace Repositories.RoomInfoR
{
    public class RoomInformationRepository : IRoomInformationRepository
    {
        public async Task AddRoomInformation(RoomInformation room) => await RoomInformationDAO.Instance.AddRoomInformation(room);

        public async Task DeleteRoomInformation(RoomInformation room) => await RoomInformationDAO.Instance.DeleteRoomInformation(room);

        public async Task<List<RoomInformation>> GetAllRoomInformation() => await RoomInformationDAO.Instance.GetAllRoomInformation();
        public async Task<List<RoomInformation>> GetAvailableRooms() => await RoomInformationDAO.Instance.GetAvailableRooms();

        public async Task<RoomInformation> GetRoomInformationById(string roomId) => await RoomInformationDAO.Instance.GetRoomInformationById(roomId);

        public async Task UpdateRoomInformation(RoomInformation room) => await RoomInformationDAO.Instance.UpdateRoomInformation(room);
    }
}
