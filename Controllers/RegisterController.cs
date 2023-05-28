using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ_Hotels.DB;
using XYZ_Hotels.Models;

namespace XYZ_Hotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
<<<<<<<< HEAD:XYZ_Hotels/Controllers/User_RegisterController.cs
    


    public class User_RegisterController : ControllerBase
    {
        private readonly HotelContext _context;

        public User_RegisterController(HotelContext context)
========
    public class RegisterController : ControllerBase
    {
        private readonly HotelContext _context;

        public RegisterController(HotelContext context)
>>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d:XYZ_Hotels/Controllers/RegisterController.cs
        {
            _context = context;
        }

        //Display
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5(route)
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        //Insert
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        //Display
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.User == null)
            {
                return Problem("Entity set 'ProCatContext.Users'  is null.");
            }
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5(route)
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.User == null)
            {
                return NotFound();
            }
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.User?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}


