using BusinessObject;
using BusinessObject.Common;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayerAccess
{
    public class RoomInformationDAO : SingletonBase<RoomInformationDAO>
    {
        private HotelDbContext? _context;

        public async Task<RoomInformation> GetRoomInformationById(string roomId)
        {
            try
            {
                _context = new();
                var room = await _context.RoomInformations.FirstOrDefaultAsync(r => r.RoomID.Equals(roomId));
                return room!;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public async Task<List<RoomInformation>> GetAllRoomInformation()
        {
            _context = new();
            return await _context.RoomInformations.AsNoTracking().Include(r => r.RoomType).ToListAsync();
        }

        public async Task AddRoomInformation(RoomInformation room)
        {
            _context = new();
            _context.RoomInformations.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoomInformation(RoomInformation room)
        {
            try
            {
                _context = new();
                var findRoom = await GetRoomInformationById(room.RoomID);
                if (findRoom != null)
                {
                    _context.Entry(findRoom).CurrentValues.SetValues(room);
                }
                else
                {
                    _context.RoomInformations.Update(findRoom);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task DeleteRoomInformation(RoomInformation room)
        {
            try
            {
                _context = new();
                var findRoom = await GetRoomInformationById(room.RoomID);
                if (findRoom != null)
                {
                    findRoom.RoomStatus = "Disable";
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error deleting room: " + e.Message);
            }
        }

        public async Task<List<RoomInformation>> GetAvailableRooms()
        {
            try
            {
                _context = new();
                var availableRoom = await _context.RoomInformations.Where(b => b.RoomStatus == "Active").ToListAsync();
                return availableRoom;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
