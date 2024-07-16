using BusinessObject;
using DataLayerAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoomTypeR
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        public async Task AddRoomType(RoomType roomType) => await RoomTypeDAO.Instance.AddRoomType(roomType);

        public async Task DeleteRoomType(RoomType roomType) => await RoomTypeDAO.Instance.DeleteRoomType(roomType);

        public async Task<List<RoomType>> GetAllRoomType() => await RoomTypeDAO.Instance.GetAllRoomType();

        public async Task<RoomType> GetRoomTypeById(int RoomTypeId) => await RoomTypeDAO.Instance.GetRoomTypeById(RoomTypeId);

        public async Task UpdateRoomType(RoomType roomType) => await RoomTypeDAO.Instance.UpdateRoomType(roomType);
    }
}
