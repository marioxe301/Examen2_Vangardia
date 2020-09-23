using Hotel.Rates.Api.Controllers;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Hotel.Rates.Tests
{
    public class ReservationsControllerTests
    {
        [Fact]
        public void Post_ValidNightlyRatePlanData_Returns200Ok()
        {
            var reservation = new ReservationTransferObject
            {
                AmountOfAdults = 1,
                AmountOfChildren = 0,
                RatePlanId = -1,
                ReservationStart = new DateTime(2020, 07, 01),
                ReservationEnd = new DateTime(2020, 07, 03),
                RoomId = -1
            };

            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite(connection)
                .Options;

            var context = new InventoryContext(dbContextOptions);
            context.Database.EnsureCreated();

            var controller = new ReservationsController(context);

            var response = controller.Post(reservation);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Post_ValidIntervalRatePlanData_Returns200Ok()
        {
            var reservation = new ReservationTransferObject
            {
                AmountOfAdults = 1,
                AmountOfChildren = 0,
                RatePlanId = -3,
                ReservationStart = new DateTime(2020, 08, 01),
                ReservationEnd = new DateTime(2020, 08, 03),
                RoomId = -1
            };

            var connection = new SqliteConnection("Data Source=:memory:");

            connection.Open();

            var dbContextOptions = new DbContextOptionsBuilder<InventoryContext>()
                .UseSqlite(connection)
                .Options;

            var context = new InventoryContext(dbContextOptions);
            context.Database.EnsureCreated();

            var controller = new ReservationsController(context);

            var response = controller.Post(reservation);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}
