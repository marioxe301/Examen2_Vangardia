using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Data
{
    public class RatePlanRoom
    {
        public int RatePlanId { get; set; }

        public RatePlan Rateplan { get; set; }

        public int RoomId { get; set; }

        public Room Room { get; set; }
    }
}
