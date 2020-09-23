using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Configurations
{
    public class IntervalRatePlanConfiguration : IEntityTypeConfiguration<IntervalRatePlan>
    {
        public void Configure(EntityTypeBuilder<IntervalRatePlan> builder)
        {
            builder.Property(i => i.IntervalLength).IsRequired();

            builder.HasData(new List<IntervalRatePlan>
            {
                new IntervalRatePlan
                {
                    Id = -3,
                    Name = "Verano 2020 Interval",
                    IntervalLength = 2,
                    Price = 450
                },
                 new IntervalRatePlan
                {
                    Id = -4,
                    Name = "Invierno 2020 Interval",
                    IntervalLength = 3,
                    Price = 350
                }
            });
        }
    }
}
