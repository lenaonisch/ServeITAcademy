using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TravelAgencyHelper.Models;

namespace TravelAgencyHelper.Data
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext(DbContextOptions<TravelAgencyContext> options)
            : base(options)
        { }

        public DbSet<Route> Routes { get; set; }
        public DbSet<DaysInRoute> DaysInRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>().
                Property(p => p.IsActive).
                HasDefaultValueSql("1");
            modelBuilder.Entity<DaysInRoute>().
                Property(p => p.IsActive).
                HasDefaultValueSql("1");
        }
    }
}
