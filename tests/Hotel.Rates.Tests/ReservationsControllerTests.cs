using Hotel.Rates.Api.Controllers;
using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Hotel.Rates.Tests.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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

            var controllerBuilder = new ReservationControllerBuilder();

            var controllerMock = controllerBuilder.GetDefaultReservationService();
            controllerMock.Setup(r => r.MakeReservationNighlyPlan(It.IsAny<ReservationTransferObject>()))
                .Returns(ServiceResult<double>.SuccessResult(1000));

            var controller = controllerBuilder.WithReservationService(controllerMock.Object).Build();

            var response = controller.PostNightly(reservation);

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
                RoomId = -2
            };

            var controllerBuilder = new ReservationControllerBuilder();

            var controllerMock = controllerBuilder.GetDefaultReservationService();
            controllerMock.Setup(r => r.MakeReservationIntervalPlan(It.IsAny<ReservationTransferObject>()))
                .Returns(ServiceResult<double>.SuccessResult(450));

            var controller = controllerBuilder.WithReservationService(controllerMock.Object).Build();

            var response = controller.PostInterval(reservation);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void MakeReservation_ValidateResultNightlyRatePlan_Success()
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

            var expectedValue = 1000;

            var controllerBuilder = new ReservationControllerBuilder();

            var Mock = controllerBuilder.GetDefaultReservationService();
            Mock.Setup(r => r.MakeReservationNighlyPlan(It.IsAny<ReservationTransferObject>()))
                .Returns(ServiceResult<double>.SuccessResult(expectedValue));

            var response = Mock.Object.MakeReservationNighlyPlan(reservation);

            Assert.Equal(response.ResponseCode, ResponseCode.Success);
            Assert.Equal(response.Result, expectedValue);


        }

        [Fact]
        public void MakeReservation_ValidateResultInternalRatePlan_Success()
        {
            var reservation = new ReservationTransferObject
            {
                AmountOfAdults = 1,
                AmountOfChildren = 0,
                RatePlanId = -3,
                ReservationStart = new DateTime(2020, 07, 01),
                ReservationEnd = new DateTime(2020, 07, 03),
                RoomId = -2
            };

            var expectedValue = 450;

            var controllerBuilder = new ReservationControllerBuilder();

            var Mock = controllerBuilder.GetDefaultReservationService();
            Mock.Setup(r => r.MakeReservationIntervalPlan(It.IsAny<ReservationTransferObject>()))
                .Returns(ServiceResult<double>.SuccessResult(expectedValue));

            var response = Mock.Object.MakeReservationIntervalPlan(reservation);

            Assert.Equal(response.ResponseCode, ResponseCode.Success);
            Assert.Equal(response.Result, expectedValue);
        }
    }
}
