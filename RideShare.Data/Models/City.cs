using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RideShare.Data.Models
{
    public class City
    {
        [Key]
        public int CityCode { get; set; }
        public string Name { get; set; }
    }
}
