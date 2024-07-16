using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.RoomTypeR
{
    public interface IRoomTypeRepository
    {
        Task<RoomType> GetRoomTypeById(int RoomTypeId);
        Task<List<RoomType>> GetAllRoomType();
        Task AddRoomType(RoomType roomType);
        Task UpdateRoomType(RoomType roomType);
        Task DeleteRoomType(RoomType roomType);

    }
}
