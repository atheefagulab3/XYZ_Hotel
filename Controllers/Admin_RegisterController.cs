using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using XYZ_Hotels.DB;
using XYZ_Hotels.Models;

namespace XYZ_Hotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class Admin_RegisterController : ControllerBase
    {
        private readonly HotelContext _context;

        public Admin_RegisterController(HotelContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            var Admin = await _context.Admin.ToListAsync();
            var GetStaff = Admin.Select(s => new Admin
            {
                AdminId = s.AdminId,
                AdminName = s.AdminName,
                AdminPassword = HashPassword(s.AdminPassword),
            }).ToList();
            return Admin;
        }

        // GET: api/Admin/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            if (_context.Admin == null)
            {
                return NotFound();
            }
            var Admin = await _context.Admin.FindAsync(id);

            if (Admin == null)
            {
                return NotFound();
            }

            return Admin;
        }

        // PUT: api/Admin/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin Admin)
        {
            if (id != Admin.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(Admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Admin
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Admin>> PostStaff(Admin Admin)
        {
            if (_context.Admin == null)
            {
                return Problem("Entity set 'HotelContext.Admin'  is null.");
            }
            _context.Admin.Add(Admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = Admin.AdminId }, Admin);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            if (_context.Admin == null)
            {
                return NotFound();
            }
            var Admin = await _context.Admin.FindAsync(id);
            if (Admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(Admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string HashPassword(string password)
        {
            // Implement password hashing logic or any other modification you require
            // Example: Hash the password using SHA256
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private bool StaffExists(int id)
        {
            return (_context.Admin?.Any(e => e.AdminId == id)).GetValueOrDefault();
        }
    }
}
