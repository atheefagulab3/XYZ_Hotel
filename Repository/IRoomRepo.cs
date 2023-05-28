using Library.Models;

namespace XYZ_Hotels.Repository
{
    public interface  IRoomRepo
    {
        public IEnumerable<Rooms> GetRooms();
        public Rooms GetRoomsById(int Rid);
        public Rooms PostRooms(Rooms rooms);
        public Rooms PutRooms(int Rid, Rooms rooms);
        public Rooms DeleteRooms(int Rid);

       

        IEnumerable<Rooms> GetPrice(int price);

    }
}
