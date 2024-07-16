using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class RoomTypeDAO : SingletonBase<RoomTypeDAO>
    {
        private HotelDbContext? _context;

        public async Task<RoomType> GetRoomTypeById(int RoomTypeId)
        {
            try
            {
                _context = new();
                var roomType = await _context.RoomTypes.FirstOrDefaultAsync(r => r.RoomTypeID == RoomTypeId);
                return roomType!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<RoomType>> GetAllRoomType()
        {
            _context = new();
            return await _context.RoomTypes.AsNoTracking().ToListAsync();
        }

        public async Task AddRoomType(RoomType roomType)
        {
            _context = new();
            _context.RoomTypes.Add(roomType);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomType(RoomType roomType)
        {
            try
            {
                _context = new();
                var findRoomType = await GetRoomTypeById(roomType.RoomTypeID);
                if (findRoomType != null)
                {
                    _context.Entry(findRoomType).CurrentValues.SetValues(roomType);
                }
                else
                {
                    _context.RoomTypes.Update(roomType);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteRoomType(RoomType roomType)
        {
            try
            {
                _context = new();
                var findRoomType = await GetRoomTypeById(roomType.RoomTypeID);
                if (findRoomType != null)
                {
                    _context.RoomTypes.Remove(findRoomType);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
