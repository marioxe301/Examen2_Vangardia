using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<NightlyRatePlan> nightlyRatePlanRepository;
        private readonly IRepository<IntervalRatePlan> intervalRatePlanRepository;

        public ReservationService(IRepository<NightlyRatePlan> nightlyRatePlanRepository, IRepository<IntervalRatePlan> intervalRatePlanRepository)
        {
            this.nightlyRatePlanRepository = nightlyRatePlanRepository;
            this.intervalRatePlanRepository = intervalRatePlanRepository;
        }

        public ServiceResult<double> MakeReservationIntervalPlan(ReservationTransferObject ReservationTransferObject)
        {
            var ratePlan = intervalRatePlanRepository.All()
               .Include(r => r.Seasons)
               .Include(r => r.RatePlanRooms)
               .ThenInclude(r => r.Room)
               .First(r => r.Id == ReservationTransferObject.RatePlanId);

            var canReserve = ratePlan.Seasons
                .Any(s => ReservationTransferObject.ReservationStart >= s.StartDate && ReservationTransferObject.ReservationEnd <= s.EndDate && (ReservationTransferObject.ReservationEnd - ReservationTransferObject.ReservationStart).Days >= ratePlan.IntervalLength);

            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == ReservationTransferObject.RoomId && r.RatePlanId == ReservationTransferObject.RatePlanId);

            var isRoomAvailable = room.Room.Amount > 0 &&
                ReservationTransferObject.AmountOfAdults <= room.Room.MaxAdults &&
                ReservationTransferObject.AmountOfChildren <= room.Room.MaxChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                nightlyRatePlanRepository.SaveChanges();
                var days = (ReservationTransferObject.ReservationEnd - ReservationTransferObject.ReservationStart).TotalDays;
                var Price = days * (ratePlan.Price/ratePlan.IntervalLength);
                return ServiceResult<double>.SuccessResult(Price);
            }
            return ServiceResult<double>.ErrorResult("No se puede Reservar");
        }

        public ServiceResult<double> MakeReservationNighlyPlan(ReservationTransferObject ReservationTransferObject)
        {
            
           
            var ratePlan = nightlyRatePlanRepository.All()
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .First(r => r.Id == ReservationTransferObject.RatePlanId);

            var canReserve = ratePlan.Seasons
                .Any(s => ReservationTransferObject.ReservationStart >= s.StartDate && ReservationTransferObject.ReservationEnd <= s.EndDate);

            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == ReservationTransferObject.RoomId && r.RatePlanId == ReservationTransferObject.RatePlanId);

            var isRoomAvailable = room.Room.Amount > 0 &&
                ReservationTransferObject.AmountOfAdults <= room.Room.MaxAdults &&
                ReservationTransferObject.AmountOfChildren <= room.Room.MaxChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                nightlyRatePlanRepository.SaveChanges();
                var days = (ReservationTransferObject.ReservationEnd - ReservationTransferObject.ReservationStart).TotalDays;
                var Price = days * ratePlan.Price;
                return ServiceResult<double>.SuccessResult(Price);
            }
            return ServiceResult<double>.ErrorResult("No se puede Reservar");
        }
    }
}
