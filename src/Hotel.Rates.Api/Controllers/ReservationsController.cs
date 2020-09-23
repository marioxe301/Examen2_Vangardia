using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Rates.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationsController : ControllerBase
    {
        private readonly InventoryContext _context;

        public ReservationsController(InventoryContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody]ReservationTransferObject ReservationTransferObject)
        {
            var ratePlan = _context
                .NightlyRatePlans
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .First(r => r.Id == ReservationTransferObject.RatePlanId);
            var canReserve = ratePlan.Seasons
                .Any(s => ReservationTransferObject.ReservationStart >= s.StartDate  && ReservationTransferObject.ReservationEnd <= s.EndDate );
            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == ReservationTransferObject.RoomId && r.RatePlanId == ReservationTransferObject.RatePlanId);
            var isRoomAvailable = room.Room.Amount > 0 &&
                ReservationTransferObject.AmountOfAdults <= room.Room.MaxAdults &&
                ReservationTransferObject.AmountOfChildren <= room.Room.MaxChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                _context.SaveChanges();
                var days = (ReservationTransferObject.ReservationEnd - ReservationTransferObject.ReservationStart).TotalDays;
                return Ok(new
                {
                    Price = days * ratePlan.Price
                });
            }
            return BadRequest();
        }
    }
}
