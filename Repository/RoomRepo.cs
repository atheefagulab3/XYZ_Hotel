using Library.Models;
using Microsoft.EntityFrameworkCore;
using XYZ_Hotels.DB;

namespace XYZ_Hotels.Repository
{
    public class RoomRepo : IRoomRepo
    {
        private readonly HotelContext _hotelContext;
        public RoomRepo(HotelContext con)
        {
            _hotelContext = con;
        }
        public IEnumerable<Rooms> GetRooms()
        {
            return _hotelContext.Rooms.ToList();
        }
        public Rooms GetRoomsById(int Rid)
        {

            return _hotelContext.Rooms.FirstOrDefault(x => x.Rid == Rid);

        }

        public Rooms PostRooms(Rooms rooms)
        {


            _hotelContext.Rooms.Add(rooms);
            _hotelContext.SaveChanges();
            return rooms;
        }

        public Rooms PutRooms(int Rid, Rooms rooms)
        {

            _hotelContext.Entry(rooms).State = EntityState.Modified;
            _hotelContext.SaveChangesAsync();
            return rooms;
        }

        public Rooms DeleteRooms(int Rid)
        {

            var hot = _hotelContext.Rooms.Find(Rid);



            _hotelContext.Rooms.Remove(hot);

            _hotelContext.SaveChanges();

            return hot;
        }
        public IEnumerable<Rooms> GetPrice(int price)
        {
            return _hotelContext.Rooms.Where(e => e.Price == price).ToList();
        }

       
    }
}
