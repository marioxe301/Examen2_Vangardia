using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data.Configurations
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name).IsRequired();

            builder.Property(r => r.MaxAdults).IsRequired();

            builder.Property(r => r.MaxChildren).IsRequired();

            builder.Property(r => r.Amount).IsRequired();

            builder.HasData(new List<Room>
            {
                new Room
                {
                    Amount = 5,
                    Id = -1,
                    MaxAdults = 2,
                    MaxChildren = 2,
                    Name = "King"
                },
                new Room
                {
                    Amount = 10,
                    Id = -2,
                    MaxAdults = 4,
                    MaxChildren = 0,
                    Name = "Queen"
                }
            });

        }
    }
}
