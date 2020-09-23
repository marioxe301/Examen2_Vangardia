using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using Hotel.Rates.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly IRepository<Room> roomRepository;

        public RoomServices(IRepository<Room> roomRepository)
        {
            this.roomRepository = roomRepository;
        }
        public ServiceResult<IEnumerable<RoomTransferObject>> getAllRooms()
        {
            var rooms = roomRepository.All().Select(r => new RoomTransferObject
            {
                Id = r.Id,
                Name = r.Name,
                MaxAdults = r.MaxAdults,
                MaxChildren = r.MaxChildren,
                Amount = r.Amount
            }).ToList();

            return ServiceResult<IEnumerable<RoomTransferObject>>.SuccessResult(rooms);
        }
    }
}
