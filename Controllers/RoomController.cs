using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZ_Hotels.Repository;

namespace XYZ_Hotels.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/[controller]")]
    [ApiController]
    
    
  
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepo hot;
        public RoomController(IRoomRepo hot)
        {
            this.hot = hot;
        }
        //Display
        [HttpGet]
        public IEnumerable<Rooms>? Get()
        {
            try
            {
                return hot.GetRooms();

            }
            catch (Exception ex)
            {
                throw new Exception("unable to display" + ex.Message);
            }
        }
        //Display by id
        [HttpGet("{id}")]
        public Rooms? GetById(int Rid)
        {
            try
            {
                return hot.GetRoomsById(Rid);
            }
            catch (Exception ex)
            {
                throw new Exception("your id is not valid" + ex.Message);

            }
            
        }
        //insert
        [HttpPost]
        public Rooms? PostRooms(Rooms rooms)
        {
            try
            {
                return hot.PostRooms(rooms);
            }
            catch(Exception ex)
            {
                throw new Exception("cannot insert" + ex.Message);

            }
            
        }
        //update
        [HttpPut("{id}")]
        public Rooms? PutRooms(int Rid, Rooms rooms)
        {

            try
            {
                return hot.PutRooms(Rid, rooms);
            }
            catch (Exception ex)
            {
                throw new Exception("cannot update " + ex.Message);
            }
<<<<<<< HEAD
=======
         

       

>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
        }
        //Delete
        [HttpDelete("{id}")]
        public Rooms? DeleteRooms(int Rid)
        {
            try
            {
                return hot.DeleteRooms(Rid);
            }
            catch(Exception ex)
            {
                throw new Exception("did not delete do try again" + ex.Message);
            }
            
        }
        [HttpGet("/filter/price")]
        public ActionResult<IEnumerable<Rooms>> GetPrice(int price)
        {
            try
            {
                return Ok(hot.GetPrice(price));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
