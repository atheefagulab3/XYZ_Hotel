using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XYZ_Hotels.DB;
using XYZ_Hotels.Models;

namespace XYZ_Hotels.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    

    public class AuthenticatorController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly HotelContext _context;
        private const string UserRole = "User";
        private const string AdminRole = "Admin";

        public AuthenticatorController(IConfiguration config, HotelContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var users = await GetUser(_userData.Email, _userData.Password);

                if (users != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("UserId", users.UserId.ToString()),
                         new Claim("Email", users.Email),
                        new Claim("Password",users.Password),
                        new Claim(ClaimTypes.Role, UserRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        [HttpPost("Admin")]
        public async Task<IActionResult> PostAdmin(Admin _adminData)
        {
            if (_adminData != null && _adminData.AdminName != null && _adminData.AdminPassword != null)
            {
                var admin = await GetAdmin(_adminData.AdminName, _adminData.AdminPassword);

                if (admin != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("AdminName", admin.AdminName.ToString()),
                        new Claim("AdminPassword",admin.AdminPassword),
                        new Claim(ClaimTypes.Role, AdminRole)

                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Admin> GetAdmin(string adminname, string adminpassword)
        {
            return await _context.Admin.FirstOrDefaultAsync(u => u.AdminName == adminname && u.AdminPassword == adminpassword);
        }
    }
}

