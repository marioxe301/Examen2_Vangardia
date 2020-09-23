using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.TransferObjects
{
    public class RatePlanTransferObject
    {
        public long RatePlanId { get; set; }
        public string RatePlanName { get; set; }
        public int RatePlanType { get; set; }
        public double Price { get; set; }

        public IEnumerable<SeasonTransferObject>Seasons {get; set;}
        public IEnumerable<RoomTransferObject> Rooms { get; set; }

    }
}
