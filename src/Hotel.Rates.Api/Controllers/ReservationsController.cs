using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }
        [HttpPost]
        [Route("api/[controller]/Nightly")]
        public IActionResult PostNightly([FromBody] ReservationTransferObject ReservationTransferObject)
        {
            var result = reservationService.MakeReservationNighlyPlan(ReservationTransferObject);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }

        [HttpPost]
        [Route("api/[controller]/Interval")]
        public IActionResult PostInterval([FromBody] ReservationTransferObject ReservationTransferObject)
        {
            var result = reservationService.MakeReservationIntervalPlan(ReservationTransferObject);
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }
    }
}
