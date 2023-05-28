using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Rooms
    {
        [Key]
        public int Rid { get; set; }

        [ForeignKey("Hotels")]
        public int Hid { get; set; }

        public string? Room_Type { get; set; }

        public string? Room_Status { get; set; }

        public int Price { get; set; }

        public hotels? Hotels { get; set; }



    }
}
