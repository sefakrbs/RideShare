using Microsoft.EntityFrameworkCore;
using RideShare.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RideShare.Data.Context
{
    public class RideShareContext : DbContext
    {
        public RideShareContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Trip_City> Trip_Cities { get; set; }
    }
}
