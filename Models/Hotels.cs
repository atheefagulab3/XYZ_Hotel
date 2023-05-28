using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class hotels
    {
        [Key]
        public int Hid { get; set; }
        public string? HName { get; set; }

        public string? Location { get; set; }
        public int   Rating {get;set;}

        public string Amenities { get; set; }

        public string? Feedback { get; set; }

        public ICollection<Rooms>? Rooms { get; set; }

    }
}
