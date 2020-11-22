using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RideShare.Data.Models
{
    public class Trip
    {
        [Key]
        public int Id { get; set; }
        [Required]     
        ///<summary>
        ///Route cities from starting city to ending city. Assuming the cities have borders in order.
        ///</summary>
        public List<Trip_City> RouteList { get; set; }
        public DateTime TripDate { get; set; }
        public string Explanation { get; set; }
        /// <summary>
        /// Avaliable seats for trip
        /// </summary>
        [Required]
        public int Capacity { get; set; }

        /// <summary>
        /// Trip Planner
        /// </summary>
        [Required]
        public User Owner { get; set; }

        public List<Passenger> Passengers { get; set; }

        /// <summary>
        /// determines that trip is on air or not
        /// </summary>
        public bool IsActive { get; set; }
    }
}
