using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RideShare.Data.Models
{
    public class Trip_City
    {
        [Key]
        public int Id { get; set; }
        public int Index { get; set; }
        public int TripId { get; set; }
        public int CityId { get; set; }
    }
}
