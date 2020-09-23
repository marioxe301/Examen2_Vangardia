using Hotel.Rates.Api.Controllers;
using Hotel.Rates.Services.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Tests.Builder
{
    public class ReservationControllerBuilder
    {
        private IReservationService _defaultService;
        private bool _useDefaultService = true;

        public ReservationControllerBuilder WithReservationService(IReservationService reservationService)
        {
            _defaultService = reservationService;
            _useDefaultService = false;
            return this;
        }

        public Mock<IReservationService> GetDefaultReservationService() => new Mock<IReservationService>();

        public ReservationsController Build()
        {
            if (_useDefaultService)
                _defaultService = GetDefaultReservationService().Object;
            return new ReservationsController(_defaultService);
        }
    }
}
