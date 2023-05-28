using Library.Models;
using Microsoft.EntityFrameworkCore;
using XYZ_Hotels.Models;

namespace XYZ_Hotels.DB
{
    public class HotelContext : DbContext
    {
        public DbSet<hotels> Hotels { get; set; }

        public DbSet<Rooms> Rooms { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Admin> Admin { get; set; }

        

        




<<<<<<< HEAD
=======

>>>>>>> effe07a1058d611fe015f38fcf119ed50992349d
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }


    }
}
