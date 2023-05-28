using Library.Models;
using XYZ_Hotels.Migrations;


namespace XYZ_Hotels.Repository
{
    public interface IHotelRepo
    {
        public IEnumerable<hotels> GetHotels();
<<<<<<< HEAD
        public hotels GetHotelsId(int Hid);
=======
        public hotels GetHotelsbyId(int Hid);
>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
        public hotels PostHotels(hotels hotel);
        public hotels PutHotels(int HotelId, hotels hotel);
        public hotels DeleteHotels(int HotelId);

        public object Count(int Rid);
        public object RoomList();

        public object GetHotelsByLocation(string Location);
<<<<<<< HEAD

        IEnumerable<hotels> GetAmenities(string amenities);

=======
       
>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
    }
}
