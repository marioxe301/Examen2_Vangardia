using Hotel.Rates.Data;
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
        private readonly InventoryContext _inventoryContext;

        public RoomsController(InventoryContext inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_inventoryContext.Rooms);
        }
    }
}
