using Hotel.Rates.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Season> Seasons { get; set; }

        public DbSet<RatePlan> RatePlans { get; set; }

        public DbSet<NightlyRatePlan> NightlyRatePlans { get; set; }

        public DbSet<IntervalRatePlan> IntervalRatePlans { get; set; }

        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new NightlyRatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new IntervalRatePlanConfiguration());
            modelBuilder.ApplyConfiguration(new SeasonConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new RatePlanRoomConfiguration());
        }
    }
}
