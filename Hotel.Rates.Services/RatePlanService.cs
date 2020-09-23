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
    public class RatePlanService : IRatePlanService
    {
        private readonly IRepository<RatePlan> ratePlanrepository;

        public RatePlanService(IRepository<RatePlan> ratePlanrepository)
        {
            this.ratePlanrepository = ratePlanrepository;
        }
        public ServiceResult<IEnumerable<RatePlanTransferObject>> GetAllRatePlans()
        {
            var result = ratePlanrepository.All().Include(r => r.Seasons).Include(r => r.RatePlanRooms).ThenInclude(r => r.Room)
               .Select(x => new RatePlanTransferObject
               {
                   RatePlanId = x.Id,
                   RatePlanName = x.Name,
                   RatePlanType = x.RatePlanType,
                   Price = x.Price,
                   Seasons = x.Seasons.Select(s => new SeasonTransferObject
                   {
                       Id = s.Id,
                       StartDate=s.StartDate,
                       EndDate = s.EndDate
                   }),
                   Rooms = x.RatePlanRooms.Select(r => new RoomTransferObject
                   {
                       Id = 0,
                       Name = r.Room.Name,
                       MaxAdults = r.Room.MaxAdults,
                       MaxChildren =r.Room.MaxChildren,
                       Amount =r.Room.Amount
                   })
               });

            return ServiceResult<IEnumerable<RatePlanTransferObject>>.SuccessResult(result);
            
        }

        public ServiceResult<RatePlanTransferObject> GetRatePlanById(long id)
        {
            var ratePlan = ratePlanrepository.All()
                .Include(r => r.Seasons)
                .Include(r => r.RatePlanRooms)
                .ThenInclude(r => r.Room)
                .FirstOrDefault(x => x.Id == id);

            var ratePlanFound = new RatePlanTransferObject
            {
                RatePlanId = ratePlan.Id,
                RatePlanName = ratePlan.Name,
                RatePlanType = ratePlan.RatePlanType,
                Price = ratePlan.Price,
                Seasons = ratePlan.Seasons.Select(s => new SeasonTransferObject
                {
                    Id = s.Id,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate
                }),
                Rooms = ratePlan.RatePlanRooms.Select(r => new RoomTransferObject
                {
                    Id = 0,
                    Name = r.Room.Name,
                    MaxAdults = r.Room.MaxAdults,
                    MaxChildren = r.Room.MaxChildren,
                    Amount = r.Room.Amount
                })
            };

            return ServiceResult<RatePlanTransferObject>.SuccessResult(ratePlanFound);
        }
    }

}
