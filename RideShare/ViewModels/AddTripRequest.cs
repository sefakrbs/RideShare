using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideShare.API.ViewModels
{
    public class AddTripRequest
    {
        public List<int> RouteList { get; set; }
        public DateTime TripDate { get; set; }
        public string Explanation { get; set; }
        public int Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
