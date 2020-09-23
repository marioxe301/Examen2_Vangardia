using Hotel.Rates.Core;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomServices roomServices;

        public RoomsController(IRoomServices roomServices)
        {
            this.roomServices = roomServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = roomServices.getAllRooms();
            if (result.ResponseCode == ResponseCode.Success)
                return Ok(result.Result);
            return BadRequest(result.Error);
        }
    }
}
