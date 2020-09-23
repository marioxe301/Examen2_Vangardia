using Hotel.Rates.Core;
using Hotel.Rates.Core.TransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Services.Interface
{
    public interface IRatePlanService
    {
       ServiceResult<IEnumerable<RatePlanTransferObject>> GetAllRatePlans();
        ServiceResult<RatePlanTransferObject> GetRatePlanById(long id);
    }
}
