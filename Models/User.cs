


using System.ComponentModel.DataAnnotations;

namespace XYZ_Hotels.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
       
    }
}
