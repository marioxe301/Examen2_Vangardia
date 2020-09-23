using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Configurations
{
    public class SeasonConfiguration : IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.RatePlan)
                .WithMany(r => r.Seasons)
                .HasForeignKey(s => s.RatePlanId);

            builder.Property(s => s.StartDate).IsRequired();

            builder.Property(s => s.EndDate).IsRequired();

            builder.HasData(new List<Season>
            {
                new Season
                {
                    Id = -1,
                    StartDate = new DateTime(2020, 06, 01),
                    EndDate = new DateTime(2020, 07, 31),
                    RatePlanId = -1
                },
                new Season
                {
                    Id = -2,
                    StartDate = new DateTime(2020, 12, 01),
                    EndDate = new DateTime(2021, 01, 01),
                    RatePlanId = -2
                },
                new Season
                {
                    Id = -3,
                    StartDate = new DateTime(2020, 06, 01),
                    EndDate = new DateTime(2020, 07, 31),
                    RatePlanId = -3
                },
                new Season
                {
                    Id = -4,
                    StartDate = new DateTime(2020, 12, 01),
                    EndDate = new DateTime(2021, 01, 01),
                    RatePlanId = -4
                }
            });
        }
    }
}
