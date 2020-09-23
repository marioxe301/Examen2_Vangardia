using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using Hotel.Rates.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Services.Interface
{
    public interface IRoomServices
    {
        ServiceResult<IEnumerable<RoomTransferObject>> getAllRooms(); 
    }
}
