using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZ_Hotels.Repository;

namespace XYZ_Hotels.Controllers
{
<<<<<<< HEAD
    [Authorize(Roles = "User,Admin")]
    [Route("api/[controller]")]
=======
   [Route("api/[controller]")]
>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
    [ApiController]
   
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepo hot;
        public HotelController(IHotelRepo hot)
        {

            this.hot = hot;
        }
        //Display
        [HttpGet]
        public IEnumerable<hotels>? Get()
        {
            try
            {
                return hot.GetHotels();
            }
            catch(Exception ex)
            {
                throw new Exception("cannot be displayed" + ex.Message);
            }
            
        }
<<<<<<< HEAD
        //Insert
=======

      

>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
        [HttpPost]
        public hotels? PostHotels(hotels hotel)
        {
            try
            {
                return hot.PostHotels(hotel);
            }
            catch(Exception ex)
            {
                throw new Exception("unvalid method" + ex.Message);
            }
            
        }
        //Update
        [HttpPut("{id}")]
        public hotels? PutHotels(int HotelId, hotels hotel)
        {
            try
            {
                return hot.PutHotels(HotelId, hotel);
            }
            catch(Exception ex)
            {
                throw new Exception("cannot update " + ex.Message);
            }
            
        }
        //Delete
        [HttpDelete("{id}")]
        public hotels? DeleteHotels(int HotelId)
        {
            try
            {
                return hot.DeleteHotels(HotelId);
            }
            catch(Exception ex)
            {
                throw new Exception("did not delete" + ex.Message);
            }
           
        }
        //Count by id
        [HttpGet("/count/{Rid}")]
        public ActionResult<object>? Count(int Rid)
        {
            try
            {
                var result = hot.Count(Rid);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception("unable to count" + ex.Message);
            }
           
        }
        //Listing
        [HttpGet("/room/list")]
        public ActionResult<object>? CountList()
        {
            try
            {
                var result = hot.RoomList();
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception("unable to list" + ex.Message);
            }
           
        }
        //Filter
        [HttpGet("/filter/Location")]

        public ActionResult<object> HotelsByLocation(string Location)
        {
            var h = hot.GetHotelsByLocation(Location.ToLower());
            return Ok(h);
        }

        [HttpGet("/filter/amenities")]
        public ActionResult<IEnumerable<hotels>> GetAmenities(string amenities)
        {
            try
            {
                return Ok(hot.GetAmenities(amenities));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}

