using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RideShare.API.ViewModels;
using RideShare.Data.Context;
using RideShare.Data.Models;

namespace RideShare.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripPlannerController : ControllerBase
    {
        private readonly ILogger<TripPlannerController> _logger;

        private readonly RideShareContext _rideShareContext;
        public TripPlannerController(ILogger<TripPlannerController> logger, RideShareContext context)
        {
            _logger = logger;
            _rideShareContext = context;
        }

        [Route("{userId}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Trip([FromRoute] int userId, AddTripRequest trip)
        {
            if (ModelState.IsValid)
            {
                var user = _rideShareContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null) throw new Exception("User Not found");

                var newTrip = new Trip()
                {
                    Capacity = trip.Capacity,
                    Explanation = trip.Explanation,
                    IsActive = trip.IsActive,
                    Owner = user,
                    TripDate = trip.TripDate,
                };

                _rideShareContext.Trips.Add(newTrip);
                await _rideShareContext.SaveChangesAsync();

                int index = 0;
                foreach (var route in trip.RouteList)
                {
                    var item = new Trip_City();
                    item.CityId = route;
                    item.TripId = newTrip.Id;
                    item.Index = index++;

                    _rideShareContext.Trip_Cities.Add(item);
                }
                await _rideShareContext.SaveChangesAsync();
            }

            return Created(string.Empty, null);
        }

        [Route("{from}/{to}")]
        [HttpGet]
        [ProducesResponseType(typeof(Trip), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Trip>> GetTrips([FromRoute] int from, [FromRoute] int to)
        {
            List<Trip> trips = new List<Trip>();
            var filteredData = _rideShareContext.Trips.Where(t => t.IsActive
                                                    && t.RouteList.Any(c => c.CityId == from)
                                                    && t.RouteList.Any(c => c.CityId == to));

            //filteredData.Where(t => t.RouteList.IndexOf(c => c.));

            foreach (var trip in filteredData)
            {
                int fromCityIndex = 0, toCityIndex = 0;
                foreach (var route in trip.RouteList)
                {
                    if (from == route.CityId)
                    {
                        fromCityIndex = route.Index;
                    }

                    if (to == route.CityId)
                    {
                        toCityIndex = route.Index;
                        //break;
                    }
                }

                if (fromCityIndex < toCityIndex)
                {
                    trips.Add(trip);
                }
            }

            return await Task.FromResult<IEnumerable<Trip>>(trips);
        }

        [Route("{tripId}/{activate}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Trip(int tripId, bool activate)
        {
            var trip = _rideShareContext.Trips.FirstOrDefault(t => t.Id == tripId);
            //if (trip.IsActive)
            //{
            //    return Ok();
            //}
            trip.IsActive = activate;
            await _rideShareContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// only one user enrolled at the same time
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="tripId"></param>
        /// <returns></returns>
        [Route("{userId}/{tripId}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddPassenger([FromRoute]int userId, [FromRoute]int tripId)
        {
            var trip = _rideShareContext.Trips.FirstOrDefault(t => t.IsActive && t.Id == tripId);
            var user = _rideShareContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null || trip == null)
            {
                throw new Exception("User or Trip not found");
            }

            if (trip.Passengers == null || trip.Capacity > trip.Passengers.Count)
            {
                if(trip.Passengers == null)
                {
                    trip.Passengers = new List<Passenger>();
                }
                
                if (trip.Passengers.Any(u => u.UserId == user.Id))
                {
                    throw new Exception("User already enrolled");
                }
                trip.Passengers.Add(new Passenger() { UserId = user.Id, TripId = trip.Id });

                await _rideShareContext.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Capacity full");
            }

            return Created(string.Empty, null);
        }

    }
}
