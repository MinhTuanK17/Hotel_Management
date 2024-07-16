using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public required string RoomTypeName { get; set; }
        public string? TypeDescription { get; set; }
        public string? TypeNote { get; set; }
        public virtual ICollection<RoomInformation>? RoomInformation { get; set; }
    }
}
